using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ADMControl.Dominio.Entidades
{
    public class Produto
    {
        [Key]
        [Display(Name = "Código")]
        public int PRO_ID { get; set; }

        public int PRO_IDCATEGORIA { get; set; }
        public int PRO_IDUNIDADE { get; set; }

        [Display(Name = "Descrição")]
        public string PRO_DESC { get; set; } = string.Empty;

        [Display(Name = "Estoque Minimo")]
        public double PRO_MIN { get; set; } = 0;

        [Display(Name = "Estoque Maximo")]
        public double PRO_MAX { get; set; } = 0;

        [Display(Name = "Estoque Atual")]
        public double PRO_ATU { get; set; } = 0;

        //###################################
        //Relacionamentos

        [ForeignKey("PRO_IDCATEGORIA")]
        public virtual Categoria? Categoria { get; set; }

        [ForeignKey("PRO_IDUNIDADE")]
        public virtual Unidade? Unidade { get; set; }
    }
}
