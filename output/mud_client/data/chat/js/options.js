(function (window){
	window.options = {};

	window.setOption = function (name, value){
		window.options[name] = value;
		$(document).trigger('optionchange', [name, value]);
		$(document).trigger('optionchange.' + name, [value]);
	};
	window.getOption = function (name){
		return window.options[name];
	};
	window.serilizeOption = function (){
		return JSON.stringify(window.options);
	};
	window.unserilizeOption = function (jsondata){
		try{
			window.options = JSON.parse(jsondata);
		} catch(e){
			window.options = {};
		}
	};
	$(function(){
		window.external.initRequired();
	})
})(window);