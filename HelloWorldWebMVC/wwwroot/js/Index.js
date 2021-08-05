$(document).ready(function () {
    // see https://api.jquery.com/click/
    $("#clearButton").click(function () {
        $("#nameField").val("");
        $('#createButton').prop('disabled', true);
    });

    $('#nameField').on('input change', function () {
        if ($(this).val() != '') {
            $('#createButton').prop('disabled', false);
        } else {
            $('#createButton').prop('disabled', true);
        }
    });

    $("#createButton").click(function () {
        var newcomerName = $("#nameField").val();

        // Remember string interpolation
        
        $.ajax({
            method: "POST",
            url: "/Home/AddTeamMember",
            data: { "name": newcomerName },
            success: function (result) 
            {
                $("#team-list").append(
                    `<li class="member">
                        <span class="name">${newcomerName}</span>
                        <span class="delete fa fa-remove"></span>
                        <span class="edit fa fa-pencil"></span>
                    </li>`
                );
                $("#nameField").val("");
                $('#createButton').prop('disabled', true);
            }
        })

     
    })
});