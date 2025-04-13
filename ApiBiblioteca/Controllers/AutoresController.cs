using ApiBiblioteca.Datos;
using ApiBiblioteca.DTO;
using ApiBiblioteca.Entidades;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiBiblioteca.Controllers {
    [ApiController]
    [Route("api/autores")]
    public class AutoresController : ControllerBase {
        private readonly ApplicationDbContext context;

        private readonly IMapper mapper;

        public AutoresController(ApplicationDbContext context, IMapper mapper) {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<AutorDTO>> Get() {
            var autores = await context.Autores.ToListAsync();
            return mapper.Map<List<AutorDTO>>(autores);
        }

        [HttpGet("{id:int}", Name = "ObtenerAutores")]
        public async Task<ActionResult<AutorConLibrosDTO>> Get(int id) {
            var autor = await context.
                            Autores.Include(l => l.Libros).
                            FirstOrDefaultAsync(a => a.Id == id);
            if (autor == null) NotFound();

            var autorDTO = mapper.Map<AutorConLibrosDTO>(autor);

            return autorDTO;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Autor autor) {
            context.Add(autor);
            await context.SaveChangesAsync();
            return CreatedAtRoute("ObtenerAutores", new { id = autor.Id }, autor);
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int Id, Autor autor) {
            if (Id != autor.Id) return BadRequest("El autor indicado no existe");
            context.Update(autor);
            await context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id) {
            var registro = await context.Autores.Where(a => a.Id == id).ExecuteDeleteAsync();
            return registro == 0 ? NotFound() : Ok();
        }


    }
}
