import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { IPerson } from '../entities/Person';
import { Observable, catchError, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PersonService {

  constructor(private client: HttpClient) {
    this.GetAll();
  }

  public people: IPerson[] = [];
  private baseURL: string = "https://localhost:5000/api/Person"

  GetAll() {
    return this.client.get<IPerson[]>(this.baseURL).subscribe(res => this.people = res)
  }

  CreatePerson(person: IPerson) {
    return this.client.post<IPerson[]>(this.baseURL, person)
      .pipe(
        catchError((error: HttpErrorResponse) => {
          console.error('An error occurred:', error);
          return throwError('Something went wrong. Please try again later.');
        })
      )
      .subscribe(
        (response: IPerson[]) => {
          console.log('Person created:', response);
        },
        (error: any) => {
          console.error('An error occurred:', error);
        }
      );
  }


}
