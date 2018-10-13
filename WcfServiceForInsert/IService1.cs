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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        //operation contract to insert user
        [OperationContract]
        string InsertUserDetails(UserDetails userInfo);
        
        //operation contract to get user
        [OperationContract]
        DataSet SelectUserDetails();

        //[OperationContract]
        //string GetData(int value);

        //[OperationContract]
        //CompositeType GetDataUsingDataContract(CompositeType composite);

        //// TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.

    [DataContract]
    public class UserDetails
    {
        int userid;
        string username;
        string password;
        string country;
        string email;
        
        [DataMember]
        public int UserID
        {
            get { return userid; }
            set { userid = value; }
        }

        [DataMember]
        public string UserName
        {
            get { return username; }
            set { username = value; }
        }

        [DataMember]
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        [DataMember]
        public string Country
        {
            get { return country; }
            set { country = value; }
        }

        [DataMember]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
    }



// Use a data contract as illustrated in the sample below to add composite types to service operations.
    //[DataContract]
    //public class CompositeType
    //{
    //    bool boolValue = true;
    //    string stringValue = "Hello ";

    //    [DataMember]
    //    public bool BoolValue
    //    {
    //        get { return boolValue; }
    //        set { boolValue = value; }
    //    }

    //    [DataMember]
    //    public string StringValue
    //    {
    //        get { return stringValue; }
    //        set { stringValue = value; }
    //    }
    //}
}
