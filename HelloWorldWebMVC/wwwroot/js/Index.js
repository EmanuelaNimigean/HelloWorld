﻿
$(document).ready(function () {
    // see https://api.jquery.com/click/

    //clearButton
    $("#clearButton").click(function () {
        $("#nameField").val("");
        $('#createButton').prop('disabled', true);
    });

    //disable createButton
    $('#nameField').on('input change', function () {
        if ($(this).val() != '') {
            $('#createButton').prop('disabled', false);
        } else {
            $('#createButton').prop('disabled', true);
        }
    });


    //create
    $("#createButton").click(function () {
        var newcomerName = $("#nameField").val();

        $.ajax({
            method: "POST",
            url: "/Home/AddTeamMember",
            data: { "name": newcomerName },
            success: function (result) {
                var ind = result;
                //console.log(result);
                $("#team-list").append(
                    `<li class="member">
                        <span class="name">${newcomerName}</span>
                        <span class="delete fa fa-remove" onClick="deleteMember(${ind})"></span>
                        <span class="edit fa fa-pencil"></span>
                    </li>`
                );
                $("#nameField").val("");
                $('#createButton').prop('disabled', true);
            },
            error: function (err) {
                console.log(err);
            }
        })


    });

    
    
});

function deleteMember(index) {

    $.ajax({
        url: "/Home/DeleteTeamMember",
        method: "DELETE",
        data: {
            "index": index
        },
        success: function (result) {
             console.log("deleete:"+ index);
            location.reload();
        }
    })
};
