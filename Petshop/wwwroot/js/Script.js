const uri = "/api/ProductShop/";
const urii = "/api/ShoppingCart/";
const uriii = "js/bootstrap.js"
let items = null;

function load() {
    loadProducts();
    loadBaskets();
}

function loadProducts() {
    var i, j, x = "";
    
    var request = new XMLHttpRequest();
    request.open("GET", uri, false);
    request.onload = function () {
        items = JSON.parse(request.responseText);
        for (i in items) {
            var scr = items[i].photo;
            x += "<h5><a>" + items[i].name + "<img src=' " + scr + "' marigin = '100' max-width = '100%' height='184'>"; /*+ items[i].photo;*/
            x += "</a><button type='button' class='button' onclick='createBasket(" + items[i].id + ");'>Добавить</button></h5>";
        }
        document.getElementById("productsDiv").innerHTML = x;
    };
    request.send();
}
function loadBaskets() {
    var i, j, x = "";
    var request = new XMLHttpRequest();
    request.open("GET", urii, false);
    request.onload = function () {
        items = JSON.parse(request.responseText);
        for (i in items) {
            x += "<h5>" + items[i].productName + ": <a>" + items[i].number + "шт. </a>";
            x += "<button type='button' class='button' onclick='deleteBasket(" + items[i].id + ");'>Удалить</button>";
            x += "<button type='button' class='button' onclick='plus(" + items[i].id + ");'>+</button>";
            x += "<button type='button' class='button' onclick='minus(" + items[i].id + ");'>-</button></h5>";
        }
        document.getElementById("basketDiv").innerHTML = x;
    };
    request.send();
}
function createBasket(id) {
    var request = new XMLHttpRequest();
    var url = urii + id;
    request.open("POST", url, false);
    request.setRequestHeader("Content-Type", "application/json;charset=UTF-8");
    request.onload = function () {
        loadBaskets();
    };
    request.send();
}
function deleteBasket(id) {
    var request = new XMLHttpRequest();
    var url = urii + id;
    request.open("DELETE", url, false);
    request.onload = function ()
    {
        loadBaskets();
    };
    request.send();
}
function plus(id) {
    var request = new XMLHttpRequest();
    request.open("PUT", urii + id + "/" + "1");
    request.onload = function ()
    {
        loadBaskets();
    };
    request.send();
}
function minus(id) {
    var request = new XMLHttpRequest();
    request.open("PUT", urii + id + "/" + "-1");
    request.onload = function () {
        loadBaskets();
    };
    request.send();
}