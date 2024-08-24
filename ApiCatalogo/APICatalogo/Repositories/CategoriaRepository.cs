using APICatalogo.Context;
using APICatalogo.Model;


namespace APICatalogo.Repositories;

public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
{
    public CategoriaRepository(AppDbcontext context) : base(context) // A palavra base é usada para acessar membros de classe base de dentro de uma classe derivada
    {
    }
}
