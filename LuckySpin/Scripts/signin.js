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
    return password.length > 0;
}
