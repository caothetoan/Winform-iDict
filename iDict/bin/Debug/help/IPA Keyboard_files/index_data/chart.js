function init(){
	var anchors = document.getElementsByTagName('a');
	var i;
	for(i = 0; i < anchors.length; i++){
		var a = anchors[i];
		if(a.getAttribute("href"))
			a.target = '_top';
	}
	var forms = document.getElementsByTagName('form');
	for(i = 0; i < forms.length; i++)
		forms[i].target = '_top';
}