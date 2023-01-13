using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTracker2._0.Model
{
    public class ExpenseDataModel
    {

        
        public int ExpenseId { get; set; }


        public string ExpenseName { get; set; }

   
        public string? Description { get; set; }

        public int CategoryId { get; set; }

        public int Amount { get; set; }

    
        public string CategoryName { get; set; }

        public int CategoryLimit { get; set; }
    }


}

