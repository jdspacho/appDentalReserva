using SupportFragment = Android.Support.V4.App.Fragment;
using Android.OS;
using Android.Views;
using Android.App;
using Android.Support.V7.Widget;
using System.Collections.Generic;
using System;
using Android.Util;
using Android.Content.Res;
using Android.Content;
using Android.Graphics;
using Android.Widget;
using App4.Adapters;
using App4.Services;
using App4.Models;
using App4.Adapters;
namespace App4.Fragments
{
    public class Fragment4 : SupportFragment
    {
        private CitasAdapter _citasAdapter = new CitasAdapter();
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            RecyclerView recyclerView = inflater.Inflate(Resource.Layout.FragmentListCitas, container, false) as RecyclerView;
            //var especialidadesListView=recyclerView.FindViewById<ListView>(Resource.Id.listEspecialidades);
            var citasService = new CitasService();
            ISharedPreferences preferences = GetSharedPreferences("SessionLogin", FileCreationMode.Private);
            var idUser = preferences.GetString("SessionId", "");
            var citas = citasService.GetCitas(idUser);
            //especialidadesListView.Adapter=new EspecialidadesListAdapter(recyclerView,especialidades)
            _citasAdapter.SetUpRecyclerView(recyclerView, citas,Activity.Resources);

            return recyclerView;
        }
        private ISharedPreferences GetSharedPreferences(string v, FileCreationMode @private)
        {
            new Activity();
            return Activity.GetSharedPreferences(v, @private);
        }
    }
}