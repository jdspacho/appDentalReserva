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
using App4.Data;
using App4.Models;

namespace App4.Services
{
    public class EspecialistasService
    {
        private EspecialistasRepository _especialistasRepository;
        public EspecialistasService()
        {
            _especialistasRepository = new EspecialistasRepository();
        }
        public List<Especialistas> GetEspecialistas()
        {
            return _especialistasRepository.GetEspecialistas();
        }
    }
}