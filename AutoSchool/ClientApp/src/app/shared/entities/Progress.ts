import { User } from './User';


export class Progress {
    constructor(
        public id?: number,
        public points?: number,
        public user?: User,
        public creatorId?: number,
        public updatedAt?: string
    ) { }
}
