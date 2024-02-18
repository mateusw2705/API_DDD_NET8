﻿using Dominio.Interfaces.Genericos;
using Entidades.Entidades;
using System.Linq.Expressions;

namespace Dominio
{
    public  interface INoticia : IGenericos<Noticia>
    {
        Task<List<Noticia>> ListarNoticias(Expression<Func<Noticia, bool>> exNoticia);
    }
 
}
