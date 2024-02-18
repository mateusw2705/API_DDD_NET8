using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Entidades.Notificacoes;

namespace Entidades.Entidades
{
    public class Noticia:Notifica
    {
       
        public int Id { get; set; }
     
        [MaxLength(255)]
        public string Titulo { get; set; }

        [MaxLength(255)]
        public string Informacao { get; set; }

        public bool Ativo { get; set; }
       
        public DateTime DataCadastro { get; set; }

        public DateTime DataAlteracao { get; set; }

        [ForeignKey("AplicationUser")]
        [Column(Order = 1)]
        public string UserId { get; set; }
        public virtual AplicationUser ApplicationUser { get; set; }


    }
}
