using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BlazorRVAPI.Models.Expense
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Expense")]
        [Required]
        public string ExpsenseName { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0")]
        public double Amount { get; set; }

        public string Category { get; set; }


    }
}