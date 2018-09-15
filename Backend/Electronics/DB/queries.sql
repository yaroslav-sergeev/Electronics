select Category.* from (Category inner join CategoryBrand on Category.Id=CategoryBrand.CategoryId) inner join Brand on CategoryBrand.BrandId=Brand.Id
where BrandId=@brandId;

select Product.* from (((select Category.Id from Category where Name=@category) as Cat inner join CategoryBrand on Cat.Id=CategoryBrand.CategoryId)
inner join (select Brand.Id from Brand where Name=@brand) as Br on CategoryBrand.BrandId=Br.Id)
inner join Product on Product.BrandId=CategoryBrand.BrandId and Product.CategoryId=CategoryBrand.CategoryId