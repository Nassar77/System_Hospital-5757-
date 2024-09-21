using SH.BLL.ModelVm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SH.BLL.Services.Abstraction
{
    public interface IDocServices
    {
        List<GetAllDoctorsVM> GetAllDoctors();
        bool Create(CreateDocVM createDocVM);
        bool Delete(DeleteDocVM deleteDocVM);
        bool Edit(EditDocVM editDocVM);
        GetByIdDocVM GetByIdDocVM(int id);

    }
}
