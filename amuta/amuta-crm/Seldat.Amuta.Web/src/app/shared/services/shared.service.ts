import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SharedService {

  showAllColumnsSubject: Subject<void> = new Subject<void>();
  private directionSubject: Subject<any> = new Subject<any>();

  changeDirection(direction: string) {
    this.directionSubject.next({ direction });
  }

  getDirection() {
    return this.directionSubject.asObservable();
  }
  constructor() { }
}
