function addChatMessage(channel_id, uid, uname, content){
	if(uname == "" || content == ""){
		console.log('信息内容为空，或者用户名为空。');
		return;
	}

	if(!labelTypeDefine[channel_id]){
		console.log('频道ID ' + channel_id + ' 没有定义');
		return;
	}

	var data = {
		channel: labelTypeDefine[channel_id],
		user   : {id: uid, name: uname},
		content: content
	};

	data.channel.id = channel_id;

	if(uid == window.options['current_uid']){
		data.user.type = 'primary';
	}

	var $newLine = $($p(line_template).render(data));
	$("#lstMain").append($newLine);

	/* 鼠标点击 */
	$newLine.find('.uname').on(function (e){
		window.external.userNameClicked($(this).attr('id'), e.which);
	});

	// 追加新元素
	//$("body").fadeIn().append("<a href=aaaaaa style=resize: none; width:320px; height:70px;>fuck</a>"); 

}

function newPost(channel_id, to_uid, content){
	if(!content){
		console.log('信息内容为空。');
		return;
	}
	if(!labelTypeDefine[channel_id]){
		console.log('频道ID ' + channel_id + ' 没有定义');
		return;
	}
	window.external.postChat(channel_id, to_uid, content);
}