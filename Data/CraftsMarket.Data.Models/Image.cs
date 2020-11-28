namespace CraftsMarket.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using CraftsMarket.Data.Common.Models;

    public class Image : BaseDeletableModel<int>
    {
        [Required]
        public string Path { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
