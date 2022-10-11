﻿using Revisao.Business.Interfaces;
using Revisao.Business.Models;
using Revisao.Business.Models.Validations;

namespace Revisao.Business.Services
{
    public class ProdutoService : BaseService, IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly ICategoriaRepository _categoriaRepository;

        public ProdutoService(IProdutoRepository produto, ICategoriaRepository categoria,
                                 INotificador notificador) : base(notificador)
        {
            _produtoRepository = produto;
            _categoriaRepository = categoria;
         
        }

        public async Task Adicionar(Produto produto)
        {
            if (!ExecutarValidacao(new ProdutoValidation(), produto)
                || !ExecutarValidacao(new CategoriaValidation(), produto.Categoria)) return;

            await _produtoRepository.Adicionar(produto);
        }

        public async Task Atualizar( Produto produto)
        {
            if  (!ExecutarValidacao(new ProdutoValidation(), produto)) return;


            await _produtoRepository.Atualizar(produto);
        }

        public async Task AtualizarCategoria(Categoria categoria)
        {
            if (!ExecutarValidacao(new CategoriaValidation(), categoria)) return;

            await _categoriaRepository.Atualizar(categoria);
        }

        public async Task Remover(Guid id)
        {
            await _produtoRepository.Remover(id);
        }

        public void Dispose()
        {
            _categoriaRepository?.Dispose();
            _produtoRepository?.Dispose();
        }
    }
}

