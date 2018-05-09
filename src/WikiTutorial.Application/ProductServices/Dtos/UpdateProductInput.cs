using Abp.Application.Services.Dto;

namespace WikiTutorial.ProductServices.Dtos
{
    public class UpdateProductInput : EntityDto<long>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Value { get; set; }
    }
}
