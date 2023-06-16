using System.ComponentModel.DataAnnotations.Schema;

namespace ADMControl.Dominio.Entidades
{
    public class ProdutoxEntrada
    {
        [Key]
        [Display(Name = "Código")]
        public int PXE_ID { get; set; }

        [Display(Name = "Quantidade")]
        public double PXE_QUANTIDADE { get; set; }
        public int PXE_IDPRODUTO { get; set; }
        public int PXE_IDENTRADA { get; set; }

        //###################################
        //Relacionamentos

        [ForeignKey("PXE_IDPRODUTO")]
        public virtual Produto? Produto { get; set; }

        [ForeignKey("PXE_IDENTRADA")]
        public virtual Entrada? Entrada { get; set; }
    }
}
