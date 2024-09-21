using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SH.BLL.ModelVm
{
    public class EditDocVM
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30, ErrorMessage = "Name must be less than 30 letter")]
        [MinLength(3, ErrorMessage = "NAme must be greater than 3 letter")]
        public string FullName { get; set; }
        public string Email { get; set; }
        [Required]
        [MinLength(11)]
        public string PhoneNumber { get; set; }
        [Required]
        public string Address { get; set; }
    }
}
