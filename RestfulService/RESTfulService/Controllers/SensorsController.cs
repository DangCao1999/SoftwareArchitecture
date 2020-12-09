using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using RESTfulService.Models;
using RESTfulService.DAL;

namespace RESTfulService.Controllers
{
    public class SensorsController : ApiController
    {
        [HttpGet]
        [Route("api/sensors")]
        public List<Sensor> Get()
        {
            List<Sensor> sensors = new SensorDAO().SelectAll();
            return sensors;
        }

        [HttpGet]
        [Route("api/sensors/{code}")]
        public Sensor Get(int code)
        {
            Sensor sensor = new SensorDAO().SelectByCode(code);
            return sensor;
        }

        [HttpPost]
        [Route("api/sensors")]
        public bool Post(Sensor addSensor)
        {
            bool result = new SensorDAO().Add(addSensor);
            return result;
        }

        [HttpPut]
        [Route("api/sensors/{code}")]
        public bool Put(int code, Sensor newSensor)
        {
            Sensor sensor = new SensorDAO().SelectByCode(code);
            if(sensor != null)
            {
                bool result = new SensorDAO().Update(newSensor);
                return result;
            }
            return false;
        }

        [HttpDelete]
        [Route("api/sensors/{code}")]
        public bool Delete(int code)
        {
            bool result = new SensorDAO().Delete(code);
            return result;
        }

        [HttpGet]
        [Route("api/sensors/search/{keyword}")]
        public List<Sensor> Search(String keyword)
        {
            List<Sensor> sensors = new SensorDAO().SelectByName(keyword);
            return sensors;
        }
    }
}