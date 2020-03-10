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
    public class Contact
    {
        public Contact(string name)
        {
            Name = name;
            TextMessage = new List<string>();
            
        }

        public Contact(Drawable drawable)
        {
            Avatar = drawable;
            TextMessage = new List<string>();
        }

        public Contact(string name, Drawable drawable)
        {
            Name = name;
            Avatar = drawable;
            TextMessage = new List<string>();
        }

        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public List<string> TextMessage { get; set; }

        public Drawable Avatar { get; set; }

    }
}