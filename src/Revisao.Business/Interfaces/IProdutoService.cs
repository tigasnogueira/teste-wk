using Revisao.Business.Models;

namespace Revisao.Business.Interfaces
{
    public interface IProdutoService : IDisposable
    {
        Task Adicionar(Produto produto);
        Task Atualizar(Produto produto);
        Task Remover(Guid id);
        Task AtualizarCategoria(Categoria categoria);
    }
}
