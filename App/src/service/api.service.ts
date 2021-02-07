import { Injectable } from '@angular/core';
import { Observable, of, throwError } from 'rxjs';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { catchError, tap, map } from 'rxjs/operators';
import { User } from 'src/model/user';
import { Deposit } from 'src/model/deposit';
import { Payment } from 'src/model/payment';
import { Transfer } from 'src/model/transfer';
import { Withdraw } from 'src/model/withdraw';
import { CurrentAccount } from 'src/model/currentaccount';
import { HistoricCurrentAccount } from 'src/model/historiccurrentaccount';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};
const apiUrlUser = 'http://localhost:5000/api/users';
const apiUrlCurrentAccount = 'http://localhost:5000/api/currentaccount';
const apiUrlHistoricCurrentAccount = 'http://localhost:5000/api/historiccurrentaccount';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http: HttpClient) { }

  getUsers(): Observable<User[]> {
    return this.http.get<User[]>(apiUrlUser)
      .pipe(
        tap(users => console.log('get users')),
        catchError(this.handleError('getUsers', []))
      );
  }

  getUser(id: string): Observable<User> {
    const url = `${apiUrlUser}/${id}`;
    return this.http.get<User>(url).pipe(
      tap(_ => console.log('get user by id=${id}')),
      catchError(this.handleError<User>('getUser id=${id}'))
    );
  }

  addUser(user: any): Observable<User> {
    return this.http.post<User>(apiUrlUser, user, httpOptions).pipe(
      tap((user: User) => console.log('add user w/ id=${user.id}')),
      catchError(this.handleError<User>('addUser'))
    );
  }

  updateUser(id: any, user: any): Observable<any> {
    const url = `${apiUrlUser}/${id}`;
    return this.http.put(url, user, httpOptions).pipe(
      tap(_ => console.log('update user by id=${id}')),
      catchError(this.handleError<any>('updateUser'))
    );
  }

  deleteUser(id: any): Observable<User> {
    const url = `${apiUrlUser}/delete/${id}`;
    return this.http.delete<User>(url, httpOptions).pipe(
      tap(_ => console.log('delete user by id=${id}')),
      catchError(this.handleError<User>('deleteUser'))
    );
  }

  getCurrentAccount(userId: string): Observable<CurrentAccount> {
    const url = `${apiUrlCurrentAccount}/${userId}`;
    return this.http.get<CurrentAccount>(url).pipe(
      tap(_ => console.log('get current account by userId=${userId}')),
      catchError(this.handleError<CurrentAccount>('getCurrentAccount userId=${userId}'))
    );
  }

  addDeposit(userId: string, deposit: any): Observable<any> {
    const url = `${apiUrlCurrentAccount}/deposit/${userId}`;
    return this.http.put(url, deposit, httpOptions).pipe(
      tap(_ => console.log('update current account by deposit userId=${userId}')),
      catchError(this.handleError<Deposit>('addDeposit'))
    );
  }

  addPayment(userId: string, payment: any): Observable<any> {
    const url = `${apiUrlCurrentAccount}/payment/${userId}`;
    return this.http.put(url, payment, httpOptions).pipe(
      tap(_ => console.log('update current account by payment userId=${userId}')),
      catchError(this.handleError<Payment>('addPayment'))
    );
  }

  addTransfer(userId: string, transfer: any): Observable<any> {
    const url = `${apiUrlCurrentAccount}/transfer/${userId}`;
    return this.http.put(url, transfer, httpOptions).pipe(
      tap(_ => console.log('update current account by transfer userId=${userId}')),
      catchError(this.handleError<Transfer>('addTransfer'))
    );
  }

  addWithdraw(userId: string, withdraw: any): Observable<any> {
    const url = `${apiUrlCurrentAccount}/withdraw/${userId}`;
    return this.http.put(url, withdraw, httpOptions).pipe(
      tap(_ => console.log('update current account by withdraw userId=${userId}')),
      catchError(this.handleError<Withdraw>('addWithdraw'))
    );
  }

  addApplyIncome(): Observable<CurrentAccount> {
    return this.http.post<CurrentAccount>(apiUrlCurrentAccount + "applyincome", httpOptions).pipe(
      tap((Income: CurrentAccount) => console.log('add withdraw w/ id=${user.id}')),
      catchError(this.handleError<CurrentAccount>('addWithdraw'))
    );
  }

  getHistoric(userId: string): Observable<HistoricCurrentAccount[]> {
    const url = `${apiUrlHistoricCurrentAccount}/${userId}`
    return this.http.get<HistoricCurrentAccount[]>(url)
      .pipe(
        tap(users => console.log('get historic')),
        catchError(this.handleError('getHistoric', []))
      );
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error);
      return of(result as T);
    };
  }
}
