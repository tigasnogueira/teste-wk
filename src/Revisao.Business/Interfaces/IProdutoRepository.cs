﻿using Revisao.Business.Models;

namespace Revisao.Business.Interfaces
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<IEnumerable<Produto>> ObterPorProdutoCategoria(Guid categoriaId);
        Task<IEnumerable<Produto>> ObterProdutosCategorias();
        Task<Produto> ObterProdutoCategoria(Guid id);

    }
}
