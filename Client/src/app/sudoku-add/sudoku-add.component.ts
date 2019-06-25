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

  sudoku: Sudoku = new Sudoku();

  constructor(private service: SudokuService) { }

  ngOnInit() {
  }

  onSubmit() {

    for (let i = 0; i < 81; i++) {
        this.sudoku.board += !this.boardValues[i] ? '0' : this.boardValues[i];
    }

    console.log(this.sudoku);

    this.service.addSudoku(this.sudoku).subscribe(res => this.refreshBoard(res));

  }

  refreshBoard(sudoku: Sudoku) {
    this.boardValues = sudoku.solvedBoard.split('');
  }

}
