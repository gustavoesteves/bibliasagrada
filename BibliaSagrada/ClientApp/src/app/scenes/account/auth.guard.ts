import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable, Subject } from 'rxjs';

import { AuthService } from './auth.service';
import { BibleService } from '../bible/bible.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(
    private authService: AuthService,
    private bible: BibleService,
    private router: Router) { }

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean> {

    var subject = new Subject<boolean>();

    this.authService.validateCookie().subscribe((result: any) => {
      if (result.email !== undefined) {
        this.authService.setUsername(result.email);
        this.authService.setLogged(true);
        this.bible.setCheckInline(result.checkInline);
        this.bible.setRangeValue(result.rangeValue);
        subject.next(true);
      } else {
        subject.next(false);
        this.router.navigate(['/Home']);
      }
    });

    return subject.asObservable();
  }

}
