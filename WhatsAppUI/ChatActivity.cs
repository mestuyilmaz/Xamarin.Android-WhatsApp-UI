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
    [Activity(Label = "chat")]
    public class ChatActivity : AppCompatActivity
    {
        Button buttonSend;
        EditText messageEdit;
        ListView _listViewChat;
        public static List<string> listChat = new List<string>();
        private int progressBarStatus = 0;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.chat);

            int position = Intent.GetIntExtra("ItemPosition", -1);
            var contact = MainActivity.list[position];

            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = contact.Name;

            if (SupportActionBar != null)
            {
                SupportActionBar.SetDisplayHomeAsUpEnabled(true);
                SupportActionBar.SetDisplayShowHomeEnabled(true);
            }

            messageEdit = FindViewById<EditText>(Resource.Id.messageEdit);
            listChat = contact.TextMessage;

            if (listChat != null)
            {
                _listViewChat = FindViewById<ListView>(Resource.Id.messagesContainer);
                _listViewChat.Adapter = new MyListViewAdapterForChat(this, ChatActivity.listChat);
            }

            buttonSend = FindViewById<Button>(Resource.Id.buttonSend);
            buttonSend.Click += ButtonSend_Click;

        }

        private void ButtonSend_Click(object sender, EventArgs e)
        {
            int position = Intent.GetIntExtra("ItemPosition", -1);
            var contact = MainActivity.list[position];

            messageEdit = FindViewById<EditText>(Resource.Id.messageEdit);

            if (progressBarStatus != 10)
            {
                var progressBar = FindViewById<ProgressBar>(Resource.Id.progressBar);
                progressBar.Max = 10;
                progressBar.Progress = 0;
                progressBarStatus += 1;
                progressBar.Progress += progressBarStatus;

                contact.TextMessage.Add(messageEdit.Text);
                listChat = contact.TextMessage;

                _listViewChat = FindViewById<ListView>(Resource.Id.messagesContainer);
                _listViewChat.Adapter = new MyListViewAdapterForChat(this, ChatActivity.listChat);

                messageEdit.Text = "";

            }

            else
            {
                Toast.MakeText(this, "Sorry, out of message limit", ToastLength.Short).Show();
                messageEdit.Text = "";
            }
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.toolbar_menu_chat, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.home:
                    Finish();
                    break;

                case Resource.Id.menu_call:
                    Toast.MakeText(this, "Call service disabled at the moment", ToastLength.Short).Show();
                    break;

                case Resource.Id.menu_attach:
                    Toast.MakeText(this, "Attachment service disabled at the moment", ToastLength.Short).Show();
                    break;

                case Resource.Id.menu_details:
                    Intent detailIntent = new Intent(this, typeof(InfoActivity));
                    var position = Intent.GetIntExtra("ItemPosition", -1);
                    detailIntent.PutExtra("Position", position);
                    StartActivity(detailIntent);
                    break;
            }

            return base.OnOptionsItemSelected(item);
        }

    }
}