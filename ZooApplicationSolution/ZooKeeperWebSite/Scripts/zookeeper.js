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

        scope.createNewAnimal = function () {
            rootScope.$broadcast('createNewAnimal');
        };

        rootScope.$on('refreshAnimals', function (event, arg) {
            scope.getAnimals();
        });

        scope.getAnimals();
    };

    var animalController = function (rootScope, scope, http) {
        var baseAddress = "http://localhost:59255/";

        var onGetAnimalComplete = function (response) {
            scope.animal = response.data;
            getAnimalFamilies();
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

        var refreshAnimals = function () {
            rootScope.$broadcast('refreshAnimals')
        };

        scope.saveAnimal = function (animal, callBack) {
            if (!scope.animal.Id) {
                http.post(baseAddress + "api/Animal/", scope.animal)
                .then(refreshAnimals)
                .then(scope.animal = "");
                return;
            }

            http.put(baseAddress + "api/Animal/" + scope.animal.Id, scope.animal)
            .then(refreshAnimals)
            .then(scope.animal = "");
        };

        scope.deleteAnimal = function () {
            http.delete(baseAddress + "api/Animal/" + scope.animal.Id)
            .then(refreshAnimals)
            .then(scope.animal = "");
        };

        rootScope.$on('getAnimal', function (event, id) {
            getAnimal(id);
        });

        rootScope.$on('createNewAnimal', function (event, id) {
            scope.animal = "";
            getAnimalFamilies();
        });

        getAnimalFamilies();
    };

    app.controller('AnimalsController', ['$rootScope', '$scope', '$http', animalsController]);
    app.controller('AnimalController', ['$rootScope', '$scope', '$http', animalController]);

}());