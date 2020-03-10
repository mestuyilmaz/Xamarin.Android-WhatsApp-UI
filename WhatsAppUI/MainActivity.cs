using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;


namespace WhatsAppUI
{
    [Activity(Label = "MainActivity", MainLauncher = true, Icon = "@drawable/ic_whatsapp")]
    public class MainActivity : AppCompatActivity
    {

        ListView _listView;
        public static List<Contact> list = new List<Contact>();
        FloatingActionButton fab;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.activity_main);

            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = "Whatsapp++";



            list.Add(new Contact("Taylor LaShae", Resources.GetDrawable(Resource.Drawable.pp1)));
            list.Add(new Contact("Jorah Mormont", Resources.GetDrawable(Resource.Drawable.pp2)));

            _listView = FindViewById<ListView>(Resource.Id.customListView);
            var mAdapter = new MyListViewAdapter(this, MainActivity.list);
            _listView.Adapter = mAdapter;
            mAdapter.Update();
            RunOnUiThread(() => mAdapter.NotifyDataSetChanged());

            _listView.ItemClick += _listView_ItemClick;



            fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += Fab_Click;

        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.toolbar_menu, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.menu_search:
                    Toast.MakeText(this, "Search service disabled at the moment", ToastLength.Short).Show();
                    break;

                case Resource.Id.menu_settings:
                    Toast.MakeText(this, "Settings cannot be reached at the moment", ToastLength.Short).Show();
                    break;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void Fab_Click(object sender, System.EventArgs e)
        {
            var intent = new Intent(this, typeof(AddContactActivity));
            StartActivity(intent);

        }
        private void _listView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var intent = new Intent(this, typeof(ChatActivity));
            intent.PutExtra("ItemPosition", e.Position);
            StartActivity(intent);

        }




    }
}