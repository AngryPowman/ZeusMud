using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf.network;

namespace zeus_mud.game.data
{
    public enum MessageChannel
    {
        ChannelSystem = 0,
        ChannelWorld = 1,
        ChannelPrivate = 2,
        ChannelGuild = 3,
    };

    [System.Runtime.InteropServices.ComVisible(true)]
    public class ChatControl
    {
        public const UInt64 SystemUid = 0;

        private System.Windows.Forms.WebBrowser wb;
        private UInt64 mCurrentUid;
        //private string current_uname = "飞翔的泡面";

        private UInt64 current_uid
        {
            get
            {
                return mCurrentUid;
            }
            set
            {
                mCurrentUid = value;
                setOption("current_uid", mCurrentUid.ToString());
            }
        }
        
        public ChatControl(ref System.Windows.Forms.WebBrowser browser, string pageurl)
        {
            wb = browser;
            wb.ObjectForScripting = this;
            wb.Navigate(pageurl);
            wb.AllowNavigation = false;

            OpcodesHandler.registerHandler(Opcodes.S2CChatMessageNotify, this.chatMessageCallback);
        }


        /**
         * 修改一个配置的值
         * 
         * 当修改时，触发 optionchange 事件。
         * 绑定方法：
         * $(document).on('optionchange', function(e, name, new_value){
         *   // do something
         * });
         * 或者只对单个键绑定
         * $(document).on('optionchange.a_spec_key', function(e, new_value){
         *   // do something
         * });
         * 
         * @param string name 配置项名称，限制： 英文字母开头、可以有字母+数字+下划线（最好只用小写）
         * @param string value 内容，如果是复杂内容，考虑分解（分成多个项）
         */
        public void setOption(string name, string value)
        {
            wb.Document.InvokeScript("setOption", new Object[] { name, value });
        }

        public object getOption(string name)
        {
            return wb.Document.InvokeScript("getOption", new Object[] { name });
        }

        /**
         * 序列化所有配置以供保存
         * @return string JSON数据
         */
        public string serilizeOption()
        {
            return (string)wb.Document.InvokeScript("serilizeOption");
        }

        /**
         * 用于还原以前保存的配置
         * 不会触发setOption里说的那两个事件
         * 
         * @param string jsonData JSON数据
         */
        public void unserilizeOption(string jsonData)
        {
            wb.Document.InvokeScript("unserilizeOption", new Object[] { jsonData });
        }

        public void sendMessage(String content)
        {
            Console.WriteLine("发送消息：" + content);
        }

        public void initRequired()
        {
            this.unserilizeOption("{current_uid:9999, bgcolor: '#c8c8c8'}");

            current_uid = PlayerProfile.guid; // <--

            writeLine(MessageChannel.ChannelSystem, "信息", SystemUid, "连接成功！");
        }

        public void postChat(MessageChannel channel,string sendto, string content)
        {
            // 向服务器请求的代码
            if (channel == MessageChannel.ChannelPrivate ||
                channel == MessageChannel.ChannelWorld ||
                channel == MessageChannel.ChannelGuild)
            {
                Protocol.C2SChatMessageReq chatRequest = new Protocol.C2SChatMessageReq();
                chatRequest.chat_type = (int)channel;
                if (channel == MessageChannel.ChannelPrivate)
                {
                    chatRequest.chat_target_guid = 439715978;   // > Debug
                }

                chatRequest.chat_content = Encoding.Default.GetBytes(content);
                NetworkEvent.sendPacket<Protocol.C2SChatMessageReq>(chatRequest);
            }
            else
            {
                writeLine(MessageChannel.ChannelSystem, "错误", SystemUid, "信息“" + content + "”发送失败！" );
            }

        }

        public void writeLine(MessageChannel channel, string uname, UInt64 from_uid, string content)
        {
            wb.Document.InvokeScript("addChatMessage", new Object[] { (int)channel, from_uid, uname, content });
        }

        /**
         * id - 用户ID
         * btn - 鼠标按钮
         *     1： 左键
         *     2： 中键
         *     3： 右键
         */
        public void userNameClicked(UInt64 id,int btn)
        {
            Console.WriteLine("点击了用户：" + id + "，按钮：" + btn);
        }

        public void console_log(string data)
        {
            Console.WriteLine(data);
        }

        private void chatMessageCallback(MemoryStream stream)
        {
            Protocol.S2CChatMessageNotify notify = NetworkEvent.parseMessage<Protocol.S2CChatMessageNotify>(stream);

            //如果是私聊
            if (notify.chat_type == (int)MessageChannel.ChannelPrivate)
            {
                writeLine(
                    (MessageChannel)notify.chat_type,
                    Encoding.Default.GetString(notify.chat_sender_nickname),
                    notify.chat_sender_guid,
                    Encoding.Default.GetString(notify.chat_content));
            }
            else
            {
                writeLine(
                    (MessageChannel)notify.chat_type,
                    Encoding.UTF8.GetString(notify.chat_sender_nickname),
                    notify.chat_sender_guid,
                    Encoding.Default.GetString(notify.chat_content));
            }
        }
    }
}
