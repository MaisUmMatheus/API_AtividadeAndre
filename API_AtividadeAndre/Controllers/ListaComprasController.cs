using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_AtividadeAndre.Models;
using API_LINGUILEARN.Models;

namespace API_AtividadeAndre.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListaComprasController : ControllerBase
    {
        public ApiDbContext _context;

        public ListaComprasController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/ListaCompras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ListaCompras>>> GetListaCompras()
        {
            return await _context.ListaCompras.ToListAsync();
        }

        // GET: api/ListaCompras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ListaCompras>> GetListaCompras(int id)
        {
            var listaCompras = await _context.ListaCompras.FindAsync(id);

            if (listaCompras == null)
            {
                return NotFound();
            }

            return listaCompras;
        }

        // PUT: api/ListaCompras/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutListaCompras(int id, ListaCompras listaCompras)
        {
            if (id != listaCompras.Id)
            {
                return BadRequest();
            }

            _context.Entry(listaCompras).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ListaComprasExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // GET: api/ListaCompras/user/5
        // GET: api/ListaCompras/user/5
        [HttpGet("user/{Id}")]
        public async Task<ActionResult> GetComprasByUser(int Id)
        {
            // Verifica se o usuário existe
            if (!await _context.Users.AnyAsync(u => u.Id == Id))
            {
                return NotFound("Usuário não encontrado");
            }

            // Retorna diretamente o resultado da consulta com JOIN
            return Ok(await (from lc in _context.ListaCompras
                             join u in _context.Users on lc.UserId equals u.Id
                             where lc.UserId == Id
                             select new
                             {
                                 lc.Id,
                                 lc.Itens,
                                 lc.Comprado,
                                 lc.UserId,
                                 u.Name,
                                 u.password
                             }).ToListAsync());
        }




        // POST: api/ListaCompras
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{UserId}")]
        public async Task<ActionResult<ListaCompras>> PostListaCompras(int UserId, ListaCompras listaCompras)
        {
            var user = await _context.Users.FindAsync(UserId);

            if (user == null)
            {
                return NotFound("Usuário não encontrado");
            }

            _context.ListaCompras.Add(listaCompras);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ListaComprasExists(listaCompras.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetListaCompras", new { id = listaCompras.Id }, listaCompras);
        }


        // DELETE: api/ListaCompras/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteListaCompras(int id)
        {
            var listaCompras = await _context.ListaCompras.FindAsync(id);
            if (listaCompras == null)
            {
                return NotFound();
            }

            _context.ListaCompras.Remove(listaCompras);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ListaComprasExists(int id)
        {
            return _context.ListaCompras.Any(e => e.Id == id);
        }
    }
}
