namespace ADMControl.Dominio.Entidades
{
    public class Entrada
    {
        [Key]
        [Display(Name = "Código")]
        public int ENT_ID { get; set; }

        [Display(Name = "Numero")]
        public int ENT_NUMERO { get; set; }

        [Display(Name = "Fornecedor")]
        public string ENT_FORNECEDOR { get; set; } = string.Empty;

        [Display(Name = "Data Entrada")]
        public DateTime ENT_DATA { get; set; }

    }
}
