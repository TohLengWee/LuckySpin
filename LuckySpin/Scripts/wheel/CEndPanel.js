var _$_1e68 = ["_init", "x", "y", "", "bold 70px Arial", "#000", "Text", "textAlign", "center", "textBaseline", "alphabetic", "lineWidth", "#ffffff", "Container", "alpha", "visible", "addChild", "unload", "mousedown", "_onExit", "off", "_initListener", "on", "show", "game_over", "play", "Sound", "text", "call", "to", "get", "Tween", "removeChild", "onExit"];
function CEndPanel(e) {
  var a; var b; var d; var c;
  this[_$_1e68[0]] = function(e) {
    a = createBitmap(e);
    a[_$_1e68[1]] = 0;
    a[_$_1e68[2]] = 0;
    d = new createjs[_$_1e68[6]](_$_1e68[3], _$_1e68[4], _$_1e68[5]);
    d[_$_1e68[1]] = CANVAS_WIDTH / 2 + 3;
    d[_$_1e68[2]] = (CANVAS_HEIGHT / 2) - 50;
    d[_$_1e68[7]] = _$_1e68[8];
    d[_$_1e68[9]] = _$_1e68[10];
    d[_$_1e68[11]] = 800;
    c = new createjs[_$_1e68[6]](_$_1e68[3], _$_1e68[4], _$_1e68[12]); c[_$_1e68[1]] = CANVAS_WIDTH / 2;
    c[_$_1e68[2]] = (CANVAS_HEIGHT / 2) - 53;
    c[_$_1e68[7]] = _$_1e68[8];
    c[_$_1e68[9]] = _$_1e68[10];
    c[_$_1e68[11]] = 800;
    b = new createjs[_$_1e68[13]]();
    b[_$_1e68[14]] = 0;
    b[_$_1e68[15]] = false; b[_$_1e68[16]](a, d, c); s_oStage[_$_1e68[16]](b)
  };
  this[_$_1e68[17]] = function() {
     b[_$_1e68[20]](_$_1e68[18], this[_$_1e68[19]])
  };
  this[_$_1e68[21]] = function() {
     b[_$_1e68[22]](_$_1e68[18], this[_$_1e68[19]])
  };
  this[_$_1e68[23]] = function() {
     if (DISABLE_SOUND_MOBILE === false || s_bMobile === false) {
        createjs[_$_1e68[26]][_$_1e68[25]](_$_1e68[24])
    };
    d[_$_1e68[27]] = TEXT_GAMEOVER;
    c[_$_1e68[27]] = TEXT_GAMEOVER;
    b[_$_1e68[15]] = true;
    var f = this;
    createjs[_$_1e68[31]][_$_1e68[30]](b)[_$_1e68[29]]({ alpha: 1 }, 500)[_$_1e68[28]](function () { f[_$_1e68[21]]() })
  };
  this[_$_1e68[19]] = function() {
     b[_$_1e68[20]](_$_1e68[18], this[_$_1e68[19]]); s_oStage[_$_1e68[32]](b); s_oGame[_$_1e68[33]]()
  };
  this[_$_1e68[0]](e);
  return this;
}