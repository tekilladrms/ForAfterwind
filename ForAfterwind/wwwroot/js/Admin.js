

$(document).ready(function () {

    $("#skills").submit();
    $("#links").submit();
    $("#photos").submit();
    $("#songs").submit();
    $("#videos").submit();

});

function removeSkillsFormEvents() {
    $("#skills").submit();
    $("#addskill").trigger("reset");
}

function removeLinksFormEvents() {
    $("#links").submit();
    $("#addlink").trigger("reset");
}
function removePhotosFormEvents() {
    $("#photos").submit();
    $("#addphotos").trigger("reset");
}
function removeSongsFormEvents() {
    $("#songs").submit();
    $("#addsongs").trigger("reset");
}
function removeVideosFormEvents() {
    $("#videos").submit();
    $("#addvideo").trigger("reset");
}
