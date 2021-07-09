import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-config',
  templateUrl: './config.component.html',
  styleUrls: ['./config.component.css']
})
export class ConfigComponent implements OnInit {

  formConf = this.formBuilder.group({
    fila: ['']
  });

  constructor(private formBuilder: FormBuilder, private cookie: CookieService){
    this.formConf.controls['fila'].setValue(parseInt(cookie.get('fila')));
  }

  ngOnInit(): void {
  }

  onSubmit(){
    console.log(this.formConf.value.fila)
    this.cookie.set('fila', this.formConf.value.fila+'')
  }

}
