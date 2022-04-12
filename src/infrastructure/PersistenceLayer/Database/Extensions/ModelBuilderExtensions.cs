using DomainLayer.Entities.Product;
using Microsoft.EntityFrameworkCore;

namespace PersistenceLayer.Database.Extensions
{
    internal static class ModelBuilderExtensions
    {
        private static readonly DateTime _created = new(2022, 4, 12, 17, 00, 00, 222, DateTimeKind.Local);

        public static ModelBuilder SeedData(this ModelBuilder modelBuilder)
        {
            var smth = new ProductEntity()
            {
                Name = "Something cool",
                Created = _created,
                Price = 250,
                Id = new Guid("076D49AF-6BC0-4DDA-84AB-473C9F72BF60"),
                ImgUri = new Uri("http://www.someuri.sf/smth-cool"),
                Description = "Realy cool stuff"
            };

            var smth2 = new ProductEntity()
            {
                Name = "Something way cooler",
                Created = _created,
                Price = 250,
                Id = new Guid("36FAA1FB-88BC-4664-BC94-0FFA86E048A4"),
                ImgUri = new Uri("http://www.someuri.sf/smth-cool"),
                Description = "Realy cool and cheap stuff"
            };

            modelBuilder.Entity<ProductEntity>()
                .HasData(smth, smth2);

            return modelBuilder;
        }
    }
}
