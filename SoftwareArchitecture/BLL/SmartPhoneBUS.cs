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

        public List<Smartphone> getAllList()
        {
            List<Smartphone> smartPhones = new SmartPhoneDAO().getListSmartPhone();
            return smartPhones;
        }

        public bool deleteSmartPhoneByCode(int code)
        {

            bool rs = new SmartPhoneDAO().DeleteSmartPhoneByCode(code);
            return true;
        }

        public List<Smartphone> searchByName(string keyword)
        {
            List<Smartphone> smartPhones = new SmartPhoneDAO().searchByName(keyword);
            return smartPhones;
        }

        public bool addSmartPhone (Smartphone smartPhone)
        {
            bool rs = new SmartPhoneDAO().addSmartPhone(smartPhone);
            return rs;
        }

        public bool updateSmartPhone(SmartPhone smartPhone)
        {
            bool rs = new SmartPhoneDAO().updateSmartPhone(smartPhone);
            return rs;
        }
    }
}
