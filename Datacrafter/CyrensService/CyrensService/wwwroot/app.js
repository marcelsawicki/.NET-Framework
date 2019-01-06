var Greeter = (function () {
    function Greeter(element) {
        this.element = element;
        this.element.innerHTML += "The time is: ";
        this.span = document.createElement('span');
        this.element.appendChild(this.span);
        this.span.innerText = new Date().toUTCString();
    }
    Greeter.prototype.start = function () {
        var _this = this;
        this.timerToken = setInterval(function () { return _this.span.innerHTML = new Date().toUTCString(); }, 500);
    };
    Greeter.prototype.stop = function () {
        clearTimeout(this.timerToken);
    };
    return Greeter;
}());
var Hafn = (function () {
    function Hafn(element) {
        this.list = ['miecz', 'zbroja', 'wlocznia']; // dopisalem
        this.element = element;
        // let kostkaDoGry = Math.floor(Math.random() * 3);
        // let numerNaStrone: string = this.list[kostkaDoGry];
        // this.element.innerHTML += "Wybieram z tablicy: " + numerNaStrone + ". ";
        // this.element.innerHTML += "Losuje jakas wartosc od 0 do 100: " + Math.floor(Math.random() * 100);
        this.span = document.createElement('span');
        this.element.appendChild(this.span);
        // this.span.innerText = new Date().toUTCString();
    }
    Hafn.prototype.start = function () {
        var _this = this;
        this.timerToken = setInterval(function () { return _this.span.innerHTML = new Date().toUTCString(); }, 500);
    };
    Hafn.prototype.stop = function () {
        clearTimeout(this.timerToken);
    };
    return Hafn;
}());
var r_zdarzenia = ['wrog', 'nieznajomy', 'przedmiot', 'nic'];
var r_nieznajomego = ['zlodziej', 'dobry_d', 'zly_d', 'czarodziej'];
var r_przedmiotu = ['miecz', 'zbroja', 'eliksir', 'mieso', 'zloto', 'trucizna'];
var OpisSwiata = (function () {
    function OpisSwiata() {
    }
    return OpisSwiata;
}());
var swiat = [
    { opis: 'nic', prawdo: 40, rodzaj: [1], sila: 7 },
    { opis: 'oblesny gnom', prawdo: 10, rodzaj: [1], sila: 2 },
    { opis: 'wielki smok', prawdo: 5, rodzaj: [1], sila: 7 },
    { opis: 'straszny troll', prawdo: 10, rodzaj: [1], sila: 3 },
    { opis: 'zlodzieja', prawdo: 1, rodzaj: [2], sila: 1 },
    { opis: 'czarodzieja', prawdo: 6, rodzaj: [2], sila: 1 },
    { opis: 'dobrego duszka', prawdo: 5, rodzaj: [2], sila: 1 },
    { opis: 'zlego ducha', prawdo: 5, rodzaj: [2], sila: 1 },
    { opis: 'miecz', prawdo: 2, rodzaj: [3], sila: 1 },
    { opis: 'zbroje', prawdo: 2, rodzaj: [3], sila: 1 },
    { opis: 'magiczny eliksir', prawdo: 4, rodzaj: [3], sila: 1 },
    { opis: 'sztuke miesa', prawdo: 4, rodzaj: [3], sila: 1 },
    { opis: 'zloto', prawdo: 5, rodzaj: [3], sila: 1 },
    { opis: 'trucizne', prawdo: 3, rodzaj: [3], sila: 1 }
];
var Bohater = (function () {
    function Bohater(element, wytrzymalosc, sila, bagaz, zloto) {
        this.element = element;
        this.wytrzymalosc = wytrzymalosc;
        this.sila = sila;
        this.bagaz = bagaz;
        this.zloto = zloto;
    }
    Bohater.prototype.opiszBohatera = function () {
        // description
        this.element.innerHTML = "Bohater: wytrzymalosc:" + this.wytrzymalosc + " , bagaz: " + this.bagaz + " , zloto: " + this.zloto;
        this.span = document.createElement('span');
        this.element.appendChild(this.span);
    };
    return Bohater;
}());
;
var Zdarzenie = (function () {
    function Zdarzenie(element) {
        this.element = element;
        //this.element.innerHTML += "Zdarzenie: ";
        //this.span = document.createElement('span');
        //this.element.appendChild(this.span);
    }
    Zdarzenie.prototype.spotkajWroga = function (kogo) {
        var losowanie = Math.floor(Math.random() * 14);
        // description
        this.element.innerHTML = "Spotkales: " + swiat[kogo].opis + " , rodzaj: " + swiat[kogo].rodzaj + " , sila: " + swiat[kogo].sila;
        this.span = document.createElement('span');
        this.element.appendChild(this.span);
    };
    Zdarzenie.prototype.getEnemyStrength = function (kogo) {
        return swiat[kogo].sila;
    };
    Zdarzenie.prototype.spotkajNieznajomego = function (kogo) {
        // description
    };
    Zdarzenie.prototype.znajdzPrzedmiot = function (jaki) {
        // description
    };
    Zdarzenie.prototype.describe = function (communicat) {
        var element = document.getElementById('rezultaty');
        element.innerHTML = communicat;
        var span = document.createElement('span');
        element.appendChild(span);
    };
    Zdarzenie.prototype.fight = function (strengthHero, strengthEnemy) {
        this.describe('Walczyles przed chwila!');
        if (strengthEnemy >= (strengthHero + (Math.floor(Math.random() * 6)))) {
            this.describe('Przegrales!');
        }
        else {
            this.describe('Wygrales!');
        }
        generujPrzygode();
    };
    Zdarzenie.prototype.flee = function (strengthHero) {
        if (strengthHero > Math.floor(Math.random() * 6)) {
            this.describe('Udalo Ci sie uciec!');
        }
        else {
            this.describe('Probowales uciekac, ale nie udalo sie. Czeka Cie walka!');
        }
        generujPrzygode();
    };
    Zdarzenie.prototype.talk = function () {
        this.describe('Ile zlota proponujesz za uwolnienie?');
        generujPrzygode();
    };
    Zdarzenie.prototype.setupButtons = function (strengthHero) {
        var _this = this;
        var btnFight = document.getElementById("fight");
        btnFight.addEventListener("click", function (e) { return _this.fight(); });
        var btnFlee = document.getElementById("flee");
        btnFlee.addEventListener("click", function (e) { return _this.flee(strengthHero); });
        var btnTalk = document.getElementById("talk");
        btnTalk.addEventListener("click", function (e) { return _this.talk(); });
    };
    return Zdarzenie;
}());
;
var Przyciski = (function () {
    function Przyciski() {
    }
    return Przyciski;
}());
window.onload = function () {
    var el = document.getElementById('content');
    var greeter = new Greeter(el);
    greeter.start();
    generujPrzygode(true);
};
function generujPrzygode(setupButtons) {
    if (setupButtons === void 0) { setupButtons = false; }
    var tbl = document.getElementById('tablica');
    var hafn = new Hafn(tbl);
    var ekran = document.getElementById('ekran');
    var statystyki = document.getElementById('stat');
    var bohater = new Bohater(statystyki, 5, 5, [5], 5);
    bohater.opiszBohatera();
    var losowanie = Math.floor(Math.random() * 14);
    var zdarzenie = new Zdarzenie(ekran);
    if (setupButtons) {
        zdarzenie.setupButtons(bohater.sila);
    }
    else {
        console.log('Not defined!');
    }
    zdarzenie.spotkajWroga(losowanie);
}
//# sourceMappingURL=app.js.map