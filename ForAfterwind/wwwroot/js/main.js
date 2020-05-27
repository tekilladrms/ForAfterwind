//const menuToggle = document.querySelector('#menuToggle');
//const navItemsToggle = document.querySelector('#navItemsToggle');
const musiciansPhotos = document.getElementsByClassName("musician-photo");
const infoElements = document.getElementsByClassName("info");
const albumCovers = document.getElementsByClassName("album__cover");
const albums = document.getElementsByClassName("album");
const videoAlbums = document.getElementsByClassName("video-album");
const photoAlbums = document.getElementsByClassName("photo-album");
const videos = Array.from(document.querySelectorAll('video'));
const audios = Array.from(document.querySelectorAll('audio'));



//menuToggle.onclick = function () {
//    navItemsToggle.classList.toggle('nav__items-visible');
//}

$(document).ready(function () {
    $(".owl-carousel").owlCarousel({
        loop: true,
        nav: true,

        responsive: {
            0: {
                items: 1

            }
        }
    });

    $(document).ready(function () {
        $(".fancybox").fancybox();
    });

    let playing = true;

    videos.forEach(video => {
        video.addEventListener('play', function () {
            if (playing) {
                videos.forEach(el => {
                    el.pause();
                });
            }
            if (this.paused) {
                playing = false;
                this.play();
            } else {
                playing = true;
            }
        });
    });

    audios.forEach(audio => {
        audio.addEventListener('play', function () {
            if (playing) {
                audios.forEach(el => {
                    el.pause();
                });
            }
            if (this.paused) {
                playing = false;
                this.play();
            } else {
                playing = true;
            }
        });
    });
}
);

// ------------------- Musicians ----------------------

function showInfo(e) {

    let collection;




    if (e.parentNode.classList.contains("musician")) {
        collection = musiciansPhotos;
    }
    //else {
    //    collection = albums;
    //}

    // проверка на уникальность

    for (var i = 0; i < collection.length; i++) {
        if (e == collection[i]) {
            continue;
        }
        collection[i].classList.remove("active");
        collection[i].parentNode.classList.remove("active");

    }

    if (!e.classList.contains("active")) {

        //первое нажатие на элемент

        e.classList.add("active");
        e.parentNode.classList.add("active");
        e.parentNode.classList.add("order-first");
        e.parentNode.classList.add("col-md-10");


        newActiveElement(e, collection);

    }
    else {

        // при повторном нажатии сработает этот код

        e.classList.remove("active");
        e.parentNode.classList.remove("active");
        toDefault(collection);
        return;
    }

}



function toDefault(collection) {
    for (var i = 0; i < collection.length; i++) {
        collection[i].classList.remove("minimize-photo");
        collection[i].parentNode.classList.remove("order-first");
        collection[i].parentNode.classList.remove("col-md-10");
    }
    for (var i = 0; i < infoElements.length; i++) {
        infoElements[i].classList.add("hidden");
    }
}

function newActiveElement(e, collection) {
    for (var i = 0; i < collection.length; i++) {
        if (collection[i] != e) {
            collection[i].classList.add("minimize-photo");
            collection[i].parentNode.classList.remove("order-first");
            collection[i].parentNode.classList.remove("col-md-10");
        }
        else {
            collection[i].classList.remove("minimize-photo");
        }
    }
    displayInfo(infoElements);

}

function displayInfo(collection) {

    for (var i = 0; i < collection.length; i++) {
        if (collection[i].parentNode.classList.contains("active")) {
            collection[i].classList.remove("hidden");

        }
        else {
            collection[i].classList.add("hidden");
        }
    }
}

// --------------------- Audio ---------------------------

function showAlbum(e) {

    let collection;
    let oldClass;
    let newClass;

    if (e.parentNode.classList.contains("video-album")) {
        collection = videoAlbums;
        
    }
    else if (e.parentNode.classList.contains("photo-album")) {
        collection = photoAlbums;
    }
    else {
        collection = albums;
        oldClass = "col-md-3";
        newClass = "col-md";
    }

    for (var i = 0; i < collection.length; i++) {
        if (collection[i] == e.parentNode) {
            continue;
        }
        collection[i].classList.remove("active");
        
    }

    if (!e.parentNode.classList.contains("active")) {
        e.parentNode.classList.add("active");
        switchClass(e.parentNode, oldClass, newClass);
        
        $('#unhiddenInfo').prepend(e.parentNode);
        displayInfo(infoElements);
    }
    else {
        e.parentNode.classList.remove("active");
        $("#hiddenInfo").append(e.parentNode);
        displayInfo(infoElements);
    }

    move(collection, oldClass, newClass);
}



function move(collection, oldClass, newClass) {

    for (var i = 0; i < collection.length; i++) {
        if (collection[i].classList.contains("active")) {
            switchClass(collection[i], oldClass, newClass);
            $('#unhiddenInfo').prepend(collection[i]);
            displayInfo(infoElements);
        }
        else {
            $("#hiddenInfo").append(collection[i]);
            switchClass(collection[i], newClass, oldClass);
        }
    }
}

function switchClass(element, oldClass, newClass) {
    element.classList.remove(oldClass);
    element.classList.add(newClass);
}




