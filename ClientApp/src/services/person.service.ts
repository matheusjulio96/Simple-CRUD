import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Person } from '../interfaces/person';

@Injectable({
  providedIn: 'root'
})
export class PersonService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  create(person: Person): Observable<any> {
    return this.http.post<any>(`${this.baseUrl}person/create`, person);
  }
  update(person: Person): Observable<any> {
    return this.http.post<any>(`${this.baseUrl}person/update`, person);
  }
  delete(id: number): Observable<any> {
    return this.http.post<any>(`${this.baseUrl}person/delete`, { id });
  }

  get(filter?: any) {
    return this.http.post<Person[]>(this.baseUrl + 'person', filter);
  }

  getById(id: number) {
    return this.http.post<Person>(this.baseUrl + `person/id`, { id });
  }
}
