﻿using AutoMapper;
using Ecommerce_Business.Repository.IRepository;
using Ecommerce_DataAccess;
using Ecommerce_DataAccess.Data;
using Ecommerce_Models;

namespace Ecommerce_Business.Repository;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _db;
    private readonly IMapper _mapper;

    public CategoryRepository(ApplicationDbContext db,IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }
    public CategoryDTO Create(CategoryDTO category)
    {
        var c = _mapper.Map<CategoryDTO, Category>(category);
        c.CreatedDate = DateTime.Now.ToString();
       var addC = _db.Categories.Add(c);
        _db.SaveChanges();
        return _mapper.Map<Category, CategoryDTO>(addC.Entity);
    }

    public int Delete(int categoryId)
    {
        var obj = _db.Categories.FirstOrDefault(c=>c.CategoryId == categoryId);
        if(obj != null)
        {
            _db.Categories.Remove(obj);
            return _db.SaveChanges();
        }
        return 0;
    }

    public CategoryDTO Get(int id)
    {
        var obj = _db.Categories.FirstOrDefault(c => c.CategoryId == id);
        if (obj != null)
        {
           return _mapper.Map<Category, CategoryDTO>(obj);
        }
        return new CategoryDTO();
    }

    public IEnumerable<CategoryDTO> GetAll()
    {
        return _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(_db.Categories);
    }

    public CategoryDTO Update(CategoryDTO category)
    {
        var objFromDB = _db.Categories.FirstOrDefault(c => c.CategoryId == category.Id);

        if(objFromDB != null)
        {
            objFromDB.Name = category.Name;
            _db.Categories.Update(objFromDB);
            _db.SaveChanges();
            return _mapper.Map<Category, CategoryDTO>(objFromDB);
        }
        return category;
    }
}
