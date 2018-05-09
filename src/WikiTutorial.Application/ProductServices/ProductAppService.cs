using Abp.Application.Services;
using Abp.AutoMapper;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WikiTutorial.Entities.ProductEntity;
using WikiTutorial.ProductServices.Dtos;

namespace WikiTutorial.ProductServices
{
    public class ProductAppService : ApplicationService, IProductAppService
    {
        private IProductManager _productManager;

        public ProductAppService(IProductManager productManager)
        {
            _productManager = productManager;
        }

        public async Task<CreateProductOutput> CreateProductAsync(CreateProductInput input)
        {
            var produto = input.MapTo<Product>();
            var createdProdutoId = await _productManager.Create(produto);
            return new CreateProductOutput
            {
                Id = createdProdutoId
            };
        }

        public async Task DeleteProduct(long id)
        {
            await _productManager.Delete(id);
        }
        
        public async Task<GetAllProductsOutput> GetAllProducts()
        {
            var produtos = await _productManager.GetAllList();
            return new GetAllProductsOutput { Products = Mapper.Map<List<GetAllProductsItem>>(produtos) };
        }
        
        public async Task<GetProductByIdOutput> GetById(long id)
        {
            var produto = await _productManager.GetById(id);
            return produto.MapTo<GetProductByIdOutput>();
        }

        public async Task<UpdateProductOutput> UpdateProduct(UpdateProductInput input)
        {
            var produto = input.MapTo<Product>();
            var produtoUpdated = await _productManager.Update(produto);
            return produtoUpdated.MapTo<UpdateProductOutput>();
        }
    }
}
