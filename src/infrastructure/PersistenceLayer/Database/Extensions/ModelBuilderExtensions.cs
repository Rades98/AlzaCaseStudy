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

            var pagData = new List<ProductEntity>()
            {
                new ProductEntity() { Name = "Pagination test item 1", Created = _created, Price = 0, Id = new Guid("3b05b497-1f1b-487f-bf71-0084d51604d4"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test pagination data" },
                new ProductEntity() { Name = "Pagination test item 2", Created = _created, Price = 0, Id = new Guid("f1d516c1-069c-4d93-ba22-14ae1785891e"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test pagination data" },
                new ProductEntity() { Name = "Pagination test item 3", Created = _created, Price = 0, Id = new Guid("2b9e68c4-8f8e-43b3-9755-b892dcbeaeba"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test pagination data" },
                new ProductEntity() { Name = "Pagination test item 4", Created = _created, Price = 0, Id = new Guid("f6225d98-0f14-4dce-8543-5811b6049f9b"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test pagination data" },
                new ProductEntity() { Name = "Pagination test item 5", Created = _created, Price = 0, Id = new Guid("e4b116e0-d018-4cb0-90e0-c5b9ef17f4e2"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test pagination data" },
                new ProductEntity() { Name = "Pagination test item 6", Created = _created, Price = 0, Id = new Guid("392f47fc-ad49-4d7e-b43a-21388c63c86f"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test pagination data" },
                new ProductEntity() { Name = "Pagination test item 7", Created = _created, Price = 0, Id = new Guid("3d2c2880-8ebe-4c36-933c-3d4435a28ede"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test pagination data" },
                new ProductEntity() { Name = "Pagination test item 8", Created = _created, Price = 0, Id = new Guid("5c400b7c-6ac4-47b9-9f78-417349f953a9"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test pagination data" },
                new ProductEntity() { Name = "Pagination test item 9", Created = _created, Price = 0, Id = new Guid("3054191e-0b54-436d-9e85-4ac7f8ef1277"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test pagination data" },
                new ProductEntity() { Name = "Pagination test item 10", Created = _created, Price = 0, Id = new Guid("26e017fc-0626-4540-9691-11bfcc15d5a3"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test pagination data" },
                new ProductEntity() { Name = "Pagination test item 11", Created = _created, Price = 0, Id = new Guid("ac2538e6-90c0-40c5-bdb0-bf991b84ef66"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test pagination data" },
                new ProductEntity() { Name = "Pagination test item 12", Created = _created, Price = 0, Id = new Guid("587392f1-ed02-471c-b97d-475ca66e5a4f"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test pagination data" },
                new ProductEntity() { Name = "Pagination test item 13", Created = _created, Price = 0, Id = new Guid("cab02fb2-81e8-45d3-8bcf-d8787fa028da"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test pagination data" },
                new ProductEntity() { Name = "Pagination test item 14", Created = _created, Price = 0, Id = new Guid("1751d157-33dd-438c-92f4-00f5f9b1d066"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test pagination data" },
                new ProductEntity() { Name = "Pagination test item 15", Created = _created, Price = 0, Id = new Guid("d6d32626-5d4d-4bd0-82ac-723e48f4bc1c"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test pagination data" },
                new ProductEntity() { Name = "Pagination test item 16", Created = _created, Price = 0, Id = new Guid("162d4fd2-a3f7-441c-a3b0-9c6fcb9f4eb2"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test pagination data" },
                new ProductEntity() { Name = "Pagination test item 18", Created = _created, Price = 0, Id = new Guid("c8a55f25-dbf7-41a4-87a9-4766f87e45d3"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test pagination data" },
                new ProductEntity() { Name = "Pagination test item 17", Created = _created, Price = 0, Id = new Guid("fed2db27-f1b7-43b6-a5df-6e6d43eb22ac"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test pagination data" },
                new ProductEntity() { Name = "Pagination test item 19", Created = _created, Price = 0, Id = new Guid("6bc496f5-a270-49ad-90ee-f00b3243053e"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test pagination data" },
                new ProductEntity() { Name = "Pagination test item 20", Created = _created, Price = 0, Id = new Guid("baf7b04a-0424-407b-a4f3-d4ae38b3d5d2"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test pagination data" },
                new ProductEntity() { Name = "Pagination test item 21", Created = _created, Price = 0, Id = new Guid("48be6036-a2a8-42cb-bbdf-b23277a3fedf"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test pagination data" },
                new ProductEntity() { Name = "Pagination test item 22", Created = _created, Price = 0, Id = new Guid("77e795e2-e959-4b79-9278-5dcdfb74eb6b"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test pagination data" },
                new ProductEntity() { Name = "Pagination test item 23", Created = _created, Price = 0, Id = new Guid("44d8560a-996b-49ee-a149-0148075dad46"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test pagination data" },
                new ProductEntity() { Name = "Pagination test item 24", Created = _created, Price = 0, Id = new Guid("2351cfb2-0d6d-4578-a9e2-0ec2ae5016d1"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test pagination data" },
                new ProductEntity() { Name = "Pagination test item 25", Created = _created, Price = 0, Id = new Guid("a5ea6a5a-5316-4722-a009-8cc4ef1779c0"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test pagination data" },
                new ProductEntity() { Name = "Pagination test item 26", Created = _created, Price = 0, Id = new Guid("c68d7767-9c7b-4fd4-8833-17ecde007165"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test pagination data" },
                new ProductEntity() { Name = "Pagination test item 27", Created = _created, Price = 0, Id = new Guid("13fd5fb3-f452-4105-b431-0a36605d1b43"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test pagination data" },
                new ProductEntity() { Name = "Pagination test item 28", Created = _created, Price = 0, Id = new Guid("5f1be375-cec9-475e-96cd-d99d8dd40688"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test pagination data" },
                new ProductEntity() { Name = "Pagination test item 29", Created = _created, Price = 0, Id = new Guid("08c0db85-a7d1-46de-8ed0-4215a5c73f30"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test pagination data" },
                new ProductEntity() { Name = "Pagination test item 30", Created = _created, Price = 0, Id = new Guid("f1803ebd-4458-47a1-a1bc-861bc69cfd87"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test pagination data" },
                new ProductEntity() { Name = "Pagination test item 31", Created = _created, Price = 0, Id = new Guid("daba5ec9-99c7-4505-83c5-f4a5350769d3"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test pagination data" },
                new ProductEntity() { Name = "Pagination test item 32", Created = _created, Price = 0, Id = new Guid("6b3ae464-c9a9-4e22-9448-88733707af0a"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test pagination data" },
                new ProductEntity() { Name = "Pagination test item 33", Created = _created, Price = 0, Id = new Guid("ce3f1caa-b272-404b-b604-69aa5e475371"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test pagination data" },
                new ProductEntity() { Name = "Pagination test item 34", Created = _created, Price = 0, Id = new Guid("b13fad29-28f9-4f34-ab86-e4620af3837f"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test pagination data" },
                new ProductEntity() { Name = "Pagination test item 35", Created = _created, Price = 0, Id = new Guid("b88f7f89-e1ce-4103-a733-42674bbf7d50"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test pagination data" },
                new ProductEntity() { Name = "Pagination test item 36", Created = _created, Price = 0, Id = new Guid("bc3c489e-0604-4f33-bdaf-1ae6fd1a7e9b"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test pagination data" },
                new ProductEntity() { Name = "Pagination test item 37", Created = _created, Price = 0, Id = new Guid("f19577a4-7211-4db7-a8f9-a9ce272fff9e"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test pagination data" },
                new ProductEntity() { Name = "Pagination test item 38", Created = _created, Price = 0, Id = new Guid("ba8ae4a3-9b30-4f11-a501-499a80fe810b"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test pagination data" },
                new ProductEntity() { Name = "Pagination test item 39", Created = _created, Price = 0, Id = new Guid("956460ee-5b90-4865-88c4-fb8e24c1be35"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test pagination data" },
                new ProductEntity() { Name = "Pagination test item 40", Created = _created, Price = 0, Id = new Guid("ea2ed07b-7017-4e28-90ea-7fd941c8dfe3"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test pagination data" },
                new ProductEntity() { Name = "Pagination test item 41", Created = _created, Price = 0, Id = new Guid("6a33a7d9-c490-4068-a6ed-d1a7ec7ff74e"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test pagination data" },
                new ProductEntity() { Name = "Pagination test item 42", Created = _created, Price = 0, Id = new Guid("b1c48db4-3ca6-4c9c-a4d7-4a239f82ef3a"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test pagination data" },
                new ProductEntity() { Name = "Pagination test item 43", Created = _created, Price = 0, Id = new Guid("3cebfb4d-fc88-4432-9e54-f5b5d2861df1"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test pagination data" },
                new ProductEntity() { Name = "Pagination test item 44", Created = _created, Price = 0, Id = new Guid("093ce8c4-0910-42cf-b5c4-95b21107a371"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test pagination data" },
                new ProductEntity() { Name = "Pagination test item 45", Created = _created, Price = 0, Id = new Guid("fe8d06d2-c22a-47c3-ad9e-88cd9bba309b"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test pagination data" },
                new ProductEntity() { Name = "Pagination test item 46", Created = _created, Price = 0, Id = new Guid("288147d8-3a74-4025-918d-deadabad1580"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test pagination data" },
                new ProductEntity() { Name = "Pagination test item 47", Created = _created, Price = 0, Id = new Guid("b4cbdffb-7ab0-4622-a97f-8d369c45d1ac"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test pagination data" },
                new ProductEntity() { Name = "Pagination test item 48", Created = _created, Price = 0, Id = new Guid("fd4abd72-677e-4f64-840c-26a8d29ecab9"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test pagination data" },
                new ProductEntity() { Name = "Pagination test item 49", Created = _created, Price = 0, Id = new Guid("522ba220-4511-4978-913a-fcc8692c8c94"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test pagination data" },
                new ProductEntity() { Name = "Pagination test item 50", Created = _created, Price = 0, Id = new Guid("53a01ec6-10fc-4977-8e4e-b8422e1f7481"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test pagination data" },
            };



            modelBuilder.Entity<ProductEntity>()
                .HasData(smth, smth2);

            //Add pagination test data
            modelBuilder.Entity<ProductEntity>()
                .HasData(pagData);

            return modelBuilder;
        }
    }
}
