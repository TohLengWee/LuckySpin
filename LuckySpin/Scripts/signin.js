$(document).ready(function () {
    $("#formSignin").click(submitForm);
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

    var formData = {
        Username: $("#inputUsername").val(),
        Password: $("#inputPassword").val(),
        __RequestVerificationToken : $('input[name="__RequestVerificationToken"]').val()
    };

    $.ajax({
        method: "POST",
        url: "/Home/Login",
        data: formData
    });
}

function validateUsername() {
    var username = $("#inputUsername").val();
    return username.length > 0;
}

function validatePassword() {
    var password = $("#inputPassword").val();
    return password.length > 0;
}