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

    //Горизонтальная прокрутка
    (function () {
        function scrollHorizontally(e) {
            e = window.event || e;
            var delta = Math.max(-1, Math.min(1, (e.wheelDelta || -e.detail)));
            document.getElementById('hiddenInfo').scrollLeft -= (delta * 60); // Multiplied by 60
            e.preventDefault();
        }
        if (document.getElementById('hiddenInfo').addEventListener) {
            // IE9, Chrome, Safari, Opera
            document.getElementById('hiddenInfo').addEventListener("mousewheel", scrollHorizontally, false);
            // Firefox
            document.getElementById('hiddenInfo').addEventListener("DOMMouseScroll", scrollHorizontally, false);
        } else {
            // IE 6/7/8
            document.getElementById('hiddenInfo').attachEvent("onmousewheel", scrollHorizontally);
        }
    })();
}
);

//HomeController
//Index
//Progress bar

document.addEventListener("DOMContentLoaded", function () {

    var circleProgress = (function (selector) {
        var wrapper = document.querySelectorAll(selector);
        Array.prototype.forEach.call(wrapper, function (wrapper, i) {
            var wrapperWidth,
                wrapperHeight,
                percent,
                innerHTML,
                context,
                lineWidth,
                centerX,
                centerY,
                radius,
                newPercent,
                speed,
                from,
                to,
                duration,
                start,
                strokeStyle,
                text;

            var getValues = function () {
                wrapperWidth = parseInt(window.getComputedStyle(wrapper).width);
                wrapperHeight = wrapperWidth;
                percent = wrapper.getAttribute('data-cp-percentage');
                innerHTML = '<span class="percentage"><strong>' + percent + '</strong> %</span><canvas class="circleProgressCanvas" width="' + (wrapperWidth * 2) + '" height="' + wrapperHeight * 2 + '"></canvas>';
                wrapper.innerHTML = innerHTML;
                text = wrapper.querySelector(".percentage");
                canvas = wrapper.querySelector(".circleProgressCanvas");
                wrapper.style.height = canvas.style.width = canvas.style.height = wrapperWidth + "px";
                context = canvas.getContext('2d');
                centerX = canvas.width / 2;
                centerY = canvas.height / 2;
                newPercent = 0;
                speed = 1;
                from = 0;
                to = percent;
                duration = 3000;
                lineWidth = 40;
                radius = canvas.width / 2 - lineWidth;
                strokeStyle = wrapper.getAttribute('data-cp-color');
                start = new Date().getTime();
            };

            function animate() {
                requestAnimationFrame(animate);
                var time = new Date().getTime() - start;
                if (time <= duration) {
                    var x = easeInOutQuart(time, from, to - from, duration);
                    newPercent = x;
                    text.innerHTML = Math.round(newPercent) + " %";
                    drawArc();
                }
            }

            function drawArc() {
                var circleStart = 1.5 * Math.PI;
                var circleEnd = circleStart + (newPercent / 50) * Math.PI;
                context.clearRect(0, 0, canvas.width, canvas.height);
                context.beginPath();
                context.arc(centerX, centerY, radius, circleStart, 4 * Math.PI, false);
                context.lineWidth = lineWidth;
                context.strokeStyle = "#ddd";
                context.stroke();
                context.beginPath();
                context.arc(centerX, centerY, radius, circleStart, circleEnd, false);
                context.lineWidth = lineWidth;
                context.strokeStyle = strokeStyle;
                context.stroke();

            }
            var update = function () {
                getValues();
                animate();
            }
            update();

            var resizeTimer;
            window.addEventListener("resize", function () {
                clearTimeout(resizeTimer);
                resizeTimer = setTimeout(function () {
                    clearTimeout(resizeTimer);
                    start = new Date().getTime();
                    update();
                }, 250);
            });
        });

        
        function easeInOutQuart(t, b, c, d) {
            if ((t /= d / 2) < 1) return c / 2 * t * t * t * t + b;
            return -c / 2 * ((t -= 2) * t * t * t - 2) + b;
        }

    });

    circleProgress('.counter');

    
    function getRandom(min, max) {
        return Math.random() * (max - min) + min;
    }
});

// ------------------- Musicians ----------------------

function showInfo(e) {

    let collection;


    if (e.parentNode.classList.contains("musician")) {
        collection = musiciansPhotos;
    }
    

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

function showInfoMobile(e) {

}

// --------------------- Audio ---------------------------

function showAlbum(e) {

    let collection;
    let oldClassCollection;
    let newClassCollection;
    let oldClass;
    let newClass;

    if (e.parentNode.classList.contains("video-album")) {
        collection = videoAlbums;
        oldClassCollection = ["col-md-3", "col-sm-6", "col-6"];
        newClassCollection = ["col-md", "col-sm", "col"];
    }
    else if (e.parentNode.classList.contains("photo-album")) {
        collection = photoAlbums;
        oldClassCollection = ["col-md-3", "col-sm-6", "col-6"];
        newClassCollection = ["col-md", "col-sm", "col"];
    }
    else {
        collection = albums;
        
        oldClassCollection = ["col-md-3", "col-sm-6", "col-6"];
        newClassCollection = ["col-md", "col-sm", "col"];
    }

    // проверка на то, содержит ли еще какой-нибудь элемент класс active
    for (var i = 0; i < collection.length; i++) {
        if (collection[i] == e.parentNode) {
            continue;
        }
        collection[i].classList.remove("active");
        
    }

    // первое нажатие
    if (!e.parentNode.classList.contains("active")) {
        e.parentNode.classList.add("active");
        switchClass(e.parentNode, oldClassCollection, newClassCollection);

        $('#hiddenInfo').removeClass("row");
        
        $('#unhiddenInfo').prepend(e.parentNode);
        displayInfo(infoElements);
    }
    // повторное нажатие
    else {
        e.parentNode.classList.remove("active");
        $("#hiddenInfo").append(e.parentNode);
        $('#hiddenInfo').addClass("row");
        displayInfo(infoElements);
    }

    move(collection, oldClassCollection, newClassCollection);
}



function move(collection, oldClassCollection, newClassCollection) {

    for (var i = 0; i < collection.length; i++) {
        if (collection[i].classList.contains("active")) {
            switchClass(collection[i], oldClassCollection, newClassCollection);
            $('#unhiddenInfo').prepend(collection[i]);
            
            displayInfo(infoElements);
        }
        else {
            $("#hiddenInfo").append(collection[i]);
            switchClass(collection[i], newClassCollection, oldClassCollection);
            
        }
    }
}

function switchClass(element, oldClassCollection, newClassCollection) {
    for (var i = 0; i < oldClassCollection.length; i++) {
        element.classList.remove(oldClassCollection[i])
        element.classList.add(newClassCollection[i]);
    }
    
}



// Mobile menu

function toggleMenu() {
    if (document.getElementById("mobileMenu").classList.contains("hidden")) {
        document.getElementById("mobileMenu").classList.remove("hidden");
    }
    else {
        document.getElementById("mobileMenu").classList.add("hidden");
    }
    
}



