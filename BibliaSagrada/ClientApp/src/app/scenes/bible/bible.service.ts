import { Injectable } from '@angular/core';
import { Observable, BehaviorSubject } from 'rxjs';
import { HttpClient, HttpResponse } from '@angular/common/http';

import {
  HttpOptions,
  BibleUserUrl,
  GetUserVerciclesUrl,
  GetPickOneUrl,  PreviousNextUrl
} from '../../global/urls';
import { catchError } from 'rxjs/operators';
import { HandleError } from '../../global/handleError';

@Injectable({
  providedIn: 'root'
})
export class BibleService {

  private checkInline = new BehaviorSubject<boolean>(false);
  _checkInline = this.checkInline.asObservable();

  private rangeValue = new BehaviorSubject<number>(0);
  _rangeValue = this.rangeValue.asObservable();

  constructor(private http: HttpClient) { }

  //////// methods //////////

  /** GET: UserDetail */
  getUserDetail(): Observable<HttpResponse<Object>> {
    return this.http.get<HttpResponse<Object>>(BibleUserUrl, HttpOptions)
      .pipe(catchError(HandleError<HttpResponse<Object>>('getUserDetail')));
  }

  /** GET: GetUserVercicles*/
  getUserVercicles(): Observable<HttpResponse<Object>> {
    return this.http.get<HttpResponse<Object>>(GetUserVerciclesUrl, HttpOptions)
      .pipe(catchError(HandleError<HttpResponse<Object>>('getUserVercicles')));
  }

  /** GET: GetPickOne*/
  getPickOne(): Observable<HttpResponse<Object>> {
    return this.http.get<HttpResponse<Object>>(GetPickOneUrl, HttpOptions)
      .pipe(catchError(HandleError<HttpResponse<Object>>('getPickOne')));
  }

  /** GET: GetPreviousNext*/
  getPreviousNext(value: boolean): Observable<HttpResponse<Object>> {
    return this.http.get<HttpResponse<Object>>(PreviousNextUrl + '/' + value, HttpOptions)
      .pipe(catchError(HandleError<HttpResponse<Object>>('getPreviousNext')));
  }
  
  setCheckInline(check: boolean) {
    this.checkInline.next(check);
  }

  setRangeValue(value: number) {
    this.rangeValue.next(value);
  }

}
