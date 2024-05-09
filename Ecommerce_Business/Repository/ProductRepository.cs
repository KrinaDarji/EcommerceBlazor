using AutoMapper;
using Ecommerce_Business.Repository.IRepository;
using Ecommerce_DataAccess;
using Ecommerce_DataAccess.Data;
using Ecommerce_Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_Business.Repository;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _db;
    private readonly IMapper _mapper;

    public ProductRepository(ApplicationDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }
    public async Task<ProductDTO> Create(ProductDTO Product)
    {
        var p = _mapper.Map<ProductDTO, Product>(Product);
        var addC = _db.Products.Add(p);
        await _db.SaveChangesAsync();
        return _mapper.Map<Product, ProductDTO>(addC.Entity);
    }

    public async Task<int> Delete(int productId)
    {
        var obj = await _db.Products.FirstOrDefaultAsync(c => c.Id == productId);
        if (obj != null)
        {
            _db.Products.Remove(obj);
            return await _db.SaveChangesAsync();
        }
        return 0;
    }

    public async Task<ProductDTO> Get(int id)
    {
        var obj = await _db.Products.Include(u=>u.Category).FirstOrDefaultAsync(c => c.Id == id);
        if (obj != null)
        {
            return _mapper.Map<Product, ProductDTO>(obj);
        }
        return new ProductDTO();
    }

    public async Task<IEnumerable<ProductDTO>> GetAll()
    {
        return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(_db.Products.Include(u=>u.Category));
    }

    public async Task<ProductDTO> Update(ProductDTO objDTO)
    {
        var objFromDb = await _db.Products.FirstOrDefaultAsync(u => u.Id == objDTO.Id);
        if (objFromDb != null)
        {
            objFromDb.Name = objDTO.Name;
            objFromDb.Description = objDTO.Description;
            objFromDb.ImageUrl = objDTO.ImageUrl;
            objFromDb.CategoryId = objDTO.CategoryId;
            objFromDb.Color = objDTO.Color;
            objFromDb.ShopFavorites = objDTO.ShopFavorites;
            objFromDb.CustomerFavorites = objDTO.CustomerFavorites;
            _db.Products.Update(objFromDb);
            await _db.SaveChangesAsync();
            return _mapper.Map<Product, ProductDTO>(objFromDb);
        }
        return objDTO;
    }
}
