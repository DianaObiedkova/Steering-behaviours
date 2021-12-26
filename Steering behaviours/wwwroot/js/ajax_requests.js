
var hunter = document.getElementById("circle");

function MoveHunter() {
    $.ajax({
        url: '/Game/MoveHunter',
        type: 'POST',
        data: {
            "X": hunter.getBoundingClientRect().left,//$(this).css("left"),
            "Y": hunter.getBoundingClientRect().top//$(this).css("top")
        },
        success: function (response) {
            alert(response);
        }
    });
}

function TakeShot() {
    $.ajax({
        url: '/Game/TakeShot',
        type: 'POST',
        data: {
            "X": $(this).css("left"),
            "Y": $(this).css("top")
        },
        success: function (response) {
            alert(response);
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
            alert(response);
        }
    });
}
function GetPositions() {
    $.ajax({
        url: '/Game/GetMembersPositions',
        type: 'GET',
        success: function (response) {

            let helper = document.getElementById("helper");
            helper.innerHTML = "";
            helper.insertAdjacentHTML('afterbegin', response);
            //todo
            alert(response);
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