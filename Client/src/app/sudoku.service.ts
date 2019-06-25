import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Sudoku } from './models/sudoku.model';
import { HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type':  'application/json',
    'Authorization': 'my-auth-token'
  })
};

@Injectable({
  providedIn: 'root'
})
export class SudokuService {

  constructor(private http: HttpClient) { }

  addSudoku (sudoku: Sudoku): Observable<Sudoku> {
    return this.http.post<Sudoku>('http://localhost:56541/api/Sudoku', sudoku, httpOptions);
  }
}
