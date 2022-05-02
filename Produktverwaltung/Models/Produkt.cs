using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Produktverwaltung.Models
{
    [Table("PRODUKTS")]
    public class Produkt
    {


        #region properties
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Preis muss größer als 0 sein")]
        public double Preis { get; set; }
        public int Menge { get; set; }
        [DisplayName("Category")]
        public int CategoryId { get; set; }
        //Navigation-Property Product --> Cateogry [0...1]
        public virtual Category Category { get; set; }

        #endregion

        #region ctor
        public Produkt()
        {

        }
        #endregion
 }  }

