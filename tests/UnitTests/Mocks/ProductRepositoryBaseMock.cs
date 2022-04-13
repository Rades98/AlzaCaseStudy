namespace UnitTests.Mocks
{
    using DomainLayer.Entities.Product;
    using System;
    using System.Collections.Generic;

    public class ProductRepositoryBaseMock
    {
        private static readonly DateTime _created = new(2022, 4, 12, 17, 00, 00, 222, DateTimeKind.Local);
        public static List<ProductEntity> Products => new()
        {
            new ProductEntity() { Name = "test item", Created = _created, Price = 0, Id = new Guid("3b05b497-1f1b-487f-bf71-0084d51604d4"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
            new ProductEntity() { Name = "test item", Created = _created, Price = 0, Id = new Guid("f1d516c1-069c-4d93-ba22-14ae1785891e"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
            new ProductEntity() { Name = "test item", Created = _created, Price = 0, Id = new Guid("2b9e68c4-8f8e-43b3-9755-b892dcbeaeba"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
            new ProductEntity() { Name = "test item", Created = _created, Price = 0, Id = new Guid("f6225d98-0f14-4dce-8543-5811b6049f9b"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
            new ProductEntity() { Name = "test item", Created = _created, Price = 0, Id = new Guid("e4b116e0-d018-4cb0-90e0-c5b9ef17f4e2"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
            new ProductEntity() { Name = "test item", Created = _created, Price = 0, Id = new Guid("392f47fc-ad49-4d7e-b43a-21388c63c86f"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
            new ProductEntity() { Name = "test item", Created = _created, Price = 0, Id = new Guid("3d2c2880-8ebe-4c36-933c-3d4435a28ede"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
            new ProductEntity() { Name = "test item", Created = _created, Price = 0, Id = new Guid("5c400b7c-6ac4-47b9-9f78-417349f953a9"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
            new ProductEntity() { Name = "test item", Created = _created, Price = 0, Id = new Guid("26e017fc-0626-4540-9691-11bfcc15d5a3"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
            new ProductEntity() { Name = "test item", Created = _created, Price = 0, Id = new Guid("ac2538e6-90c0-40c5-bdb0-bf991b84ef66"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
            new ProductEntity() { Name = "test item", Created = _created, Price = 0, Id = new Guid("cab02fb2-81e8-45d3-8bcf-d8787fa028da"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
            new ProductEntity() { Name = "test item", Created = _created, Price = 0, Id = new Guid("1751d157-33dd-438c-92f4-00f5f9b1d066"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
            new ProductEntity() { Name = "test item", Created = _created, Price = 0, Id = new Guid("d6d32626-5d4d-4bd0-82ac-723e48f4bc1c"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
            new ProductEntity() { Name = "test item", Created = _created, Price = 0, Id = new Guid("162d4fd2-a3f7-441c-a3b0-9c6fcb9f4eb2"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
            new ProductEntity() { Name = "test item", Created = _created, Price = 0, Id = new Guid("fed2db27-f1b7-43b6-a5df-6e6d43eb22ac"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
            new ProductEntity() { Name = "test item", Created = _created, Price = 0, Id = new Guid("6bc496f5-a270-49ad-90ee-f00b3243053e"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
            new ProductEntity() { Name = "test item", Created = _created, Price = 0, Id = new Guid("baf7b04a-0424-407b-a4f3-d4ae38b3d5d2"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
        };
    }
}
