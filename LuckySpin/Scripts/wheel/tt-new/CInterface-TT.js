function CInterface(){
    var _oAudioToggle;
    var _oButExit;
    var _oButSpin;
    var _oButPlus;
    var _oButMin;
    var _oHelpPanel=null;    
    var _iCurAlpha;
    var _oCreditNum;
    var _oMoneyNum;
    var _oBetNum;
    var _oParent;
    var _oTextHighLight;
    
    var _pStartPosExit;
    var _pStartPosAudio;
    
    this._init = function(){
        _oParent = this;
        _iCurAlpha = 0;
        
        var oExitX;        
        
        var oSprite = s_oSpriteLibrary.getSprite('but_exit');
        _pStartPosExit = {x: CANVAS_WIDTH-60, y: 60};
        _oButExit = new CTextButton(_pStartPosExit.x - 220, _pStartPosExit.y,oSprite," HOME ","Arial","#ffffff",40, false, s_oStage);
        _oButExit.addEventListener(ON_MOUSE_UP, this._onExit, this);
        _oButExit.enable();
        // _oButExit.unload();
        
        oExitX = CANVAS_WIDTH - (oSprite.width/2) - 100;
        _pStartPosAudio = {x: oExitX, y: (oSprite.height/2) + 10};
        
        if(DISABLE_SOUND_MOBILE === false || s_bMobile === false){
            var oSprite = s_oSpriteLibrary.getSprite('audio_icon');
            _oAudioToggle = new CToggle(_pStartPosAudio.x,_pStartPosAudio.y,oSprite,s_bAudioActive);
            _oAudioToggle.addEventListener(ON_MOUSE_UP, this._onAudioToggle, this);
            _oAudioToggle.unload(); 
        }      

        var oSprite = s_oSpriteLibrary.getSprite('but_spin');
        _oButSpin = new CTextButton(975,CANVAS_HEIGHT - 140,oSprite," ","Helvetica","#fff",40, false, s_oStage);
        _oButSpin.enable();
        if (numb_kupn < 1){
        _oButSpin.disable(); 
        }
        _oButSpin.addEventListener(ON_MOUSE_UP, this._onButSpinRelease, this);

        var oSprite = s_oSpriteLibrary.getSprite('but_plus');
        _oButPlus = new CTextButton(650,CANVAS_HEIGHT - 320,oSprite,TEXT_PLUS,"Arial","#ffffff",70, false, s_oStage);
        _oButPlus.enable();
        _oButPlus.unload();
        _oButPlus.addEventListener(ON_MOUSE_UP, this._onButPlusRelease, this);

        var oSprite = s_oSpriteLibrary.getSprite('but_plus');
        _oButMin = new CTextButton(350,CANVAS_HEIGHT - 320,oSprite,TEXT_MIN,"Arial","#ffffff",70, false, s_oStage);
        _oButMin.enable();
        _oButMin.unload();
        _oButMin.addEventListener(ON_MOUSE_UP, this._onButMinRelease, this);

        var oSprite = s_oSpriteLibrary.getSprite('but_plus');
        _oButHelp = new CTextButton(CANVAS_WIDTH-150,CANVAS_HEIGHT - 340,oSprite," ","Arial","#ffffff",70, false, s_oStage);
        _oButHelp.enable();
        // _oButMin.unload();
        _oButHelp.addEventListener(ON_MOUSE_UP, this._onButHelpRelease, this);

        var oSprite = s_oSpriteLibrary.getSprite('bg_history');
        _oButHelp = new CTextButton(CANVAS_WIDTH-260,CANVAS_HEIGHT - 340,oSprite," ","Arial","#ffffff",70, false, s_oStage);
        _oButHelp.enable();
        // _oButMin.unload();
        _oButHelp.addEventListener(ON_MOUSE_UP, this._onButHistoryRelease, this);

        var oSprite = s_oSpriteLibrary.getSprite('bg_info');
        _oButHelp = new CTextButton(CANVAS_WIDTH-50,180,oSprite," ","Arial","#ffffff",70, false, s_oStage);
        _oButHelp.enable();
        // _oButMin.unload();
        _oButHelp.addEventListener(ON_MOUSE_UP, this._onButInfoRelease, this);

        var oSprite = s_oSpriteLibrary.getSprite('but_toa');
        _oButHelp = new CTextButton(CANVAS_WIDTH-370,CANVAS_HEIGHT - 340,oSprite," ","Arial","#ffffff",70, false, s_oStage);
        _oButHelp.enable();
        if(announcActive == 0){
            _oButHelp.unload();
        }
        _oButHelp.addEventListener(ON_MOUSE_UP, this._onButToaRelease, this);
        
        var oCreditTextBack = new createjs.Text(point_zonk,"bold 50px Arial", "#fff");
        oCreditTextBack.x = CANVAS_WIDTH-110;
        oCreditTextBack.y = 200;
        oCreditTextBack.textAlign = "right";
        oCreditTextBack.textBaseline = "alphabetic";
        oCreditTextBack.lineWidth = 400;
        s_oStage.addChild(oCreditTextBack);

        var oCreditTextBack = new createjs.Text(TEXT_CREDITS,"bold 90px Arial", "#000000");
        oCreditTextBack.x = 304;
        oCreditTextBack.y = 204;
        oCreditTextBack.textAlign = "left";
        oCreditTextBack.textBaseline = "alphabetic";
        oCreditTextBack.lineWidth = 400;
        s_oStage.addChild(oCreditTextBack);
                
        var oCreditText = new createjs.Text(TEXT_CREDITS,"bold 90px Arial", "#ffffff");
        oCreditText.x = 300;
        oCreditText.y = 200;
        oCreditText.textAlign = "left";
        oCreditText.textBaseline = "alphabetic";
        oCreditText.lineWidth = 400;
        s_oStage.addChild(oCreditText);
        
        _oCreditNum = new createjs.Text(TEXT_CURRENCY + START_CREDIT,"bold 70px Arial", "#ffffff");
        _oCreditNum.x = 0;
        _oCreditNum.y = 0;
        _oCreditNum.textAlign = "left";
        _oCreditNum.textBaseline = "alphabetic";
        _oCreditNum.lineWidth = 400;
        s_oStage.addChild(_oCreditNum);

        _oMoneyNum = new createjs.Text("" +"","bold 40px Arial", "#ffffff");
        _oMoneyNum.x = 280;
        _oMoneyNum.y = 400;
        _oMoneyNum.textAlign = "center";
        _oMoneyNum.textBaseline = "alphabetic";
        _oMoneyNum.lineWidth = 400;
        s_oStage.addChild(_oMoneyNum);
        
        _oTextHighLight = new createjs.Text("","bold 70px Arial", "#ffffff");
        _oTextHighLight.x = 280;
        _oTextHighLight.y = 350;
        _oTextHighLight.textAlign = "center";
        _oTextHighLight.textBaseline = "alphabetic";
        _oTextHighLight.lineWidth = 400;
        // _oTextHighLight.alpha = _iCurAlpha;
        s_oStage.addChild(_oTextHighLight);
        
        _oBetNum = new createjs.Text("","bold 40px Helvetica", "#ffffff");
        _oBetNum.x = 280;
        _oBetNum.y = 280;
        _oBetNum.textAlign = "center";
        _oBetNum.textBaseline = "alphabetic";
        _oBetNum.lineWidth = 400;
        s_oStage.addChild(_oBetNum);

        if(numb_kupn < 10){
            numb_kupn = "0" + numb_kupn;
        }

        numb_kupnx = numb_kupn.toString().split("");

        _oTextHighLightx = new createjs.Text(numb_kupnx[0],"bold 200px Helvetica", "#ffffff");
        _oTextHighLightx.x = 190;
        _oTextHighLightx.y = 440;
        _oTextHighLightx.textAlign = "center";
        _oTextHighLightx.textBaseline = "middle";
        _oTextHighLightx.lineWidth = 500;
        // _oTextHighLight.alpha = _iCurAlpha;
        s_oStage.addChild(_oTextHighLightx);

        _oTextHighLighty = new createjs.Text(numb_kupnx[1],"bold 200px Helvetica", "#ffffff");
        _oTextHighLighty.x = 330;
        _oTextHighLighty.y = 440;
        _oTextHighLighty.textAlign = "center";
        _oTextHighLighty.textBaseline = "middle";
        _oTextHighLighty.lineWidth = 500;
        // _oTextHighLight.alpha = _iCurAlpha;
        s_oStage.addChild(_oTextHighLighty);
        
        idpertama = new createjs.Text(lastus[0],"normal 25px Helvetica", "#000");
        idpertama.x = 1490;
        idpertama.y = 370;
        idpertama.textAlign = "left";
        idpertama.textBaseline = "alphabetic";
        idpertama.lineWidth = 400;
        // _oTextHighLight.alpha = _iCurAlpha;
        s_oStage.addChild(idpertama);
        
        hadiahpertama = new createjs.Text(lastnm[0],"normal 25px Helvetica", "#000");
        hadiahpertama.x = 1700;
        hadiahpertama.y = 370;
        hadiahpertama.textAlign = "left";
        hadiahpertama.textBaseline = "alphabetic";
        hadiahpertama.lineWidth = 400;
        s_oStage.addChild(hadiahpertama);

        idpertama = new createjs.Text(lastus[1],"normal 25px Helvetica", "#000");
        idpertama.x = 1490;
        idpertama.y = 430;
        idpertama.textAlign = "left";
        idpertama.textBaseline = "alphabetic";
        idpertama.lineWidth = 400;
        // _oTextHighLight.alpha = _iCurAlpha;
        s_oStage.addChild(idpertama);
        
        hadiahpertama = new createjs.Text(lastnm[1],"normal 25px Helvetica", "#000");
        hadiahpertama.x = 1700;
        hadiahpertama.y = 430;
        hadiahpertama.textAlign = "left";
        hadiahpertama.textBaseline = "alphabetic";
        hadiahpertama.lineWidth = 400;
        s_oStage.addChild(hadiahpertama);

        idpertama = new createjs.Text(lastus[2],"normal 25px Helvetica", "#000");
        idpertama.x = 1490;
        idpertama.y = 490;
        idpertama.textAlign = "left";
        idpertama.textBaseline = "alphabetic";
        idpertama.lineWidth = 400;
        // _oTextHighLight.alpha = _iCurAlpha;
        s_oStage.addChild(idpertama);
        
        hadiahpertama = new createjs.Text(lastnm[2],"normal 25px Helvetica", "#000");
        hadiahpertama.x = 1700;
        hadiahpertama.y = 490;
        hadiahpertama.textAlign = "left";
        hadiahpertama.textBaseline = "alphabetic";
        hadiahpertama.lineWidth = 400;
        s_oStage.addChild(hadiahpertama);

        idpertama = new createjs.Text(lastus[3],"normal 25px Helvetica", "#000");
        idpertama.x = 1490;
        idpertama.y = 555;
        idpertama.textAlign = "left";
        idpertama.textBaseline = "alphabetic";
        idpertama.lineWidth = 400;
        // _oTextHighLight.alpha = _iCurAlpha;
        s_oStage.addChild(idpertama);
        
        hadiahpertama = new createjs.Text(lastnm[3],"normal 25px Helvetica", "#000");
        hadiahpertama.x = 1700;
        hadiahpertama.y = 555;
        hadiahpertama.textAlign = "left";
        hadiahpertama.textBaseline = "alphabetic";
        hadiahpertama.lineWidth = 400;
        s_oStage.addChild(hadiahpertama);

        idpertama = new createjs.Text(lastus[4],"normal 25px Helvetica", "#000");
        idpertama.x = 1490;
        idpertama.y = 620;
        idpertama.textAlign = "left";
        idpertama.textBaseline = "alphabetic";
        idpertama.lineWidth = 400;
        // _oTextHighLight.alpha = _iCurAlpha;
        s_oStage.addChild(idpertama);
        
        hadiahpertama = new createjs.Text(lastnm[4],"normal 25px Helvetica", "#000");
        hadiahpertama.x = 1700;
        hadiahpertama.y = 620;
        hadiahpertama.textAlign = "left";
        hadiahpertama.textBaseline = "alphabetic";
        hadiahpertama.lineWidth = 400;
        s_oStage.addChild(hadiahpertama);
        
        this.refreshButtonPos(s_iOffsetX,s_iOffsetY);
    };
    
    this.unload = function(){
        if(DISABLE_SOUND_MOBILE === false || s_bMobile === false){
            _oAudioToggle.unload();
            _oAudioToggle = null;
        }

        _oButExit.unload();
        _oButSpin.unload();

        
        s_oInterface = null;
    };

    this.refreshCredit = function(iValue){        
        _oCreditNum.text = TEXT_CURRENCY + iValue;
    };
    
    this.clearMoneyPanel = function(){
        _oTextHighLight.alpha=0;
        createjs.Tween.removeTweens(_oTextHighLight); 
    };

    this.refreshMoney = function(iValue){ 
        var hasil = (iValue + "").replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1,");
        _oMoneyNum.text = TEXT_CURRENCY;
        _oTextHighLight.text = TEXT_CURRENCY;  
        
    };

    this.refreshBet = function(iValue){
        _oBetNum.text = TEXT_CURRENCY + iValue;
    };

    this.animWin = function(){
        if(_iCurAlpha === 1){
            _iCurAlpha = 0;
            createjs.Tween.get(_oTextHighLight).to({alpha:_iCurAlpha }, 150,createjs.Ease.cubicOut).call(function(){_oParent.animWin();});
        }else{
            _iCurAlpha = 1;
            createjs.Tween.get(_oTextHighLight).to({alpha:_iCurAlpha }, 150,createjs.Ease.cubicOut).call(function(){_oParent.animWin();});
        }
        
    };

    this._onButSpinRelease = function(){
        numb_kupn = numb_kupn - 1;
        if(numb_kupn < 10){
            numb_kupn = "0" + numb_kupn;
        }
        numb_kupnx = numb_kupn.toString().split("");
        _oTextHighLightx.text = numb_kupnx[0];
        _oTextHighLighty.text = numb_kupnx[1];
        s_oGame.spinWheel();
    };
    
    this._onButPlusRelease = function(){
        s_oGame.modifyBonus("plus");
    };

    this._onButMinRelease = function(){
        s_oGame.modifyBonus("min");
    };

    this.disableSpin = function(bDisable){
        if(bDisable === true){
            _oButSpin.disable();
            _oButPlus.disable();
            _oButMin.disable();
        } else {
            _oButSpin.enable();
            _oButPlus.enable();
            _oButMin.enable();
        }        
    };

    this._onButHelpRelease = function(){
        _oHelpPanel = new CHelpPanel();
    };

    this._onButHistoryRelease = function(){
        _oHelpPanel = new CHelpPanel2();
    };
    
    this._onButInfoRelease = function(){
        _oHelpPanel = new CHelpPanel3();
    };

    this._onButToaRelease = function(){
        _oHelpPanel = new CHelpPanel6();
    };

    this._onButRestartRelease = function(){
        s_oGame.restartGame();
    };
    
    this.onExitFromHelp = function(){
        _oHelpPanel.unload();
    };
    
    this.refreshButtonPos = function(iNewX,iNewY){
        // _oButExit.setPosition(_pStartPosExit.x - iNewX,iNewY + _pStartPosExit.y);
        if(DISABLE_SOUND_MOBILE === false || s_bMobile === false){
            _oAudioToggle.setPosition(_pStartPosAudio.x - iNewX,iNewY + _pStartPosAudio.y);
        }
        
    };
    
    this._onAudioToggle = function(){
        createjs.Sound.setMute(s_bAudioActive);
        s_bAudioActive = !s_bAudioActive;
    };
    
    this._onExit = function(){
      window.location = atob(rturl); 
    };
    
    s_oInterface = this;
    
    this._init();
    
    return this;
}

var s_oInterface = null;