using Dominio;
using Entidades.Entidades;
using InfraEstrtutura.Configuracoes;
using InfraEstrtutura.Repositorios.Genericos;
using Microsoft.EntityFrameworkCore;

namespace InfraEstrtutura.Repositorios
{
    public class RepositorioUsuario : RepositorioGenerico<AplicationUser>, IUsuario
    {

        private readonly DbContextOptions<Contexto> _optionsbuilder;

        public RepositorioUsuario()
        {
            _optionsbuilder = new DbContextOptions<Contexto>();
        }

        public async Task<bool> AdicionaUsuario(string email, string senha, int idade, string celular)
        {

            try
            {
                using (var data = new Contexto(_optionsbuilder))
                {
                    await data.ApplicationUser.AddAsync(
                          new AplicationUser
                          {
                              Email = email,
                              PasswordHash = senha,
                              Idade = idade,
                              Celular = celular
                          });

                    await data.SaveChangesAsync();

                }
            }
            catch (Exception)
            {
                return false;
            }


            return true;

        }

        public async Task<bool> ExisteUsuario(string email, string senha)
        {
            try
            {
                using (var data = new Contexto(_optionsbuilder))
                {
                    return await data.ApplicationUser.
                          Where(u => u.Email.Equals(email) && u.PasswordHash.Equals(senha))
                          .AsNoTracking()
                          .AnyAsync();

                }
            }
            catch (Exception)
            {
                return false;
            }

        }

        public async Task<string> RetornaIdUduario(string email)
        {
            try
            {
                using (var data = new Contexto(_optionsbuilder))
                {
                    var usuario = await data.ApplicationUser.
                            Where(u => u.Email.Equals(email))
                            .AsNoTracking()
                            .FirstOrDefaultAsync();

                    return usuario.Id;
                          

                }
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }
}
