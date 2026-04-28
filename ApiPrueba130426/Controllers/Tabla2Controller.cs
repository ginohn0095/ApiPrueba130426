using ApiPrueba130426.Data;
using ApiPrueba130426.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;
using System.Text.Json;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiPrueba130426.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Tabla2Controller : ControllerBase
    {
        private readonly AppDbContext _db;

        public Tabla2Controller(AppDbContext db)
        {
            _db = db;
        }

        // GET: api/<Tabla2Controller>
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
            var consulta = await _db.Tabla2.FindAsync(Id);
            consulta.Id = registros.Id;
            consulta.NumeroT = registros.NumeroT;
            consulta.Apellido = registros.Apellido;
            consulta.pelos = registros.pelos;

            _db.Entry(consulta).State = EntityState.Modified;
            await _db.SaveChangesAsync();

            return Ok(
                new
                {
                    ok = true,
                    mensaje = "registro actualizado con exito",
                    data = registros
                });





        }

        // DELETE api/<Tabla2Controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var consulta = await _db.Tabla2.FindAsync(id);
            _db.Tabla2.Remove(consulta);

            await _db.SaveChangesAsync();

            return Ok(
               new
               {
                   ok = true,
                   mensaje = "registro eliminado con exito",
                   data = consulta
               });


        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchTabla2(int id, [FromBody] Dictionary<string, object> actualizar)
        {
            var registro = await _db.Tabla2.FindAsync(id);
            foreach (var campo in actualizar)
            {
                switch (campo.Key.ToLower())
                {
                    case "apellido":
                        registro.Apellido = campo.Value.ToString();
                        break;
                    case "numerot":
                        registro.NumeroT = Convert.ToInt32(campo.Value);
                        break;
                    case "pelos":
                        registro.pelos = campo.Value.ToString();
                        break;
                }
                await _db.SaveChangesAsync();


            }
            return Ok(
                new
                {
                    OK = true,
                    mensaje = "Registro actualizado exitosamente",
                    data = registro
                });

        }

        private int ConvierteAEntero(object valor)
        {
            if (valor == null)
            {
                return 0;
            }
            if (valor is JsonElement elemntoJson)
            {
                return elemntoJson.GetInt32();
            }
            if (valor is string cadenaValor)
            {
                return Convert.ToInt32(cadenaValor);
            }
            return Convert.ToInt32(valor);
        }
    }
}


