import { Observable, of } from 'rxjs';

export interface IError {
  error: {};
}

export function HandleError<T>(operation = 'operation', result?: T) {
  return (error: any): Observable<T> => {
    return of(error as T);
  };
}
