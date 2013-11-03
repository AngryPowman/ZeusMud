(function(window){
	window.$p=constructor;

	function constructor(content){
		this.render=function(data){
			data = parse_to_path(data);
			for(var id in data){
				content=content.replace(new RegExp('{%'+id+'%}','ig'),data[id]);
			}
			return content.replace(/{%.*?%}/ig, '');
		}
		return this;
	}
	var temp_path='';
	function parse_to_path(json){
	        var ret = {};
	        for(var i in json){
	                if(!json.hasOwnProperty(i)){
	                        continue;
	                }
	                var val = json[i];
	                var type = typeof val;
	                var path = temp_path? temp_path + '.' + i : i;	

	                if(val===undefined || val===null){
	                        ret[path] = '';
	                } else if(/string|number|boolean/.test(type)){
	                        ret[path] = val;
	                } else if(val.constructor === Object || val.constructor === Array){
	                        var save = temp_path;
	                        temp_path = path;
	                        $.extend(ret, parse_to_path(val));
	                        temp_path = save;
	                } else{
	                        console.error('未知类型', val);
	                }
	        }
	        return ret;
	}
})(window);