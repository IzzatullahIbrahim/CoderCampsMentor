namespace CoderCampsMentor.Controllers {

    export class AccountController {
        public externalLogins;
        public userID;
        public userPicture;


        public getPicture() {
            return this.accountService.getPicture();
        }

        public getUserName() {
            return this.accountService.getUserName();
        }

        public getUserId() {
            return this.accountService.getUserId();
        }

        public getClaim(type) {
            return this.accountService.getClaim(type);
        }

        public isLoggedIn() {
            return this.accountService.isLoggedIn();
        }

        public logout() {
            this.accountService.logout();
            this.$location.path('/');
        }

        public getExternalLogins() {
            return this.accountService.getExternalLogins();
        }

        constructor(private accountService: CoderCampsMentor.Services.AccountService, private $location: ng.ILocationService) {
            this.getExternalLogins().then((results) => {
                this.externalLogins = results;
            });
        }
    }

    angular.module('CoderCampsMentor').controller('AccountController', AccountController);


    export class LoginController {
        public loginUser;
        public validationMessages;

        public login() {
            console.log('a');
            this.accountService.login(this.loginUser).then(() => {
                this.$location.path('/');
                location.reload();
            }).catch((results) => {
                this.validationMessages = results;
            });
        }

        constructor(private accountService: CoderCampsMentor.Services.AccountService, private $location: ng.ILocationService) { }
    }

    angular.module('CoderCampsMentor').controller('LoginController', LoginController);

    export class RegisterController {
        public registerUser;
        public validationMessages;

        public register() {
            this.accountService.getPicture();
            this.accountService.register(this.registerUser).then(() => {
                this.$location.path('/');
                location.reload();
            }).catch((results) => {
                this.validationMessages = results;
            });
        }

        constructor(private accountService: CoderCampsMentor.Services.AccountService, private $location: ng.ILocationService) { }
    }

    angular.module('CoderCampsMentor').controller('RegisterController', RegisterController);

    export class ExternalRegisterController {
        public registerUser;
        public validationMessages;

        public register() {
            this.accountService.registerExternal(this.registerUser.email)
                .then((result) => {
                    this.$location.path('/');
                }).catch((result) => {
                    this.validationMessages = result;
                });
        }

        constructor(private accountService: CoderCampsMentor.Services.AccountService, private $location: ng.ILocationService) {}

    }

    export class ConfirmEmailController {
        public validationMessages;

        constructor(
            private accountService: CoderCampsMentor.Services.AccountService,
            private $http: ng.IHttpService,
            private $stateParams: ng.ui.IStateParamsService,
            private $location: ng.ILocationService
        ) {
            let userId = $stateParams['userId'];
            let code = $stateParams['code'];
            accountService.confirmEmail(userId, code)
                .then((result) => {
                    this.$location.path('/');
                }).catch((result) => {
                    this.validationMessages = result;
                });
        }
    }

}
