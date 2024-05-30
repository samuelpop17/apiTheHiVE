﻿using ApiProyectoConjuntoAWSRedSocial.Models;
using ApiProyectoConjuntoAWSRedSocial.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProyectoConjuntoAWSRedSocial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuscadorController : ControllerBase
    {
        private RepositoryTheHive repo;

        public BuscadorController(RepositoryTheHive repo)
        {
            this.repo = repo;
        }


        [Authorize]
        [HttpGet]
        [Route("[action]/{query}")]
        public ActionResult<List<Usuario>> BuscarUsuarios(string query)
        {
            var usuariosEncontrados = this.repo.BuscarUsuarios(query);
            return usuariosEncontrados;
        }



    }
}

