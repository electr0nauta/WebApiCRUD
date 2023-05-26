using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiPortfolio.Entidades;
using WebApiPortfolio.Filtros;

namespace WebApiPortfolio.Controllers
{
    [ApiController]
    [Route("api/autores")]
    //[Authorize]//filtro de autorizacion que afecta a todas acciones de mi controlador
    public class AutoresController: ControllerBase
    {
        private readonly ApplicationDbContext context;
        public AutoresController(ApplicationDbContext context)
        {
            this.context = context;
        }

        

        [HttpGet]// api/autores
        public async Task<ActionResult<List<Autor>>> Get() 
        {
            return await context.Autores.ToListAsync();
        }

        
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Autor>> Get(int id)
        {
            var autor = await context.Autores.FirstOrDefaultAsync(x => x.Id == id);

            if (autor == null)
            {
                return NotFound();
            }

            return autor;
        }

        [HttpGet("{nombre}")]
        public async Task<ActionResult<Autor>> Get(string nombre)
        {
            var autor = await context.Autores.FirstOrDefaultAsync(x => x.Nombre.Contains(nombre));

            if (autor == null)
            {
                return NotFound();
            }

            return autor;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Autor autor) 
        {
            //quiero hacer una validacion desde el controlador directamente hacia la base de datos, para validar que no exista un autor con el mismo nombre antes de crear un nuevo registro.
            var existeAutorConElMismoNombre = await context.Autores.AnyAsync(x => x.Nombre == autor.Nombre);

            if (existeAutorConElMismoNombre) 
            {
                return BadRequest($"Ya existe un autor con el nombre {autor.Nombre}");
            }
            //****************************************************************************************


            context.Add(autor);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")] //api/autores/1, o 2, o 3, etc...
        public async Task<ActionResult> Put(Autor autor, int id) 
        {
            if (autor.Id != id) 
            {
                return BadRequest("El id del autor no coincide con el id de la url");
            }
            context.Update(autor);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]//api/autores/2 
        public async Task<ActionResult> Delete(int id) 
        {
            var existe = await context.Autores.AnyAsync(x => x.Id == id);

            if (!existe) 
            {
                return NotFound();
            }

            context.Remove(new Autor() { Id = id });
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
