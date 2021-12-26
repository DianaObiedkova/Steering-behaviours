// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//let circle = document.getElementById('circle');
//const onMouseMove = (e) => {
//    circle.style.left = e.pageX - 400  + 'px';
//    circle.style.top = e.pageY - 120 + 'px';
//}
//document.addEventListener('mousemove', onMouseMove);

//$(document).on("click mousemove", ".box", function (e) {
//    var x = e.clientX;
//    var y = e.clientY;
//    var newposX = x - 60;
//    var newposY = y - 60; $(".circle").css("transform", "translate3d(" + newposX + "px," + newposY + "px,0px)");
//});

var mouseX = 0, mouseY = 0, limitX = 750, limitY = 500;

$(window).mousemove(function (e) {
    var offset = $('.field').offset();
    mouseX = Math.min(e.pageX - offset.left, limitX);
    mouseY = Math.min(e.pageY - offset.top, limitY);
    if (mouseX < 0) mouseX = 0;
    if (mouseY < 0) mouseY = 0;
});

// cache the selector
var follower = $("#circle");
var xp = 0, yp = 0;
var loop = setInterval(function () {
    // change 24 to alter damping higher is slower
    xp += (mouseX - xp) / 24;
    yp += (mouseY - yp) / 24;
    follower.css({ left: xp, top: yp });

}, 30);