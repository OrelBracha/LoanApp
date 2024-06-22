import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../src/environments/environments';

export interface LoanRequest {
  clientId: number;
  amount: number;
  periodInMonths: number;
}

export interface LoanResponse {
  totalAmount: number;
  interest: number;
}

@Injectable({
  providedIn: 'root'
})
export class LoanService {

  private apiUrl = `${environment.apiUrl}/Loan/calculate`;

  constructor(private http: HttpClient) { }

  calculateLoan(request: LoanRequest): Observable<LoanResponse> {
    return this.http.post<LoanResponse>(this.apiUrl, request);
  }
}
