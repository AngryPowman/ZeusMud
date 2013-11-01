if(!window.console){
	window.console = {
		log: function (){
			var ret = [];
			$(arguments).each(function (_, data){
				ret.push(JSON.stringify(data, null, 4));
			});
			if(!ret.length){
				return;
			}

			for(var i = 0; i < ret.length; i++){
				ret[i] = '\n-------------[' + i + ']------------\n' + ret[i].replace(/^/m, '\t');
			}
			var str = '===========javascript调试输出：===========\n' + printStackTrace().slice(3).join('\n') +
					  ret.join() + '\n===========输出结束===========\n';
			window.external.console_log(str);
		}
	};
}
window.onerror = function (sMsg, sUrl, sLine){
	var str = 'IE内发生无法恢复的错误：\n\t信息:' + sMsg + '\n\t位置:' + sUrl + ':' + sLine + '\n======================';
	if(window.external && window.external.console_log){
		window.external.console_log(str);
	}
	return false;
};

function intval(val){
	val = parseInt(val, 10);
	if(isNaN(val)){
		return 0;
	} else{
		return val;
	}
}

function setStylesheet(id, css){
	var head = $('head')[0], style = document.createElement('style');

	style.type = 'text/css';
	style.id = id;
	if(style.styleSheet){
		style.styleSheet.cssText = css;
	} else{
		style.appendChild(document.createTextNode(css));
	}

	$('#' + id).remove();

	head.appendChild(style);
}