
function MoveHunter() {

    $.ajax({
        url: '/Game/MoveHunter',
        type: 'POST',
        data: {
            "X": hunter.offsetLeft,//hunter.getBoundingClientRect().left,//$(this).css("left"),
            "Y": hunter.offsetTop//hunter.getBoundingClientRect().top//$(this).css("top")
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
            creatures.forEach(element => {
                if (document.getElementById(element.id) !== null) {
                    removeAnimal(element.id);
                } 
            });
            creatures = response;
            let helper = document.getElementById("helper");
            helper.innerHTML = "";
            creatures.forEach(element => {
                helper.insertAdjacentHTML('afterbegin', element.id + " " + element.x + " " + element.y + " " + element.creatureType + ", ");
                createAnimal(element.id, element.x, element.y, element.creatureType);
            });
            //helper.insertAdjacentHTML('afterbegin', response.data);
        }
    });
}

//old
//function getPositions() {
//    $.ajax({
//        type: "GET",
//        url: "/Game/GetMembersPositions",
//        success: function (response) {

//            let helper = document.getElementById("helper");
//            helper.insertAdjacentHTML('afterbegin', response);
//        },
//        failure: function (response) {
//            alert(response.responseText);
//        },
//        error: function (response) {
//            if (response.status == 400)
//                alert("Impossible!");
//            else
//                alert(response.status);
//        }
//    })
//}

function addClassRabbit(animal) {
    animal.classList.add("rabbit");
}

function addClassDoe(animal) {
    animal.classList.add("doe");
}

function addClassWolf(animal) {
    animal.classList.add("wolf");
}

function createAnimal(id,posX,posY,type){
    const animal = document.createElement("div");
    animal.setAttribute("id", id);
    animal.style.left = posX + 'px';
    animal.style.top = posY + 'px';

    switch (type) {
        case "Doe":
            addClassDoe(animal);
            break;
        case "Rabbit":
            addClassRabbit(animal);
            break;
        case "Wolf":
            addClassWolf(animal);
            break;
    }
    
    field.appendChild(animal);
}

function removeAnimal(id) {
    var elem = document.getElementById(id);
    return elem.remove();
}