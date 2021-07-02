using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Respuestas
{
    public class ApiRespuesta<T>
    {
        public T Dato { get; set; }
        public ApiRespuesta(T dato){
            Dato = dato;
        }
    }
}
