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
    public class CitasService
    {
        private CitaRepository _citasRepository;
        public CitasService()
        {
            _citasRepository = new CitaRepository();
        }
        public List<Citas> GetCitas(string idPaciente)
        {
            return _citasRepository.GetCitas(idPaciente);
        }
        public Citas SetCitasRegister(string date, string time, string especialidad, string paciente,string idEspecialista)
        {
            return _citasRepository.SetCitasRegister(date,time,especialidad,paciente, idEspecialista);
        }
    }
}