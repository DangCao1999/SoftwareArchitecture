﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AppServiceSOAP
{
    public class SmartPhoneDAO
    {
        
          
            private mydbDataContext db;
            public SmartPhoneDAO()
            {                
                db = new mydbDataContext("SERVER=den1.mssql7.gear.host;DATABASE=cao2246;USER=cao2246;PASSWORD=Ed490?jf-m5Q");
            }

            public List<Smartphone> getListSmartPhone()
            {
                List<Smartphone> smartphones = db.Smartphones.ToList();
                return smartphones;
            }

            public bool DeleteSmartPhoneByCode(int code)
            {             
                Smartphone smartphoneDel = db.Smartphones.Single(x => x.Code == code);
                try
                {
                    db.Smartphones.DeleteOnSubmit(smartphoneDel);
                    db.SubmitChanges();
                    return true;
                }
                catch { return false; }

            }

            public List<Smartphone> searchByName(string keyword)            {
       
                List<Smartphone> smartphones = db.Smartphones.Where(x => x.Name.Contains(keyword)).ToList();
                return smartphones;
            }

            public bool addSmartPhone(Smartphone smartPhone)
            {
                try
                {
                    db.Smartphones.InsertOnSubmit(smartPhone);
                    db.SubmitChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }

            public bool updateSmartPhone(Smartphone smartPhone)
            {
            Smartphone smartphoneUpdate = db.Smartphones.SingleOrDefault(x => x.Code == smartPhone.Code);

                if (smartphoneUpdate != null)
                {
                    smartphoneUpdate.Name = smartPhone.Name;
                    smartphoneUpdate.Price = smartPhone.Price;
                    smartphoneUpdate.Color = smartPhone.Color;
                    smartphoneUpdate.Brand = smartPhone.Brand;

                    db.SubmitChanges();
                    return true;
                }
                else
                {
                    return false;
                }

            }

        
    }
}