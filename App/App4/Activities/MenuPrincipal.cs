using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Widget;
using SupportFragment = Android.Support.V4.App.Fragment;
using SupportActionBar = Android.Support.V7.App.ActionBar;
using SupportFragmentManager = Android.Support.V4.App.FragmentManager;

using Android.Views;
using Android.Widget;
using SupportToolBar = Android.Support.V7.Widget.Toolbar;
using Android.Support.V7.App;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Java.Lang;
using Android.Support.V4.App;
using App4.Fragments;

namespace App4.Activities
{
    [Activity(Label = "App Dental", Theme = "@style/Theme.DesignDemo")]
    public class MenuPrincipal : AppCompatActivity
    {
        private DrawerLayout mDrawerLayout;
        public string userName;
        public string userId;
        public string userMessage;
        public ISharedPreferences session;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Main);
            // Create your application here
            SupportToolBar toolBar = FindViewById<SupportToolBar>(Resource.Id.toolBar);
            SetSupportActionBar(toolBar);
            SupportActionBar ab = SupportActionBar;
            ab.SetHomeAsUpIndicator(Resource.Mipmap.ic_menu);
            ab.SetDisplayHomeAsUpEnabled(true);
            mDrawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            NavigationView navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            if (navigationView != null)
            {
                SetUpDrawerContent(navigationView);

            }
            TabLayout tabs = FindViewById<TabLayout>(Resource.Id.tabs);
            ViewPager viewPager = FindViewById<ViewPager>(Resource.Id.viewpager);

            SetUpViewPager(viewPager);
            tabs.SetupWithViewPager(viewPager);

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += (o, e) => {
                View anchor = o as View;
                Snackbar.Make(anchor, "Yay Scakbar!!", Snackbar.LengthLong)
                    .SetAction("Action", v =>
                    {

                    })
                    .Show();
            };
            
        }
        private void SetUpViewPager(ViewPager viewPager)
        {
            TabAdapter adapter = new TabAdapter(SupportFragmentManager);
            adapter.AddFragment(new Fragment1(), "Especialidades");
            adapter.AddFragment(new Fragment2(), "Cita");
            adapter.AddFragment(new Fragment4(), "Recordatorio");

            viewPager.Adapter = adapter;
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    mDrawerLayout.OpenDrawer((int)GravityFlags.Left);
                    return true;
                default:
                    return base.OnOptionsItemSelected(item);
            }

        }
        private void SetUpDrawerContent(NavigationView navigationView)
        {
            
            navigationView.NavigationItemSelected += (object sender, NavigationView.NavigationItemSelectedEventArgs e) =>
            {
                e.MenuItem.SetChecked(true);
                mDrawerLayout.CloseDrawers();
                var item = e.MenuItem.ToString();
                var trans= SupportFragmentManager.BeginTransaction();
                switch (item)
                {
                    case "Citas":
                        trans.Add(Resource.Id.viewpager, new Fragment2(), "Citas");
                        trans.Commit();
                        break;
                    case "Salir":

                        session = GetSharedPreferences("SessionLogin", FileCreationMode.Private);
                        ISharedPreferencesEditor sessionEditor = session.Edit();
                        sessionEditor.Remove("SessionName");
                        sessionEditor.Remove("SessionId");
                        sessionEditor.Remove("SessionUserName");
                        sessionEditor.Remove("SessionCorreo");
                        sessionEditor.Commit();
                        Finish();
                        break;
                }
                    
                Toast.MakeText(this, item, ToastLength.Long).Show();
            };
        }
        public class TabAdapter : FragmentPagerAdapter
        {
            public List<SupportFragment> Fragments { get; set; }
            public List<string> FragmentNames { get; set; }
            public TabAdapter(SupportFragmentManager sfm) : base(sfm)
            {
                Fragments = new List<SupportFragment>();
                FragmentNames = new List<string>();
            }
            public void AddFragment(SupportFragment fragment, string name)
            {
                Fragments.Add(fragment);
                FragmentNames.Add(name);
            }
            public override int Count
            {
                get
                {
                    return Fragments.Count;
                }
            }
            public override SupportFragment GetItem(int position)
            {
                return Fragments[position];
            }
            public override ICharSequence GetPageTitleFormatted(int position)
            {
                return new Java.Lang.String(FragmentNames[position]);
            }

        }
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.MyMenu, menu);
            ISharedPreferences preferences = GetSharedPreferences("SessionLogin",FileCreationMode.Private);
            TextView ViewnName = FindViewById<TextView>(Resource.Id.txtViewNameLogin);
            ViewnName.Text = preferences.GetString("SessionUserName", "");
            return base.OnCreateOptionsMenu(menu);
        }
    }
}