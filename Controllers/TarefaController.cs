using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Models;

namespace API.Controllers;

[Route("api/tarefa")]
[ApiController]
public class TarefaController : ControllerBase
{
    private readonly AppDataContext _context;

    public TarefaController(AppDataContext context) =>
        _context = context;

    // GET: api/tarefa/listar
    [HttpGet]
    [Route("listar")]
    public IActionResult Listar()
    {
        try
        {
            List<Tarefa> tarefas = _context.Task.Include(x => x.Cate).ToList();
            return Ok(tarefas);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    [Route("listarNaoConcluidas")]
    public IActionResult TarefasNaoConcluidas()
    {
        try
        {
        List<Tarefa> tarefas = _context.Task.Where(t => t.SttsId == 1 || t.SttsId == 2).ToList();
        return Ok(tarefas);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    [Route("listarConcluidas")]
    public IActionResult TarefasConcludias()
    {
        try
        {
        List<Tarefa> tarefas = _context.Task.Where(t => t.SttsId == 3).ToList();
        return Ok(tarefas);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPatch]
    [Route("atualizar/{id}")]
    public IActionResult Atualizar(int id)
    {
        try
        {
            Tarefa tarefaExistente = _context.Task.Find(id) ?? throw new InvalidOperationException($"Tarefa com id {id} não encontrado");

                 
            if (tarefaExistente != null)
            {
                if(tarefaExistente.SttsId == 1){
                    tarefaExistente.SttsId = 2;
                     _context.SaveChanges();
                    return Ok(tarefaExistente);
                }else if(tarefaExistente.SttsId == 2){
                    tarefaExistente.SttsId = 2;
                    _context.SaveChanges();
                    return Ok(tarefaExistente);
                }else if(tarefaExistente.SttsId == 3){
                    tarefaExistente.SttsId = 1;
                    _context.SaveChanges();
                    return Ok(tarefaExistente);
                }
                
            }
            return NotFound();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }



    // POST: api/tarefa/cadastrar
    [HttpPost]
    [Route("cadastrar")]
    public IActionResult Cadastrar([FromBody] Tarefa tarefa)
    {
        try
        {
            Categoria? categoria = _context.Cate.Find(tarefa.CateId);
            if (categoria == null)
            {
                return NotFound();
            }
            tarefa.Cate = categoria;
            _context.Task.Add(tarefa);
            _context.SaveChanges();
            return Created("", tarefa);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
