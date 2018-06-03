function CHelpPanel6(){
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
        _oHelpBg = createBitmap(s_oSpriteLibrary.getSprite('bg_help6'));
        _oGroup = new createjs.Container();
        var oText1Pos = {x: CANVAS_WIDTH/2, y: (CANVAS_HEIGHT/2)-180};
  
        _oText1 = new createjs.Text(announcTitle,"bold 40px Helvetica", "#fff400");
        _oText1.x = oText1Pos.x;
        _oText1.y = oText1Pos.y;
        _oText1.textAlign = "center";
        _oText1.textBaseline = "alphabetic";
        _oText1.lineWidth = 600;  

         var oText1Pos1 = {x: CANVAS_WIDTH/2-400, y: (CANVAS_HEIGHT/2)-80};
  
        _oText1x = new createjs.Text(atob(announcContent),"bold 22px Helvetica", "#ffffff");
        _oText1x.x = oText1Pos1.x;
        _oText1x.y = oText1Pos1.y;
        _oText1x.textAlign = "left";
        _oText1x.textBaseline = "alphabetic";
        _oText1x.lineWidth = 800;             

        console.log(_oText1x);

        _oGroup.addChild(_oHelpBg,_oText1,_oText1x);
        
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
