﻿namespace Dominio
{
    public interface IUsuario
    {
        Task<bool> AdicionaUsuario(string email, string senha, int idade, string celular);
        Task<bool> ExisteUsuario(string email, string senha);
    }
}
