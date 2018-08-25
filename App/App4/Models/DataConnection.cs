using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.IO;
using Java.Lang;
using Java.Net;
using Org.Json;
using App4.Activities;
namespace App4.Models
{
    public class DataConnection
    {
        static string mFunction, mName, mNameUser, mApellidoP,mApellidoM,mDni,mCorreo, mPassword, loadData, dataUser,message,error;
        static Activity activity;
        static List<Users> useronList;
        static JSONObject json_data;
        static JSONObject json_message;
        static JSONObject json_user;

        public DataConnection(Activity context, string funcion, string name, string nameUser, string apellidoP,string apellidoM,string dni, string correo, string password)
        {
            activity = context;
            mFunction= funcion;
            mName = name;
            mNameUser = nameUser;
            mPassword = password;
            mCorreo = correo;
            mApellidoP = apellidoP;
            mApellidoM = apellidoM;
            mDni = dni;
            useronList = new List<Users>();
            new GetAndSet().Execute();
        }
        public static string getData()
        {
            WebClient wc = new WebClient();
            wc.Headers.Add(HttpRequestHeader.ContentType, "application/json; charset=utf-8");
            wc.Headers.Add(HttpRequestHeader.Accept, "application/json, text/javascript, */*; q=0.01");
            wc.Headers.Add("X-Requested-With", "XMLHttpRequest");
            string responseString="";
            switch (mFunction)
            {
                case "setUser":
                    string dataString = @"{""name"":""" + mName + @""",""usuario"":""" + mNameUser + @""",""apellidoP"":""" + mApellidoP + @""",""apellidoM"":""" + mApellidoM + @""",""correo"":""" + mCorreo + @""",""password"":""" + mPassword + @""",""dni"":""" + mDni + @"""}";
                    //   string dataString = @"{""user"":{""email"":"""+uEmail+@""",""password"":"""+uPassword+@"""}}";
                    byte[] dataBytes = Encoding.UTF8.GetBytes(dataString);
                    byte[] responseBytes = wc.UploadData(new Uri("http://percovichdental.syslacstraining.com/pacientes/register"), "POST", dataBytes);
                    responseString = Encoding.UTF8.GetString(responseBytes);
                   break;
                //case "setLoginUser":

                //    dataString = @"{""correo"":""" + mCorreo + @""",""password"":""" + mPassword + @"""}";
                //    //   string dataString = @"{""user"":{""email"":"""+uEmail+@""",""password"":"""+uPassword+@"""}}";
                //    dataBytes = Encoding.UTF8.GetBytes(dataString);
                //    responseBytes = wc.UploadData(new Uri("http://percovichdental.syslacstraining.com/pacientes/login"), "POST", dataBytes);
                //    responseString = Encoding.UTF8.GetString(responseBytes);
                //    break;
            }
            return responseString;
        }
        static bool filterData()
        {
            loadData = getData();
            try
            {
                if (loadData != "" || loadData != null)
                {
                    json_data = new JSONObject(loadData);
                    switch (mFunction)
                    {
                        case "setUser":
                            dataUser = json_data.GetString("Paciente");
                            json_message = new JSONObject(json_data.GetString("message"));
                            message = json_message.GetString("message");
                            break;

                        //case "setLoginUser":
                        //    json_user = new JSONObject(json_data.GetString("Paciente"));
                        //    json_message = new JSONObject(json_data.GetString("message"));
                        //    message = json_message.GetString("message");
                        //    error = json_message.GetString("error");

                        //    break;

                    }
                }
            }
            catch (System.Exception)
            {

            }
            return true;
        }
        private static void Activity()
        {
            switch (mFunction)
            {
                case "setUser":
                    if (dataUser == "true")
                    {
                        Toast.MakeText(activity, message, ToastLength.Long).Show();
                        Intent newActivity = new Intent(activity, typeof(MainActivity));
                        activity.Finish();
                        activity.StartActivity(newActivity);
                    }
                    else
                    {
                        Toast.MakeText(activity, message, ToastLength.Long).Show();
                    }
                    break;

                //case "setLoginUser":
                    
                //    if (error!="true")
                //    {
                //        MenuPrincipal menu = new MenuPrincipal();
                //        menu.userName= json_user.GetString("pUsuario");
                //        menu.userId= json_user.GetString("id");
                //        menu.userMessage = message;
                //    }
                //    break;

            }
        }
        class GetAndSet: AsyncTask<string,string,string>
        {
            protected override string RunInBackground(params string[] @params)
            {
                if (filterData())
                {
                    activity.RunOnUiThread(() =>
                    {
                        Activity();
                    });
                }
                return null;
            }
        }

    }
}