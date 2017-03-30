namespace CoderCampsMentor.Services {
    export class ProfileService {
        private usersResource;
        private picResource;
        constructor(private $resource: angular.resource.IResourceService, ) {
            this.usersResource = this.$resource('/api/applicationUsers/:id');
        }

        // get user id
        public getUserById(id) {
            var user = this.usersResource.get({ id: id }).$promise;
            return user;
        }

        public saveProfile(profileToSave) {
            return this.usersResource.save(profileToSave).$promise;
        }
    }
    angular.module('CoderCampsMentor').service('profileService', ProfileService);
}