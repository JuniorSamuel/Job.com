import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'filtroTabla'
})
export class FiltroTablaPipe implements PipeTransform {

  transform(value: any, args: any): any {

   const resul = [];
   for(const elemento of value){
     if (elemento.nombre.toLowerCase().indexOf(args.toLowerCase()) > -1){
       resul.push(elemento);
     }
   }

    return resul;
  }
}
