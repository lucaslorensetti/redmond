import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private httpClient: HttpClient) { }

  get<T>(url: string): Observable<T> {
    return this.httpClient.get<T>(environment.apiUrl + url);
  }

  post<T>(url: string, value: any): Observable<T> {
    return this.httpClient.post<T>(environment.apiUrl + url, value);
  }

  put<T>(url: string, value: any): Observable<T> {
    return this.httpClient.put<T>(environment.apiUrl + url, value);
  }

  delete<T>(url: string): Observable<T> {
    return this.httpClient.delete<T>(environment.apiUrl + url);
  }
}
