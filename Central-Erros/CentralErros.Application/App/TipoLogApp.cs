﻿using System.Collections.Generic;
using AutoMapper;
using CentralErros.Application.Interface;
using CentralErros.Application.ViewModel;
using CentralErros.Domain.Interfaces;
using CentralErros.Domain.Models;

namespace CentralErros.Application.App
{
    public class TipoLogApp : ITipoLogApp
    {

        private readonly ITipoLogRepositorio _repo;
        private readonly IMapper _mapper;

        public TipoLogApp(ITipoLogRepositorio repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public void Alterar(TipoLogViewModel entity)
        {
            _repo.Alterar(_mapper.Map<TipoLog>(entity));
        }

        public bool Deletar(int id)
        {
            try
            {
                _repo.Deletar(id);
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public bool Incluir(TipoLogViewModel entity)
        {
            try
            {
                _repo.Incluir(_mapper.Map<TipoLog>(entity));
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public IEnumerable<TipoLogViewModel> ListarTodos()
        {
            return _mapper.Map<IEnumerable<TipoLogViewModel>>(_repo.ListarTodos());
        }

        public TipoLogViewModel Selecionar(int id)
        {
            return _mapper.Map<TipoLogViewModel>(_repo.Selecionar(id));
        }
    }
}
