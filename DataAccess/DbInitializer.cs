namespace DataAccess
{
    internal class DbInitializer
    {
        private readonly ModelBuilder _modelBuilder;
        private readonly MaadContext _context;

        public DbInitializer(ModelBuilder modelBuilder, MaadContext context)
        {
            _modelBuilder = modelBuilder;
            _context = context;
        }

        public void Seed()
        {
            _modelBuilder.Entity<Country>().HasData(
                   new Country
                   {
                       Id = Ulid.NewUlid(),
                       CountryName = "Iran",
                       IsDefault = true,
                       DisplayOrder = 1
                   }
            );

            //var countryId = _context.Countries.FirstOrDefaultAsync().Result.Id;

            //_modelBuilder.Entity<Province>().HasData(
            //    new Province
            //    {
            //        Id = Ulid.NewUlid(),
            //        ProvinceName = "Iran",
            //        IsDefault = true,
            //        DisplayOrder = 1,
            //        IdCountry = countryId
            //    }
            //);
        }
    }
}