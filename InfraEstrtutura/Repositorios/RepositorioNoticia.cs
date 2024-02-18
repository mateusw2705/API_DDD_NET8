﻿using Dominio;
using Entidades.Entidades;
using InfraEstrtutura.Configuracoes;
using InfraEstrtutura.Repositorios.Genericos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InfraEstrtutura.Repositorios
{
    public class RepositorioNoticia : RepositorioGenerico<Noticia>, INoticia
    {

        private readonly DbContextOptions<Contexto> _optionsbuilder;

        public RepositorioNoticia()
        {
            _optionsbuilder = new DbContextOptions<Contexto>();
        }

        public async Task<List<Noticia>> ListarNoticias(Expression<Func<Noticia, bool>> exNoticia)
        {
            using (var banco = new Contexto(_optionsbuilder))
            {
                return await banco.Noticia.Where(exNoticia).AsNoTracking().ToListAsync();
            }
        }
    }
}
