namespace ADMControl.Dominio.Repositorios
{
    public class EfDbContext : DbContext
    {
        public EfDbContext(DbContextOptions<EfDbContext> options) : base(options)
        {
            Console.Write(options.ContextType);
        }

        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Unidade> Unidade { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>().ToTable("CATEGORIA");
            modelBuilder.Entity<Unidade>().ToTable("UNIDADE");
        }
    }
}
