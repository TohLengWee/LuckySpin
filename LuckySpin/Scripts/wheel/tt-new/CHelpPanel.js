function CHelpPanel(){
    var _oText1;
    var _oText1Back;
    var _oText2;
    var _oText2Back;    

    var _oHelpBg;
    var _oGroup;
    var _oParent;

    this._init = function(){
        var oParent = this;
        _oHelpBg = createBitmap(s_oSpriteLibrary.getSprite('bg_help1'));
  
        var oText1Pos = {x: CANVAS_WIDTH/2, y: (CANVAS_HEIGHT/2)-300};
  
        _oText1 = new createjs.Text(TEXT_HELP1,"bold 35px Helvetica", "#ffffff");
        _oText1.x = oText1Pos.x;
        _oText1.y = oText1Pos.y;
        _oText1.textAlign = "center";
        _oText1.textBaseline = "alphabetic";
        _oText1.lineWidth = 600;  

         var oText1Pos1 = {x: CANVAS_WIDTH/2, y: (CANVAS_HEIGHT/2)-250};
  
        _oText1x = new createjs.Text(gamename,"bold 35px Helvetica", "#fff400");
        _oText1x.x = oText1Pos1.x;
        _oText1x.y = oText1Pos1.y;
        _oText1x.textAlign = "center";
        _oText1x.textBaseline = "alphabetic";
        _oText1x.lineWidth = 600;                 
  
        var oText2Pos1 = {x: CANVAS_WIDTH/2-220, y: (CANVAS_HEIGHT/2)-65}
  
        _oText21 = new createjs.Text("Rp. " + ((toprz[0] + 1) + "").replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1."),"bold 35px Helvetica", "#ffffff");
        _oText21.x = oText2Pos1.x;
        _oText21.y = oText2Pos1.y;
        _oText21.textAlign = "right";
        _oText21.textBaseline = "alphabetic";
        _oText21.lineWidth = 600;
     
        var oText3Pos1 = {x: CANVAS_WIDTH/2-190, y: (CANVAS_HEIGHT/2)-65}
  
        _oText31 = new createjs.Text("s/d","bold 35px Helvetica", "#fff400");
        _oText31.x = oText3Pos1.x;
        _oText31.y = oText3Pos1.y;
        _oText31.textAlign = "center";
        _oText31.textBaseline = "alphabetic";
        _oText31.lineWidth = 600;

        var oText4Pos1 = {x: CANVAS_WIDTH/2+90, y: (CANVAS_HEIGHT/2)-65}
  
        _oText41 = new createjs.Text("Rp. " + (toprz[1] + "").replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1."),"bold 35px Helvetica", "#ffffff");
        _oText41.x = oText4Pos1.x;
        _oText41.y = oText4Pos1.y;
        _oText41.textAlign = "right";
        _oText41.textBaseline = "alphabetic";
        _oText41.lineWidth = 600;

        var oText5Pos1 = {x: CANVAS_WIDTH/2+300, y: (CANVAS_HEIGHT/2)-65}
  
        _oText51 = new createjs.Text("","bold 35px Helvetica", "#ffffff");
        _oText51.x = oText5Pos1.x;
        _oText51.y = oText5Pos1.y;
        _oText51.textAlign = "right";
        _oText51.textBaseline = "alphabetic";
        _oText51.lineWidth = 600;

        var oText6Pos1 = {x: CANVAS_WIDTH/2+190, y: (CANVAS_HEIGHT/2)-65}
  
        _oText61 = new createjs.Text(tokup[0],"bold 35px Helvetica", "#fff400");
        _oText61.x = oText6Pos1.x;
        _oText61.y = oText6Pos1.y;
        _oText61.textAlign = "center";
        _oText61.textBaseline = "alphabetic";
        _oText61.lineWidth = 600;

        var oText2Pos2 = {x: CANVAS_WIDTH/2-220, y: (CANVAS_HEIGHT/2)+5}
  
        _oText22 = new createjs.Text("Rp. " + ((toprz[1] + 1) + "").replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1."),"bold 35px Helvetica", "#ffffff");
        _oText22.x = oText2Pos2.x;
        _oText22.y = oText2Pos2.y;
        _oText22.textAlign = "right";
        _oText22.textBaseline = "alphabetic";
        _oText22.lineWidth = 600;
     
        var oText3Pos2 = {x: CANVAS_WIDTH/2-190, y: (CANVAS_HEIGHT/2)+5}
  
        _oText32 = new createjs.Text("s/d","bold 35px Helvetica", "#fff400");
        _oText32.x = oText3Pos2.x;
        _oText32.y = oText3Pos2.y;
        _oText32.textAlign = "center";
        _oText32.textBaseline = "alphabetic";
        _oText32.lineWidth = 600;

        var oText4Pos2 = {x: CANVAS_WIDTH/2+90, y: (CANVAS_HEIGHT/2)+5}
  
        _oText42 = new createjs.Text("Rp. " + (toprz[2] + "").replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1."),"bold 35px Helvetica", "#ffffff");
        _oText42.x = oText4Pos2.x;
        _oText42.y = oText4Pos2.y;
        _oText42.textAlign = "right";
        _oText42.textBaseline = "alphabetic";
        _oText42.lineWidth = 600;

        var oText5Pos2 = {x: CANVAS_WIDTH/2+300, y: (CANVAS_HEIGHT/2)+5}
  
        _oText52 = new createjs.Text("","bold 35px Helvetica", "#ffffff");
        _oText52.x = oText5Pos2.x;
        _oText52.y = oText5Pos2.y;
        _oText52.textAlign = "right";
        _oText52.textBaseline = "alphabetic";
        _oText52.lineWidth = 600;

        var oText6Pos2 = {x: CANVAS_WIDTH/2+190, y: (CANVAS_HEIGHT/2)+5}
  
        _oText62 = new createjs.Text(tokup[1],"bold 35px Helvetica", "#fff400");
        _oText62.x = oText6Pos2.x;
        _oText62.y = oText6Pos2.y;
        _oText62.textAlign = "center";
        _oText62.textBaseline = "alphabetic";
        _oText62.lineWidth = 600;

        var oText2Pos3 = {x: CANVAS_WIDTH/2-220, y: (CANVAS_HEIGHT/2)+75}
  
        _oText23 = new createjs.Text("Rp. " + ((toprz[2] + 1) + "").replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1."),"bold 35px Helvetica", "#ffffff");
        _oText23.x = oText2Pos3.x;
        _oText23.y = oText2Pos3.y;
        _oText23.textAlign = "right";
        _oText23.textBaseline = "alphabetic";
        _oText23.lineWidth = 600;
     
        var oText3Pos3 = {x: CANVAS_WIDTH/2-190, y: (CANVAS_HEIGHT/2)+75}
  
        _oText33 = new createjs.Text("s/d","bold 35px Helvetica", "#fff400");
        _oText33.x = oText3Pos3.x;
        _oText33.y = oText3Pos3.y;
        _oText33.textAlign = "center";
        _oText33.textBaseline = "alphabetic";
        _oText33.lineWidth = 600;

        var oText4Pos3 = {x: CANVAS_WIDTH/2+90, y: (CANVAS_HEIGHT/2)+75}
  
        _oText43 = new createjs.Text("Rp. " + (toprz[3] + "").replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1."),"bold 35px Helvetica", "#ffffff");
        _oText43.x = oText4Pos3.x;
        _oText43.y = oText4Pos3.y;
        _oText43.textAlign = "right";
        _oText43.textBaseline = "alphabetic";
        _oText43.lineWidth = 600;

        var oText5Pos3 = {x: CANVAS_WIDTH/2+300, y: (CANVAS_HEIGHT/2)+75}
  
        _oText53 = new createjs.Text("","bold 35px Helvetica", "#ffffff");
        _oText53.x = oText5Pos3.x;
        _oText53.y = oText5Pos3.y;
        _oText53.textAlign = "center";
        _oText53.textBaseline = "alphabetic";
        _oText53.lineWidth = 600;

        var oText6Pos3 = {x: CANVAS_WIDTH/2+190, y: (CANVAS_HEIGHT/2)+75}
  
        _oText63 = new createjs.Text(tokup[2],"bold 35px Helvetica", "#fff400");
        _oText63.x = oText6Pos3.x;
        _oText63.y = oText6Pos3.y;
        _oText63.textAlign = "center";
        _oText63.textBaseline = "alphabetic";
        _oText63.lineWidth = 600;

		var oText2Pos4 = {x: CANVAS_WIDTH/2, y: (CANVAS_HEIGHT/2)+150}
  
        _oText24 = new createjs.Text("Rp. " + ((toprz[3] + 1) + "").replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1."),"bold 35px Helvetica", "#ffffff");
        _oText24.x = oText2Pos4.x;
        _oText24.y = oText2Pos4.y;
        _oText24.textAlign = "right";
        _oText24.textBaseline = "alphabetic";
        _oText24.lineWidth = 600;
     
        var oText3Pos4 = {x: CANVAS_WIDTH/2+70, y: (CANVAS_HEIGHT/2)+150}
  
        _oText34 = new createjs.Text(">","bold 35px Helvetica", "#fff400");
        _oText34.x = oText3Pos4.x;
        _oText34.y = oText3Pos4.y;
        _oText34.textAlign = "center";
        _oText34.textBaseline = "alphabetic";
        _oText34.lineWidth = 600;

        var oText4Pos4 = {x: CANVAS_WIDTH/2+90, y: (CANVAS_HEIGHT/2)+150}
  
        _oText44 = new createjs.Text(" ","bold 35px Helvetica", "#ffffff");
        _oText44.x = oText4Pos4.x;
        _oText44.y = oText4Pos4.y;
        _oText44.textAlign = "center";
        _oText44.textBaseline = "alphabetic";
        _oText44.lineWidth = 600;

        var oText5Pos4 = {x: CANVAS_WIDTH/2+300, y: (CANVAS_HEIGHT/2)+150}
  
        _oText54 = new createjs.Text("","bold 35px Helvetica", "#ffffff");
        _oText54.x = oText5Pos4.x;
        _oText54.y = oText5Pos4.y;
        _oText54.textAlign = "center";
        _oText54.textBaseline = "alphabetic";
        _oText54.lineWidth = 600;

        var oText6Pos4 = {x: CANVAS_WIDTH/2+190, y: (CANVAS_HEIGHT/2)+150}
  
        _oText64 = new createjs.Text(tokup[3],"bold 35px Helvetica", "#fff400");
        _oText64.x = oText6Pos4.x;
        _oText64.y = oText6Pos4.y;
        _oText64.textAlign = "center";
        _oText64.textBaseline = "alphabetic";
        _oText64.lineWidth = 600;

        _oTextNote = new createjs.Text("* Kupon akan Hangus jika dalam 3 hari tidak di gunakan","bold 20px Helvetica", "#fff400");
        _oTextNote.x = CANVAS_WIDTH/2;
        _oTextNote.y = (CANVAS_HEIGHT/2)+210;
        _oTextNote.textAlign = "center";
        _oTextNote.textBaseline = "alphabetic";
        _oTextNote.lineWidth = 600;

        _oGroup = new createjs.Container();
        _oGroup.addChild(_oHelpBg, _oText21, _oText31,_oText41,_oText51,_oText61,_oText22, _oText32,_oText42,_oText52,_oText62,_oText23, _oText33,_oText43,_oText53,_oText63,_oText24, _oText34,_oText44,_oText54,_oText64,_oTextNote);
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
