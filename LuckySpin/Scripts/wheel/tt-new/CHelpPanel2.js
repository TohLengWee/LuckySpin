function CHelpPanel2(){
    var _oText1;
    var _oText1Back;
    var _oText2;
    var _oText2Back;    

    var _oHelpBg;
    var _oGroup;
    var _oParent;
    var oText2Posxx = new Array();
    var _oText21x = new Array();
    var oText2Posyy = new Array();
    var _oText21y = new Array();
    var oText2Poscc = new Array();
    var _oText21c = new Array();
    this._init = function(){
        var oParent = this;
        _oHelpBg = createBitmap(s_oSpriteLibrary.getSprite('bg_help2'));
        _oGroup = new createjs.Container();
        var oText1Pos = {x: CANVAS_WIDTH/2, y: (CANVAS_HEIGHT/2)-300};
  
        _oText1 = new createjs.Text("Hi, " + usidxx,"bold 35px Helvetica", "#ffffff");
        _oText1.x = oText1Pos.x;
        _oText1.y = oText1Pos.y;
        _oText1.textAlign = "center";
        _oText1.textBaseline = "alphabetic";
        _oText1.lineWidth = 600;  

         var oText1Pos1 = {x: CANVAS_WIDTH/2, y: (CANVAS_HEIGHT/2)-265};
  
        _oText1x = new createjs.Text("HISTORY PERMAINAN ANDA","bold 35px Helvetica", "#fff400");
        _oText1x.x = oText1Pos1.x;
        _oText1x.y = oText1Pos1.y;
        _oText1x.textAlign = "center";
        _oText1x.textBaseline = "alphabetic";
        _oText1x.lineWidth = 600;                 
  
        var i = 0;

            oText2Posxxz = {x: CANVAS_WIDTH/2-430, y: (CANVAS_HEIGHT/2)-220+(i * 35)}
  
            _oText21xz = new createjs.Text("Transaction Id","bold 33px Helvetica", "#fff400");
            _oText21xz.x = oText2Posxxz.x;
            _oText21xz.y = oText2Posxxz.y;
            _oText21xz.textAlign = "left";
            _oText21xz.textBaseline = "alphabetic";
            _oText21xz.lineWidth = 600;

            oText2Posxxy = {x: CANVAS_WIDTH/2, y: (CANVAS_HEIGHT/2)-220+(i * 35)}
  
            _oText21xy = new createjs.Text("Hasil","bold 33px Helvetica", "#fff400");
            _oText21xy.x = oText2Posxxy.x;
            _oText21xy.y = oText2Posxxy.y;
            _oText21xy.textAlign = "center";
            _oText21xy.textBaseline = "alphabetic";
            _oText21xy.lineWidth = 600;

            oText2Posxxv = {x: CANVAS_WIDTH/2+250, y: (CANVAS_HEIGHT/2)-220+(i * 35)}
  
            _oText21xv = new createjs.Text("Tanggal Bermain","bold 25px Helvetica", "#fff400");
            _oText21xv.x = oText2Posxxv.x;
            _oText21xv.y = oText2Posxxv.y;
            _oText21xv.textAlign = "left";
            _oText21xv.textBaseline = "alphabetic";
            _oText21xv.lineWidth = 600;

        _oGroup.addChild(_oHelpBg);
        while (i < jum_line) {

            oText2Posxx[i] = {x: CANVAS_WIDTH/2-430, y: (CANVAS_HEIGHT/2)-80+(i * 39)}
  
            _oText21x[i] = new createjs.Text(trs_prz[i],"normal 25px Helvetica", "#ffffff");
            _oText21x[i].x = oText2Posxx[i].x;
            _oText21x[i].y = oText2Posxx[i].y;
            _oText21x[i].textAlign = "left";
            _oText21x[i].textBaseline = "alphabetic";
            _oText21x[i].lineWidth = 600;
            _oGroup.addChild(_oText21x[i]);

            oText2Posyy[i] = {x: CANVAS_WIDTH/2, y: (CANVAS_HEIGHT/2)-80+(i * 39)}
  
            _oText21y[i] = new createjs.Text(hasil_prz[i],"normal 25px Helvetica", "#ffffff");
            _oText21y[i].x = oText2Posyy[i].x;
            _oText21y[i].y = oText2Posyy[i].y;
            _oText21y[i].textAlign = "center";
            _oText21y[i].textBaseline = "alphabetic";
            _oText21y[i].lineWidth = 600;
            _oGroup.addChild(_oText21y[i]);

            oText2Poscc[i] = {x: CANVAS_WIDTH/2+180, y: (CANVAS_HEIGHT/2)-80+(i * 39)}
  
            _oText21c[i] = new createjs.Text(date_prz[i],"normal 25px Helvetica", "#ffffff");
            _oText21c[i].x = oText2Poscc[i].x;
            _oText21c[i].y = oText2Poscc[i].y;
            _oText21c[i].textAlign = "left";
            _oText21c[i].textBaseline = "alphabetic";
            _oText21c[i].lineWidth = 600;
            _oGroup.addChild(_oText21c[i]);

            i++;
        }

        _oGroup.alpha=0;
        s_oStage.addChild(_oGroup);

        createjs.Tween.get(_oGroup).to({alpha:1}, 700);        
        
        _oGroup.on("pressup",function(){oParent._onExitHelp();});
     
    };

    this.unload = function(){
        s_oStage.removeChild(_oGroup);

        var oParent = this;
        _oGroup.off("pressup",function(){oParent._onExitHelp()});
    };

    this._onExitHelp = function(){
        _oParent.unload();
        s_oGame._onExitHelp();
    };

    _oParent=this;
    this._init();

}
