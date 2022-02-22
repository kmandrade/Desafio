﻿using AutoMapper;
using Data.Entities;
using Domain.Dtos.AtorDto;
using Domain.Dtos.FilmeDto;
using Domain.Models;
using FluentResults;
using Servicos.Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicos.Services.Handlers
{
    public class AtorServices : IAtorService
    {
        
        IAtorDao _atorDao;

        private readonly IMapper _mapper;
        public AtorServices(IAtorDao atorDao, IMapper mapper)
        {
            _atorDao = atorDao;
            _mapper = mapper;
            
        }


        public LerAtorDto ConsultaPorId(int id)
        {
            var atores = _atorDao.BuscarPorId(id);
            if (atores == null)
            {
                return null;
            }
            var atorDto = _mapper.Map<LerAtorDto>(atores);
            return atorDto;

        }

        public IEnumerable<LerAtorDto> ConsultaTodos(int skip, int take)
        {
            var atores = _atorDao.BuscarTodos().Skip(skip).Take(take).ToList();
            if (atores == null)
            {
                return null;
            }
            var atoresDto = _mapper.Map<IEnumerable<LerAtorDto>>(atores);
            return atoresDto;
        }

        public Result Cadastra(CriarAtorDto obj)
        {
            var buscaAtor = _atorDao.BuscarTodos().Where(a => a.NomeAtor == obj.NomeAtor);
            if (buscaAtor!=null){
                return Result.Fail("Ator ja existe");
            }
            var atorMapeado = _mapper.Map<Ator>(obj);
            _atorDao.Incluir(atorMapeado);
            return Result.Ok();
        }

        public Result Altera(int id, AlterarAtorDto obj)
        {
            var atorSelecionado = _atorDao.BuscarPorId(id);
            if (atorSelecionado == null)
            {
                return Result.Fail("Filme nao existe");
            }
            _mapper.Map(obj, atorSelecionado);
            _atorDao.Save();
            return Result.Ok();

        }

        public Result Excluir(int id)
        {
            var atorSelecionado = _atorDao.BuscarPorId(id);
            if (atorSelecionado != null)
            {
                _atorDao.Excluir(atorSelecionado);
                return Result.Ok();
            }
            return Result.Fail("Esse Ator nao existe");
        }

    
    }
}
