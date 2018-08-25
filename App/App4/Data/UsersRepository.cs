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
using App4.Models;
using App4.Services;
namespace App4.Data
{
    public class UsersRepository
    {
        private List<Users> _users;
        private WebServices _webServices;
        public UsersRepository()
        {
             _webServices = new WebServices();
        }
        public List<Users> GetUsers()
        {
            return _users;
        }
        public Users GetUsersAutentication(string Correo, string Password)
        {
            string dataString = @"{""correo"":""" + Correo + @""",""password"":""" + Password + @"""}";
            var response = _webServices.POST(ValuesService.ApiUrl + "pacientes/login", dataString);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Users>(response.Content);
        }
    }
}