import { NgbDate } from '@ng-bootstrap/ng-bootstrap';

export interface User {
   userName: string;
   token: string;
   firstName: string;
   lastName: string;
   dateOfBirth: Date;
   idNumber: number;
}
