using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WikiTutorial.ProductServices.Dtos;

namespace WikiTutorial.ProductServices
{
    public interface IProductAppService : IApplicationService
    {
        Task<CreateProductOutput> CreateProductAsync(CreateProductInput input);
        Task<UpdateProductOutput> UpdateProduct(UpdateProductInput input);
        Task DeleteProduct(long id);
        Task<GetProductByIdOutput> GetById(long id);
        Task<GetAllProductsOutput> GetAllProducts();
    }
}
