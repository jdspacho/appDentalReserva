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

namespace App4.Models
{
    public class Citas
    {
        public int id { get; set; }
        public string date { get; set; }
        public string time { get; set; }
        public string especialidad { get; set; }
        public string paciente { get; set; }
        public string estado { get; set; }
        public string observacion { get; set; }
        public string titulo { get; set; }


    }
}