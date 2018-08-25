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
    public class Users
    {
        public int id { get; set; }
        public string pUsuario { get; set; }
        public string pNombres { get; set; }
        public string pApellidoPaterno { get; set; }
        public string pApellidoMaterno { get; set; }
        public string pCorreoE { get; set; }
        public string pEstado { get; set; }
        public string pDNI { get; set; }
    }
}