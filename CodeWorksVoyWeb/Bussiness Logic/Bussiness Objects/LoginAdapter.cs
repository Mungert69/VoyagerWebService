using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


/// <summary>
/// Summary description for LoginAdapter
/// </summary>
public class LoginAdapter
{
	public LoginAdapter()
	{
       
	}

    public UserInfoObj getUserInfoObj(int UserID) {
        /*
        LoginTableAdapter loginAdapter = new LoginTableAdapter();
        LoginData.LoginDataTable loginTable = loginAdapter.GetDataByUserID(UserID);

        foreach (LoginData.LoginRow row in loginTable)
        {
            UserInfoObj userObj = new UserInfoObj();
            userObj.AddressLine1 = row.AddressLine1;
            userObj.AddressLine2 = row.Addressline2;
            userObj.AddressLine3 = row.Addressline3;
            userObj.AddressLine4 = row.Addressline4;
            userObj.AgencyName = row.AgencyName;
            userObj.ContactName = row.ContactName;
            userObj.Email = row.Email;
            userObj.Password = row.Password;
            userObj.PhoneNumber = row.PhoneNumber;
            userObj.Postcode = row.Postcode;
            userObj.ATOL = row.ATOL;
            userObj.ABTA = row.ABTA;
            userObj.IsAdmin = row.IsAdmin;
            userObj.IsAgent = row.IsAgent;
            userObj.IsSuperUser = row.IsSuperUser;
            return userObj;
        }*/
        return null;
    }

    public int checkLogin(string userName, string password){
          /*
            LoginTableAdapter loginAdapter=new LoginTableAdapter();
            LoginData.LoginDataTable loginTable=loginAdapter.GetData(userName,password);
             foreach (LoginData.LoginRow row in loginTable) {
            return row.UserID;
        }*/
            return 0;
        }

    public bool checkUsernameFree(string userName)
    {
        /*
        LoginTableAdapter loginAdapter = new LoginTableAdapter();
        LoginData.LoginDataTable loginTable = loginAdapter.GetDataUsernameFree(userName);
        foreach (LoginData.LoginRow row in loginTable)
        {
            return false;
        }*/
        return true;
    }

}