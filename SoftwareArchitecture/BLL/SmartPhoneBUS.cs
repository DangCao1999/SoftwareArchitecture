using SoftwareArchitecture.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftwareArchitecture.DAL;
namespace SoftwareArchitecture.BLL
{
    class SmartPhoneBUS
    {

        public List<SmartPhone> getAllList()
        {
            List<SmartPhone> smartPhones = new SmartPhoneDAO().getListSmartPhone();
            return smartPhones;
        }
    }
}
