import { Component, OnInit } from '@angular/core';
import { SudokuService } from '../sudoku.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-sudoku-form',
  templateUrl: './sudoku-form.component.html',
  styleUrls: ['./sudoku-form.component.css']
})
export class SudokuFormComponent implements OnInit {

  values: number[] = [];
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
        console.log('Success');
      },
      err => {
        console.log(err);
      }
    );

  }

}
