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

            FindViewById<Button>(Resource.Id.addButton).Click += OnAddClick;
            FindViewById<Button>(Resource.Id.cancelButton).Click += OnCancelClick;
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