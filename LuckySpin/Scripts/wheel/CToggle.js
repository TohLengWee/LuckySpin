var _$_a378=["_init","width","height","SpriteSheet","state_","x","y","stop","addChild","_initListener","unload","mousedown","buttonDown","off","pressup","buttonRelease","removeChild","on","addEventListener","setActive","gotoAndStop","scaleX","scaleY","click","play","Sound","call","setPosition"];function CToggle(f,g,h,e){var c;var a;var b;var d;this[_$_a378[0]]= function(f,g,h,e){a=  new Array();b=  new Array();var i={images:[h],frames:{width:h[_$_a378[1]]/ 2,height:h[_$_a378[2]],regX:(h[_$_a378[1]]/ 2)/ 2,regY:h[_$_a378[2]]/ 2},animations:{state_true:[0],state_false:[1]}};var j= new createjs[_$_a378[3]](i);c= e;d= createSprite(j,_$_a378[4]+ c,(h[_$_a378[1]]/ 2)/ 2,h[_$_a378[2]]/ 2,h[_$_a378[1]]/ 2,h[_$_a378[2]]);d[_$_a378[5]]= f;d[_$_a378[6]]= g;d[_$_a378[7]]();s_oStage[_$_a378[8]](d);this[_$_a378[9]]()};this[_$_a378[10]]= function(){d[_$_a378[13]](_$_a378[11],this[_$_a378[12]]);d[_$_a378[13]](_$_a378[14],this[_$_a378[15]]);s_oStage[_$_a378[16]](d)};this[_$_a378[9]]= function(){d[_$_a378[17]](_$_a378[11],this[_$_a378[12]]);d[_$_a378[17]](_$_a378[14],this[_$_a378[15]])};this[_$_a378[18]]= function(m,k,l){a[m]= k;b[m]= l};this[_$_a378[19]]= function(e){c= e;d[_$_a378[20]](_$_a378[4]+ c)};this[_$_a378[15]]= function(){d[_$_a378[21]]= 1;d[_$_a378[22]]= 1;if(DISABLE_SOUND_MOBILE=== false|| s_bMobile=== false){createjs[_$_a378[25]][_$_a378[24]](_$_a378[23])};c=  !c;d[_$_a378[20]](_$_a378[4]+ c);if(a[ON_MOUSE_UP]){a[ON_MOUSE_UP][_$_a378[26]](b[ON_MOUSE_UP],c)}};this[_$_a378[12]]= function(){d[_$_a378[21]]= 0.9;d[_$_a378[22]]= 0.9;if(a[ON_MOUSE_DOWN]){a[ON_MOUSE_DOWN][_$_a378[26]](b[ON_MOUSE_DOWN])}};this[_$_a378[27]]= function(f,g){d[_$_a378[5]]= f;d[_$_a378[6]]= g};this[_$_a378[0]](f,g,h,e)}