import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Observable, InteropObservable, BehaviorSubject } from 'rxjs';
import { catchError, tap, map } from 'rxjs/operators';

import { MessageService } from '../../message/message.service';
import { User, IUserLogin, IToken, IChangePassword } from './user';
import { HttpOptions, RegisterUrl, LoginUrl, ValuesUrl, TestUrl, LogoutUrl, ChangePassUrl, ValidateCookieUrl } from '../../global/urls';
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

  /** GET: get Test string after login */
  getTest(): Observable<HttpResponse<Object>> {
    return this.http.get<HttpResponse<Object>>(TestUrl, HttpOptions)
      .pipe(catchError(HandleError<HttpResponse<Object>>('Login')));
  }

  /** POST: get Token from server */
  getToken(user: IUserLogin): Observable<HttpResponse<Object>> {
    return this.http.post<HttpResponse<Object>>(LoginUrl, BodyEncode<IUserLogin>(user), HttpOptions)
      .pipe(catchError(HandleError<HttpResponse<Object>>('Login')));
  }

  /** POST: add a new user to the server */
  registerUser(user: User): Observable<User | IError> {
    return this.http.post<User>(RegisterUrl, BodyEncode<User>(user), HttpOptions)
      .pipe(catchError(HandleError<IError>('Register', this._error)));
  }

  /** POST: Logout */
  postLogOut(): Observable<HttpResponse<Object>> {
    return this.http.post<HttpResponse<Object>>(LogoutUrl, HttpOptions)
      .pipe(catchError(HandleError<HttpResponse<Object>>('Login')));
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
  //////// authentication //////////

  loggedIn(): boolean {
    return !!localStorage.getItem('token');
  }

  getValues(): Observable<any> {
    return this.http.get<any>(ValuesUrl, HttpOptions);
  }
}
