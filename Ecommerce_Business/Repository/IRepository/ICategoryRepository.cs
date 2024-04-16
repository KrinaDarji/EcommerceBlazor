using Ecommerce_Models;

namespace Ecommerce_Business.Repository.IRepository;

public interface ICategoryRepository
{
    public CategoryDTO Create(CategoryDTO category);
    public CategoryDTO Update(CategoryDTO category);
    public int Delete(int categoryId);
    public CategoryDTO Get(int id);
    public IEnumerable<CategoryDTO> GetAll();
}
