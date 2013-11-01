function addChatMessage(type, uid, uname, content){
	if(uname == "" || content == ""){
		console.log('empty');
		return;
	}

	if(!labelTypeDefine[type]){
		console.log(type + ' not exist');
		return;
	}

	var data = {
		channel: labelTypeDefine[type],
		user   : {id: uid, name: uname},
		content: content
	};

	if(uid == window.options['current_uid']){
		data.user.type = 'primary';
	}

	$("#lstMain").append($p(line_template).render(data));

	// 追加新元素
	//$("body").fadeIn().append("<a href=aaaaaa style=resize: none; width:320px; height:70px;>fuck</a>"); 

}