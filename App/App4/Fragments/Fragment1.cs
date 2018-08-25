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
    public class Fragment1 : SupportFragment
    {
        private EspecialidadesListAdapter _especialidadesListAdapter = new EspecialidadesListAdapter();
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            RecyclerView recyclerView = inflater.Inflate(Resource.Layout.FragmentEspecialidades, container, false) as RecyclerView;
            //var especialidadesListView=recyclerView.FindViewById<ListView>(Resource.Id.listEspecialidades);
            var especialidadesService = new EspecialidadesService();
            var especialidades = especialidadesService.GetEspecialidades();
            //especialidadesListView.Adapter=new EspecialidadesListAdapter(recyclerView,especialidades)
            _especialidadesListAdapter.SetUpRecyclerView(recyclerView, especialidades, Activity.Resources);

            return recyclerView;
        }
        private List<string> GetRandomSubList(List<string> items, int amount)
        {
            List<string> list = new List<string>();
            Random random = new Random();
            while (list.Count < amount)
            {
                list.Add(items[random.Next(items.Count)]);
            }
            return list;
        }
        
    }
}