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
    public class EspecialidadesService
    {
        private EspecialidadesRepository _especialidadesRepository;
        public EspecialidadesService()
        {
            _especialidadesRepository = new EspecialidadesRepository();
        }
        public List<Especialidades> GetEspecialidades()
        {
            return _especialidadesRepository.GetEspecialidad();
        }
    }
}