using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SH.BLL.ModelVm
{
    public class DeleteDocVM
    {
        [Key]
        public int Id { get; set; }
        public bool IsDelete { get; set; }
    }
}
