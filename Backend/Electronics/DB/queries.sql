
select Category.* from (Category inner join CategoryBrand on Category.Id=CategoryBrand.CategoryId) inner join Brand on CategoryBrand.BrandId=Brand.Id
where BrandId=@brandId