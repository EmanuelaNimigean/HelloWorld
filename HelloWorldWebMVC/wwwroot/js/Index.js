'use strict';
$(document).ready(function () {
    // see https://api.jquery.com/click/
    var connection = new signalR.HubConnectionBuilder().withUrl("/messagehub").build();

    deleteMember(); editMember();

    connection.on("NewTeamMemberAdded", createNewcomer);
    connection.on("TeamMemberDeleted", deleteMmb);
    connection.on("TeamMemberEdit", editMmb);

    connection.start().then(function () {
        console.log("SignalR started")
    }).catch(function (err) {
        return console.error(err.toString());
    });
    //disable createButton when the field is empty
    $('#nameField').on('input change', function () {
        if ($(this).val() != '') {
            $('#createButton').prop('disabled', false);
        } else {
            $('#createButton').prop('disabled', true);
        }
    });
    //clearButton
    $("#clearButton").click(function () {
        $("#nameField").val("");
        $('#createButton').prop('disabled', true);
    });
    //add team member button
    $("#createButton").click(function () {
        var newcomerName = $("#nameField").val();
        $.ajax({
            method: "POST",
            url: "/Home/AddTeamMember",
            data: { "name": newcomerName },
            success: function (result) {
                var ind = result;

                $("#team-list").append(
                    `<li class="member" data-member-id="${ind}">
                        <span class="memberName">${newcomerName}</span>
                        <span class="delete fa fa-remove" ></span></>
                        <span class="edit fa fa-pencil" onClick="editMember()"></span>
                    </li>`
                );

                $("#nameField").val("");
                $('#createButton').prop('disabled', true);
                deleteMember();
                editMember();
            },
            error: function (err) {
                console.log(err);
            }
        })
    });
    //edit team member by pressing submit button in modal view
    $("#editTeamMember").on("click", "#submit", function () {
        var id = $("#editTeamMember").attr('data-member-id');
        var newName = $("#memberName").val();
        console.log('submit changes to server');
        $.ajax({
            url: "/Home/EditTeamMember",
            method: "PUT",
            data: {
                "id": id,
                "name": newName
            },
            success: function (result) {
                console.log(`edited the member: ${id}`);
                location.reload();
            }
        })
    })
    //cancel the edit member
    $("#editTeamMember").on("click", "#cancel", function () {
        console.log('cancel changes');
    })
});
//delete button member
function deleteMember() {
    $(".delete").off("click").click(function () {
        var id = $(this).parent().attr("data-member-id");
        $.ajax({
            url: "/Home/DeleteTeamMember",
            method: "DELETE",
            data: {
                "id": id
            },
            success: function (result) {
                console.log("deleted member:" + id);
                $(this).parent().remove();
                location.reload();
            }
        })
    })
}
function editMember() {
    //open the Modal View
    $("#team-list").off("click").on("click", ".edit", function () {
        var targetMemberTag = $(this).closest('li');
        var id = targetMemberTag.attr('data-member-id');
        var currentName = targetMemberTag.find(".memberName").text().trim();
        $('#editTeamMember').attr("data-member-id", id);
        $('#memberName').val(currentName);
        $('#editTeamMember').modal('show');
    })
}
function createNewcomer(name, id) {
    // Remember string interpolation
    $("#team-list").append(`<li class="member" data-member-id="${id}">
                        <span class="memberName">${name}</span>
                        <span class="delete fa fa-remove"></span>
                        <span class="edit fa fa-pencil"></span>
                             </li>`);
    deleteMember(); editMember();
}

var deleteMmb = (id) => {
    $(`li[data-member-id=${id}]`).remove();
}

var editMmb = (name, id) => {
    $(`li[data-member-id=${id}]`).find(".memberName").text(name);
}

$("#clear").click(function () {
    $("#newcomer").val("");
})