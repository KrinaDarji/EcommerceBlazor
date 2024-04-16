using Ecommerce_Models;

namespace Ecommerce_Business.Repository.IRepository;

public interface ICategoryRepository
{
    public Task<CategoryDTO> Create(CategoryDTO category);
    public Task<CategoryDTO> Update(CategoryDTO category);
    public Task<int> Delete(int categoryId);
    public Task<CategoryDTO> Get(int id);
    public Task<IEnumerable<CategoryDTO>> GetAll();
}
