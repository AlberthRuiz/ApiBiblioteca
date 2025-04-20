using ApiBiblioteca.Datos;
using ApiBiblioteca.DTO;
using ApiBiblioteca.Entidades;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiBiblioteca.Controllers {
    [ApiController]
    [Route("api/autores")]
    public class AutoresController : ControllerBase {
        private readonly IMapper mapper;
        private readonly ApplicationDbContext context;

        public AutoresController(ApplicationDbContext context, IMapper mapper) {
            this.mapper = mapper;
            this.context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<AutorDTO>> Get() {
            var autores = await context.Autores.ToListAsync();
            var autoresDTO = mapper.Map<List<AutorDTO>>(autores);
            return autoresDTO;
        }

        [HttpGet("{id:int}", Name = "obtenerAutor")]
        public async Task<ActionResult<AutorConLibrosDTO>> Get(int id) {
            var autor = await context.Autores.Include(l => l.Libros).FirstOrDefaultAsync(a => a.Id == id);
            if (autor == null) return NotFound();
            return mapper.Map<AutorConLibrosDTO>(autor);
        }

        [HttpGet("obtener/{id:int}")]
        public async Task<ActionResult<Autor>> GetByID(int id) {
            var autor = await context.Autores.Include(l => l.Libros).FirstOrDefaultAsync(a => a.Id == id);
            if (autor == null) return NotFound();
            return autor;
        }



        [HttpPost]
        public async Task<ActionResult> Post(AutorCreacionDTO autorCreacionDTO) {
            var autor = mapper.Map<Autor>(autorCreacionDTO);
            context.Add(autor);
            await context.SaveChangesAsync();
            var autorDTO = mapper.Map<AutorDTO>(autor);
            return CreatedAtRoute("obtenerAutor", new { id = autor.Id }, autorDTO);
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int Id, AutorCreacionDTO autorCreacionDTO) {
            var autor = mapper.Map<Autor>(autorCreacionDTO);
            autor.Id = Id;
            context.Update(autor);
            await context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id) {
            var registro = await context.Autores.Where(a => a.Id == id).ExecuteDeleteAsync();
            return registro == 0 ? NotFound() : NoContent();
        }


    }
}
