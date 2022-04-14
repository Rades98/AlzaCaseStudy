namespace UnitTests.Mocks.MockRepoSetups
{
    using DomainLayer.Entities.Product;
    using System;
    using System.Collections.Generic;

    public class ProductRepositoryBaseMock
    {
        private static readonly DateTime _created = new(2022, 4, 12, 17, 00, 00, 222, DateTimeKind.Local);
        public static List<ProductEntity> Products => new()
        {
            new ProductEntity() { Name = "test item", Created = _created, Price = 0, Id = new Guid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
            new ProductEntity() { Name = "test item", Created = _created, Price = 0, Id = new Guid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
            new ProductEntity() { Name = "test item", Created = _created, Price = 0, Id = new Guid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
            new ProductEntity() { Name = "test item", Created = _created, Price = 0, Id = new Guid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
            new ProductEntity() { Name = "test item", Created = _created, Price = 0, Id = new Guid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
            new ProductEntity() { Name = "test item", Created = _created, Price = 0, Id = new Guid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
            new ProductEntity() { Name = "test item", Created = _created, Price = 0, Id = new Guid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
            new ProductEntity() { Name = "test item", Created = _created, Price = 0, Id = new Guid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
            new ProductEntity() { Name = "test item", Created = _created, Price = 0, Id = new Guid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
            new ProductEntity() { Name = "test item", Created = _created, Price = 0, Id = new Guid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
            new ProductEntity() { Name = "test item", Created = _created, Price = 0, Id = new Guid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
            new ProductEntity() { Name = "test item", Created = _created, Price = 0, Id = new Guid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
            new ProductEntity() { Name = "test item", Created = _created, Price = 0, Id = new Guid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
            new ProductEntity() { Name = "test item", Created = _created, Price = 0, Id = new Guid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
            new ProductEntity() { Name = "test item", Created = _created, Price = 0, Id = new Guid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
            new ProductEntity() { Name = "test item", Created = _created, Price = 0, Id = new Guid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
            new ProductEntity() { Name = "test item", Created = _created, Price = 0, Id = new Guid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
        };
    }
}
