﻿using Aplicação.Interfaces;
using Dominio.Interfaces.InterfaceServicos;
using Dominio;
using Entidades.Entidades;

namespace Aplicação.Aplicacoes
{
    public class AplicacaoNoticia : IAplicacaoNoticia
    {

        INoticia _INoticia;
        IServicoNoticia _IServicoNoticia;

        public AplicacaoNoticia(INoticia INoticia, IServicoNoticia IServicoNoticia)
        {
            _INoticia = INoticia;
            _IServicoNoticia = IServicoNoticia;
        }
        public async Task AdicionaNoticia(Noticia noticia)
        {
            await _IServicoNoticia.AdicionaNoticia(noticia);
        }

        public async Task AtualizaNoticia(Noticia noticia)
        {
            await _IServicoNoticia.AtualizaNoticia(noticia);
        }

        public async Task<List<Noticia>> ListarNoticiasAtivas()
        {
            return await _IServicoNoticia.ListarNoticiasAtivas();
        }



        public async Task Adicionar(Noticia Objeto)
        {
            await _INoticia.Adicionar(Objeto);
        }

        public async Task Atualizar(Noticia Objeto)
        {
            await _INoticia.Atualizar(Objeto);
        }

        public async Task<Noticia> BuscarPorId(int Id)
        {
            return await _INoticia.BuscarPorId(Id);
        }

        public async Task Excluir(Noticia Objeto)
        {
            await _INoticia.Excluir(Objeto);
        }

        public async Task<List<Noticia>> Listar()
        {
            return await _INoticia.Listar();
        }

    }
}
