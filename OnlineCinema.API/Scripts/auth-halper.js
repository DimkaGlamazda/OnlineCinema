$(function () {

    var modal = $('#loginModal');

    $('#login').on('click', function (e) {
        e.preventDefault();

        var username = $.trim($('[name=email]').val()); // gldmvl@gmail.com
        var password = $.trim($('[name=password]').val()); // Q1234-4321
        console.log(username);
        console.log(password);
        $.ajax({
            method: 'POST',
            url: "/Token",
            data: {
                grant_type: 'password',
                username: username,
                password: password
            },
            beforeSend: function () {
                modal.modal('hide');
            },
            success: function (data) {
                location.reload();
            },
            complete: function (jqXHR) {
                if (jqXHR.status === 400) {
                    alert(jqXHR.responseJSON.error_description);
                    modal.modal("show");
                }
            }
        });
    });
});