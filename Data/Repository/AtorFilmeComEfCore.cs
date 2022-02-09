﻿using Data.Context;
using Data.Entities;
using Domain.Dtos.FilmeDto;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class AtorFilmeComEfCore : BaseRepository<AtoresFilme>, IAtorFilme
    {
        private readonly DbSet<AtoresFilme> _dbsetAtorFilme;
        
        
        public AtorFilmeComEfCore(MyContext _context):base(_context)
        {
            _dbsetAtorFilme = _context.Set<AtoresFilme>();
            
        }

        public  IEnumerable<AtoresFilme> BuscarFilmesPorAtor(int IdAtorFilme)
        {
            //sem conseguir acessar genero
            var queryFilmes = _context.AtoresFilmes
                .Include(a => a.Ator)
                .Include(f => f.Filme)
                .ThenInclude(d=>d.Diretor)
                .Where(atf => atf.IdAtor == IdAtorFilme)
                .ToList();
            return queryFilmes;
         
        }
        public AtoresFilme BuscaAtorDoFilme(int idAtor)
        {
            var query = _context.AtoresFilmes
                .Include(a => a.Ator)
                .Include(f => f.Filme)
                .FirstOrDefault(at=>at.IdAtor==idAtor);
            //aqui eue tenho o primeiro AtorFilme que possua o mesmo IdAtor
            return query;
        }
    }
}
