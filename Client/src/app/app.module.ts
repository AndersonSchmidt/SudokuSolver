import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { SudokuFormComponent } from './sudoku-form/sudoku-form.component';
import { SudokuService } from './sudoku.service';
import { SidebarComponent } from './sidebar/sidebar.component';

@NgModule({
  declarations: [
    AppComponent,
    SudokuFormComponent,
    SidebarComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [SudokuService],
  bootstrap: [AppComponent]
})
export class AppModule { }
