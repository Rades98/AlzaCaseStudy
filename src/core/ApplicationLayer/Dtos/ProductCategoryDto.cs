namespace ApplicationLayer.Dtos
{
    using DomainLayer.Entities.Product;

    public class ProductCategoryDto
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public List<ProductCategoryDto>? Children { get; set; } = new List<ProductCategoryDto>();

        public static explicit operator ProductCategoryDto(ProductCategoryEntity entity)
        {
            //This shit should be made better once... but not now :D 
            return new ProductCategoryDto()
            {
                Id = entity.Id,
                CategoryName = entity.Name,
                Children = entity.ChildrenCategories?
                .Select(x => new ProductCategoryDto()
                {
                    Id = x.Id,
                    CategoryName = x.Name,
                    Children = x.ChildrenCategories?
                    .Select(y => new ProductCategoryDto()
                    {
                        Id = y.Id,
                        CategoryName = y.Name,
                        Children = y.ChildrenCategories?
                        .Select(z => new ProductCategoryDto()
                        {
                            Id =z.Id,
                            CategoryName = z.Name,
                            Children = z.ChildrenCategories?
                            .Select(aa => new ProductCategoryDto()
                            { 
                                Id = aa.Id,
                                CategoryName = aa.Name,
                                Children = aa.ChildrenCategories?
                                .Select(ab => new ProductCategoryDto()
                                {
                                    Id = ab.Id,
                                    CategoryName = ab.Name
                                }).ToList()
                            }).ToList()
                        }).ToList()
                    }).ToList()
                }).ToList()
            };
        }
    }
}
