using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    public class EspecialidadesRepository
    {
        //private WebServices_webServices;
        private List<Especialidades> _especialidades;
        private WebServices _webServices;
        public EspecialidadesRepository()
        {
            _webServices = new WebServices();
        }
        public List<Especialidades> GetEspecialidad()
        {
            var response = _webServices.Get(ValuesService.ApiUrl+"pacientes/list");
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<Especialidades>>(response.Content);
        }

        /*
        public Especialidades GetNewsById(int Id)
        {
            var response = _webServices.Get(ValuesService.ApiUrl + Id);

            if (response.HttpStatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new ApplicationException("news not found");
            }
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Especialidades>(response.Content);

        }
        */
    }
}