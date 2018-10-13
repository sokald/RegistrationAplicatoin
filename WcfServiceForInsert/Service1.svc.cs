using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace WcfServiceForInsert
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public DataSet SelectUserDetails()
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Registration;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from RegistrationTable", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmd.ExecuteNonQuery();
            con.Close();
            return ds;
        }
        
        public string InsertUserDetails(UserDetails userInfo)
        {
            string Message;
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Registration;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into RegistrationTable(UserName,Password,Country,Email) values(@UserName,@Password,@Country,@Email)", con);
            cmd.Parameters.AddWithValue("@UserName", userInfo.UserName);
            cmd.Parameters.AddWithValue("@Password", userInfo.Password);
            cmd.Parameters.AddWithValue("@Country", userInfo.Country);
            cmd.Parameters.AddWithValue("@Email", userInfo.Email);
            int result = cmd.ExecuteNonQuery();
            if (result == 1)
            {
                Message = userInfo.UserName + " Details inserted successfully";
            }
            else
            {
                Message = userInfo.UserName + " Details not inserted successfully";
            }
            con.Close();
            return Message;
        }

        //public string GetData(int value)
        //{
        //    return string.Format("You entered: {0}", value);
        //}

        //public CompositeType GetDataUsingDataContract(CompositeType composite)
        //{
        //    if (composite == null)
        //    {
        //        throw new ArgumentNullException("composite");
        //    }
        //    if (composite.BoolValue)
        //    {
        //        composite.StringValue += "Suffix";
        //    }
        //    return composite;
        //}
    }
}
