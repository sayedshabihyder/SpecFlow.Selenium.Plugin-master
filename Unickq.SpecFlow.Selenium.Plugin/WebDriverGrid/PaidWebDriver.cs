﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Security;
using System.Text;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Unickq.SpecFlow.Selenium.WebDriverGrid
{
    public abstract class PaidWebDriver : RemoteWebDriver
    {
        protected PaidWebDriver(string url, string browser, Dictionary<string, string> capabilities) : base(url,
            browser, capabilities)
        {
        }

        protected PaidWebDriver(string url, Dictionary<string, string> capabilities) : base(url, capabilities)
        {
        }

        public abstract string Name { get; }

        protected string SecretUser { get; set; }
        protected string SecretKey { get; set; }
        protected abstract Uri Uri { get; }

        protected static string FixedTestName
        {
            get
            {
                var name = TestContext.CurrentContext.Test.Name;
                if (name.Length > 255) name = name.Substring(0, 252) + "...";

                return name;
            }
        }

        protected void Publish(string reqString)
        {
            var uri = Uri;
            var requestData = Encoding.UTF8.GetBytes(reqString);
            var myWebRequest = WebRequest.Create(uri);
            var myHttpWebRequest = (HttpWebRequest) myWebRequest;
            myWebRequest.ContentType = "application/json";
            myWebRequest.Method = "PUT";
            myWebRequest.ContentLength = requestData.Length;
            using (var st = myWebRequest.GetRequestStream())
            {
                st.Write(requestData, 0, requestData.Length);
            }

            var networkCredential = new NetworkCredential(SecretUser, SecretKey);
            var myCredentialCache = new CredentialCache {{uri, "Basic", networkCredential}};
            myHttpWebRequest.PreAuthenticate = true;
            myHttpWebRequest.Credentials = myCredentialCache;
            myWebRequest.GetResponse().Close();
        }

        public dynamic ExecuteApiCall(string uri)
        {
            using (var wc = new WebClient())
            {
                wc.Credentials = new NetworkCredential(SecretUser, SecretKey);
                var json = wc.DownloadString(uri);
                if (!string.IsNullOrEmpty(json)) return JObject.Parse(json);

                Debug.WriteLine($"{uri} has no data");
                return null;
            }
        }

        public abstract void UpdateTestResult();

        protected static string NameTransform(string str)
        {
            switch (str)
            {
                case null:
                    return string.Empty;
                case "@@datetime":
                    return DateTime.Now.ToString("MM/dd/yyyy hh:mm");
                case "@@time":
                    return DateTime.Now.ToString("hh:mm");
                case "@@user":
                    return Environment.UserName;
                case "@@machine":
                    return Environment.MachineName;
            }

            if (str.StartsWith("@@env:"))
                try
                {
                    var envVar = str.Replace("@@env:", string.Empty);
                    var envVarValue = Environment.GetEnvironmentVariable(envVar);
                    return string.IsNullOrEmpty(envVarValue) ? envVar : envVarValue;
                }
                catch (SecurityException)
                {
                    return string.Empty;
                }

            return str;
        }
    }
}