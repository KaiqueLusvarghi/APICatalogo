using APICatalogo.Context;
using APICatalogo.Model;
using System.Reflection.Metadata.Ecma335;

namespace APICatalogo.Repositories;

public class ProdutosRepository : Repository<Produto>, IProdutoRepository
{
    public ProdutosRepository(AppDbcontext context): base(context)
    {
        
    }

    public IEnumerable<Produto> GetProdutosPorCategoria(int id)
    {
        return GetAll().Where(c => c.CategoriaId == id);
    }
}

