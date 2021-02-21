import { Injectable } from '@angular/core';
import { User } from './user-model';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { throwError } from 'rxjs';

@Injectable({
    providedIn: 'root'
  })

  export class UserDetailsService {

    activeUsers: Array<User>;
    totalUsers: Array<User>;

    private readonly baseUrl = "http://localhost:50481/api/Home";
    httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    
    constructor (private http: HttpClient) {
      this.activeUsers = new Array<User>();
      this.totalUsers = new Array<User>();
    } 
    
    getActiveUsers() {
      return this.http.get(`${this.baseUrl}`+ "/ActiveUsers")
        .toPromise();
    }
    
    getUsers() {
      return this.http.get(`${this.baseUrl}/Users`, this.httpOptions)
        .toPromise()
        .then(res => this.totalUsers = res as User[]);
    }

    setActiveUser(id:number){
      return this.http.put(`${this.baseUrl}/Activate/${id}`,this.httpOptions)
    }

    setDisActiveUser(id:number){
      return this.http.put(`${this.baseUrl}/DisActivate/${id}`, this.httpOptions)
    }

    isChecked(isActive:boolean, id:number){
      isActive ? this.setActiveUser(id) : this.setDisActiveUser(id);
    }

    errorHandler(error:any) {
      let errorMessage = '';
      if(error.error instanceof ErrorEvent) {
        // Get client-side error
        errorMessage = error.error.message;
      } else {
        // Get server-side error
        errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
      }
      console.log(errorMessage);
      return throwError(errorMessage);
   }

  }