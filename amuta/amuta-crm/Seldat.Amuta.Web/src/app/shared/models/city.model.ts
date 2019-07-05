import { Country } from './country.model';

export class City {
    constructor(
        public Id: number,
        public Name: string='',
        public Country:Country=null
    ) { }
}