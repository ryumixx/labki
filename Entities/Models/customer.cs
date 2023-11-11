using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class customer
    {
        [Column("customerID")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "customer name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")] public string Name { get; set; }
        [Required(ErrorMessage = "customer address is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for rhe Address is 60 characte")]
        public string Address { get; set; }
        public string Country { get; set; }
        public string PhoneNumber {  get; set; }
        public ICollection<customer> customer { get; set; }
    }
}
