import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Profissional } from '../model/Profissional';
import { Observable } from 'rxjs';

@Injectable()
export class ProfissionalService {

  baseUrl = 'http://localhost:5076/api/Profissional'
  constructor(private http: HttpClient) {}

  getProfissionais():Observable<Profissional[]>{
    return this.http.get<Profissional[]>(this.baseUrl);
  }

  getProfissionalById(id:number):Observable<Profissional>{
    return this.http.get<Profissional>(`${this.baseUrl}/${id}`);
  }
}
