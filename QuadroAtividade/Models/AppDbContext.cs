namespace QuadroAtividade.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;

    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("name=DefaultConnection") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);

            //  caso ter que recrirar o banco de dados , este c�digo recria e revisa todo o banco criado para trocar NVarChar no campo Discriminator AspNetusers
            //  tambem revisar todas as tabelas criadas para trocar o o campo varChar(8000) por VarChar(max)
            modelBuilder.Properties()
                .Where(x => x.PropertyType.FullName.Equals("System.String") &&
                !x.GetCustomAttributes(false).OfType<ColumnAttribute>().Where(q => q.TypeName != null && q.TypeName.Equals("varchar", StringComparison.InvariantCultureIgnoreCase)).Any())
                .Configure(c => c.HasColumnType("varchar").HasMaxLength(100));
        }

        public DbSet<Task> Task { get; set; }
    }
}