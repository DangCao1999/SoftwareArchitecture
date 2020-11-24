using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AppClientRestful
{
    class SmartPhoneBUS
    {
        public List<Smartphone> getAllList()
        {
            WebClient client = new WebClient();
            String res = client.DownloadString("http://cao2246restful.gearhostpreview.com/api/smartphones");
            List<Smartphone> smartphones = JsonConvert.DeserializeObject<List<Smartphone>>(res);
            return smartphones;
        }

        public bool deleteSmartPhoneByCode(int code)
        {
            WebClient client = new WebClient();
            String res = client.UploadString("http://cao2246restful.gearhostpreview.com/api/smartphones/" + code, "DELETE", "");
            return Boolean.Parse(res);
        }

        public List<Smartphone> searchByName(string keyword)
        {
            WebClient client = new WebClient();
            String res = client.DownloadString("http://cao2246restful.gearhostpreview.com/api/smartphones/search/"+keyword);
            List<Smartphone> smartphones = JsonConvert.DeserializeObject<List<Smartphone>>(res);
            return smartphones;
        }

        public bool addSmartPhone(Smartphone smartPhone)
        {
            String data = JsonConvert.SerializeObject(smartPhone);
            WebClient client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            String res = client.UploadString("http://cao2246restful.gearhostpreview.com/api/smartphones", "POST", data);
            return Boolean.Parse(res);
        }

        public bool updateSmartPhone(Smartphone smartPhone)
        {
            String data = JsonConvert.SerializeObject(smartPhone);
            WebClient client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            String res = client.UploadString("http://cao2246restful.gearhostpreview.com/api/smartphones", "PUT", data);
            return Boolean.Parse(res);
        }
    }
}
