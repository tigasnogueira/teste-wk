﻿using Revisao.Business.Interfaces;
using Revisao.Business.Models;

namespace Revisao.Business.Services
{
    public class CategoriaService : BaseService, ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IProdutoRepository _produtoRepository;

        public CategoriaService(ICategoriaRepository categoria,
                              INotificador notificador,
                              IProdutoRepository produtoRepository) : base(notificador)
        {
            _categoriaRepository = categoria;
            _produtoRepository = produtoRepository;
        }

        public async Task Adicionar(Categoria categoria)
        {
            //if (!ExecutarValidacao(new ProdutoValidation(), produto)) return;

            await _categoriaRepository.Adicionar(categoria);
        }

        public async Task Atualizar(Categoria categoria)
        {
            //if (!ExecutarValidacao(new ProdutoValidation(), produto)) return;

            await _categoriaRepository.Atualizar(categoria);
        }

        public async Task Remover(Guid id)
        {
            if (_categoriaRepository.ObterCategoriaProduto(id).Result.Produtos.Any())
                {
                Notificar("A categoria possui produtos cadastrados!");
                return;
            }

            var categoria = await _categoriaRepository.ObterCategoriaProduto(id);

            if (categoria != null)
            {
                await _produtoRepository.Remover(categoria.Id);
            }

            await _categoriaRepository.Remover(id);
        }

        public void Dispose()
        {
            _categoriaRepository?.Dispose();
        }
    }
}
