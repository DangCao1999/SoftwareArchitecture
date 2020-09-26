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

        public List<SmartPhone> getListSmartPhone()
        {
            List<SmartPhone> listSmartPhones = new List<SmartPhone>();

            string strCon = "SERVER=den1.mssql7.gear.host;DATABASE=cao2246;USER=cao2246;PASSWORD=Ed490?jf-m5Q";

            SqlConnection sqlConnection = new SqlConnection(strCon);

            sqlConnection.Open();

            string query = "select * from SmartPhone";

            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);


            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                SmartPhone smartPhone = new SmartPhone() {
                    Code = (int)sqlDataReader["Code"],
                    Name = sqlDataReader["Name"].ToString(),
                    Price = (int)sqlDataReader["Price"],
                    Brand = sqlDataReader["Brand"].ToString(),
                    Color = sqlDataReader["Color"].ToString()
                };


                listSmartPhones.Add(smartPhone);
               
            }
            return listSmartPhones;
        }
    }
}
