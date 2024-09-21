using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.BLL.ModelVM.Account
{
    public class VerifyEmailVM
    {
        public string UserName { get; set; }
        public string Code { get; set; }
    }

}