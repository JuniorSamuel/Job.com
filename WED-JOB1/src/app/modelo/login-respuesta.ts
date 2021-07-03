export interface ILoginRespuesta {
         mensaje : string,
         exito : number,
         data : {
           idUsuario : number,
           idRol : number,
           nombre :  string ,
           cedula : number,
           telefono : number,
           correo :  string,
           token :  string 
        }
}
