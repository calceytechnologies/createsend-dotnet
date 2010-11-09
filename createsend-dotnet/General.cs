﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace createsend_dotnet
{
    public class General
    {
        public static string ApiKey(string siteUrl, string username, string password)
        {
            HttpHelper.OverrideAuthenticationCredentials(username, password);
            string getKeyResult = HttpHelper.Get("/apikey.xml", string.Format("?SiteUrl={0}", HttpUtility.UrlEncode(siteUrl)));
            //reset to default
            HttpHelper.OverrideAuthenticationCredentials(CreateSendOptions.ApiKey, "x");
            return XMLSerializer.Deserialize<ApiKeyResult>(getKeyResult).ApiKey;
        }

        public static DateTime SystemDate()
        {
            return DateTime.Parse(XMLSerializer.Deserialize<SystemDateResult>(HttpHelper.Get("/systemdate.xml", null)).SystemDate);
        }

        public static IEnumerable<string> Countries()
        {
            return XMLSerializer.Deserialize<ArrayOfstring>(HttpHelper.Get("/countries.xml", null));
        }

        public static IEnumerable<string> Timezones()
        {
            return XMLSerializer.Deserialize<ArrayOfstring>(HttpHelper.Get("/timezones.xml", null));
        }

        public static IEnumerable<Client> Clients()
        {
            return XMLSerializer.Deserialize<Clients>(HttpHelper.Get("/clients.xml", null));
        }
    }
}
