import { City } from './city.model';

export class Street {
    constructor(
        public Id:number,
        public Name:string='',
        public City:City=null
    ){}}