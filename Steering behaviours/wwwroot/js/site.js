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

function MoveHunter(){
    $.ajax({
     url: '/Game/MoveHunter',
     type: 'POST',
     data: { "X": $(this).css("left"), 
            "Y": $(this).css("top")},
     success: function(response){
      alert(response);
     }
    });
}
   
$(document).ready(function(){
setInterval(fetchdata,5000);
});

var mouseX = 0, mouseY = 0, limitX = 1200 - 310, limitY = 800;

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
    // change 12 to alter damping higher is slower
    xp += (mouseX - xp) / 12;
    yp += (mouseY - yp) / 12;
    follower.css({ left: xp, top: yp });

}, 30);

function getPositions() {
    $.ajax({
        type: "GET",
        url: "/Game/GetMembersPositions",
        success: function (response) {

            let helper = document.getElementById("helper");
            helper.insertAdjacentHTML('afterbegin', response);
        },
        failure: function (response) {
            alert(response.responseText);
        },
        error: function (response) {
            if (response.status == 400)
                alert("Impossible!");
            else
                alert(response.status);
        }
    })
}