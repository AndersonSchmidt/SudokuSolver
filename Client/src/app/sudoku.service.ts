import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class SudokuService {

  constructor(private http: HttpClient) { }

  postSudoku(sudoku) {
    return this.http.post('http://localhost:56541/api/Sudoku', sudoku);
  }
}
