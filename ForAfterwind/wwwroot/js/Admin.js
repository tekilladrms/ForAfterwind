

$(document).ready(function () {

    $("#skills").submit();
    $("#links").submit();
    $("#photos").submit();
    $("#songs").submit();
    $("#videos").submit();
    $("#albumstages").submit();
    $("#cities").submit();
    $("#markers").submit();



    $('textarea#tiny').tinymce({
        height: 200,
        menubar: false,
        plugins: [
            'advlist autolink lists link image charmap print preview anchor',
            'searchreplace visualblocks code fullscreen',
            'insertdatetime media table paste code help wordcount'
        ],
        toolbar: 'undo redo | formatselect | bold italic backcolor | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | removeformat | help'
    });

});




$(function () {
    $('#IsOnMap').on('change', function () {
        if ($('#IsOnMap').prop('checked')) {
            $('#marker').removeClass('hidden');
        } else {
            $('#marker').addClass('hidden');
        }
    });

    $("#map").click(function (event) {
        event = event || window.Event;
        
        $("#top").val(PixelsToPercents(event.offsetY, $("#map").height()).toFixed());
        $("#left").val(PixelsToPercents(event.offsetX, $("#map").width()).toFixed());

    });

    $("#map").on("click", ".marker", function () {
        if ($(this).children().last().hasClass("hidden")) {
            $(this).children().removeClass("hidden");
            
        }
        else {
            $(this).children().addClass("hidden");
        }
        
        $(".pointer").removeClass("hidden");
    });

   

});



function onDragOver(event) {
    event.preventDefault();
}



function PixelsToPercents(value, parentValue) {
    return value / (parentValue / 100);
}

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
function removeAlbumStageFormEvents() {
    $("#albumstages").submit();
    $("#addlbumstage").trigger("reset");
}
function removeCitiesFormEvents() {
    $("#cities").submit();
    $("#markers").submit();
    $("#addcity").trigger("reset");


}


