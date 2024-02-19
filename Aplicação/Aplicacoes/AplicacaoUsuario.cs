using Aplicação.Interfaces;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicação.Aplicacoes
{
    public class AplicacaoUsuario : IAplicacaoUsuario
    {
        IUsuario _IUsuario;
        public AplicacaoUsuario(IUsuario IUSuario) 
        {
           _IUsuario = IUSuario;

        }

        public async Task<bool> AdicionaUsuario(string email, string senha, int idade, string celular)
        {
            return await _IUsuario.AdicionaUsuario(email, senha, idade, celular);
        }

        public async Task<bool> ExisteUsuario(string email, string senha)
        {
            return await _IUsuario.ExisteUsuario(email, senha);
        }

        public async Task<string> RetornaIdUduario(string email)
        {
            return await _IUsuario.RetornaIdUduario(email);
        }
    }
}
