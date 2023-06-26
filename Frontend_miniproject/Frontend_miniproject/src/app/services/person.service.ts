import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Person } from '../entities/Person';
import { Observable, catchError, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PersonService {

  constructor(private client: HttpClient) {
    this.GetAll();
  }

  public people: Person[] = [];
  private baseURL: string = "https://localhost:5000/api/Person"

  GetAll() {
    return this.client.get<Person[]>(this.baseURL).subscribe(res => this.people = res)
  }

  CreatePerson(person: Person) {
    return this.client.post<Person[]>(this.baseURL, person)
      .pipe(
        catchError((error: HttpErrorResponse) => {
          console.error('An error occurred:', error);
          return throwError('Something went wrong. Please try again later.');
        })
      )
      .subscribe(
        (response: Person[]) => {
          console.log('Person created:', response);
        },
        (error: any) => {
          console.error('An error occurred:', error);
        }
      );
  }


}
