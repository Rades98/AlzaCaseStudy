namespace PersistenceLayer.Database.Extensions
{
	using AppUtils.PasswordHashing;
	using CodeLists.Languages;
	using CodeLists.MessageTypes;
	using CodeLists.OrderStatuses;
	using CodeLists.ProductCategories;
	using CodeLists.UserRoles;
	using DomainLayer.Entities.LanguageMutations;
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
                new() { Id = UserRoles.AdminId, Name = UserRoles.Admin, Created = _created }
            };

            // Admin
            // aJc48262_1Kjkz>X!
            PasswordHashing.CreatePasswordHash("aJc48262_1Kjkz>X!", out byte[] pwHash, out byte[] pwSalt);

            var userRegistrations = new List<UserRegistrationEntity>()
            {
				new(){ Id = 1, Created = _created, Code="some hash haha ha ha ha haaaaaaaaaa", LinkActiveTill = _created}
            };

            var users = new List<UserEntity>()
            {
                new(){ Id = 1, Name = "Admin", UserName = "Admin", Surname = "Admin", PasswordHash = pwHash, PasswordSalt = pwSalt, Email = "some@email.com", Created = _created, IsActive = true, RegistrationId = 1 }
            };

            var productCategories = new List<ProductCategoryEntity>()
            {
                new() { Name = "Eshop", Id = ProductCategories.EshopId, Created = _created },
                new() { Name = "Mobile Devices and accessories", Id = ProductCategories.MobAndAccId, Created = _created , ParentProductCategoryId = ProductCategories.EshopId},
                new() { Name = "Mobile Phones", Id = MobileAndAccesories.MobilePhonesId, Created = _created, ParentProductCategoryId = ProductCategories.MobAndAccId },
                new() { Name = "Cases", Id = MobileAndAccesories.CasesId, Created = _created, ParentProductCategoryId = ProductCategories.MobAndAccId },
                new() { Name = "Adapters", Id = MobileAndAccesories.AdaptersId, Created = _created, ParentProductCategoryId = ProductCategories.MobAndAccId },

                new() { Name = "PC and accessories", Id = ProductCategories.PcAndAccId, Created = _created, ParentProductCategoryId = ProductCategories.EshopId },
                new() { Name = "Graphic cards", Id = PCAndAccesories.GraphicCarsId, Created = _created, ParentProductCategoryId = ProductCategories.PcAndAccId },
                new() { Name = "Disks", Id = PCAndAccesories.DisksId, Created = _created, ParentProductCategoryId = ProductCategories.PcAndAccId },
                new() { Name = "SSD", Id = PCAndAccesories.SsdId, Created = _created, ParentProductCategoryId = PCAndAccesories.DisksId },
                new() { Name = "HDD", Id = PCAndAccesories.HddId, Created = _created, ParentProductCategoryId = PCAndAccesories.DisksId },
            };

            var orderStatuse = new List<OrderStatusEntity>()
            {
                new() {Name = "New", Id = OrderStatuses.New, IsOrderEditable = true, Created = _created },
                new() {Name = "Created", Id = OrderStatuses.Created, IsOrderEditable = true, Created = _created },
                new() {Name = "WaitingForPayment", Id = OrderStatuses.WaitingForPayment, IsOrderEditable = false, Created = _created },
                new() {Name = "InExpedition", Id = OrderStatuses.InExpedition, IsOrderEditable = false, Created = _created },
                new() {Name = "Delivered", Id = OrderStatuses.Delivered, IsOrderEditable = false, Created = _created },
                new() {Name = "Canceled", Id = OrderStatuses.Canceled, IsOrderEditable = false, Created = _created },
            };

            var languages = new List<LanguageEntity>()
            {
                new() {Name="Čeština", Code="cs", Id = Languages.CZLanguage, Created = _created },
                new() {Name="English", Code="en", Id = Languages.ENLanguage, Created = _created },
                new() {Name="Slovenčina", Code="sk", Id = Languages.SKLanguage, Created = _created },
                new() {Name="Polski", Code="pl", Id = Languages.PLLanguage, Created = _created },
                new() {Name="Deutsch", Code="de", Id = Languages.DELanguage, Created = _created },
                new() {Name="Français", Code="fe", Id = Languages.FELanguage, Created = _created },
            };

            var messageTypes = new List<MessageTypeEntity>()
            {
                new() { Name = "Info", Id = MessagTypes.Info, Created = _created },
                new() { Name = "Hint", Id = MessagTypes.Hint, Created = _created },
                new() { Name = "Error", Id = MessagTypes.Error, Created = _created },
            };

            //Add Languages
            modelBuilder.Entity<LanguageEntity>()
                .HasData(languages);

			//Add messageTypes
            modelBuilder.Entity<MessageTypeEntity>()
                .HasData(messageTypes);

            //Add user roles
            modelBuilder.Entity<UserRoleEntity>()
                    .HasData(userRoles);

            //Add user registration
            modelBuilder.Entity<UserRegistrationEntity>()
                .HasData(userRegistrations);

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
