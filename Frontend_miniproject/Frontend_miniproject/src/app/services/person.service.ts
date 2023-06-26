import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Person } from '../entities/Person';

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


}
