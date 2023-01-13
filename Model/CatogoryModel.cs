using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTracker2._0.Model
{
    public class CategoryModel
    {
        [Key]
        public int CategoryId { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string CategoryName { get; set; }

        public int CategoryLimit { get; set; }


    }
}
