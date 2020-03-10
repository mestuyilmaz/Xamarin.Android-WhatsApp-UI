using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace WhatsAppUI
{
    class MyListViewAdapterForChat : BaseAdapter
    {
        List<string> _listChat;
        Context _contextChat;

        public MyListViewAdapterForChat(Context context, List<string> listChat)
        {
            _listChat = listChat;
            _contextChat = context;
        }

        public override int Count
        {
            get { return _listChat.Count; }
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
            View rowChat = convertView;
            if (rowChat == null)
                rowChat = LayoutInflater.From(_contextChat).Inflate(Resource.Layout.listview_row_chat, null, false);

            TextView textViewMessage = rowChat.FindViewById<TextView>(Resource.Id.textview_message);
            textViewMessage.Text = _listChat[position];

            TextView textViewTime = rowChat.FindViewById<TextView>(Resource.Id.textview_time);
            textViewTime.Text = DateTime.Now.ToShortTimeString().ToString();

            return rowChat;
        }

    }
}