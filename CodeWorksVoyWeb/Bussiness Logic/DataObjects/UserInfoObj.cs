using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserInfoObj
/// </summary>
public class UserInfoObj
{

    private int userID;

    public int UserID
    {
        get { return userID; }
        set { userID = value; }
    }

    private string email;

    public string Email
    {
        get { return email; }
        set { email = value; }
    }

    private string password;

    public string Password
    {
        get { return password; }
        set { password = value; }
    }

    private string agencyName;

public string AgencyName
{
  get { return agencyName; }
  set { agencyName = value; }
}

private string contactName;

public string ContactName
{
    get { return contactName; }
    set { contactName = value; }
}

    private string addressLine1;

    public string AddressLine1
    {
        get { return addressLine1; }
        set { addressLine1 = value; }
    }

    private string addressLine2;

    public string AddressLine2
    {
        get { return addressLine2; }
        set { addressLine2 = value; }
    }

    private string addressLine3;

    public string AddressLine3
    {
        get { return addressLine3; }
        set { addressLine3 = value; }
    }

    private string addressLine4;

    public string AddressLine4
    {
        get { return addressLine4; }
        set { addressLine4 = value; }
    }

    private string postcode;

    public string Postcode
    {
        get { return postcode; }
        set { postcode = value; }
    }

    private string phoneNumber;

    public string PhoneNumber
    {
        get { return phoneNumber; }
        set { phoneNumber = value; }
    }

    private string aBTA;

    public string ABTA
    {
        get { return aBTA; }
        set { aBTA = value; }
    }

    private string aTOL;

    public string ATOL
    {
        get { return aTOL; }
        set { aTOL = value; }
    }

    private string headerURL;

    public string HeaderURL
    {
        get { return headerURL; }
        set { headerURL = value; }
    }

    private string footerURL;

    public string FooterURL
    {
        get { return footerURL; }
        set { footerURL = value; }
    }

    private bool isAdmin;

    public bool IsAdmin
    {
        get { return isAdmin; }
        set { isAdmin = value; }
    }
    private bool isAgent;

    public bool IsAgent
    {
        get { return isAgent; }
        set { isAgent = value; }
    }
    private bool isSuperUser;

    public bool IsSuperUser
    {
        get { return isSuperUser; }
        set { isSuperUser = value; }
    }


}