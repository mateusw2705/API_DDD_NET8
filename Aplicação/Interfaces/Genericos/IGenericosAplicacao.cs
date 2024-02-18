using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicação.Interfaces.Genericos
{
    public interface IGenericosAplicacao<T> where T : class
    {
        Task Adicionar(T Objeto);
        Task Atualizar(T Objeto);
        Task Excluir(T Objeto);
        Task<T> BuscarPorId(int Id);
        Task<List<T>> Listar();
    }
}
