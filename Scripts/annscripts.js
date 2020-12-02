$(document).ready(function () {
    $("#carbrands").children().eq(0).attr("selected","selected");

    $("#carbrands").change(function (e) {
        var brand = $("#carbrands").val();
        $.ajax({
            async: true,
            contentType: "application/json",
            data: { brandname: brand },
            dataType:"json",
            url: "GetModels",
            type: "GET",
            success: function (response) {
                $("#carmodels").children().remove();
                var opt = "<option></option>";
                for (var i = 0; i < response.length; i++) {
                    $("#carmodels").append(opt);
                    $("#carmodels").children().eq(i).text(response[i].ModelName);
                }
            }
        });
    });
});