namespace PersistenceLayer.Database.Extensions
{
    using ApplicationLayer.Utils.PasswordHashing;
    using DomainLayer.Entities.Orders;
    using DomainLayer.Entities.Product;
    using DomainLayer.Entities.Users;
    using Microsoft.EntityFrameworkCore;

    internal static class ModelBuilderExtensions
    {
        private static readonly DateTime _created = new(2022, 4, 12, 17, 00, 00, 222, DateTimeKind.Local);

        public static ModelBuilder SeedData(this ModelBuilder modelBuilder)
        {
            var userRoles = new List<UserRoleEntity>()
            {
                new() { Id = new Guid("7CFD3E28-C6ED-48B9-8D08-424751E77EAF"), Name = UserRolesCodeList.UserRoles.Admin, Created = _created }
            };

            // Admin
            // aJc48262_1Kjkz>X!
            PasswordHashing.CreatePasswordHash("aJc48262_1Kjkz>X!", out byte[] pwHash, out byte[] pwSalt);

            var users = new List<UserEntity>()
            {
                new(){ Id = new Guid("1D984227-1A68-4AA2-98FE-8C398E02FF85"), Name = "Admin", UserName = "Admin", Surname = "Admin", PasswordHash = pwHash, PasswordSalt = pwSalt, Email = "some@email.com", Created = _created }
            };

            var productCategories = new List<ProductCategoryEntity>()
            {
                new() { Name = "Eshop", Id = ProductCategoryCodeList.ProductCategories.EshopId, Created = _created },
                new() { Name = "Mobile Devices and accessories", Id = ProductCategoryCodeList.ProductCategories.MobAndAccId, Created = _created , ParentProductCategoryId = ProductCategoryCodeList.ProductCategories.EshopId},
                new() { Name = "Mobile Phones", Id = ProductCategoryCodeList.MobileAndAccesories.MobilePhonesId, Created = _created, ParentProductCategoryId = ProductCategoryCodeList.ProductCategories.MobAndAccId },
                new() { Name = "Cases", Id = ProductCategoryCodeList.MobileAndAccesories.CasesId, Created = _created, ParentProductCategoryId = ProductCategoryCodeList.ProductCategories.MobAndAccId },
                new() { Name = "Adapters", Id = ProductCategoryCodeList.MobileAndAccesories.AdaptersId, Created = _created, ParentProductCategoryId = ProductCategoryCodeList.ProductCategories.MobAndAccId },

                new() { Name = "PC and accessories", Id = ProductCategoryCodeList.ProductCategories.PcAndAccId, Created = _created, ParentProductCategoryId = ProductCategoryCodeList.ProductCategories.EshopId},
                new() { Name = "Graphic cards", Id = ProductCategoryCodeList.PCAndAccesories.GraphicCarsId, Created = _created, ParentProductCategoryId = ProductCategoryCodeList.ProductCategories.PcAndAccId},
                new() { Name = "Disks", Id = ProductCategoryCodeList.PCAndAccesories.DisksId, Created = _created, ParentProductCategoryId = ProductCategoryCodeList.ProductCategories.PcAndAccId},
                new() { Name = "SSD", Id = ProductCategoryCodeList.PCAndAccesories.SsdId, Created = _created, ParentProductCategoryId = ProductCategoryCodeList.PCAndAccesories.DisksId},
                new() { Name = "HDD", Id = ProductCategoryCodeList.PCAndAccesories.HddId, Created = _created, ParentProductCategoryId = ProductCategoryCodeList.PCAndAccesories.DisksId},
            };

            var orderStatuse = new List<OrderStatusEntity>()
            {
                new() {Name = "New", Id = OrderStatusCodeList.OrderStatuses.New },
                new() {Name = "Created", Id = OrderStatusCodeList.OrderStatuses.Created },
                new() {Name = "WaitingForPayment", Id = OrderStatusCodeList.OrderStatuses.WaitingForPayment },
                new() {Name = "InExpedition", Id = OrderStatusCodeList.OrderStatuses.InExpedition },
                new() {Name = "Delivered", Id = OrderStatusCodeList.OrderStatuses.Delivered },
            };


            //Add user roles
            modelBuilder.Entity<UserRoleEntity>()
                    .HasData(userRoles);

            //Add user
            modelBuilder.Entity<UserEntity>()
                .HasData(users);

            //Add Product categories
            modelBuilder.Entity<ProductCategoryEntity>()
                .HasData(productCategories);

            //Add order statuses
            modelBuilder.Entity<OrderStatusEntity>()
                .HasData(orderStatuse);

            return modelBuilder;
        }
    }
}
