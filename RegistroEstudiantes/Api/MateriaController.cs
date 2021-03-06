﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegistroEstudiantes.Data;
using RegistroEstudiantes.Model;

namespace RegistroEstudiantes.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriaController : ControllerBase
    {
        private readonly IMateriaService service;

        public MateriaController(IMateriaService service)
        {
            this.service = service;
        }

        [Route("HolaMundo")]
        public string HolaMundo() 
        {
            return "Hola Desde Materia Controler";
        }

        [Route("Materias")]
        public List<Materia> GetMaterias()
        {
            var materias = service.GetMateriasPorNombre("");

            return materias.ToList();
        }
    }
}
