using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WikiTutorial.Entities.ProductEntity
{
    public interface IProductManager
    {
        Task<long> Create(Product produto);
        Task<Product> Update(Product produto);
        Task Delete(long id);
        Task<Product> GetById(long id);
        Task<List<Product>> GetAllList();
    }
}
