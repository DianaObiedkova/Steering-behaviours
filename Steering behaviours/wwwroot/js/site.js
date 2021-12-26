var hunter = document.getElementById("circle");
var field = document.querySelector(".field");

function createBullet(bullet) {
    bullet.classList.add("bullet");
    bullet.style.left = hunter.offsetLeft + 'px';
    bullet.style.top = hunter.offsetTop + 'px';
    hunter.after(bullet);
}


//$(document).ready(function(){
//    //setInterval(UpdateField,5000);
//    setInterval(GetPositions, 5000);
//    setInterval(MoveHunter, 1000);
//});

field.addEventListener("click", getClickPosition, false);

//field.onclick = function onclickRestartButton(e) {
//    getClickPosition(e);
//    removeAllBullets();
//};

function removeAllBullets() {
    var bullets = document.querySelectorAll(".bullet");
    bullets.forEach((el) => { el.remove(); });
}

function getClickPosition(e) {

    const bullet = document.createElement("div");
    createBullet(bullet);

    var parentPosition = getPosition(e.currentTarget);
    var xPosition = e.clientX - parentPosition.x - (bullet.clientWidth / 2);
    var yPosition = e.clientY - parentPosition.y - (bullet.clientHeight / 2);

    bullet.style.left = xPosition + "px";
    bullet.style.top = yPosition + "px";

    //removeAllBullets();
}

// Helper function to get an element's exact position
function getPosition(el) {
    var xPos = 0;
    var yPos = 0;

    while (el) {
        if (el.tagName == "BODY") {
            // deal with browser quirks with body/window/document and page scroll
            var xScroll = el.scrollLeft || document.documentElement.scrollLeft;
            var yScroll = el.scrollTop || document.documentElement.scrollTop;

            xPos += (el.offsetLeft - xScroll + el.clientLeft);
            yPos += (el.offsetTop - yScroll + el.clientTop);
        } else {
            // for all other non-BODY elements
            xPos += (el.offsetLeft - el.scrollLeft + el.clientLeft);
            yPos += (el.offsetTop - el.scrollTop + el.clientTop);
        }

        el = el.offsetParent;
    }
    return {
        x: xPos,
        y: yPos
    };


}