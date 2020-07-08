

$(document).ready(function () {

    $("#skills").submit();
    $("#links").submit();
    $("#photos").submit();
    $("#songs").submit();
    $("#videos").submit();

    $('textarea#tiny').tinymce({
        height: 700,
        menubar: false,
        plugins: [
            'advlist autolink lists link image charmap print preview anchor',
            'searchreplace visualblocks code fullscreen',
            'insertdatetime media table paste code help wordcount'
        ],
        toolbar: 'undo redo | formatselect | bold italic backcolor | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | removeformat | help'
    });

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
