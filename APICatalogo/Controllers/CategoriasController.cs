using APICatalogo.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APICatalogo.Model;
using Microsoft.EntityFrameworkCore;


namespace APICatalogo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly AppDbcontext _context;

        public CategoriasController(AppDbcontext context)
        {
            _context = context;
        }

        [HttpGet ("produtos")]
        public ActionResult<IEnumerable<Categoria>> GetCategoriasProdutos()
        {
            // return _context.Categorias.Include(p=> p.Produtos).AsNoTracking().ToList();
             return _context.Categorias.Include(p=> p.Produtos).Where(c => c.CategoriaId <=5).ToList(); //Nunca retornar objetos relacionados sem aplicar filtro 

        }

        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> Get()
        {
            var categorias = _context.Categorias.AsNoTracking().ToList();
            if (categorias is null)
            {
                return NotFound("As Categorias não foram encontradas");
            }
            return categorias;
        }

        [HttpGet("{id:int}", Name = "obterCategoria")]
        public ActionResult<Categoria> Get(int id)
        {
            var categoria = _context.Categorias.FirstOrDefault(p => p.CategoriaId == id);

            if (categoria is null) 
            {
                return NotFound("A categoria solicitada não foi encontrada ...");
            }
            return categoria;
        }

        [HttpPost]
        public ActionResult Post(Categoria categoria) 
        {
            if (categoria is null) 
            {
                return BadRequest();
            }
                _context.Add(categoria);//Adcionando a nova categoria na memoria    
                _context.SaveChanges(); // Persistindo a nova categoria no banco
            
                return Ok(categoria);
        }

        [HttpPut ("{id:int}")]
        public ActionResult Put(int id, Categoria categoria) 
        {
            if(id != categoria.CategoriaId)
            {
                return BadRequest();
            }
            _context.Entry(categoria).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        
            return Ok(categoria);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id) 
        {
            var categoria = _context.Categorias.FirstOrDefault(p => p.CategoriaId==id);
            if(categoria is null)
            {
                return BadRequest("Essa categoria não existe");
            }

            _context.Remove(categoria);
            _context.SaveChanges();

            return Ok(categoria);

        }
    }
}
