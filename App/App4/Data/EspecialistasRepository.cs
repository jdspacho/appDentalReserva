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
    public class EspecialistasRepository
    {
        private List<Especialistas> _especialistas;
        private WebServices _webServices;
        public EspecialistasRepository()
        {
            _webServices = new WebServices();
        }
        public List<Especialistas> GetEspecialistas()
        {
            var response = _webServices.Get(ValuesService.ApiUrl + "especialistas/list");
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<Especialistas>>(response.Content);
        }
    }
}