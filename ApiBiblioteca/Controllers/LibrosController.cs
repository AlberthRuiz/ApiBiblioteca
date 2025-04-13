using ApiBiblioteca.Datos;
using ApiBiblioteca.DTO;
using ApiBiblioteca.Entidades;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiBiblioteca.Controllers {
    [ApiController]
    [Route("api/libros")]
    public class LibrosController : ControllerBase {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public LibrosController(ApplicationDbContext context,IMapper mapper ) {
            this.context = context;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<Libro>> Get() {
            return await context.Libros.Include(l => l.Autor).ToListAsync();
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<LibroDTO>> Get(int id) {
            var libro = await context.Libros
                                    .Include(a => a.Autor)
                                    .FirstOrDefaultAsync(l => l.Id == id);
            if (libro == null) NotFound();
            return mapper.Map<LibroDTO>(libro) ;
        }
        [HttpPost]
        public async Task<ActionResult> Post(Libro libro) {
            var existe_autor = await context.Autores.AnyAsync(a => a.Id == libro.AutorId);
            if (!existe_autor) return BadRequest($"No se encontro autor con ID: {libro.Id}");
            context.Add(libro);
            await context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, Libro libro) {
            if (id == libro.Id) return BadRequest("El ID de libro no coincide");
            var existe_autor = await context.Autores.AnyAsync(a => a.Id == libro.AutorId);
            if (!existe_autor) return BadRequest($"No se encontro autor con ID: {libro.Id}");
            context.Update(libro);
            await context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id) {
            var eliminados = await context.Libros.Where(l => l.Id == id).ExecuteDeleteAsync();
            return eliminados == 0 ? NotFound() : Ok();
        }
    }
}
