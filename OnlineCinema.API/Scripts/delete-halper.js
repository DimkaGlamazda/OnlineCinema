$(function () {
    var modal = $("#delete-modal");
    var trigger = $("[data-action=delete]");
    var delteAction = $("#deleteAction");
    var deleteUrl = null;
    var message;

    if (message = $("[name=deleteError]").val()) {
        updateDeleteModal(2, message);
        modal.modal("show");
    }
    else if (message = $("[name=deleteSuccess]").val()) {
        updateDeleteModal(3, $("[name=deleteSuccess]").val());
        modal.modal("show");
    }

    trigger.on("click", function (e) {
        e.preventDefault();
        deleteUrl = $(this).attr("href");

        modal.modal("show");

        updateDeleteModal(1, $("[name=deleteWarning]").val());
        modal.modal("show");
    });

    delteAction.on("click", function () {
        location.href = deleteUrl;
    });

    function updateDeleteModal(type, message)
    {
        var contentBody = $("#deleteContentBody");
        var delteAction = $("#deleteAction");

        switch (type) {
            case 1:
                contentBody.addClass("alert alert-warning").html(message);
                delteAction.css("display", "inline");
                break;
            case 2:
                contentBody.addClass("alert alert-danger").html(message);
                delteAction.css("display", "none");
                break;
            case 3:
                contentBody.addClass("alert alert-success").html(message);
                delteAction.css("display", "none");
                break;
        }
    }

});