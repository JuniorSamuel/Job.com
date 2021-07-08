import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatPaginatorModule} from '@angular/material/paginator';
import { MatTableModule } from '@angular/material/table';
import {MatSnackBarModule} from '@angular/material/snack-bar';
import {MatIconModule} from '@angular/material/icon';
// import {MatDialogModule} from '@angular/material/dialog';


@NgModule({
  declarations: [],
  imports: [
    CommonModule, 
    MatTableModule,
    MatPaginatorModule,
    MatSnackBarModule,
    MatIconModule,
    // MatDialogModule,
  ],

  exports : [
    MatTableModule,
    MatPaginatorModule,
    MatSnackBarModule,
    MatIconModule,
    // MatDialogModule,
  ]
})

export class MaterialModule { }

export const materialComponent = [
    MatTableModule,
    MatPaginatorModule
]