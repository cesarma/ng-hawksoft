import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
   
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
  
import { Contact } from './contact';
import { Router } from '@angular/router';
   
@Injectable({
  providedIn: 'root'
})
export class contactService {
   
  private apiURL = "http://localhost:3298/";

  //http://localhost:3298/api/ContactsHawksofts
   
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }
  
  //constructor(private httpClient: HttpClient) { }


  _baseUrl: string;
  _http: HttpClient;
  
  constructor(
    public postService: contactService,
    private router: Router, httpClient: HttpClient, @Inject('BASE_URL') baseUrl: string
  ) {
    this._baseUrl = baseUrl;
    this._http = httpClient;
  }

   
  getAll(): Observable<Contact[]> {
    return this._http.get<Contact[]>(this.apiURL + '/contacts/')
    .pipe(
      catchError(this.errorHandler)
    )
  }
   
  create(contact): Observable<Contact> {
    return this._http.post<Contact>(this.apiURL + 'api/ContactsHawksofts', JSON.stringify(contact), this.httpOptions)
    .pipe(
      catchError(this.errorHandler)
    )
  }  
   
  find(id): Observable<Contact> {
    return this._http.get<Contact>(this.apiURL + '/contacts/' + id)
    .pipe(
      catchError(this.errorHandler)
    )
  }
   
  update(id, contact): Observable<Contact> {
    return this._http.put<Contact>(this.apiURL + '/contacts/' + id, JSON.stringify(contact), this.httpOptions)
    .pipe(
      catchError(this.errorHandler)
    )
  }
 
  delete(id){
    return this._http.delete<Contact>(this.apiURL + 'api/ContactsHawksofts/' + id, this.httpOptions)
    .pipe(
      catchError(this.errorHandler)
    )
  }
    
  
  errorHandler(error) {
    let errorMessage = '';
    if(error.error instanceof ErrorEvent) {
      errorMessage = error.error.message;
    } else {
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    return throwError(errorMessage);
 }
}
