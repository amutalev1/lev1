export class Guarantor {

    constructor(
        public Id:number,
        public FirstName:string,
        public LastName:string,
        public IdentityNumber:string,
        public IdCard:string,
        //public byte[] DigitalSignature ,
        public GuaranteeDeedWritingDate:Date,
        public LoanNote:string,
    ){}

}
