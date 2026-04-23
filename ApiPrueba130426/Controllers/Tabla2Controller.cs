using Microsoft.AspNetCore.Mvc;
using ApiPrueba130426.Data;
using Microsoft.EntityFrameworkCore;
using ApiPrueba130426.Models;
using System.Collections.Immutable;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiPrueba130426.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Tabla1Controller : ControllerBase
    {
        private readonly AppDbContext _dbe;

        public Tabla1Controller(AppDbContext dbe)
        {
            _dbe = dbe;
        }






        // GET: api/<Tabla1Controller>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var cons = _db.Tabla2.ToListAsync();
            return Ok(new { exito = true, cons });
        }

        // GET api/<Tabla1Controller>/5
        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            var cons = await _db.Tabla2.Where(x => x.Id.Equals(Id)).ToListAsync();
            return Ok(new { exito = true, cons });
        }

        // POST api/<Tabla1Controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Tabla2 registros)
        {
            _db.Tabla2.Add(registros);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { Id = registros.Id },
                new
                {
                    ok = true,
                    mensaje = "registro creado exitosamente",
                    data = registros
                });
        }

        // PUT api/<Tabla1Controller>/5
        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(int Id, [FromBody] Tabla2 registros)
        {
            var consulta = await _db.Tabla1.FindAsync(Id);
            cons.Id = consulta.Id;
            cons. = registros.NumeroT;

            _db.Entry(consulta).State = EntityState.Modified;
            await _db.SaveChangesAsync();

            return Ok(
                new
                {
                    ok = true,
                    mensaje = "registro actualizado con exito",
                    data = registros.NumeroT,
                });





        }

        // DELETE api/<Tabla1Controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var consulta = await _db.FindAsync(id);
            _db.Tabla1.Remove(consulta);

            await _db.SaveChangesAsync();

            return Ok(
               new
               {
                   ok = true,
                   mensaje = "registro actualizado con exito",
                   data = consulta
               });


        }
    }
}

