using System.ComponentModel.DataAnnotations;

namespace Ecommerce_DataAccess.Data;

public class Category
{
    [Key]
    public int CategoryId { get; set; }
    public string Name { get; set; }
    public string CreatedDate { get; set; }
}
