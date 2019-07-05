import { Loans } from './loans';
import { Guarantor } from './guarantor';

export class LoanGuarantor {

    constructor(
        public Loan:Loans,
        public Guarantor:Guarantor
    ){}

}
