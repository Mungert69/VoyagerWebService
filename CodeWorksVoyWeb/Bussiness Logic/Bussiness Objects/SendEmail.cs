using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;

/// <summary>
/// Summary description for SendEmail
/// </summary>
public class SendEmail 
{
    public static IConfiguration Configuration { get; set; }
    public static string send(string email, string name, string telephone, string messageBox)
    {
        if (email.Equals("")) return "";
        try
        {
            MailMessage message = new MailMessage();

            message.From = new MailAddress(email);
            message.To.Add(new MailAddress(Configuration.GetSection("AppConfiguration")["ContactToEmail"]));
            message.Subject = Configuration.GetSection("AppConfiguration")["Country"] + " Customer email from " + name;
            message.Body = "Email from " + name+"      Telephone number  " + telephone+ "        Message:  " + messageBox;
            SmtpClient client = new SmtpClient("127.0.0.1");

            client.Send(message);

           
            message.From = new MailAddress(Configuration.GetSection("AppConfiguration")["ContactFromEmail"]);
            message.To.Add(new MailAddress(email));
            message.Subject = "Your Holiday Inquiry to Voyager "+Configuration.GetSection("AppConfiguration")["Country"];
            message.Body = "You sent the following message to Voyager " + Configuration.GetSection("AppConfiguration")["Country"] +":           " + messageBox;

            client.Send(message);

        }
        catch (Exception ex)
        {
            return "fail";
        }
        return "success";
    }


}
