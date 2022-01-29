using Furniture_Shop_Backend.ViewModels.Common;
using Furniture_Shop_Backend.ViewModels.Product;
using Furniture_Shop_Backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;
using Furniture_Shop_Backend.Services.ProductImages;

namespace Furniture_Shop_Backend.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly FurnitureShopContext _context;
        private readonly IProductImagesService _productImagesService; 
        public ProductService(FurnitureShopContext context, IProductImagesService productImagesService)
        {    
            _context = context;
            _productImagesService = productImagesService;
        }
        public async Task<ApiResult<bool>> Create(ProductCreateRequest request)
        { var category = await _context.Categories.FindAsync(request.CategoryId);
            var brand = await _context.Brands.FindAsync(request.BrandId);
            var material = await _context.Materials.FindAsync(request.MaterialId);
            if (category == null)
            {
                return new ApiErrorResult<bool>($"Không tìm thấy loại sản phầm với id: {request.CategoryId}");
            }
            if (brand == null)
            {
                return new ApiErrorResult<bool>($"Không tìm thấy thương hiệu sản phầm với id: {request.BrandId}");
            }
            if (material == null)
            {
                return new ApiErrorResult<bool>($"Không tìm thấy chất liệu sản phầm với id: {request.MaterialId}");
            }
            var Product = new Product()
            {
                ProductBasetId = request.ProductBasetId,
                CategoryId = request.CategoryId,
                BrandId = request.BrandId,
                MaterialId = request.MaterialId,
                Size = request.Size,
                Description = request.Description,
                Quantity = request.Quantity,
                Price = request.Price,

            };
            _context.Products.Add(Product);
            await _context.SaveChangesAsync();
            return new ApiSuccessResult<bool>();
        }

        public Task<int> Delete(int productId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<PagedResult<ProductVm>> GetAllByCategoryId(GetProductPagingRequest request)
        {
            var query = from p in _context.Products
                        join c in _context.Categories on p.CategoryId equals c.Id
                        join b in _context.Brands on p.BrandId equals b.Id
                        join m in _context.Materials on p.MaterialId equals m.Id
                        select new { p, c, b, m };
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(c => c.p.Description.Contains(request.Keyword));
            }
            if (request.CategoryId > 0)
            {
                 query = query.Where(c => c.c.Id.Equals(request.CategoryId));
            }
            int totalRow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
               .Take(request.PageSize)
               .Select(x => new ProductVm()
               {
                   Id = x.p.Id,
                   Description = x.p.Description,
                   ProductBasetId = x.p.ProductBasetId,
                   Price = x.p.Price,
                   Size = x.p.Size,
                   Quantity = x.p.Quantity,
                   Categories = x.c.Description,
                   Brand = x.b.Description,
                   Material = x.m.Description
                   // Name = x.pt.Name,
                   // DateCreated = x.p.DateCreated,
                   // Details = x.pt.Details,
                   // OriginalPrice = x.p.OriginalPrice,
               }).ToListAsync();
            foreach (var item in data)
            {
                item.UrlImages = await _productImagesService.GetUrlsByIdProductbase(item.ProductBasetId);
            }
            //4. Select and projection
            var pagedResult = new PagedResult<ProductVm>()
            {
                TotalRecords = totalRow,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                Items = data
            };
            return pagedResult;
        }

        public async Task<PagedResult<ProductVm>> GetAllPaging( GetProductPagingRequest request)
        {
            var query = from p in _context.Products
                        join c in _context.Categories on p.CategoryId equals c.Id
                        join b in _context.Brands on p.BrandId equals b.Id
                        join m in _context.Materials on p.MaterialId equals m.Id
                        select new { p, c, b, m };
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(c => c.p.Description.Contains(request.Keyword));
            }
            int totalRow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
               .Take(request.PageSize)
               .Select( x => new ProductVm()
               {
                   Id = x.p.Id,
                   Description = x.p.Description,
                   ProductBasetId = x.p.ProductBasetId,
                   Price = x.p.Price,
                   Size = x.p.Size,
                   Quantity = x.p.Quantity,
                   Categories = x.c.Description,
                   Brand = x.b.Description,
                   Material = x.m.Description
                   // Name = x.pt.Name,
                   // DateCreated = x.p.DateCreated,
                   // Details = x.pt.Details,
                   // OriginalPrice = x.p.OriginalPrice,
               }).ToListAsync();
              foreach (var item in data)
              {
                item.UrlImages = await _productImagesService.GetUrlsByIdProductbase(item.ProductBasetId);
              }
            //4. Select and projection
            var pagedResult = new PagedResult<ProductVm>()
            {
                TotalRecords = totalRow,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                Items = data
            };
            return pagedResult;
        }

        public async Task<ProductVm> GetById(int productId)
        {
            var query = from p in _context.Products
                        join c in _context.Categories on p.CategoryId equals c.Id
                        join b in _context.Brands on p.BrandId equals b.Id
                        join m in _context.Materials on p.MaterialId equals m.Id
                        select new { p, c, b, m };
            query = query.Where(c => c.p.Id.Equals(productId));
            var data = await query
               .Select(x => new ProductVm()
               {
                   Id = x.p.Id,
                   Description = x.p.Description,
                   ProductBasetId = x.p.ProductBasetId,
                   Price = x.p.Price,
                   Size = x.p.Size,
                   Quantity = x.p.Quantity,
                   Categories = x.c.Description,
                   Brand = x.b.Description,
                   Material = x.m.Description
                   // Name = x.pt.Name,
                   // DateCreated = x.p.DateCreated,
                   // Details = x.pt.Details,
                   // OriginalPrice = x.p.OriginalPrice,
               }).ToListAsync();
            foreach (var item in data)
            {
                item.UrlImages = await _productImagesService.GetUrlsByIdProductbase(item.ProductBasetId);
            }
            //4. Select 
            return data.FirstOrDefault();
        }

        public async Task<ApiResult<ProductVm>> Update(int id, ProductUpdateRequest request)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return new ApiErrorResult<ProductVm>($"Không tìm thấy sản phầm với id: {id}");
            }
            if (request.CategoryId != product.CategoryId && request.CategoryId != 0)
            {
                var category = await _context.Categories.FindAsync(request.CategoryId);
                if (category == null)
                {
                    return new ApiErrorResult<ProductVm>($"Không tìm thấy loại sản phầm với id: {request.CategoryId}");
                }
            }
            if(request.BrandId != product.BrandId && request.BrandId != 0)
            {
                var brand = await _context.Brands.FindAsync(request.BrandId);
                if (brand == null)
                {
                    return new ApiErrorResult<ProductVm>($"Không tìm thấy thương hiệu sản phầm với id: {request.BrandId}");
                }
            }
            if(request.MaterialId != product.MaterialId && request.MaterialId != 0)
            {
                var material = await _context.Materials.FindAsync(request.MaterialId);
                if (material == null)
                {
                    return new ApiErrorResult<ProductVm>($"Không tìm thấy chất liệu sản phầm với id: {request.MaterialId}");
                }
            }                        
            product.CategoryId = request.CategoryId.Value == 0 ? product.CategoryId : request.CategoryId;
            product.BrandId =  request.BrandId.Value == 0 ? product.BrandId : request.BrandId;
            product.MaterialId = request.MaterialId.Value == 0 ? product.MaterialId : request.MaterialId;
            product.Size = request.Size.Equals("") ? product.Size : request.Size;
            product.Price = request.Price.HasValue && (request.Price.Value  > 0) ? request.Price : product.Price;
            product.Description = request.Description.Equals("") ? product.Description : request.Description;
            product.Quantity = request.Quantity.HasValue && (request.Quantity.Value >= 0) ? request.Quantity : product.Quantity; 
            _context.Products.Update(product);
            var productId = await _context.SaveChangesAsync();
            ProductVm productvm = new ProductVm()
            {
               Id = product.Id,
               Brand = product.Brand.Description,
               Categories = product.Category.Description,
               Material = product.Material.Description,
               Size = product.Size,
               Price = product.Price,
               Description = product.Description,
               Quantity = product.Quantity
            };
            return new ApiSuccessResult<ProductVm>(productvm);
        }

    }
}
