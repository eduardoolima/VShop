using AutoMapper;
using VShop.ProductApi.DTOs;
using VShop.ProductApi.Models;
using VShop.ProductApi.Repositories;

namespace VShop.ProductApi.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var categoriesEntity = await _productRepository.GetAll();
            return _mapper.Map<IEnumerable<ProductDTO>>(categoriesEntity);
        }

        public async Task<ProductDTO> GetProductById(int id)
        {
            var categoriesEntity = await _productRepository.GetById(id);
            return _mapper.Map<ProductDTO>(categoriesEntity);
        }

        public async Task AddProduct(ProductDTO productDto)
        {
            var productEntity = _mapper.Map<Product>(productDto);
            await _productRepository.Create(productEntity);
            productDto.Id = productEntity.Id;
        }

        public async Task UpdateProduct(ProductDTO productDto)
        {
            var productEntity = _mapper.Map<Product>(productDto);
            await _productRepository.Update(productEntity);
        }

        public async Task RemoveProduct(int id)
        {
            var productEntity = _productRepository.GetById(id).Result;
            await _productRepository.Delete(productEntity.Id);
        }
    }
}
