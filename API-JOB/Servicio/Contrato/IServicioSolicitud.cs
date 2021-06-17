using API_JOB.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_JOB.Servicio.Contrato
{
    interface IServicioSolicitud
    {
        Task<List<Solicitud>> getSolicitudAsync();
        Task<Solicitud> getIdAsync(int id);
        Task Eliminar(int id);
        Task Actualizar(Solicitud solicitud);
    }
}
