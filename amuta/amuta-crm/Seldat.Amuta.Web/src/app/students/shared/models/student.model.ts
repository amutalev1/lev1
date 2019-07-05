import { Bank } from 'src/app/shared/models/bank.model';
import { Address } from 'src/app/shared/models/address.model';
import { StudentChild } from './student-child.model';

export class Student {

  

    constructor(
        public Id: number=0,
        public FirstName: string='',
        public LastName: string='',
        public IdentityNumber: string='',
        public IdCard: string='',
        public Address: Address=null,
        public BornDate: Date=null,
        public Image: string='',
        public PhoneNumber: string='',
        public CellphoneNumber: string='',
        public Bank: Bank=null,
        public AccountNumber: string='',
        public ChildrenNumber: number=0,
        public MarriedChildrenNumber: number=0,
        public WifeName: string='',
        public JobWife: string='',
        public MonthlyIncome: number=0,
        public MonthlyIncomeCurrency: string='',
        public TravelExpenses: number=0,
        public TravelExpensesCurrency: string='',
        public FaxNumber: string='',
        public IsActive: boolean=false,
        public StudentChildren: StudentChild[]=null,
    ) { }
}