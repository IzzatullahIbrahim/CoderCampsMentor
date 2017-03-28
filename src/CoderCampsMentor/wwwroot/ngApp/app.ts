namespace CoderCampsMentor {

    angular.module('CoderCampsMentor', ['ui.router', 'ngResource', 'ui.bootstrap', 'angular-filepicker']).config((
        $stateProvider: ng.ui.IStateProvider,
        $urlRouterProvider: ng.ui.IUrlRouterProvider,
        $locationProvider: ng.ILocationProvider,
        filepickerProvider) => {
        filepickerProvider.setKey('AksRZcU5qRLawgTdZmZfpz');
        // Define routes
        $stateProvider
            .state('home', {
                url: '/',
                templateUrl: '/ngApp/views/home.html',
                controller: CoderCampsMentor.Controllers.HomeController,
                controllerAs: 'controller'
            })
            .state('applicationUsers', {
                url: '/applicationUsers',
                templateUrl: '/ngApp/views/applicationUsers.html',
                controller: CoderCampsMentor.Controllers.ApplicationUsersController,
                controllerAs: 'controller'
            })
            .state('applicationUser', {
                url: '/applicationUser/:id',
                templateUrl: '/ngApp/views/applicationUser.html',
                controller: CoderCampsMentor.Controllers.ApplicationUserController,
                controllerAs: 'controller'
            })
            .state('categories', {
                url: '/categories',
                templateUrl: '/ngApp/views/categories.html',
                controller: CoderCampsMentor.Controllers.CategoriesController,
                controllerAs: 'controller'
            })
            .state('category', {
                url: '/categories/:id',
                templateUrl: '/ngApp/views/category.html',
                controller: CoderCampsMentor.Controllers.CategoryController,
                controllerAs: 'controller'
            })
            .state('addCategory', {
                url: '/addCategory',
                templateUrl: '/ngApp/views/addCategory.html',
                controller: CoderCampsMentor.Controllers.AddCategoryController,
                controllerAs: 'controller'
            })
            .state('editCategory', {
                url: '/editCategory/:id',
                templateUrl: '/ngApp/views/editCategory.html',
                controller: CoderCampsMentor.Controllers.EditCategoryController,
                controllerAs: 'controller'
            })
            .state('addCategoryAndSubCategoryToUser', {
                url: '/addCategoryAndSubCategoryToUser/:id',
                templateUrl: '/ngApp/views/addCategoryAndSubCategoryToUser.html',
                controller: CoderCampsMentor.Controllers.AddCategoryAndSubCategoryToUserController,
                controllerAs: 'controller'
            })
            .state('subCategories', {
                url: '/subCategories',
                templateUrl: '/ngApp/views/subCategories.html',
                controller: CoderCampsMentor.Controllers.SubCategoriesController,
                controllerAs: 'controller'
            })
            .state('subCategory', {
                url: '/subCategories/:id',
                templateUrl: '/ngApp/views/subCategory.html',
                controller: CoderCampsMentor.Controllers.SubCategoryController,
                controllerAs: 'controller'
            })
            .state('addSubCategory', {
                url: '/addSubCategory',
                templateUrl: '/ngApp/views/addSubCategory.html',
                controller: CoderCampsMentor.Controllers.AddSubCategoryController,
                controllerAs: 'controller'
            })
            .state('editSubCategory', {
                url: '/editSubCategory/:id',
                templateUrl: '/ngApp/views/editSubCategory.html',
                controller: CoderCampsMentor.Controllers.EditSubCategoryController,
                controllerAs: 'controller'
            })
            .state('profile', {
                url: '/profile/:id',
                templateUrl: '/ngApp/views/profile.html',
                controller: CoderCampsMentor.Controllers.ApplicationUserController,
                controllerAs: 'controller'
            })
            .state('secret', {
                url: '/secret',
                templateUrl: '/ngApp/views/secret.html',
                controller: CoderCampsMentor.Controllers.SecretController,
                controllerAs: 'controller'
            })
            .state('login', {
                url: '/login',
                templateUrl: '/ngApp/views/login.html',
                controller: CoderCampsMentor.Controllers.LoginController,
                controllerAs: 'controller'
            })
            .state('register', {
                url: '/register',
                templateUrl: '/ngApp/views/register.html',
                controller: CoderCampsMentor.Controllers.RegisterController,
                controllerAs: 'controller'
            })
            .state('externalRegister', {
                url: '/externalRegister',
                templateUrl: '/ngApp/views/externalRegister.html',
                controller: CoderCampsMentor.Controllers.ExternalRegisterController,
                controllerAs: 'controller'
            })
            .state('about', {
                url: '/about',
                templateUrl: '/ngApp/views/about.html',
                controller: CoderCampsMentor.Controllers.AboutController,
                controllerAs: 'controller'
            })
            .state('selectPicture', {
                url: '/selectPicture',
                templateUrl: '/ngApp/views/selectPicture.html',
                controller: CoderCampsMentor.Controllers.ProfileController,
                controllerAs: 'controller'
            })
            .state('code', {
                url: '/code',
                templateUrl: '/ngApp/views/code.html',
                controller: CoderCampsMentor.Controllers.CodeController,
                controllerAs: 'controller'
            })
            .state('editProfile', {
                url: '/editProfile',
                templateUrl: '/ngApp/views/editProfile.html',
                controller: CoderCampsMentor.Controllers.ProfileController,
                controllerAs: 'controller'
            })
            .state('notFound', {
                url: '/notFound',
                templateUrl: '/ngApp/views/notFound.html'
            });

        // Handle request for non-existent route
        $urlRouterProvider.otherwise('/notFound');

        // Enable HTML5 navigation
        $locationProvider.html5Mode(true);
    });

    angular.module('CoderCampsMentor').factory('authInterceptor', (
        $q: ng.IQService,
        $window: ng.IWindowService,
        $location: ng.ILocationService
    ) =>
        ({
            request: function (config) {
                config.headers = config.headers || {};
                config.headers['X-Requested-With'] = 'XMLHttpRequest';
                return config;
            },
            responseError: function (rejection) {
                if (rejection.status === 401 || rejection.status === 403) {
                    $location.path('/login');
                }
                return $q.reject(rejection);
            }
        })
    );
    angular.module('CoderCampsMentor').config(function ($httpProvider) {
        $httpProvider.interceptors.push('authInterceptor');
    });
}
