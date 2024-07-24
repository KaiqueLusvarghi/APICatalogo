 using System.Linq.Expressions;

namespace APICatalogo.Repositories
{
    public interface IRepository<T>
    {
        //Tem que tomar cuidado para não violar o principio ISP, então seja sucinto com os metodos
        //ISP -> Interface Segregation Principle : Os clientes (da interface) não devem ser forçados a depender de interfaces que não irão utilizar...
        IEnumerable<T> GetAll(); //consulta reaquisicoes em memoria (array)

        T? Get(Expression<Func<T, bool>> predicate); // Vai aceitar por argumento uma expressão lambda, e vai retornar um valor bool 
        T Create(T entity); 
        T Update(T entity);
        T Delete(T entity);
    }
}
