
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
                        <span class="edit fa fa-pencil"  ></span >
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

    $("#editTeamMember").on("click", "#submit", function () {
        //var id = 4;
        //var newName = "newww";
        var id = $("#editTeamMember").attr('data-member-id');
        var newName = $("#memberName").val();
        console.log('submit changes to server');
        $.ajax({
        url: "/Home/EditTeamMember",
        method: "POST",
        data: {
            "id": id,
            "name": newName
        },
        success: function (result) {
            console.log(`edit: ${id}`);
            location.reload();
        }
    })
    })

    $("#editTeamMember").on("click", "#cancel", function () {
        console.log('cancel changes');
    })


    $("#team-list").on("click", ".edit", function () {
        var targetMemberTag = $(this).closest('li');
        var id = targetMemberTag.attr('data-member-id');
        var currentName = targetMemberTag.find(".memberName").text();
        $('#editTeamMember').attr("data-member-id", id);
        $('#memberName').val(currentName);
        $('#editTeamMember').modal('show');

    })
    
});

function deleteMember(id) {

    $.ajax({
        url: "/Home/DeleteTeamMember",
        method: "DELETE",
        data: {
            "id": id
        },
        success: function (result) {
             console.log("deleete:"+ id);
            location.reload();
        }
    })
};

//function editMember(index, newName) {

//    $.ajax({
//        url: "/Home/EditTeamMember",
//        method: "PUT",
//        data: {
//            "index": index,
//            "name": newName
//        },
//        success: function (result) {
//            console.log("edit:" + index);
//            location.reload();
//        }
//    })
//};
