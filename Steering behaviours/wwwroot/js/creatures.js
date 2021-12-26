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
    // change 12 to alter damping higher is slower
    xp += (mouseX - xp) / 24;
    yp += (mouseY - yp) / 24;
    follower.css({ left: xp, top: yp });

}, 30);