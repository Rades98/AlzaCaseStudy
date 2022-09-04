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

namespace PersistenceLayer.Database.Extensions
{
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
				new(){ Id = 1, Created = _created, Code="test", LinkActiveTill = _created}
			};

			var users = new List<UserEntity>()
			{
				new(){ Id = 1, Name = "Admin", UserName = "Admin", Surname = "Admin", PasswordHash = pwHash, PasswordSalt = pwSalt, Email = "some@email.com", Created = _created, IsActive = true, RegistrationId = 1 }
			};

			var productCategories = new List<ProductCategoryEntity>()
			{
				new() { Name = "Eshop", Id = ProductCategories.EshopId, Created = _created },

				new() { Name = "Mobile devices and accessories", Id = ProductCategories.MobAndAccId, Created = _created , ParentProductCategoryId = ProductCategories.EshopId},
				new() { Name = "Mobile Phones", Id = ProductCategories.MobilePhonesId, Created = _created, ParentProductCategoryId = ProductCategories.MobAndAccId },
				new() { Name = "Mobile cases", Id = ProductCategories.CasesId, Created = _created, ParentProductCategoryId = ProductCategories.MobAndAccId },
				new() { Name = "Mobile adapters", Id = ProductCategories.AdaptersId, Created = _created, ParentProductCategoryId = ProductCategories.MobAndAccId },

				new() { Name = "PC and accessories", Id = ProductCategories.PcAndAccId, Created = _created, ParentProductCategoryId = ProductCategories.EshopId },
				new() { Name = "Graphic cards", Id = ProductCategories.GraphicCarsId, Created = _created, ParentProductCategoryId = ProductCategories.PcAndAccId },
				new() { Name = "Notebooks", Id = ProductCategories.Notebooks, Created = DateTime.Now, ParentProductCategoryId = ProductCategories.PcAndAccId },
				new() { Name = "PCs", Id = ProductCategories.Pcs, Created = DateTime.Now, ParentProductCategoryId = ProductCategories.PcAndAccId },
				new() { Name = "Notebook adapters", Id = ProductCategories.NotebookAdapters, Created = DateTime.Now, ParentProductCategoryId = ProductCategories.Notebooks },
				new() { Name = "Notebook bags", Id = ProductCategories.NotebookBags, Created = DateTime.Now, ParentProductCategoryId = ProductCategories.Notebooks },
				new() { Name = "Webcams", Id = ProductCategories.Webcams, Created = DateTime.Now, ParentProductCategoryId = ProductCategories.PcAndAccId },
				new() { Name = "Disks", Id = ProductCategories.DisksId, Created = _created, ParentProductCategoryId = ProductCategories.PcAndAccId },
				new() { Name = "SSD", Id = ProductCategories.SsdId, Created = _created, ParentProductCategoryId = ProductCategories.DisksId },
				new() { Name = "HDD", Id = ProductCategories.HddId, Created = _created, ParentProductCategoryId = ProductCategories.DisksId },
				new() { Name = "Mouses", Id = ProductCategories.Mouses, Created = _created, ParentProductCategoryId = ProductCategories.PcAndAccId },
				new() { Name = "Monitors", Id = ProductCategories.Monitors, Created = _created, ParentProductCategoryId = ProductCategories.PcAndAccId },
				new() { Name = "Microphones", Id = ProductCategories.Microphones, Created = _created, ParentProductCategoryId = ProductCategories.PcAndAccId },
				new() { Name = "Bent monitors", Id = ProductCategories.BentMonitors, Created = _created, ParentProductCategoryId = ProductCategories.Monitors },
				new() { Name = "Keyboards", Id = ProductCategories.Keyboards, Created = _created, ParentProductCategoryId = ProductCategories.PcAndAccId },
				new() { Name = "Bluetooth keyboards", Id = ProductCategories.BluetoothKeyboards, Created = _created, ParentProductCategoryId = ProductCategories.Keyboards },
				new() { Name = "Gaming keyboards", Id = ProductCategories.GamingKeyboards, Created = _created, ParentProductCategoryId = ProductCategories.Keyboards },
				new() { Name = "Headphones", Id = ProductCategories.HeadPhones, Created = _created, ParentProductCategoryId = ProductCategories.PcAndAccId  },
				new() { Name = "Headphones with microphone", Id = ProductCategories.HeadPhonesWithMicrophone, Created = _created, ParentProductCategoryId = ProductCategories.HeadPhones },
				new() { Name = "Headsets", Id = ProductCategories.HeadSets, Created = _created, ParentProductCategoryId = ProductCategories.HeadPhones },
				new() { Name = "Bluetooth headsets", Id = ProductCategories.BlueToothHeadsets, Created = _created, ParentProductCategoryId = ProductCategories.HeadPhones },
				new() { Name = "Bluetooth headphones", Id = ProductCategories.BluetoothHeadphones, Created = _created, ParentProductCategoryId = ProductCategories.HeadPhones },

				new() { Name = "Printers and accessories", Id = ProductCategories.PrintersAndAccId, Created = _created, ParentProductCategoryId = ProductCategories.EshopId },
				new() { Name = "Laser printers", Id = ProductCategories.LaserPrinters, Created = _created, ParentProductCategoryId = ProductCategories.PrintersAndAccId },
				new() { Name = "Ink printers", Id = ProductCategories.InkPrinters, Created = _created, ParentProductCategoryId = ProductCategories.PrintersAndAccId },
				new() { Name = "3D printers", Id = ProductCategories.TDPrinters, Created = _created, ParentProductCategoryId = ProductCategories.PrintersAndAccId },
				new() { Name = "Tank printers", Id = ProductCategories.TankPrinters, Created = _created, ParentProductCategoryId = ProductCategories.PrintersAndAccId },
				new() { Name = "Printers accessories", Id = ProductCategories.PrinterAccessories, Created = _created, ParentProductCategoryId = ProductCategories.PrintersAndAccId },

				new() { Name = "PC chairs and accessories", Id = ProductCategories.PCChairsAndAccId, Created = _created, ParentProductCategoryId = ProductCategories.EshopId },
				new() { Name = "Gaming chairs", Id = ProductCategories.GamingChairs, Created = _created, ParentProductCategoryId = ProductCategories.PCChairs },
				new() { Name = "PC chairs", Id = ProductCategories.PCChairs, Created = _created, ParentProductCategoryId = ProductCategories.PCChairs },
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
