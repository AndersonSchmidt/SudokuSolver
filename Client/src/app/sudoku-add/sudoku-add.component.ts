import { Component, OnInit } from '@angular/core';
import { SudokuService } from '../sudoku.service';
import { Sudoku } from '../models/sudoku.model';

@Component({
  selector: 'app-sudoku-add',
  templateUrl: './sudoku-add.component.html',
  styleUrls: ['./sudoku-add.component.css']
})
export class SudokuAddComponent implements OnInit {

  boardValues: string[] = [];
  sudoku: Sudoku;

  constructor(private service: SudokuService) { }

  ngOnInit() {
  }

  onSubmit() {
    this.sudoku = new Sudoku();

    for (let i = 0; i < 81; i++) {
        this.sudoku.board += !this.boardValues[i] ? '0' : this.boardValues[i];
    }

    this.service.addSudoku(this.sudoku).subscribe(res => this.refreshBoard(res));
  }

  refreshBoard(sudoku: Sudoku) {
    this.boardValues = sudoku.solvedBoard.split('');
  }

  clearBoard() {
    this.boardValues = [];
  }

}
