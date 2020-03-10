using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace WhatsAppUI
{
    class MyListViewAdapterForAvatar : BaseAdapter
    {
        List<Drawable> _listAvatar;
        Context _contextAvatar;

        public MyListViewAdapterForAvatar(Context context, List<Drawable> listAvatar)
        {
            _listAvatar = listAvatar;
            _contextAvatar = context;
        }

        public override int Count
        {
            get { return _listAvatar.Count; }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View rowAvatar = convertView;
            if (rowAvatar == null)
                rowAvatar = LayoutInflater.From(_contextAvatar).Inflate(Resource.Layout.listview_row_avatar, null, false);

            ImageView imageView = rowAvatar.FindViewById<ImageView>(Resource.Id.imageview_avatar);
            imageView.SetImageDrawable(_listAvatar[position]);

            return rowAvatar;
        }

    }
}