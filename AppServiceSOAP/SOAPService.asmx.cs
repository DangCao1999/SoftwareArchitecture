using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace AppServiceSOAP
{
    /// <summary>
    /// Summary description for SOAPService
    /// </summary>
    [WebService(Namespace = "http://caonvd.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class SOAPService : System.Web.Services.WebService
    {
        [WebMethod]
        public List<Smartphone> getAllList()
        {
            List<Smartphone> smartPhones = new SmartPhoneDAO().getListSmartPhone();
            return smartPhones;
        }

        [WebMethod]
        public bool deleteSmartPhoneByCode(int code)
        {

            bool rs = new SmartPhoneDAO().DeleteSmartPhoneByCode(code);
            return rs;
        }

        [WebMethod]
        public List<Smartphone> searchByName(string keyword)
        {
            List<Smartphone> smartPhones = new SmartPhoneDAO().searchByName(keyword);
            return smartPhones;
        }

        [WebMethod]
        public bool addSmartPhone(Smartphone smartPhone)
        {
            bool rs = new SmartPhoneDAO().addSmartPhone(smartPhone);
            return rs;
        }

        [WebMethod]
        public bool updateSmartPhone(Smartphone smartPhone)
        {
            bool rs = new SmartPhoneDAO().updateSmartPhone(smartPhone);
            return rs;
        }
    }
}
