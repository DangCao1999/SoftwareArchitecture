using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppShared
{
    public interface ISmartPhoneBUS
    {
        List<Smartphone> getAllList();
        bool deleteSmartPhoneByCode(int code);
        List<Smartphone> searchByName(string keyword);
        bool addSmartPhone(Smartphone smartPhone);
        bool updateSmartPhone(Smartphone smartPhone);
    }
}
