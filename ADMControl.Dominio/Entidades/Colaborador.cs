namespace ADMControl.Dominio.Entidades
{
    public class Colaborador
    {
        [Key]
        [Display(Name = "Código")]
        public int COL_ID { get; set; }

        [Display(Name = "Nome")]
        public string COL_NOME { get; set; } = string.Empty;

        [Display(Name = "Ativo ?")]
        public bool COL_ATIVO { get; set; }
    }
}
