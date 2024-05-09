using Ecommerce_Models;

namespace Ecommerce_Business.Repository.IRepository;

public interface IProductRepository
{
    public Task<ProductDTO> Create(ProductDTO product);
    public Task<ProductDTO> Update(ProductDTO product);
    public Task<int> Delete(int productId);
    public Task<ProductDTO> Get(int id);
    public Task<IEnumerable<ProductDTO>> GetAll();
}
