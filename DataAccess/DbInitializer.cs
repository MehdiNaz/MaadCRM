namespace DataAccess
{
    internal class DbInitializer
    {
        private readonly ModelBuilder _modelBuilder;

        public DbInitializer(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
        }

        public void Seed()
        {
            _modelBuilder.Entity<Country>().HasData(
                   new Country()
                   {
                       Id = Ulid.NewUlid(),
                       CountryName = "Iran",
                       IsDefault = true,
                       DisplayOrder = 1
                   }
            );
        }
    }
}