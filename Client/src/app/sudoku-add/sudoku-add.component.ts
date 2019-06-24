import { Component, OnInit } from '@angular/core';
import { SudokuService } from '../sudoku.service';

@Component({
  selector: 'app-sudoku-add',
  templateUrl: './sudoku-add.component.html',
  styleUrls: ['./sudoku-add.component.css']
})
export class SudokuAddComponent implements OnInit {

  values: string[] = [];
  sudokuObj = {
    board: ''
  };

  constructor(private service: SudokuService) { }

  ngOnInit() {
  }

  onSubmit() {
    console.log('submiting');
    for (let i = 0; i < 81; i++) {
      if (!this.values[i]) {
        this.sudokuObj.board += '0';
      } else {
        this.sudokuObj.board += this.values[i];
      }
    }

    this.service.postSudoku(this.sudokuObj).subscribe(
      res => {
        console.log(res);
      },
      err => {
        console.log(err);
      }
    );

  }

}
