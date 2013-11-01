> **酷到没朋友的 ZeusMud**  
休闲在线游戏，混合多种游戏模式，如养成，战网，卡牌/竞技，社区。该游戏会合理利用你的碎片时间带给你最大的愉悦和享受。

> 开发者QQ群：37723482  

## **ZeusMud开发指南**

### **概述**
----------
前段时间我们开了一个叫做Zeus的项目，伴随着美工猝死的节奏导致项目不得不终止。鉴于对原创游戏的执着和狂热，想出了ZeusMud这种利用GUI作为游戏客户端的形式，完美解决了没有美术的问题，上手相当低。服务端采用**C++**编写并可在Windows/Linux平台下运行，客户端使用了**C#.NET/WPF混合Winform**的方式编写，纯Windows UI.

目前服务端和客户端采用的开发工具均为Visual Studio 2012.由于时间关系，Linux的编译脚本尚未整理完成，因此先用VS2012进行编译，服务端可稳定在Windows平台下运行。

### **服务端开发说明**
----------
**服务端框架**

服务端网络通信框架目前已完成（截止当前版本时间）并可稳定运行。通信底层使用了Boost.ASIO，基于，保证了底层通信的稳定。尚未进行性能测试，框架仍在不断完善。经过了第二次封装的网络框架叫做venus_net，包括：

- TCP通信库
- 日志库（基于POCO）
- 数据库
- 对象池
- 字节数据处理类
- 大小端
- 常用数据模型（如Singleton, ObjectManager等）

目前是单进程多线程的架构，游戏逻辑服务的项目名称是**center_server**。用于处理游戏IO和游戏逻辑处理。与客户端的通信流程如下：
![](docs/readme/svr_com.png)

通信协议使用了Google Protobuf，并在Protobuf前面包装了Header，包括了length和opcode，分别用于表示数据包的长度和操作码。Google Protobuf的协议描述文件存放在目录：**ZuesMud/protocol** 下，使用.proto作为后缀，使用autogen.bat生成（包括C++和C#两种语言）。

**协议定制注意事项**

1. 协议文件名采用 协议号_协议名.proto 的方式进行命名。  
2. 命名空间使用 **Protocol**，于每个proto文件的最顶行proto语法为：
     > package Protocol;
3. 协议所有字段均使用下划线分割形式的命名风格。如：is_ok, last_login ..
4. 由服务端发向客户端的协议使用 **S2C** (Server To Client) 开头，并使用**Rsp** (Response) 结尾。客户端使用 **C2S** (Client To Server)开头，使用**Req** (Request)结尾。
5. 包含中文内容的字段使用bytes类型。
6. 协议号严格参考 [protocol/协议号划分.txt](protocol/协议号划分.txt) 内的说明进行设定。


**开发习惯**

1. 游戏对象管理器继承Venus::Singleton，方便游戏逻辑处理。
2. 使用debug_log("")输出调试日志，尽可能在每个重要的流程内打印有用日志。
3. 多为指针判空（如访问到空指针则可能导致服务器崩溃）。
4. 在 opcodes_handler.cpp 文件内为操作码和回调函数注册。
5. 为频繁的游戏对象增加对象池，使用模板类**Venus::ObjectPool<T\>**,ObjectPool类提供默认构造，如果作为对象池对象的类类型不含有默认构造函数，则继承ObjectPool类扩展acquire方法，参考文件 [player_pool.h](src/center_server/player_pool.h)。
6. 如果要使用std::unordered_map，则直接使用common.h下定义的adap_map，该模板类为跨平台做了处理。