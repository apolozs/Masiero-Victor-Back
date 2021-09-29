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
    [Route("api/pessoa")]
    public class PessoaController : ControllerBase
    
    {

        private readonly DataContext _context;

        //Construtor
        public PessoaController(DataContext context) => _context = context;

        //POST /api/pessoa/create
        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] Pessoa pessoa)
        {
            try
            {
                if(pessoa.Nome == null || pessoa.GostoMusical == null || pessoa.Profissao == null || pessoa.Genero ==  null)
                    throw new Exception("Não foi possivel gerar um pessoa por falta de dados");
                
                _context.Pessoas.Add(pessoa);
                _context.SaveChanges();
                return Created("", pessoa);
            }
            catch (Exception ex)
            {
                
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message );
           
            }

        }

        
        //GET /api/pessoa/list
        [HttpGet]
        [Route("list")]
        public List<Pessoa> list() 
        {
            return _context.Pessoas.ToList();
        }


    }

}