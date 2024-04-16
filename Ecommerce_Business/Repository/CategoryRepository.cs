using AutoMapper;
using Ecommerce_Business.Repository.IRepository;
using Ecommerce_DataAccess;
using Ecommerce_DataAccess.Data;
using Ecommerce_Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_Business.Repository;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _db;
    private readonly IMapper _mapper;

    public CategoryRepository(ApplicationDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }
    public async Task<CategoryDTO> Create(CategoryDTO category)
    {
        var c = _mapper.Map<CategoryDTO, Category>(category);
        c.CreatedDate = DateTime.Now.ToString();
        var addC = _db.Categories.Add(c);
        await _db.SaveChangesAsync();
        return _mapper.Map<Category, CategoryDTO>(addC.Entity);
    }

    public async Task<int> Delete(int categoryId)
    {
        var obj = await _db.Categories.FirstOrDefaultAsync(c => c.CategoryId == categoryId);
        if (obj != null)
        {
            _db.Categories.Remove(obj);
            return await _db.SaveChangesAsync();
        }
        return 0;
    }

    public async Task<CategoryDTO> Get(int id)
    {
        var obj = await _db.Categories.FirstOrDefaultAsync(c => c.CategoryId == id);
        if (obj != null)
        {
            return _mapper.Map<Category, CategoryDTO>(obj);
        }
        return new CategoryDTO();
    }

    public async Task<IEnumerable<CategoryDTO>> GetAll()
    {
        return _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(_db.Categories);
    }

    public async Task<CategoryDTO> Update(CategoryDTO category)
    {
        var objFromDB = await _db.Categories.FirstOrDefaultAsync(c => c.CategoryId == category.Id);

        if (objFromDB != null)
        {
            objFromDB.Name = category.Name;
            _db.Categories.Update(objFromDB);
            await _db.SaveChangesAsync();
            return _mapper.Map<Category, CategoryDTO>(objFromDB);
        }
        return category;
    }
}
