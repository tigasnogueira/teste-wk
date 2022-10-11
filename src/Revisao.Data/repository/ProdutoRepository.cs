
using Revisao.Data.context.RevisaoData;
using Revisao.Business.Interfaces;
using Revisao.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace Revisao.Data.repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(MeuDbContext context) : base(context) { }

        public async Task<IEnumerable<Produto>> ObterPorProdutoCategoria(Guid categoriaId)
        {
            return await Buscar(p => p.CategoriaId == categoriaId);
        }

        public async Task<Produto> ObterProdutoCategoria(Guid id)
        {
            return await Db.Produtos.AsNoTracking().Include(f => f.Categoria)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Produto>> ObterProdutosCategorias()
        {
            return await Db.Produtos.AsNoTracking().Include(f => f.Categoria)
               .OrderBy(p => p.Descricao).ToListAsync();
        }
    }
}
