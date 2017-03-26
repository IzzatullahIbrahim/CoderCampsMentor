namespace CoderCampsMentor.Controllers {

    export class HomeController {
        public message = 'Hello please login/register';
        public loginMessage = 'Welcome Home';
    }

    export class SecretController {
        public secrets;

        constructor($http: ng.IHttpService) {
            $http.get('/api/secrets').then((results) => {
                this.secrets = results.data;
            });
        }
    }

    export class AboutController {
        public message = 'Hello from the about page!';
    }

}
