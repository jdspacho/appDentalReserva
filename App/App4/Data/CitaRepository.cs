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
using Org.Json;

namespace App4.Data
{
    public class CitaRepository
    {
        private List<Citas> _citas;
        private WebServices _webServices;
        static JSONObject json_data;
        public CitaRepository()
        {
            _webServices = new WebServices();
        }
        public List<Citas> GetCitas(string idPaciente)
        {
            var response = _webServices.Get(ValuesService.ApiUrl + "pacientes/listcita/"+ idPaciente);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<Citas>>(response.Content);
        }
        public Citas SetCitasRegister(string date, string time, string especialidad, string paciente)
        {
            string dataString = @"{""date"":""" + date + @""",""time"":""" + time + @""",""especialidad"":""" + especialidad + @""",""paciente"":""" + paciente + @"""}";
            var response = _webServices.POST(ValuesService.ApiUrl + "pacientes/citaregister", dataString);
            json_data = new JSONObject(response.Content);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Citas>(json_data.GetString("Cita"));
            //return Newtonsoft.Json.JsonConvert.DeserializeObject<Citas>(response.Content);
        }
    }
}