using Revisao.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revisao.Business.Interfaces
{
    public interface ICategoriaRepository : IRepository<Categoria>
    {
        Task<Categoria> ObterCategoriaProduto(Guid id);
        
    }
}
