$(document).ready(function () {

    $(".login").click(function (e) {
        e.stopPropagation();
    });
    
    $(".user").on("click", function (e) {
        $(this).find(".login").trigger("click");
    });;

});

