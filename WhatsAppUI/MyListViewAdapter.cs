using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;

namespace WhatsAppUI
{
    class MyListViewAdapter : BaseAdapter<Contact>
    {
        List<Contact> _liste;
        Context _context;

        public MyListViewAdapter(Context context, List<Contact> liste)
        {
            _liste = liste;
            _context = context;
        }

        public override Contact this[int position]
        {
            get { return _liste[position]; }
        }

        public override int Count
        {
            get { return _liste.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }
        public void Update()
        {
            NotifyDataSetChanged();
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;
            if (row == null)
                row = LayoutInflater.From(_context).Inflate(Resource.Layout.listview_row, null, true);

            TextView name = row.FindViewById<TextView>(Resource.Id.name);
            name.Text = _liste[position].Name;

            Refractored.Controls.CircleImageView avatar = row.FindViewById<Refractored.Controls.CircleImageView>(Resource.Id.avatar);
            avatar.SetImageDrawable(_liste[position].Avatar);

            //TextView message = row.FindViewById<TextView>(Resource.Id.message);

            //if (ChatActivity.listChat != null)
            //    message.Text = ChatActivity.listChat[ChatActivity.listChat.Count - 1];
            //else
            //    message.Text = "";
            //TextView time = row.FindViewById<TextView>(Resource.Id.time);
            //time.Text = son atılan mesajın zamanı

            return row;
        }
    }
}