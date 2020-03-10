using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Java.IO;

namespace WhatsAppUI
{
    [Activity(Label = "AddContactActivity")]
    public class AddContactActivity : AppCompatActivity
    {
        ListView _listViewAvatar;
        public static List<Drawable> listAvatar = new List<Drawable>();
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.add_contact);

            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = "Add a Contact";

            if (SupportActionBar != null)
            {
                SupportActionBar.SetDisplayHomeAsUpEnabled(true);
                SupportActionBar.SetDisplayShowHomeEnabled(true);
            }

            var inputName = FindViewById<EditText>(Resource.Id.inputName);

            listAvatar.Clear();
            listAvatar.Add(Resources.GetDrawable(Resource.Drawable.pp0));
            listAvatar.Add(Resources.GetDrawable(Resource.Drawable.pp1));
            listAvatar.Add(Resources.GetDrawable(Resource.Drawable.pp2));
            listAvatar.Add(Resources.GetDrawable(Resource.Drawable.pp3));

            _listViewAvatar = FindViewById<ListView>(Resource.Id.listview_avatar);
            _listViewAvatar.Adapter = new MyListViewAdapterForAvatar(this, AddContactActivity.listAvatar);
            _listViewAvatar.ItemClick += _listViewAvatar_ItemClick;

            FindViewById<Button>(Resource.Id.addButton).Click += OnAddClick;
            FindViewById<Button>(Resource.Id.cancelButton).Click += OnCancelClick;
        }

        public void _listViewAvatar_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var intent = new Intent(this, typeof(MainActivity));
            intent.PutExtra("SelectedImage", e.Position);

            e.View.SetBackgroundResource(Resource.Drawable.imageview_border);

            var position = e.Position;

            RunOnUiThread(() => MainActivity.list.Add(new Contact(listAvatar[position])));
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
                case Resource.Id.home:
                    Finish();
                    break;
            }
            return base.OnOptionsItemSelected(item);
        }

        private void OnAddClick(object sender, EventArgs e)
        {
            string name = FindViewById<EditText>(Resource.Id.inputName).Text;

            var intent = new Intent(this, typeof(MainActivity));

            intent.PutExtra("ItemName", name);

            SetResult(Result.Ok, intent);

            MainActivity.list.Add(new Contact(name));

            Toast.MakeText(this, name + " added", ToastLength.Short).Show();

            Finish();
        }

        private void OnCancelClick(object sender, EventArgs e)
        {
            Finish();
        }

    }
}