namespace ADMControl.Dominio.Entidades
{
    public class Unidade
    {
        [Key]
        [Display(Name = "Código")]
        public int UNI_ID { get; set; }

        [Display(Name = "Sigla")]
        public string UNI_SIGLA { get; set; } = string.Empty;

        [Display(Name = "Nome")]
        public string UNI_NOME { get; set; } = string.Empty;
    }
}
