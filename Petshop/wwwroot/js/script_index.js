////let result = null;
////const uri = "/api/Category/";

////function load() {
////    var i, x = "";
////    var request = new XMLHttpRequest();
////    request.open("GET", uri, false);
////    request.onload = function () {
////        result = JSON.parse(request.responseText);
////        for (i in result) {
////            x += "<hr>";
////            x += "<form>";
////            x += "<input class='form-control' type='text' value='" + result[i].name + "'id='update" + result[i].categoryId + "'/>";
////            x += "<button type='button' style='margin: 8px;' class='btn btn-sm btn-warning' onclick='Update(" + result[i].categoryId + ");'>Обновить</button>";
////            x += "<button type='button' style='margin: 8px;' class='btn btn-sm btn-danger' onclick='Delete(" + result[i].categoryId + ");'>Удалить</button>";
////            x += "</form>";
////        }
////        document.getElementById("Categories").innerHTML = x;
////    };
////    request.send();
////}

////function Delete(id) {
////    var request = new XMLHttpRequest();
////    var url = uri + id;
////    request.open("DELETE", url, false);
////    request.onload = function () {
////        load();
////    };
////    request.send();
////}

////function Update(id) {
////    var name = document.getElementById("update" + id.toString()).value;
////    var request = new XMLHttpRequest();
////    var url = uri + id;
////    request.open("PUT", url, false);
////    request.setRequestHeader("Content-Type", "application/json;charset=UTF-8");
////    request.onload = function () {
////        load();
////    };
////    request.send(JSON.stringify({ Name: name }));
////}

////function Create() {
////    var name = document.getElementById("create").value;
////    var request = new XMLHttpRequest();
////    request.open("POST", uri);
////    request.setRequestHeader("Content-Type", "application/json;charset=UTF-8");
////    request.onload = function () {
////        load();
////    };
////    request.send(JSON.stringify({ Name: name }));
////    document.getElementById("create").value = "";
////}