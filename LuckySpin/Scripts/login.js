$(document).ready(function () {
    $("#loginBtn").click(submitForm);
    $("#formSignin").on("keydown", function (e) {
        if (e && e.keyCode === 13) {
            submitForm();
        }
    });
    handleRememberMe();
});

function submitForm() {
    if (!validateUsername()) {
        alert("Tidak sah username.");
        return;
    }

    if (!validatePassword()) {
        alert("Tidak sah password.");
        return;
    }

    rememberMe();

    var formData = {
        Username: $("#inputUsername").val(),
        Password: $("#inputPassword").val(),
        __RequestVerificationToken : $('input[name="__RequestVerificationToken"]').val()
    };

    $.ajax({
        method: "POST",
        url: "/Login",
        data: formData,
        success: function (response) {
            if (response.Success) {
                window.location.href = response.Url;
            } else {
                alert(response.Message);
            }
        }, error: function() {
            alert("Login tak sah!");
        }

    });
}

function validateUsername() {
    var username = $("#inputUsername").val();
    return username.length > 0;
}

function validatePassword() {
    var password = $("#inputPassword").val();
    return password.length > 7;
}

function handleRememberMe() {
    var remember = Cookies.get('remember');
    if (remember == "true") {
        $("#rememberMe").prop("checked", true);
        var username = Cookies.get('username');
        $("#inputUsername").val(username);
    }
}

function rememberMe() {
    if (!$("#rememberMe").prop("checked")) {
        Cookies.remove("remember");
        Cookies.remove("username");
        return;
    }
    var username = $("#inputUsername").val();
    Cookies.set('remember', "true", { expires: 7 });
    Cookies.set('username', username, { expires: 7 });
}