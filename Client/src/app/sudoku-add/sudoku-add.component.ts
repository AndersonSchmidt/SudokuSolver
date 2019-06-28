import { Component, OnInit } from '@angular/core';
import { SudokuService } from '../sudoku.service';
import { Sudoku } from '../models/sudoku.model';

@Component({
  selector: 'app-sudoku-add',
  templateUrl: './sudoku-add.component.html',
  styleUrls: ['./sudoku-add.component.css']
})
export class SudokuAddComponent implements OnInit {

  board: string[] = []; // Array of board values
  sudoku: Sudoku;

  constructor(private service: SudokuService) { }

  ngOnInit() {
    this.sudoku = new Sudoku();
  }

  onSubmit() {
    this.sudoku = new Sudoku();

    for (let i = 0; i < 81; i++) {
        this.sudoku.board += !this.board[i] ? '0' : this.board[i];
    }

    this.service.addSudoku(this.sudoku).subscribe(res => this.refreshBoard(res));
  }

  refreshBoard(sudoku: Sudoku) {
    this.sudoku = sudoku;
    this.board = sudoku.solvedBoard.split('');
  }

  onClearBoard() {
    this.board = [];
    this.sudoku = new Sudoku;
  }

}
