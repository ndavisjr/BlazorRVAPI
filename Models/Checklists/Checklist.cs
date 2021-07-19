using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BlazorRVAPI.Models.Checklist
{
    public class Checklist
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Checklist")]
        public string Name { get; set; }

        public string Category { get; set; }

        public ICollection<ChecklistItem> ChecklistItems { get; set; } = new List<ChecklistItem>();
    }
}