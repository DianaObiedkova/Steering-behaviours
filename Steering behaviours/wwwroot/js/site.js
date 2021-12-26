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

function TakeShot(){
    $.ajax({
     url: '/Game/TakeShot',
     type: 'POST',
     data: { "X": $(this).css("left"), 
            "Y": $(this).css("top")},
     success: function(response){
      alert(response);
     }
    });
}
   
function UpdateField(){
    $.ajax({
     url: '/Game/UpdateField',
     type: 'POST',
     //todo
     data: { },
     success: function(response){
      alert(response);
     }
    });
}
function GetPositions(){
    $.ajax({
     url: '/Game/GetMembersPositions',
     type: 'GET',
     success: function(response){
      //todo
      alert(response);
     }
    });
}

$(document).ready(function(){
    setInterval(UpdateField,5000);
    setInterval(GetPositions,5000);
});

//impement onclick triggering TakeShot
//implement (?) triggering MoveHunter (using creatures.js)
