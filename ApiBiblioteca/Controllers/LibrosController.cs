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
        public LibrosController(ApplicationDbContext context, IMapper mapper) {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<LibroDTO>> Get() {
            var libros = await context.Libros.Include(l => l.Autor).ToListAsync();
            return mapper.Map<List<LibroDTO>>(libros);
        }

        [HttpGet("{id:int}", Name = "obtenerLibro")]
        public async Task<ActionResult<LibroDTO>> Get(int id) {
            var libro = await context.Libros
                                    .Include(a => a.Autor)
                                    .FirstOrDefaultAsync(l => l.Id == id);
            if (libro == null) return NotFound();
            return mapper.Map<LibroDTO>(libro);
        }

        [HttpGet("detalle/{id:int}")]
        public async Task<ActionResult<LibroConAutorDTO>> GetLibro(int id) {
            var libro = await context.Libros
                                    .Include(a => a.Autor)
                                    .FirstOrDefaultAsync(l => l.Id == id);
            if (libro == null) return NotFound();
            return mapper.Map<LibroConAutorDTO>(libro);
        }

        [HttpPost]
        public async Task<ActionResult> Post(LibroConAutorDTO libroCreacionDTO) {
            var libro = mapper.Map<Libro>(libroCreacionDTO);
            var existe_autor = await context.Autores.AnyAsync(a => a.Id == libro.AutorId);
            if (!existe_autor) return BadRequest($"No se encontró autor con ID: {libro.AutorId}");
            context.Add(libro);
            await context.SaveChangesAsync();
            var libroDTO = mapper.Map<LibroDTO>(libro);
            return CreatedAtRoute("obtenerLibro", new { id = libro.Id }, libroDTO);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, LibroConAutorDTO libroCreacionDTO) {
            var libro = mapper.Map<Libro>(libroCreacionDTO);
            libro.Id = id;
            var existe_autor = await context.Autores.AnyAsync(a => a.Id == libro.AutorId);
            if (!existe_autor) return BadRequest($"No se encontró autor con ID: {libro.AutorId}");
            context.Update(libro);
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id) {
            var eliminados = await context.Libros.Where(l => l.Id == id).ExecuteDeleteAsync();
            return eliminados == 0 ? NotFound() : NoContent();
        }
    }
}