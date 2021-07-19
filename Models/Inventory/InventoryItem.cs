using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BlazorRVAPI.Models.Inventory
{
    public class InventoryItem
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Item Name")]
        [Required]
        public string ItemName { get; set; }

        public string PurchasedFrom { get; set; }

        [DisplayName("Price")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:C0}")]
        public double PurchasedPrice { get; set; }

        public string Notes { get; set; }
    }
}