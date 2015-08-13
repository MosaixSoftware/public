'use strict';

var demoService = function ($http, $log) {
    this.PostFluentFilter = function (viewModel) {
        $log.debug("Contact Us PostFluentFilter fired with data: ");
        $log.debug(viewModel);

        return $http.post('http://localhost:10001/api/contactusfilter/post/', viewModel);
    };

    this.PostFluentInjection = function (viewModel) {
        $log.debug("Contact Us PostFluentInjection fired with data: ");
        $log.debug(viewModel);

        return $http.post('http://localhost:10001/api/contactusinjection/post/', viewModel);
    };

    this.PostEmbedded = function (viewModel) {
        $log.debug("Contact Us PostEmbedded fired with data: ");
        $log.debug(viewModel);

        return $http.post('http://localhost:10001/api/contactusembedded/post/', viewModel);
    };


    this.PostDataAnnotations = function (viewModel) {
        $log.debug("Contact Us PostDataAnnotations fired with data: ");
        $log.debug(viewModel);

        return $http.post('http://localhost:10001/api/contactusdataannotations/post/', viewModel);
    };
};

// Demonstrate how to register services
// In this case it is a simple value service.
angular.module('app.services', [])
.value('version', '0.1')
.service('demoService', ['$http', '$log', demoService]);
