using Abp.Domain.Repositories;
using Abp.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WikiTutorial.Entities.ProductEntity
{
    public class ProductManager : IDomainService, IProductManager
    {
        private IRepository<Product, long> _productRepository;

        public ProductManager(IRepository<Product, long> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<long> Create(Product product)
        {
            return await _productRepository.InsertAndGetIdAsync(product);
        }

        public async Task<Product> Update(Product product)
        {
            return await _productRepository.UpdateAsync(product);
        }

        public async Task Delete(long id)
        {
            await _productRepository.DeleteAsync(id);
        }

        public async Task<Product> GetById(long id)
        {
            return await _productRepository.GetAsync(id);
        }

        public async Task<List<Product>> GetAllList()
        {
            return await _productRepository.GetAllListAsync();
        }
    }
}
