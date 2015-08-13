'use strict';

// Google Analytics Collection APIs Reference:
// https://developers.google.com/analytics/devguides/collection/analyticsjs/

angular.module('app.controllers', [])

    // Path: /
    .controller('HomeCtrl', ['$scope', '$location', '$window', function ($scope, $location, $window) {
        $scope.$root.title = 'AngularJS SPA Template for Visual Studio';
        $scope.$on('$viewContentLoaded', function () {
            $window.ga('send', 'pageview', { 'page': $location.path(), 'title': $scope.$root.title });
        });
    }])

    // Path: /about
    .controller('AboutCtrl', ['$scope', '$location', '$window', function ($scope, $location, $window) {
        $scope.$root.title = 'Mosaix Software | About';
        $scope.$on('$viewContentLoaded', function () {
            $window.ga('send', 'pageview', { 'page': $location.path(), 'title': $scope.$root.title });
        });
    }])

        // Path: /about
    .controller('IntroductionCtrl', ['$scope', '$location', '$window', function ($scope, $location, $window) {
        $scope.$root.title = 'Mosaix Software | Introduction';
        $scope.$on('$viewContentLoaded', function () {
            $window.ga('send', 'pageview', { 'page': $location.path(), 'title': $scope.$root.title });
        });
    }])



        // Path: /about
    .controller('GoalCtrl', ['$scope', '$location', '$window', function ($scope, $location, $window) {
        $scope.$root.title = 'Mosaix Software | Introduction';
        $scope.$on('$viewContentLoaded', function () {
            $window.ga('send', 'pageview', { 'page': $location.path(), 'title': $scope.$root.title });
        });
    }])

        
    .controller('OverviewCtrl', ['$scope', '$location', '$window', function ($scope, $location, $window) {
        $scope.$root.title = 'Mosaix Software | Overview';
        $scope.$on('$viewContentLoaded', function () {
            $window.ga('send', 'pageview', { 'page': $location.path(), 'title': $scope.$root.title });
        });
    }])
    
    .controller('ResourcesCtrl', ['$scope', '$location', '$window', function ($scope, $location, $window) {
        $scope.$root.title = 'Mosaix Software | Resources';
        $scope.$on('$viewContentLoaded', function () {
            $window.ga('send', 'pageview', { 'page': $location.path(), 'title': $scope.$root.title });
        });
    }])

    // Path: /contactus
    .controller('DemoCtrl', ['$scope', '$location', '$window', '$http', '$log', 'demoService', function ($scope, $location, $window, $http, $log, dataService) {
        $scope.$root.title = 'Mosaix Software | Demo';
        $scope.$on('$viewContentLoaded', function () {
            $window.ga('send', 'pageview', { 'page': $location.path(), 'title': $scope.$root.title });
        });

        $scope.message = "";
        $scope.errorMessages = [];
        $scope.viewModel = {};

        $scope.submitFluentFilter = function () {
            $scope.message = "Submitting Fluent Filter...";
            $scope.errorMessages = [];

            dataService.PostFluentFilter($scope.viewModel)
                .success(function (data) {
                    $scope.message = "Success.";
                })
                .error(function (data) {
                $scope.message = "There were one or more errors. Please review. Submitted with Fluent Filter.";
                $scope.errorMessages = angular.copy(data);
            });
        };

        $scope.submitFluentInjection = function () {
            $scope.message = "Submitting Fluent Injection...";
            $scope.errorMessages = [];

            dataService.PostFluentInjection($scope.viewModel)
                .success(function (data) {
                    $scope.message = "Success.";
                })
                .error(function (data) {
                    $scope.message = "There were one or more errors. Please review. Submitted with Fluent Injection.";
                    $scope.errorMessages = angular.copy(data);
                });
        };

        
        $scope.submitEmbedded = function () {
            $scope.message = "Submitting Embedded...";
            $scope.errorMessages = [];

            dataService.PostEmbedded($scope.viewModel)
                .success(function (data) {
                    $scope.message = "Success.";
                })
                .error(function (data) {
                    $scope.message = "There were one or more errors. Please review. Submitted with Embedded.";
                    $scope.errorMessages = angular.copy(data);
                });
        };

        $scope.submitDataAnnotations = function () {
            $scope.message = "Submitting Data Annotations...";
            $scope.errorMessages = [];

            dataService.PostDataAnnotations($scope.viewModel)
                .success(function (data) {
                    $scope.message = "Success.";
                })
                .error(function (data) {
                    $scope.message = "There were one or more errors. Please review. Submitted with Data Annotations.";
                    $scope.errorMessages = angular.copy(data);
                });
        };
    }])


    // Path: /error/404
    .controller('Error404Ctrl', ['$scope', '$location', '$window', function ($scope, $location, $window) {
        $scope.$root.title = 'Error 404: Page Not Found';
        $scope.$on('$viewContentLoaded', function () {
            $window.ga('send', 'pageview', { 'page': $location.path(), 'title': $scope.$root.title });
        });
    }]);