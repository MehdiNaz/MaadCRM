namespace DataAccess;

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
            new Country
            {
                Id = Ulid.Parse("01GZTM8DSTQH037TNTFSK9RX9W"),
                CountryName = "Iran",
                IsDefault = true,
                DisplayOrder = 1
            }
        );

        _modelBuilder.Entity<Province>().HasData(
            new Province
            {
                Id = Ulid.NewUlid(),
                ProvinceName = "آذربايجان غربي",
                IsDefault = true,
                DisplayOrder = 1,
                IdCountry = Ulid.Parse("01GZTM8DSTQH037TNTFSK9RX9W")
            }
        );

        _modelBuilder.Entity<Province>().HasData(
            new Province
            {
                Id = Ulid.NewUlid(),
                ProvinceName = "اردبيل",
                IsDefault = true,
                DisplayOrder = 1,
                IdCountry = Ulid.Parse("01GZTM8DSTQH037TNTFSK9RX9W")
            }
        );

        _modelBuilder.Entity<Province>().HasData(
            new Province
            {
                Id = Ulid.NewUlid(),
                ProvinceName = "اصفهان",
                IsDefault = true,
                DisplayOrder = 1,
                IdCountry = Ulid.Parse("01GZTM8DSTQH037TNTFSK9RX9W")
            }
        );

        _modelBuilder.Entity<Province>().HasData(
            new Province
            {
                Id = Ulid.NewUlid(),
                ProvinceName = "ايلام",
                IsDefault = true,
                DisplayOrder = 1,
                IdCountry = Ulid.Parse("01GZTM8DSTQH037TNTFSK9RX9W")
            }
        );

        _modelBuilder.Entity<Province>().HasData(
            new Province
            {
                Id = Ulid.NewUlid(),
                ProvinceName = "بوشهر",
                IsDefault = true,
                DisplayOrder = 1,
                IdCountry = Ulid.Parse("01GZTM8DSTQH037TNTFSK9RX9W")
            }
        );

        _modelBuilder.Entity<Province>().HasData(
            new Province
            {
                Id = Ulid.NewUlid(),
                ProvinceName = "البرز",
                IsDefault = true,
                DisplayOrder = 1,
                IdCountry = Ulid.Parse("01GZTM8DSTQH037TNTFSK9RX9W")
            }
        );

        _modelBuilder.Entity<Province>().HasData(
            new Province
            {
                Id = Ulid.Parse("01GZTT98N8S8TE5J1WE205Q4WV"),
                ProvinceName = "تهران",
                IsDefault = true,
                DisplayOrder = 1,
                IdCountry = Ulid.Parse("01GZTM8DSTQH037TNTFSK9RX9W")
            }
        );

        _modelBuilder.Entity<Province>().HasData(
            new Province
            {
                Id = Ulid.NewUlid(),
                ProvinceName = "چهارمحال بختياري",
                IsDefault = true,
                DisplayOrder = 1,
                IdCountry = Ulid.Parse("01GZTM8DSTQH037TNTFSK9RX9W")
            }
        );

        _modelBuilder.Entity<Province>().HasData(
            new Province
            {
                Id = Ulid.NewUlid(),
                ProvinceName = "خراسان جنوبي",
                IsDefault = true,
                DisplayOrder = 1,
                IdCountry = Ulid.Parse("01GZTM8DSTQH037TNTFSK9RX9W")
            }
        );

        _modelBuilder.Entity<Province>().HasData(
            new Province
            {
                Id = Ulid.NewUlid(),
                ProvinceName = "خراسان رضوي",
                IsDefault = true,
                DisplayOrder = 1,
                IdCountry = Ulid.Parse("01GZTM8DSTQH037TNTFSK9RX9W")
            }
        );

        _modelBuilder.Entity<Province>().HasData(
            new Province
            {
                Id = Ulid.NewUlid(),
                ProvinceName = "خراسان شمالي",
                IsDefault = true,
                DisplayOrder = 1,
                IdCountry = Ulid.Parse("01GZTM8DSTQH037TNTFSK9RX9W")
            }
        );

        _modelBuilder.Entity<Province>().HasData(
            new Province
            {
                Id = Ulid.NewUlid(),
                ProvinceName = "خوزستان",
                IsDefault = true,
                DisplayOrder = 1,
                IdCountry = Ulid.Parse("01GZTM8DSTQH037TNTFSK9RX9W")
            }
        );

        _modelBuilder.Entity<Province>().HasData(
            new Province
            {
                Id = Ulid.NewUlid(),
                ProvinceName = "زنجان",
                IsDefault = true,
                DisplayOrder = 1,
                IdCountry = Ulid.Parse("01GZTM8DSTQH037TNTFSK9RX9W")
            }
        );

        _modelBuilder.Entity<Province>().HasData(
            new Province
            {
                Id = Ulid.NewUlid(),
                ProvinceName = "سمنان",
                IsDefault = true,
                DisplayOrder = 1,
                IdCountry = Ulid.Parse("01GZTM8DSTQH037TNTFSK9RX9W")
            }
        );

        _modelBuilder.Entity<Province>().HasData(
            new Province
            {
                Id = Ulid.NewUlid(),
                ProvinceName = "سيستان و بلوچستان",
                IsDefault = true,
                DisplayOrder = 1,
                IdCountry = Ulid.Parse("01GZTM8DSTQH037TNTFSK9RX9W")
            }
        );

        _modelBuilder.Entity<Province>().HasData(
            new Province
            {
                Id = Ulid.Parse("01GZTMF256K84ZGQFMWRB6VTV9"),
                ProvinceName = "فارس",
                IsDefault = true,
                DisplayOrder = 1,
                IdCountry = Ulid.Parse("01GZTM8DSTQH037TNTFSK9RX9W")
            }
        );

        _modelBuilder.Entity<Province>().HasData(
            new Province
            {
                Id = Ulid.NewUlid(),
                ProvinceName = "قزوين",
                IsDefault = true,
                DisplayOrder = 1,
                IdCountry = Ulid.Parse("01GZTM8DSTQH037TNTFSK9RX9W")
            }
        );

        _modelBuilder.Entity<Province>().HasData(
            new Province
            {
                Id = Ulid.NewUlid(),
                ProvinceName = "قم",
                IsDefault = true,
                DisplayOrder = 1,
                IdCountry = Ulid.Parse("01GZTM8DSTQH037TNTFSK9RX9W")
            }
        );

        _modelBuilder.Entity<Province>().HasData(
            new Province
            {
                Id = Ulid.NewUlid(),
                ProvinceName = "كردستان",
                IsDefault = true,
                DisplayOrder = 1,
                IdCountry = Ulid.Parse("01GZTM8DSTQH037TNTFSK9RX9W")
            }
        );

        _modelBuilder.Entity<Province>().HasData(
            new Province
            {
                Id = Ulid.NewUlid(),
                ProvinceName = "كرمان",
                IsDefault = true,
                DisplayOrder = 1,
                IdCountry = Ulid.Parse("01GZTM8DSTQH037TNTFSK9RX9W")
            }
        );

        _modelBuilder.Entity<Province>().HasData(
            new Province
            {
                Id = Ulid.NewUlid(),
                ProvinceName = "كرمانشاه",
                IsDefault = true,
                DisplayOrder = 1,
                IdCountry = Ulid.Parse("01GZTM8DSTQH037TNTFSK9RX9W")
            }
        );

        _modelBuilder.Entity<Province>().HasData(
            new Province
            {
                Id = Ulid.NewUlid(),
                ProvinceName = "كهكيلويه و بويراحمد",
                IsDefault = true,
                DisplayOrder = 1,
                IdCountry = Ulid.Parse("01GZTM8DSTQH037TNTFSK9RX9W")
            }
        );

        _modelBuilder.Entity<Province>().HasData(
            new Province
            {
                Id = Ulid.NewUlid(),
                ProvinceName = "گلستان",
                IsDefault = true,
                DisplayOrder = 1,
                IdCountry = Ulid.Parse("01GZTM8DSTQH037TNTFSK9RX9W")
            }
        );

        _modelBuilder.Entity<Province>().HasData(
            new Province
            {
                Id = Ulid.NewUlid(),
                ProvinceName = "گيلان",
                IsDefault = true,
                DisplayOrder = 1,
                IdCountry = Ulid.Parse("01GZTM8DSTQH037TNTFSK9RX9W")
            }
        );

        _modelBuilder.Entity<Province>().HasData(
            new Province
            {
                Id = Ulid.NewUlid(),
                ProvinceName = "لرستان",
                IsDefault = true,
                DisplayOrder = 1,
                IdCountry = Ulid.Parse("01GZTM8DSTQH037TNTFSK9RX9W")
            }
        );

        _modelBuilder.Entity<Province>().HasData(
            new Province
            {
                Id = Ulid.NewUlid(),
                ProvinceName = "مازندران",
                IsDefault = true,
                DisplayOrder = 1,
                IdCountry = Ulid.Parse("01GZTM8DSTQH037TNTFSK9RX9W")
            }
        );

        _modelBuilder.Entity<Province>().HasData(
            new Province
            {
                Id = Ulid.NewUlid(),
                ProvinceName = "مركزي",
                IsDefault = true,
                DisplayOrder = 1,
                IdCountry = Ulid.Parse("01GZTM8DSTQH037TNTFSK9RX9W")
            }
        );

        _modelBuilder.Entity<Province>().HasData(
            new Province
            {
                Id = Ulid.NewUlid(),
                ProvinceName = "هرمزگان",
                IsDefault = true,
                DisplayOrder = 1,
                IdCountry = Ulid.Parse("01GZTM8DSTQH037TNTFSK9RX9W")
            }
        );

        _modelBuilder.Entity<Province>().HasData(
            new Province
            {
                Id = Ulid.NewUlid(),
                ProvinceName = "همدان",
                IsDefault = true,
                DisplayOrder = 1,
                IdCountry = Ulid.Parse("01GZTM8DSTQH037TNTFSK9RX9W")
            }
        );

        _modelBuilder.Entity<Province>().HasData(
            new Province
            {
                Id = Ulid.NewUlid(),
                ProvinceName = "يزد",
                IsDefault = true,
                DisplayOrder = 1,
                IdCountry = Ulid.Parse("01GZTM8DSTQH037TNTFSK9RX9W")
            }
        );

        _modelBuilder.Entity<City>().HasData(
            new City
            {
                Id = Ulid.NewUlid(),
                CityName = "شیراز",
                IsDefault = true,
                DisplayOrder = 1,
                IdProvince = Ulid.Parse("01GZTMF256K84ZGQFMWRB6VTV9")
            }
        );

        _modelBuilder.Entity<City>().HasData(
            new City
            {
                Id = Ulid.NewUlid(),
                CityName = "لار",
                IsDefault = true,
                DisplayOrder = 1,
                IdProvince = Ulid.Parse("01GZTMF256K84ZGQFMWRB6VTV9")
            }
        );
        
        _modelBuilder.Entity<City>().HasData(
            new City
            {
                Id = Ulid.NewUlid(),
                CityName = "کرج",
                IsDefault = true,
                DisplayOrder = 1,
                IdProvince = Ulid.Parse("01GZTT98N8S8TE5J1WE205Q4WV")
            }
        );
        
        _modelBuilder.Entity<City>().HasData(
            new City
            {
                Id = Ulid.NewUlid(),
                CityName = "شهریار",
                IsDefault = true,
                DisplayOrder = 1,
                IdProvince = Ulid.Parse("01GZTT98N8S8TE5J1WE205Q4WV")
            }
        );
        
        _modelBuilder.Entity<City>().HasData(
            new City
            {
                Id = Ulid.NewUlid(),
                CityName = "قدس",
                IsDefault = true,
                DisplayOrder = 1,
                IdProvince = Ulid.Parse("01GZTT98N8S8TE5J1WE205Q4WV")
            }
        );
    }
}
