import { Role } from './Role';
import { Progress } from './Progress';


export class User {
    constructor(
        public id?: number,
        public roleId?: number,
        public role?: Role,
        public login?: string,
        public password?: string,
        public progressId?: number,
        public progress?: Progress
    ) { }
}
