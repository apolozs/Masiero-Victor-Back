using System.Collections.Generic;
using AndreyPerez.Data;
using AndreyPerez.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System;

namespace AndreyPerez.Controllers
{
    [ApiController]
    [Route("api/usuario")]
    public class UsuarioController : ControllerBase
    
    {

        private readonly DataContext _context;

        //Construtor
        public UsuarioController(DataContext context) => _context = context;

        //POST /api/usuario/create
        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] Usuario usuario)
        {
            try
            {
                if(usuario.Nome == null || usuario.Senha == null || usuario.Cpf == null)
                    throw new Exception("Não foi possivel gerar um usuario por falta de dados");
                
                _context.Usuarios.Add(usuario);
                _context.SaveChanges();
                return Created("", usuario);
            }
            catch (Exception ex)
            {
                
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message );
           
            }

        }

        
        //GET /api/usuario/list
        [HttpGet]
        [Route("list")]
        public List<Usuario> list() 
        {
            return _context.Usuarios.ToList();
        }


    }

}