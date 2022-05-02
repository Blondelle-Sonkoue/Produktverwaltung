using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Produktverwaltung.Models
{
    [Table("CATEGORIES")]
    public class Category
    {
        #region properies
        
        public int CategoryId { get; set; }
        [Required]
        [StringLength(100)]
        [DisplayName("Category Name")]
        public string Name { get; set; }
        public string Bescreibung { get; set; }
        public virtual ICollection<Produkt> Produkts { get; set; }


        #endregion

        #region ctor
        public Category()
        {

        }
        #endregion
    }
}
