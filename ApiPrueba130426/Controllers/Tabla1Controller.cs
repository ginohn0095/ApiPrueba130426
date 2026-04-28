using Microsoft.AspNetCore.Mvc;
using ApiPrueba130426.Data;
using Microsoft.EntityFrameworkCore;
using ApiPrueba130426.Models;
using System.Text.Json;

namespace ApiPrueba130426.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Tabla1Controller : ControllerBase
    {
        private readonly AppDbContext _db;

        public Tabla1Controller(AppDbContext db)
        {
            _db = db;
        }

        // GET: api/<Tabla1Controller>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var consulta = _db.Tabla1.ToListAsync();
            return Ok(new { exito = true, consulta });
        }

        // GET api/<Tabla1Controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var consulta = _db.Tabla1.Where(x => x.Id.Equals(id)).ToListAsync();
            return Ok(new { exito = true, consulta });
        }

        // POST api/<Tabla1Controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Tabla1 registro)
        {
            _db.Tabla1.Add(registro);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { Id = registro.Id },
                new
                {
                    OK = true,
                    mensaje = "Registro creado exitosamente",
                    data = registro
                });
        }

        // PUT api/<Tabla1Controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Tabla1 registro)
        {
            var consulta = await _db.Tabla1.FindAsync(id);
            consulta.Id = registro.Id;
            consulta.Nombre = registro.Nombre;
            consulta.Cantidad = registro.Cantidad;
            consulta.Descripcion = registro.Descripcion;

            _db.Entry(consulta).State = EntityState.Modified;
            await _db.SaveChangesAsync();

            return Ok(
                new
                {
                    OK = true,
                    mensaje = "Registro creado exitosamente",
                    data = registro
                });
        }

        // DELETE api/<Tabla1Controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var consulta = await _db.Tabla1.FindAsync(id);
            _db.Tabla1.Remove(consulta);

            await _db.SaveChangesAsync();

            return Ok(
                new
                {
                    OK = true,
                    mensaje = "Registro creado exitosamente",
                    data = consulta
                });
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchTabla1(int id, [FromBody] Dictionary<string, object> actualizar)
        {
            var registro = await _db.Tabla1.FindAsync(id);
            foreach (var campo in actualizar) 
            {
                switch (campo.Key.ToLower())
                {
                    case "nombre": 
                        registro.Nombre = campo.Value.ToString();
                        break;
                    case "cantidad":
                        registro.Cantidad = Convert.ToInt32(campo.Value);
                        break;
                    case "descripcion":
                        registro.Descripcion = campo.Value.ToString();
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