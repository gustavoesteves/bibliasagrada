import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Observable, BehaviorSubject } from 'rxjs';
import { catchError, tap, map } from 'rxjs/operators';

import { MessageService } from '../../message/message.service';
import { IUserLogin, IChangePassword, IUserRegister } from './user';
import {
  HttpOptions,
  RegisterUrl,
  LoginUrl,
  LogoutUrl,
  ChangePassUrl,
  ValidateCookieUrl,
  ManageLoginsUrl,
  ChangeNumberVerciclesUrl,
  PostChangeInLineUrl
} from '../../global/urls';
import { HandleError, IError } from '../../global/handleError';
import { BodyEncode } from '../../global/functions';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  _error = {} as IError;

  private username = new BehaviorSubject<string>('');
  _username = this.username.asObservable();

  private logged = new BehaviorSubject<boolean>(false);
  _logged = this.logged.asObservable();


  constructor(private http: HttpClient,
    private messageService: MessageService) { }

  setUsername(username: string) {
    this.username.next(username);
  }

  setLogged(logged: boolean) {
    this.logged.next(logged);
  }

  //////// methods //////////

  /** POST: get Token from server */
  getToken(user: IUserLogin): Observable<HttpResponse<Object>> {
    return this.http.post<HttpResponse<Object>>(LoginUrl, BodyEncode<IUserLogin>(user), HttpOptions)
      .pipe(catchError(HandleError<HttpResponse<Object>>('Login')));
  }

  /** POST: add a new user to the server */
  registerUser(user: IUserRegister): Observable<IUserRegister | IError> {
    return this.http.post<IUserRegister>(RegisterUrl, BodyEncode<IUserRegister>(user), HttpOptions)
      .pipe(catchError(HandleError<IError>('Register', this._error)));
  }

  /** POST: Logout */
  postLogOut(): Observable<HttpResponse<Object>> {
    return this.http.post<HttpResponse<Object>>(LogoutUrl, HttpOptions)
      .pipe(catchError(HandleError<HttpResponse<Object>>('Logout')));
  }

  /** GET: ValidateCookie */
  validateCookie(): Observable<HttpResponse<Object>> {
    return this.http.get<HttpResponse<Object>>(ValidateCookieUrl, HttpOptions)
      .pipe(catchError(HandleError<HttpResponse<Object>>('ValidateCookie')));
  }

  /** POST: ChangePassword */
  changePassword(user: IChangePassword): Observable<HttpResponse<Object>> {
    return this.http.post<HttpResponse<Object>>(ChangePassUrl, BodyEncode<IChangePassword>(user), HttpOptions)
      .pipe(catchError(HandleError<HttpResponse<Object>>('ChangePassword')));
  }

  /** GET: ManageLogins */
  manageLogins(): Observable<HttpResponse<Object>> {
    return this.http.get<HttpResponse<Object>>(ManageLoginsUrl, HttpOptions)
      .pipe(catchError(HandleError<HttpResponse<Object>>('ManageLogins')));
  }

  /** POST: PostChangeNumberVercicles */
  PostChangeNumberVercicles(value: number): Observable<HttpResponse<Object>> {
    return this.http.post<HttpResponse<Object>>(ChangeNumberVerciclesUrl + "/" + value, HttpOptions)
      .pipe(catchError(HandleError<HttpResponse<Object>>('PostChangeNumberVercicles')));
  }
  
  /** POST: PostChangeInLine */
  PostChangeInLine(): Observable<HttpResponse<Object>> {
    return this.http.post<HttpResponse<Object>>(PostChangeInLineUrl, HttpOptions)
      .pipe(catchError(HandleError<HttpResponse<Object>>('PostChangeInLine')));
  }

}
