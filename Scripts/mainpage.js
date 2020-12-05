$(document).ready(function () {

    $("#carprice").slider({
        min: 0,
        max: 900000,
        range:true,
        change: function (event, ui) {
            $("#lprice").text("Price min:" + ui.values[0] + " ,max:" + ui.values[1]);
            $("#MinPrice").val(ui.values[0]);
            $("#MaxPrice").val(ui.values[1]);
        }
    });

    $("#filterform").submit(function (event) {
        event.preventDefault();
        $.ajax({
            async: true,
            data: $(this).serialize(),
            dataType: "json",
            url:"Home/Filter",
            type: "POST",
            success: function (response) {
                console.log(response);
            }
        });
    });
});