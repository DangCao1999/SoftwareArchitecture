using RestfulService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestfulService.Controllers
{
    public class SmartphonesController : ApiController
    {
        // GET api/<controller>
        [HttpGet]
        [Route("api/smartphones")]
        public List<Smartphone> Get()
        {
            List<Smartphone> smartphones = new SmartphoneDAO().getListSmartPhone();
            return smartphones;
        }

        // GET api/<controller>/5
        [HttpGet]
        [Route("api/smartphones/{code}")]
        public Smartphone Get(int code)
        {
            Smartphone smartphone = new SmartphoneDAO().selectSmartPhoneByCode(code);
            return smartphone;
        }

        [HttpGet]
        [Route("api/smartphones/search/{keywords}")]
        public List<Smartphone> Get(string keywords)
        {
            List<Smartphone> smartphones = new SmartphoneDAO().searchByName(keywords);
            return smartphones; 
        }
        // POST api/<controller>
        [HttpPost]
        [Route("api/smartphones")]
        public bool Post(Smartphone smartphone)
        {
            bool rs = new SmartphoneDAO().addSmartPhone(smartphone);
            return rs;
        }

        // PUT api/<controller>/5
        [HttpPut]
        [Route("api/smartphones")]
        public bool Put(Smartphone smartphone)
        {
            bool rs = new SmartphoneDAO().updateSmartPhone(smartphone);
            return rs;
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        [Route("api/smartphones/{code}")]
        public bool Delete(int code)
        {
            bool rs = new SmartphoneDAO().DeleteSmartPhoneByCode(code);
            return rs;
        }
    }
}