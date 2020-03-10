using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace WhatsAppUI
{
    [Activity(Label = "InfoActivity")]
    public class InfoActivity : AppCompatActivity
    {
        TextView contact_name;
        ImageView contact_image;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.details);

            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            if (SupportActionBar != null)
            {
                SupportActionBar.SetDisplayHomeAsUpEnabled(true);
                SupportActionBar.SetDisplayShowHomeEnabled(true);
            }

            int position = Intent.GetIntExtra("Position", -1);
            var contact = MainActivity.list[position];

            contact_name = FindViewById<TextView>(Resource.Id.details_contact_name);
            contact_name.Text = contact.Name;

            contact_image = FindViewById<ImageView>(Resource.Id.details_contact_pp);
            contact_image.SetImageDrawable(contact.Avatar);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.toolbar_menu_details, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.home:
                    Finish();
                    break;

                case Resource.Id.menu_options:
                    Toast.MakeText(this, "Options cannot be reached at the moment", ToastLength.Short).Show();
                    break;
            }

            return base.OnOptionsItemSelected(item);
        }
    }
}