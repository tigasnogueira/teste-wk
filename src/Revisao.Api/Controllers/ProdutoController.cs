﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Revisao.Api.ViewModels;
using Revisao.Business.Intefaces;
using Revisao.Business.Interfaces;
using Revisao.Business.Models;

namespace Revisao.Api.Controllers
{


    [Route("api/produtos")]
    public class ProdutoController : MainController
        {
            private readonly IProdutoRepository _produtoRepository;
            private readonly IProdutoService _produtoService;
            private readonly ICategoriaRepository _categoriaRepository;
            private readonly IMapper _mapper;
          

            public ProdutoController(IProdutoRepository produtoRepository, IProdutoService produtoService, ICategoriaRepository categoriaRepository, IMapper mapper, INotificador notificador, IUser user) : base(notificador, user)
        {
             _produtoRepository = produtoRepository;
            _produtoService = produtoService;   
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;

        }

            [HttpGet]
            public async Task<IEnumerable<ProdutoViewModel>> ObterTodos()
            {
                var fornecedor = _mapper.Map<IEnumerable<ProdutoViewModel>>(await _produtoRepository.ObterTodos());
                return fornecedor;
            }


            [HttpGet("{id:guid}")]
            // [Authorize]
            public async Task<ActionResult<ProdutoViewModel>> ObterpPorId(Guid id)
            {
                var fornecedor = _mapper.Map<ProdutoViewModel>(await _produtoRepository.ObterProdutoCategoria(id));

                if (fornecedor == null) return NotFound();

                return fornecedor;
            }


            [HttpPost]
            public async Task<ActionResult<ProdutoViewModel>> Adicionar(ProdutoViewModel produtoViewModel)
            {
                if (!ModelState.IsValid) return CostumResponse(ModelState);

                await _produtoService.Adicionar(_mapper.Map<Produto>(produtoViewModel));

                return CostumResponse(produtoViewModel);
            }

        [HttpPut("{id:guid}")]
            public async Task<ActionResult<ProdutoViewModel>> Atualizar(Guid id, ProdutoViewModel produtoViewModel)
            {
                if (id != produtoViewModel.Id)
                {
                    NotificarErro("O id informado não é o mesmo que foi passado na query");
                    return CostumResponse(produtoViewModel);
                }

                if (!ModelState.IsValid) return CostumResponse(ModelState);

                await _produtoService.Atualizar(_mapper.Map<Produto>(produtoViewModel));

                return CostumResponse(produtoViewModel);
            }

            [HttpDelete("{id:guid}")]
            public async Task<ActionResult<ProdutoViewModel>> Excluir(Guid id)
            {
                var produtoviewmodel = _mapper.Map<ProdutoViewModel>(await _produtoRepository.ObterProdutoCategoria(id));

                if (produtoviewmodel == null) return NotFound();

                await _produtoService.Remover(id);

                return CostumResponse(produtoviewmodel);

            }

            [HttpGet("obter-categoria/{id:guid}")]
            public async Task<CategoriaViewModel> ObterCategoriaPorId(Guid id)
            {
                return _mapper.Map<CategoriaViewModel>(await _categoriaRepository.ObterPorId(id));
            }

            [HttpPut("atualizar-categoria/{id:guid}")]
            public async Task<IActionResult> AtualizarCategoria(Guid id, CategoriaViewModel categoriaViewModel)
            {
                if (id != categoriaViewModel.Id)
                {
                    NotificarErro("O id informado não é o mesmo que foi passado na query");
                    return CostumResponse(categoriaViewModel);
                }

                if (!ModelState.IsValid) return CostumResponse(ModelState);

                await _produtoService.AtualizarCategoria(_mapper.Map<Categoria>(categoriaViewModel));

                return CostumResponse(categoriaViewModel);
            }

            //public async Task<ProdutoViewModel> ObterProdutoCategoria(Guid id)
            //{
            //    return _mapper.Map<ProdutoViewModel>(await _produtoRepository.ObterProdutoCategoria(id));
            //}

           


        }
    }

