const uri = "api/Account/Register";
function registration() {
    var email = document.getElementById("email").value;
    var password = document.getElementById("password").value;
    var passwordConfirm = document.getElementById("password_confirm").value;
    let request = new XMLHttpRequest();
    request.open("POST", uri, false);
    request.setRequestHeader("Accepts", "application/json;charset=UTF-8");
    request.setRequestHeader("Content-Type", "application/json;charset=UTF-8");
    request.onload = function () {
        ParseResponse(this);
    };
    request.send(JSON.stringify({
        Email: email,
        Password: password,
        PasswordConfirm: passwordConfirm
    }));
}
// Разбор ответа
function ParseResponse(e) {
    var x = "";
    let response = JSON.parse(e.responseText);
    x += "<p>" + response.message + "</p>";
    if (response.error != undefined && response.error.length > 0) {
        x += "<ul>";
        for (var i = 0; i < response.error.length; i++) {
            x += "<li>" + response.error[i] + "</li>";
        }
        x += "</ul>";
        document.getElementById("errors").innerHTML = x;
    }
    else {
        document.getElementById("errors").innerHTML = "<p>Аккаунт зарегистрирован</p>";
    }
    document.getElementById("email").value = "";
    document.getElementById("password").value = "";
    document.getElementById("password_confirm").value = "";
}