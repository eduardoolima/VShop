using VShop.ProductApi.DTOs;

namespace VShop.ProductApi.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProducts();
        Task<ProductDTO> GetProductById(int id);
        Task AddProduct(ProductDTO categoryDto);
        Task UpdateProduct(ProductDTO categoryDto);
        Task RemoveProduct(int id);
    }
}
