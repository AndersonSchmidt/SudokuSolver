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
  array = Array(81);    // Just an empty array to be used by the ngFor

  constructor(private service: SudokuService) { }

  ngOnInit() {
    this.sudoku = new Sudoku();
  }

  onSubmit() {
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

  boardCellClasses(i: number) {
    return {
      'selectedItem': this.sudoku.board.length && this.sudoku.board[i] === this.sudoku.solvedBoard[i],
      'horiMargin': [18, 45].includes(i),
      'vertMargin': [2, 5].includes(i),
      'grid-item': true
    };
  }

}
