var hunter = document.getElementById("circle");
var field = document.querySelector(".field");
//addListeners();

function createBullet(bullet) {
    bullet.classList.add("bullet");
    bullet.style.left = hunter.offsetLeft + 'px';
    bullet.style.top = hunter.offsetTop + 'px';
    hunter.after(bullet);
}


$(document).ready(function(){
    //setInterval(UpdateField,5000);
    setInterval(GetPositions, 50);
    setInterval(MoveHunter, 50);
});

field.addEventListener("click", getClickPosition, false);

//function addListeners() {
//    var rabbits = document.querySelectorAll(".rabbit");
//    var wolves = document.querySelectorAll(".wolf");
//    var does = document.querySelectorAll(".doe");

//    rabbits.forEach((el) => el.addEventListener("click", getClickPosition, false));
//    wolves.forEach((el) => el.addEventListener("click", getClickPosition, false));
//    does.forEach((el) => el.addEventListener("click", getClickPosition, false));
//}

//field.onclick = function onclickField(e) {
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

    TakeShot(bullet, xPosition, yPosition);
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

function updateBullets(bullets) {
    let num = document.getElementById("num");
    num.innerHTML = bullets;
}