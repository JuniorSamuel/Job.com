import { ApiService } from 'src/app/servicios/Api/api.service';
import { Component, OnInit, ViewChild } from '@angular/core';
import {MatDialog, MatDialogConfig} from '@angular/material/dialog';
import { Form, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-agregarcategoria',
  templateUrl: './agregarcategoria.component.html',
  styleUrls: ['./agregarcategoria.component.css']
})
export class AgregarcategoriaComponent implements OnInit {
  // constructor(
  //   private service: ApiService, private dialog: MatDialog
  // ) { }
  categoriaForm = new FormGroup({
    nombre : new FormControl(['', Validators.required])
  });

  constructor(private dialog: MatDialog, private formBuilder: FormBuilder) {
    
  }
  ngAfterViewInit(): void {
  }
  
  ngOnInit(): void {
    
  }

  onCreate(){
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = "50%";
    this.dialog.open(AgregarcategoriaComponent,dialogConfig);
  }

  onSubmit(){

  }

}
