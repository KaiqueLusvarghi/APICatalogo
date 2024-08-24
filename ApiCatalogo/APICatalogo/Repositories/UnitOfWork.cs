using APICatalogo.Context;
using System;

namespace APICatalogo.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private IProdutoRepository? _produtoRepo;
    private ICategoriaRepository? _categoriaRepo;

    public AppDbcontext _context;
    public UnitOfWork(AppDbcontext context)
    {
        _context = context;
    }

    public IProdutoRepository ProdutoRepository
    { //obtendo uma instancia do repositorio de produtos
        get
        {
            return _produtoRepo = _produtoRepo ?? new ProdutosRepository(_context);
            //if (_produtoRepo == null)
            //{
            //    _produtoRepo = new ProdutoRepository(_context);
            //}
            //return _produtoRepo;
        }
    }
    public ICategoriaRepository CategoriaRepository
    {//obtendo uma instancia do repositorio de produtos
        get
        {
            return _categoriaRepo = _categoriaRepo ?? new CategoriaRepository(_context);
        }
    }
    public void Commit()
    {
        _context.SaveChanges();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
