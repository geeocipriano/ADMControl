namespace ADMControl.Dominio.Entidades
{
    public class Categoria
    {
        [Key]
        [Display(Name = "Código")]
        public int CAT_ID { get; set; }

        [Display(Name = "Nome")]
        public string CAT_NOME { get; set; } = string.Empty;
    }
}
