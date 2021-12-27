
function MoveHunter() {
    $.ajax({
        url: '/Game/MoveHunter',
        type: 'POST',
        data: {
            "X": hunter.getBoundingClientRect().left,//$(this).css("left"),
            "Y": hunter.getBoundingClientRect().top//$(this).css("top")
        },
        success: function (response) {
            //alert(response);
        }
    });
}

function TakeShot(bullet, xPosition, yPosition) {
    $.ajax({
        url: '/Game/TakeShot',
        type: 'POST',
        data: {
            "X": xPosition,//$(this).css("left"),
            "Y": yPosition//$(this).css("top")
        },
        success: function (response) {
            alert("Bullets left: " + response);

            bullet.style.left = xPosition + "px";
            bullet.style.top = yPosition + "px";

            setTimeout(removeAllBullets, 1000);
        }
    });
}

function UpdateField() {
    $.ajax({
        url: '/Game/UpdateField',
        type: 'POST',
        //todo
        data: {},
        success: function (response) {
            //alert(response);
        }
    });
}
function GetPositions() {
    $.ajax({
        url: '/Game/GetMembersPositions',
        type: 'GET',
        success: function (response) {
            //alert(response);
            creatures = response;
            let helper = document.getElementById("helper");
            helper.innerHTML = "";
            creatures.forEach(element => {
                helper.insertAdjacentHTML('afterbegin', element.id+" "+element.x+" "+element.y+" "+element.creatureType+", ");
            });
            //helper.insertAdjacentHTML('afterbegin', response.data);
        }
    });
}

//old
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