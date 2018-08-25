using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SupportFragment = Android.Support.V4.App.Fragment;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Support.Design.Widget;
using Java.Util;
using App4.Models;
using Java.Text;
using App4.Services;
using App4.Models;
using App4.Activities;
using Android.Support.V7.App;

namespace App4.Fragments
{
    public class Fragment2 : SupportFragment, DatePickerDialog.IOnDateSetListener, TimePickerDialog.IOnTimeSetListener
    {
        private Button dateCita;
        private Button timeCita;
        private View view;
        private Spinner especialidades;
        private string date;
        private string time;
        private string especialidadesName;
        private CitasService _citasService = new CitasService();
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            view = inflater.Inflate(Resource.Layout.FragmentCitas, container, false);
            Button btnGuardar = view.FindViewById<Button>(Resource.Id.btnGuardarCita);
            dateCita = view.FindViewById<Button>(Resource.Id.btnDateCita);
            timeCita = view.FindViewById<Button>(Resource.Id.btnTimeCita);
            especialidades = view.FindViewById<Spinner>(Resource.Id.cmbEspecialidades);
            //var data = new List<string> { "one", "two", "three" };
            //ArrayAdapter adapter = new ArrayAdapter(view.Context, Resource.Id.cmbEspecialidades, data);
            //especialidades.Adapter = adapter;
            try
            {
                var especialidadesService = new EspecialidadesService();
                var especialidadesList = especialidadesService.GetEspecialidades();
                List<Especialidades> itemsNew = especialidadesList;
                List<string> items = new List<string>();

                foreach (Especialidades x in especialidadesList)
                {
                    items.Add(x.Name);
                }
                ArrayAdapter adapter = new ArrayAdapter(view.Context, Android.Resource.Layout.SimpleSpinnerItem, items);
 
                especialidades.Adapter = adapter;

            }
            catch (Exception e)
            {
                string tag = Convert.ToString(e);
                Log.Error(tag, "Error lis view");
                Toast.MakeText(view.Context, "error" + e, ToastLength.Long).Show();
            };

            dateCita.Click += delegate
            {
                DateTime now = DateTime.Now;
                DatePickerDialog datePicker = new DatePickerDialog(
                   view.Context,
                   this,
                   now.Year,
                   now.Month,
                   now.Day);
                datePicker.SetTitle("Fecha de cita");
                datePicker.Show();
            };
            timeCita.Click += delegate
            {
                Calendar now = Calendar.Instance;
                TimePickerDialog datePicker = new TimePickerDialog(
                   view.Context,
                   this,
                   now.Get(CalendarField.HourOfDay),
                   now.Get(CalendarField.Minute),
                   true
                );
                datePicker.SetTitle("Hora de cita");
                datePicker.Show();
            };
            string firstItem = especialidades.SelectedItem.ToString();
            especialidadesName = firstItem;

            
            especialidades.ItemSelected += (s, e) =>
            {
                    
                   // Toast.MakeText(view.Context, "" + e.Parent.GetItemAtPosition(e.Position).ToString(), ToastLength.Long).Show();
                    especialidadesName = e.Parent.GetItemAtPosition(e.Position).ToString();
               
            };
            btnGuardar.Click += (s, e) =>
            {
                ISharedPreferences preferences = GetSharedPreferences("SessionLogin", FileCreationMode.Private);
                var userId = preferences.GetString("SessionId", "");
                //Toast.MakeText(this.Context, date + "hora: " + time + " especialidad: " + especialidadesName + "usuario" + userId, ToastLength.Long).Show();

                var citas = _citasService.SetCitasRegister(date,time,especialidadesName, userId);
                if (citas!=null)
                {
                    Toast.MakeText(this.Context, "Su cita se registro con exito ", ToastLength.Long).Show();
                }
                else
                {
                    Toast.MakeText(this.Context, "Erro al registrar ", ToastLength.Long).Show();
                }
            };

            return view;
        }

        private ISharedPreferences GetSharedPreferences(string v, FileCreationMode @private)
        {
            new Activity();
            return Activity.GetSharedPreferences(v,@private);
        }

        public void OnDateSet(DatePicker view, int year, int month, int dayOfMonth)
        {
            SimpleDateFormat dateFormat = new SimpleDateFormat("yyyy-MM-dd");
            Date dateNew = new Date(year,month, dayOfMonth, 0, 0);
            DateTime selectedDate = new DateTime(year, month, dayOfMonth);

            var dateSelect = selectedDate.ToString("yyyy-MM-dd");
            date = dateSelect;
            dateCita.Text = date;
           //Toast.MakeText(view.Context, $"Your selected: ", ToastLength.Long).Show();
        }

        public void OnTimeSet(TimePicker view, int hourOfDay, int minute)
        {
            SimpleDateFormat timeFormat = new SimpleDateFormat("hh:mm:ss");
            Date timeNew = new Date(0, 0, 0, hourOfDay, minute);
            String strDate = timeFormat.Format(timeNew);
            timeCita.Text = $"{strDate}";
            time = $"{strDate}";
            Toast.MakeText(view.Context, $"Your selected: {strDate}", ToastLength.Long).Show();
        }
    }
}