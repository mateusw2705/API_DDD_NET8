using Entidades.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades.Entidades
{
    public class AplicationUser : IdentityUser
    {
        public int Idade { get; set; }
   
        public string Celular { get; set; }
      
        public TipoUsuario? Tipo { get; set; }
    }
}

