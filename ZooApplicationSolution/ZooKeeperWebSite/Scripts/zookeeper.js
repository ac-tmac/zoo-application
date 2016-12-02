function getAnimalFromForm() {
    var animalId = document.getElementById("animal-form-id").value;
    var animalName = document.getElementById("animal-form-name").value;
    var animalDateOfBirth = document.getElementById("animal-form-date-of-birth").value;
    var animalFamilyName = document.getElementById("animal-form-family").value;

    var animal = {
        id: animalId,
        name: animalName,
        dateofbirth: animalDateOfBirth
    };

    var isNew = !animalId;
    if (isNew) {
        animal.familyname = animalFamilyName;
    }

    return animal;
}

function displayAnimalsView() {
    //refreshAnimalsView();
    document.getElementById("animals-view").style.visibility = 'visible';
}

function animalAddNewButtonOnClick() {
    displayAddNewAnimalForm();
}

function animalFormDeleteButtonOnClick() {
    var animal = getAnimalFromForm();
    var animalId = animal.id;
    createService().deleteAnimal(animalId, deleteAnimalCallBack);
}

function initaliseAddNewButton() {
    var animalAddNewButton = document.getElementById("animal-add-new-button");
    animalAddNewButton.addEventListener("click", animalAddNewButtonOnClick);
}

function intialiseDeleteButton() {
    var animalFormDeleteButton = document.getElementById("animal-form-delete-button");
    animalFormDeleteButton.addEventListener("click", animalFormDeleteButtonOnClick);
}

function refreshEditAnimalForm() {
    var animal = getAnimalFromForm();
    createService().getAnimal(animal.id, getAnimalCallBack);
}

function animalFormReset() {
    document.getElementById("animal-form-id").value = "";
    document.getElementById("animal-form").reset();
}

function displayAddNewAnimalForm() {
    animalFormReset();
    document.getElementById("animal-form-save-button").removeAttribute("onclick");
    document.getElementById("animal-form-save-button").setAttribute("onclick", "createService().postAnimal(getAnimalFromForm(), postAnimalCallBack); return false;");
    document.getElementById("animal-form-view").style.visibility = 'visible';
    document.getElementById("animal-form-delete-button").style.visibility = 'hidden';
    // document.getElementById("animal-form-family-holder").style.visibility = "visible";
}

function displayEditAnimalForm(animalModel) {
    animalFormBind(animalModel);
    document.getElementById("animal-form-save-button").removeAttribute("onclick");
    document.getElementById("animal-form-save-button").setAttribute("onclick", "createService().putAnimal(getAnimalFromForm(), putAnimalCallBack); return false;");
    document.getElementById("animal-form-view").style.visibility = 'visible';
    document.getElementById("animal-form-delete-button").style.visibility = 'visible';
    // document.getElementById("animal-form-family-holder").style.visibility = "hidden";
}

function animalFormBind(animalModel) {
    // animalFormReset();
    // document.getElementById("animal-form-id").value = animalModel.Id;
    // document.getElementById("animal-form-name").value = animalModel.Name;
    // document.getElementById("animal-form-date-of-birth").value = animalModel.DateOfBirth;

    //var familyNameList = document.getElementById("animal-form-family");
    //for (i = 0; i < familyNameList.options.length; i++) {
    //    if (familyNameList.options[i].value === animalModel.FamilyName) {
    //        familyNameList.options[i].selected = true;
    //        break;
    //    }
    //}
}

function getAnimalCallBack(responseText) {
    var animalModel = JSON.parse(responseText);
    displayEditAnimalForm(animalModel);
}

function postAnimalCallBack(responseText) {
    //refreshAnimalsView();
    displayAddNewAnimalForm();
    //var animalFormFeedback = document.getElementById("animal-form-feedback");
}

function putAnimalCallBack(responseText) {
    //refreshAnimalsView();
    refreshEditAnimalForm();
    //var animalFormFeedback = document.getElementById("animal-form-feedback");
}

function deleteAnimalCallBack(responseText) {
    //refreshAnimalsView();
    displayAddNewAnimalForm();
    //var animalFormFeedback = document.getElementById("animal-form-feedback");
}

function getFamiliesCallBack(responseText) {

    var animalFamilyNames = JSON.parse(responseText);
    var familyNameList = document.getElementById("animal-form-family");

    for (var i = 0; i < animalFamilyNames.length; i++) {
        var animalFamilyName = animalFamilyNames[i];

        var option = document.createElement("option");
        option.setAttribute("value", animalFamilyName);

        var optionText = document.createTextNode(animalFamilyName);
        option.appendChild(optionText);

        familyNameList.appendChild(option);
    }
}


var createService = function (scope, http) {

    var baseAddress = "http://localhost:59255/";

    function sendGetRequest(url) {
        var request = new XMLHttpRequest();
        request.open("GET", url, false);
        request.send();

        return request.responseText;
    }

    var sendJsonStringOnRequest = function (type, url, jsonString, callBack) {
        var request = new XMLHttpRequest();
        request.open(type, url);
        request.setRequestHeader("Content-Type", "application/json;charset=UTF-8");
        request.onload = function () {
            if (request.status === 200) {
                callBack(request.responseText);
            }
        };

        request.send(jsonString);
    }

    var getFamilies = function (callBack) {
        var url = baseAddress + "api/AnimalFamilies/";
        var responseText = sendGetRequest(url);
        callBack(responseText);
    };

    var getAnimals = function (callBack) {
        var url = baseAddress + "api/Animals/";
        var responseText = sendGetRequest(url);
        callBack(responseText);
    };

    var getAnimal = function (id, callBack) {
        var url = baseAddress + "api/Animal/" + id;
        var responseText = sendGetRequest(url);
        callBack(responseText);
    };

    var postAnimal = function (animal, callBack) {
        var type = "POST";
        var url = baseAddress + "api/Animal/";
        var jsonString = JSON.stringify(animal);
        sendJsonStringOnRequest(type, url, jsonString, callBack);
    };

    var putAnimal = function (animal, callBack) {
        var type = "PUT";
        var url = baseAddress + "api/Animal/" + animal.id;
        var jsonString = JSON.stringify(animal);
        sendJsonStringOnRequest(type, url, jsonString, callBack);
    };

    var deleteAnimal = function (id, callBack) {
        var request = new XMLHttpRequest();
        request.open("DELETE", baseAddress + "api/Animal/" + id, false);
        request.send();
        callBack(request.responseText);
    }

    return {
        getFamilies: getFamilies,
        getAnimals: getAnimals,
        getAnimal: getAnimal,
        postAnimal: postAnimal,
        putAnimal: putAnimal,
        deleteAnimal: deleteAnimal
    };
};

(function () {

    var app = angular.module('zooKeeper', []);

    var animalsController = function (rootScope, scope, http) {
        var baseAddress = "http://localhost:59255/";

        var onGetAnimalsComplete = function (response) {
            scope.animals = response.data;
        };

        scope.getAnimals = function () {
            http.get(baseAddress + "api/Animals/")
            .then(onGetAnimalsComplete);
        };

        scope.getAnimal = function (id) {
            rootScope.$broadcast('getAnimal', id);
        };

        scope.getAnimals();
    };

    var animalController = function (rootScope, scope, http) {
        var baseAddress = "http://localhost:59255/";

        var onGetAnimalComplete = function (response) {
            scope.animal = response.data;
            getAnimalFamilies();
            displayEditAnimalForm(scope.animal);
        };

        var onGetFamiliesComplete = function (response) {
            scope.animalFamilies = response.data;
        };

        var getAnimal = function (id) {
            http.get(baseAddress + "api/Animal/" + id)
            .then(onGetAnimalComplete);
        };

        var getAnimalFamilies = function () {
            http.get(baseAddress + "api/AnimalFamilies/")
            .then(onGetFamiliesComplete);
        };

        rootScope.$on('getAnimal', function (event, id) {
            getAnimal(id);
        });
    };

    app.controller('AnimalsController', ['$rootScope', '$scope', '$http', animalsController]);
    app.controller('AnimalController', ['$rootScope', '$scope', '$http', animalController]);

    initaliseAddNewButton();
    intialiseDeleteButton();

}());