﻿using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Servicios.Contracts
{
    public interface ISolicitudServicios
    {

        Task<List<Solicitud>> GetSolicitudAsync();
        Task<Solicitud> GetSolicitudByIdAsync(int SolicitudId);
        Task<List<Solicitud>> GetSolicitudByUsuarioAsync(int UsuarioId);
        Task<List<Solicitud>> GetSolicitudByVacanteAsync(int VacanteId);
        Task<Solicitud> AddSolicitudAsync(Solicitud solicitud);
        Task<Solicitud> UpdateSolicitudAsync(Solicitud solicitud);
        Task DeleteSolicitudAsync(int SolicitudId);
    }
}
