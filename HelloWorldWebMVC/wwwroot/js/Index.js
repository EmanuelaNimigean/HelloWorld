﻿$(document).ready(function () {
    // see https://api.jquery.com/click/
    $("#createButton").click(function () {
        var newcomerName = $("#nameField").val();

        // Remember string interpolation
        $("#team-list").append(`<li>${newcomerName}</li>`);

        $("#nameField").val("");
    })
});