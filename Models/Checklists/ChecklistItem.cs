using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BlazorRVAPI.Models.Checklist
{
    public class ChecklistItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Checklist Item")]
        public string Name { get; set; }

        public string Category { get; set; }

        public int Priority { get; set; }

        [Required]
        public int ChecklistId { get; set; }

        public Checklist Checklist { get; set; }
    }
}