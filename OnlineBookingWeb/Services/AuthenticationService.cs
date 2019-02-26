using SQLConnectionApplication.DataProviders;
using SQLConnectionApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineBookingWeb.Services
{
    public class AuthenticationService
    {
        KundeDataprovider kundeDataprovider;
        public AuthenticationService ()
        {
            kundeDataprovider = new KundeDataprovider();
        }
        public bool ValidateUser(string userName, string password)
        {
            Kunde kunde = kundeDataprovider.FinnKunde(userName);

            if (kunde == null)
            {
                return false;
            }

            if (kunde.Passord.Equals(password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}