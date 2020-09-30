using SoftwareArchitecture.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareArchitecture.DAL
{
    class SmartPhoneDAO
    {
        private string strCon;
        private SqlConnection sqlConnection;
        private caodbDataContext db;
        public SmartPhoneDAO()
        {
            //strCon = "SERVER=den1.mssql7.gear.host;DATABASE=cao2246;USER=cao2246;PASSWORD=Ed490?jf-m5Q";
            //sqlConnection = new SqlConnection(strCon);
            //sqlConnection.Open();
            db = new caodbDataContext("SERVER=den1.mssql7.gear.host;DATABASE=cao2246;USER=cao2246;PASSWORD=Ed490?jf-m5Q");
        }

        public List<Smartphone> getListSmartPhone()
        {
            //List<SmartPhone> listSmartPhones = new List<SmartPhone>();

            //string query = "select * from SmartPhone";

            //SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);


            //SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            //while (sqlDataReader.Read())
            //{
            //    SmartPhone smartPhone = new SmartPhone() {
            //        Code = (int)sqlDataReader["Code"],
            //        Name = sqlDataReader["Name"].ToString(),
            //        Price = (int)sqlDataReader["Price"],
            //        Brand = sqlDataReader["Brand"].ToString(),
            //        Color = sqlDataReader["Color"].ToString()
            //    };


            //    listSmartPhones.Add(smartPhone);

            //}
            //return listSmartPhones;


            List<Smartphone> smartphones = db.Smartphones.ToList();
            return smartphones;
        }

        public bool DeleteSmartPhoneByCode(int code)
        {
            //List<SmartPhone> listSmartPhones = new List<SmartPhone>();

            //string query = "Delete from SmartPhone where Code = @code";

            //SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            //sqlCommand.Parameters.Add(new SqlParameter("@code", code));
            //try
            //{

            //    return sqlCommand.ExecuteNonQuery() > 0;
            //}
            //catch{  return false; }

            Smartphone smartphoneDel = db.Smartphones.Single(x => x.Code == code);
            try
            {
                db.Smartphones.DeleteOnSubmit(smartphoneDel);
                db.SubmitChanges();
                return true;
            }
            catch { return false; }

        }

        public List<Smartphone> searchByName(string keyword)
        {
            //List<SmartPhone> listSmartPhones = new List<SmartPhone>();

            //string query = "select * from SmartPhone where Name LIKE '%" + keyword + "%'";

            //SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);


            //SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            //while (sqlDataReader.Read())
            //{
            //    SmartPhone smartPhone = new SmartPhone()
            //    {
            //        Code = (int)sqlDataReader["Code"],
            //        Name = sqlDataReader["Name"].ToString(),
            //        Price = (int)sqlDataReader["Price"],
            //        Brand = sqlDataReader["Brand"].ToString(),
            //        Color = sqlDataReader["Color"].ToString()
            //    };


            //    listSmartPhones.Add(smartPhone);

            //}
            //return listSmartPhones;
            List<Smartphone> smartphones = db.Smartphones.Where(x => x.Name.Contains(keyword)).ToList();
            return smartphones;

        }

        public bool addSmartPhone(Smartphone smartPhone)
        {
            //string query = "INSERT INTO SmartPhone values(@Name, @Price, @Brand, @Color)";

            //SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            //sqlCommand.Parameters.Add(new SqlParameter("@Name", smartPhone.Name));
            //sqlCommand.Parameters.Add(new SqlParameter("@Price", smartPhone.Price));
            //sqlCommand.Parameters.Add(new SqlParameter("@Brand", smartPhone.Brand));
            //sqlCommand.Parameters.Add(new SqlParameter("@Color", smartPhone.Color));

            //return sqlCommand.ExecuteNonQuery() > 0;

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

        public bool updateSmartPhone(SmartPhone smartPhone)
        {
            //string query = "UPDATE SmartPhone SET Name = @Name, Price = @Price, Brand = @Brand, Color = @Color WHERE Code = @Code";

            //SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            //sqlCommand.Parameters.Add(new SqlParameter("@Code", smartPhone.Code));
            //sqlCommand.Parameters.Add(new SqlParameter("@Name", smartPhone.Name));
            //sqlCommand.Parameters.Add(new SqlParameter("@Price", smartPhone.Price));
            //sqlCommand.Parameters.Add(new SqlParameter("@Brand", smartPhone.Brand));
            //sqlCommand.Parameters.Add(new SqlParameter("@Color", smartPhone.Color));

            //return sqlCommand.ExecuteNonQuery() > 0;


            Smartphone smartphoneUpdate = db.Smartphones.SingleOrDefault(x => x.Code == smartPhone.Code);

            if(smartphoneUpdate != null)
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
