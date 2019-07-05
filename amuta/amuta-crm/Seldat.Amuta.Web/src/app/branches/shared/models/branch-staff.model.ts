import { Branch } from './branch.model';
import { Role } from './role';
import { User } from './user';

export class BranchStaff {
    constructor(
        public Branch : Branch=null ,
        public UserExtraDetails: User=null ,
        public Role: Role=null,
    ){}
}
