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
        //_pStartPosExit = {x: CANVAS_WIDTH-60, y: 60};
        //_oButExit = new CTextButton(_pStartPosExit.x - 220, _pStartPosExit.y,oSprite," HOME ","Arial","#ffffff",40, false, s_oStage);
        //_oButExit.addEventListener(ON_MOUSE_UP, this._onExit, this);
        //_oButExit.enable();
         //_oButExit.unload();
        
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
        //_oCreditNum.text = TEXT_CURRENCY + iValue;
    };
    
    this.clearMoneyPanel = function(){
        //_oTextHighLight.alpha=0;
        //createjs.Tween.removeTweens(_oTextHighLight); 
    };

    this.refreshMoney = function(iValue){ 
        var hasil = (iValue + "").replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1,");
        //_oMoneyNum.text = TEXT_CURRENCY;
        //_oTextHighLight.text = TEXT_CURRENCY;  
        
    };

    this.refreshBet = function(iValue){
        _oBetNum.text = TEXT_CURRENCY + iValue;
    };

    this.animWin = function(){
        if(_iCurAlpha === 1){
            _iCurAlpha = 0;
            createjs.Tween.get(_oTextHighLight).to({alpha:_iCurAlpha }, 150, createjs.Ease.cubicOut).call(function(){_oParent.animWin();});
        }else{
            _iCurAlpha = 1;
            createjs.Tween.get(_oTextHighLight).to({alpha:_iCurAlpha }, 150, createjs.Ease.cubicOut).call(function(){_oParent.animWin();});
        } 
    };

  this._onButSpinRelease = function () {
        numb_kupn = numb_kupn - 1;
        if(numb_kupn < 10){
            numb_kupn = "0" + numb_kupn;
        } 
        numb_kupnx = numb_kupn.toString().split("");
        _oTextHighLightx.text = numb_kupnx[0];
        _oTextHighLighty.text = numb_kupnx[1];
        this.disableSpin(true);
        $.ajax({
          type: "GET",
          url: "/main/GetSpinResult?voucherId="+voucherId,
          success: function (data) {
            if (data.status && data.status === "success")
              s_oGame.spinWheel(data);
            else
              window.location = '/main';
          },
          error: function(data) {
            window.location = '/main';
          }
        });
    };

    this.disableSpin = function (bDisable) {
      bDisable || numb_kupn <=0 ? _oButSpin.disable() : _oButSpin.enable();
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