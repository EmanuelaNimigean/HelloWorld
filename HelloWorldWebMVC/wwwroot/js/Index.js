$(document).ready(function () {
    // see https://api.jquery.com/click/
    $("#createButton").click(function () {
        var newcomerName = $("#nameField").val();

        // Remember string interpolation
        
        $.ajax({
            method: "POST",
            url: "https://localhost:44370/Home/AddTeamMember",
            data: { "name": newcomerName },
            success: function (result) =>
            {
                $("#TeamMembers").append(`<li>${newcomerName}</li>`),
                $("#nameField").val("")
            }
        })

        $("#nameField").val("");
    })
});