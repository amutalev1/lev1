import { Country } from './country.model';
import { City } from './city.model';
import { Street } from './street.model';

export class Address {
    constructor(
        public Id:number=0,
        public Country:Country=null,
        public City:City=null,
        public NeighborhoodName:string='',
        public Street:Street=null,
        public HouseNumber:number=0,
        public ApartmentNumber:number=0,
        public ZipCode:string=''
    ){}}