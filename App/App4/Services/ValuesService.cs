using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace App4.Services
{
    public class ValuesService
    {

        public static readonly string ImagesBaseURL = "http://percovichdental.syslacstraining.com/asset/images/";
        public static readonly string ApiUrl = "http://percovichdental.syslacstraining.com/";
        /*
        public static readonly string DbName = "notiXamarinDb.db";

        public static string GetDbPath()
        {
            string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return System.IO.Path.Combine(folder, DbName);
        }
        */
    }
}