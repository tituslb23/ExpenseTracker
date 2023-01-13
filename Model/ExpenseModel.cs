using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTracker2._0.Model
{
    public class ExpenseModel
    {
        [Key]
        public int ExpenseId { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string ExpenseName { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string? Description { get; set; }

        public int CategoryId { get; set; }
        public CategoryModel Category { get; set; }

        public int Amount { get; set; }
       
    }
}
