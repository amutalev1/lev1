import { Address } from 'src/app/shared/models/address.model';

export class Bank {
    constructor(//public Id:number,
        public BankNumber:string='',
        public Name:string='',
        public BranchNumber:string='',
        public Address:Address=null){

    }
}