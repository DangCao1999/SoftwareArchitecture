using RESTfulService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTfulService.DAL
{
    public class SensorDAO
    {
        SensorDBDataContext db = new SensorDBDataContext("SERVER = den1.mssql8.gear.host; DATABASE = hentaixxx; USER = hentaixxx; PASSWORD = $qwert1");

        public List<Sensor> SelectAll()
        {
            List<Sensor> sensors = db.Sensors.ToList();
            return sensors;
        }

        public Sensor SelectByCode(int code)
        {
            Sensor sensor = db.Sensors.SingleOrDefault(x => x.Code == code);
            return sensor;
        }

        public bool Add(Sensor addSensor)
        {
            try
            {
                db.Sensors.InsertOnSubmit(addSensor);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Sensor newSensor)
        {
            Sensor dbSensor = db.Sensors.SingleOrDefault(x => x.Code == newSensor.Code);
            if (dbSensor != null)
            {
                dbSensor.Name = newSensor.Name;
                dbSensor.Brand = newSensor.Brand;
                dbSensor.Price = newSensor.Price;
                dbSensor.Description = newSensor.Description;
                try
                {
                    db.SubmitChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }

        public bool Delete(int code)
        {
            Sensor dbSensor = db.Sensors.SingleOrDefault(x => x.Code == code);
            if (dbSensor != null)
            {
                try
                {
                    db.Sensors.DeleteOnSubmit(dbSensor);
                    db.SubmitChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false; 
        }

        public List<Sensor> SelectByName(String keyword)
        {
            List<Sensor> sensors = db.Sensors.Where(x => x.Name.Contains(keyword)).ToList();
            return sensors;
        }

    }
}