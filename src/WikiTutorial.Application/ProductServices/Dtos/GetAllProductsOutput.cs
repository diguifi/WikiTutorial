using System.Collections.Generic;

namespace WikiTutorial.ProductServices.Dtos
{
    public class GetAllProductsOutput
    {
        public List<GetAllProductsItem> Products { get; set; }
    }
}
