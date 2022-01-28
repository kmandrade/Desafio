﻿using Data.Context;
using Data.Entities;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class GeneroComEfCore : IGeneroDao
    {
        MyContext _context;

        public GeneroComEfCore(MyContext context)
        {
            _context = context;
        }

        public IEnumerable<Filme> BuscaFilmesPorGenero(Genero genero)
        {

            yield return _context.Filmes
                .Include(g => g.Generos)
                .First(f => f.Generos == genero);
        }

        public Genero BuscarPorId(int id)
        {
            return _context.Generos.Find(id);
        }

        public IEnumerable<Genero> BuscarTodos()
        {
            var generos = _context.Generos;
            return generos;
        }

        public void Excluir(Genero obj)
        {
            _context.Generos.Remove(obj);
        }
        public void Alterar(Genero obj)
        {
            _context.Generos.Update(obj);
        }

        public void Incluir(Genero obj)
        {
            _context.Generos.Add(obj);
        }
    }
}