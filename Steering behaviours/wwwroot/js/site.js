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