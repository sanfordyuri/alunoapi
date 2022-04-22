using AlunoApi.Data;
using AlunoApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Web.Http.Cors;

namespace AlunoApi.Controllers
{

    [ApiController]
    [Route("Aluno")]
    [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
    public class AlunoController : ControllerBase
    {

        public AlunoContext _context;
        public AlunoController(AlunoContext _context)
        {
            this._context = _context;  
        }

        [HttpPost]
        public IActionResult CriarAluno([FromBody] Aluno aluno)
        {
            _context.alunos.Add(aluno);
            _context.SaveChanges();
            return CreatedAtAction(nameof(PesquisarAlunoPorId), new { Id = aluno.Id }, aluno);
        }

        [HttpGet]

        public IActionResult RetornarAlunos()
        {
            return Ok(_context.alunos);
        }

        [HttpGet("{id}")]
        public IActionResult PesquisarAlunoPorId(Guid Id)
        {
            Aluno aluno = _context.alunos.FirstOrDefault(_aluno => _aluno.Id == Id);
            if(aluno != null)
            {
                return Ok(aluno);
            }
            return NotFound(aluno);
        }

        [HttpDelete("{id}")]
        public IActionResult RemoverAlunoPorId(Guid Id)
        {
            Aluno aluno = _context.alunos.FirstOrDefault(_aluno => _aluno.Id == Id);
            if (aluno != null)
            {
                _context.Remove(aluno);
                _context.SaveChanges();
                return NoContent();
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult EditarAlunoPorId(Guid Id, [FromBody] Aluno novoAluno)
        {
            Aluno aluno = _context.alunos.FirstOrDefault(_aluno => _aluno.Id == Id);
            if (aluno != null)
            {
                aluno.CPF = novoAluno.CPF;
                aluno.Nome = novoAluno.Nome;
                aluno.Email = novoAluno.Email;
                aluno.Telefone = novoAluno.Telefone;
                aluno.Nascimento = novoAluno.Nascimento;
                _context.SaveChanges();
                return NoContent();
            }
            return NotFound();
        }

    }
}
