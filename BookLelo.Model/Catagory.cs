using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLelo.Model
{
    public class Catagory
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(30)]
        [DisplayName("Catagory Name")]
        public string Name { get; set; }
        
        [DisplayName("Dispaly Order")]
        [Range(1, 100,ErrorMessage="Display Oredr must be between 1-100")]
        public int DisplayOrder { get; set; }
        public DateTime DateCreated{ get; set; }

    }
}
