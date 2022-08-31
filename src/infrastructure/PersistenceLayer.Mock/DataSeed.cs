namespace PersistenceLayer.Mock
{
	using AppUtils.PasswordHashing;
	using CodeLists.OrderStatuses;
	using CodeLists.ProductCategories;
	using CodeLists.UserRoles;
	using DomainLayer.Entities.Orders;
	using DomainLayer.Entities.Product;
	using DomainLayer.Entities.Users;
	using Microsoft.EntityFrameworkCore;

	public static class DataSeed
	{
		public static void Seed(this ModelBuilder modelBuilder)
		{
			var orderStatuses = new List<OrderStatusEntity>()
			{
				new() {Name = "New", Id = OrderStatuses.New, IsOrderEditable = true, Created = DateTime.Now },
				new() {Name = "Created", Id = OrderStatuses.Created, IsOrderEditable = true, Created = DateTime.Now },
				new() {Name = "WaitingForPayment", Id = OrderStatuses.WaitingForPayment, IsOrderEditable = false, Created = DateTime.Now },
				new() {Name = "InExpedition", Id = OrderStatuses.InExpedition, IsOrderEditable = false, Created = DateTime.Now },
				new() {Name = "Delivered", Id = OrderStatuses.Delivered, IsOrderEditable = false, Created = DateTime.Now },
				new() {Name = "Canceled", Id = OrderStatuses.Canceled, IsOrderEditable = false, Created = DateTime.Now },
			};

			//Add order statuses
			modelBuilder.Entity<OrderStatusEntity>()
				.HasData(orderStatuses);

			var productCategories = new List<ProductCategoryEntity>()
			{
				new() { Name = "Eshop", Id = ProductCategories.EshopId, Created = DateTime.Now },
				new() { Name = "Mobile Devices and accessories", Id = ProductCategories.MobAndAccId, Created = DateTime.Now , ParentProductCategoryId = ProductCategories.EshopId},
				new() { Name = "Mobile Phones", Id = MobileAndAccesories.MobilePhonesId, Created = DateTime.Now, ParentProductCategoryId = ProductCategories.MobAndAccId },
				new() { Name = "Cases", Id = MobileAndAccesories.CasesId, Created = DateTime.Now, ParentProductCategoryId = ProductCategories.MobAndAccId },
				new() { Name = "Adapters", Id = MobileAndAccesories.AdaptersId, Created = DateTime.Now, ParentProductCategoryId = ProductCategories.MobAndAccId },

				new() { Name = "PC and accessories", Id = ProductCategories.PcAndAccId, Created = DateTime.Now, ParentProductCategoryId = ProductCategories.EshopId },
				new() { Name = "Graphic cards", Id = PCAndAccesories.GraphicCarsId, Created = DateTime.Now, ParentProductCategoryId = ProductCategories.PcAndAccId },
				new() { Name = "Disks", Id = PCAndAccesories.DisksId, Created = DateTime.Now, ParentProductCategoryId = ProductCategories.PcAndAccId },
				new() { Name = "SSD", Id = PCAndAccesories.SsdId, Created = DateTime.Now, ParentProductCategoryId = PCAndAccesories.DisksId },
				new() { Name = "HDD", Id = PCAndAccesories.HddId, Created = DateTime.Now, ParentProductCategoryId = PCAndAccesories.DisksId },
			};

			//Add Product categories
			modelBuilder.Entity<ProductCategoryEntity>()
				.HasData(productCategories);

			PasswordHashing.CreatePasswordHash("aJc48262_1Kjkz>X!", out byte[] pwHash, out byte[] pwSalt);
			PasswordHashing.CreatePasswordHash("hovnoPrdel", out byte[] pwHash2, out byte[] pwSalt2);
			PasswordHashing.CreatePasswordHash("hovnoPrdel", out byte[] pwHash3, out byte[] pwSalt3);
			PasswordHashing.CreatePasswordHash("hovnoPrdel", out byte[] pwHash4, out byte[] pwSalt4);

			var userRoles = new List<UserRoleEntity>()
			{
				new(){Id = UserRoles.AdminId, Name = UserRoles.Admin, Created =DateTime.Now }
			};

			modelBuilder.Entity<UserRoleEntity>()
				.HasData(userRoles);

			var users = new List<UserEntity>()
			{
				new(){ Id = 1, Name = "Admin", UserName = "Admin", Surname = "Admin", PasswordHash = pwHash, PasswordSalt = pwSalt, Email = "some@email.com", Created = DateTime.Now, IsActive = true },
				new(){ Id = 2, Name = "Libor", UserName = "LibikSojik", Surname = "Sojka", PasswordHash = pwHash2, PasswordSalt = pwSalt2, Email = "liborSojka@email.com", Created = DateTime.Now, IsActive = true  },
				new(){ Id = 3, Name = "Onder", UserName = "WonderMan", Surname = "Vonder", PasswordHash = pwHash3, PasswordSalt = pwSalt3, Email = "onder@email.com", Created = DateTime.Now, IsActive = true  },
				new(){ Id = 4, Name = "Ransad", UserName = "sdfsa", Surname = "sdfs", PasswordHash = pwHash4, PasswordSalt = pwSalt4, Email = "dfs@email.com", Created = DateTime.Now, IsActive = true  },
			};

			//Add order statuses
			modelBuilder.Entity<UserEntity>()
				.HasData(users);

			var productDetailInfos = new List<ProductDetailInfoEntity>()
			{
				new() { Id = 1, Created = DateTime.Now, DetailedDescription = "asdfjhsad kjfhaskdjfhsadkjfh ksjfh kjsafjskadh fsakdfh asdf sdfa ssda fsdaf sadfsa dfsa f", Parameters = "{Json:\"value\"}"},
				new() { Id = 2, Created = DateTime.Now, DetailedDescription = "asdfjhsad kjfhaskdjfhsadkjfh ksjfh kjsafjskadh fsakdfh asdf sdfa ssda fsdaf sadfsa dfsa f", Parameters = "{Json:\"value\"}"},
				new() { Id = 3, Created = DateTime.Now, DetailedDescription = "asdfjhsad kjfhaskdjfhsadkjfh ksjfh kjsafjskadh fsakdfh asdf sdfa ssda fsdaf sadfsa dfsa f", Parameters = "{Json:\"value\"}"},
				new() { Id = 4, Created = DateTime.Now, DetailedDescription = "asdfjhsad kjfhaskdjfhsadkjfh ksjfh kjsafjskadh fsakdfh asdf sdfa ssda fsdaf sadfsa dfsa f", Parameters = "{Json:\"value\"}"},
				new() { Id = 5, Created = DateTime.Now, DetailedDescription = "asdfjhsad kjfhaskdjfhsadkjfh ksjfh kjsafjskadh fsakdfh asdf sdfa ssda fsdaf sadfsa dfsa f", Parameters = "{Json:\"value\"}"},
			};

			modelBuilder.Entity<ProductDetailInfoEntity>()
				.HasData(productDetailInfos);

			var productDetails = new List<ProductDetailEntity>()
			{
				new(){ Id = 1, Created = DateTime.Now, Description = "description", Name = "AAAA", Price = 800, ProductCategoryId = 1001, ProductCode = "AAAA0000", ProductDetailInfoId = 1 },
				new(){ Id = 2, Created = DateTime.Now, Description = "jkljkdjfk afkjdskfskdfj", Name = "BBBB", Price = 200, ProductCategoryId = 2004, ProductCode = "AAAA0001", ProductDetailInfoId = 2 },
				new(){ Id = 3, Created = DateTime.Now, Description = "jkljkdjfk afkjdskfskdfj", Name = "CCCC", Price = 1800, ProductCategoryId = 2003, ProductCode = "AAAA0002", ProductDetailInfoId = 3 },
				new(){ Id = 4, Created = DateTime.Now, Description = "jkljkdjfk afkjdskfskdfj", Name = "DDDD", Price = 500, ProductCategoryId = 1002, ProductCode = "AAAA0003", ProductDetailInfoId = 4 },
				new(){ Id = 5, Created = DateTime.Now, Description = "jkljkdjfk afkjdskfskdfj", Name = "EEEE", Price = 50, ProductCategoryId = 2002, ProductCode = "AAAA0004", ProductDetailInfoId = 5 }
			};

			modelBuilder.Entity<ProductDetailEntity>()
				.HasData(productDetails);

			var products = new List<ProductEntity>
			{
				new(){ Id = 1, Created = DateTime.Now, ProductDetailId = 1},
				new(){ Id = 2, Created = DateTime.Now, ProductDetailId = 1},
				new(){ Id = 3, Created = DateTime.Now, ProductDetailId = 1},
				new(){ Id = 4, Created = DateTime.Now, ProductDetailId = 1},
				new(){ Id = 5, Created = DateTime.Now, ProductDetailId = 2},
				new(){ Id = 6, Created = DateTime.Now, ProductDetailId = 2},
				new(){ Id = 7, Created = DateTime.Now, ProductDetailId = 2},
				new(){ Id = 8, Created = DateTime.Now, ProductDetailId = 3},
				new(){ Id = 9, Created = DateTime.Now, ProductDetailId = 3},
				new(){ Id = 10, Created = DateTime.Now, ProductDetailId = 3},
				new(){ Id = 11, Created = DateTime.Now, ProductDetailId = 3},
				new(){ Id = 12, Created = DateTime.Now, ProductDetailId = 4},
				new(){ Id = 13, Created = DateTime.Now, ProductDetailId = 4},
				new(){ Id = 14, Created = DateTime.Now, ProductDetailId = 4},
				new(){ Id = 15, Created = DateTime.Now, ProductDetailId = 5},
				new(){ Id = 16, Created = DateTime.Now, ProductDetailId = 5},
				new(){ Id = 17, Created = DateTime.Now, ProductDetailId = 5},
				new(){ Id = 18, Created = DateTime.Now, ProductDetailId = 5},
			};

			modelBuilder.Entity<ProductEntity>()
				.HasData(products);

			var orders = new List<OrderEntity>()
			{
				new(){ Id = 1, Created = DateTime.Now, OrderStatusId = 4, OrderCode = "AAAAA00000", UserId = 1},
				new(){ Id = 2, Created = DateTime.Now, OrderStatusId = 1, OrderCode = "AAAAA00001", UserId = 2},
				new(){ Id = 3, Created = DateTime.Now, OrderStatusId = 1, OrderCode = "AAAAA00002", UserId = 1},
				new(){ Id = 4, Created = DateTime.Now, OrderStatusId = 1, OrderCode = "AAAAA00003", UserId = 4},
			};

			modelBuilder.Entity<OrderEntity>()
				.HasData(orders);

			var orderItems = new List <OrderItemEntity>()
			{
				new(){ Id = 1, Created = DateTime.Now, OrderId = 1, ProductId = 1},
				new(){ Id = 2, Created = DateTime.Now, OrderId = 1, ProductId = 4},
				new(){ Id = 3, Created = DateTime.Now, OrderId = 1, ProductId = 8},
				new(){ Id = 4, Created = DateTime.Now, OrderId = 3, ProductId = 2},
			};

			modelBuilder.Entity<OrderItemEntity>()
				.HasData(orderItems);
		}
	}
}
