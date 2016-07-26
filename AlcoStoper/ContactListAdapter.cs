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
using Android.Graphics;

namespace AlcoStoper
{
    class ContactListAdapter : BaseAdapter<Contact>
    {
        private Context mContext;
        private int mLayout;
        private List<Contact> mContacts;

        public ContactListAdapter(Context context, int layout, List<Contact> contacts)
        {
            mContext = context;
            mLayout = layout;
            mContacts = contacts;
        }

        public override Contact this[int position]
        {
            get { return mContacts[position]; }
        }

        public override int Count
        {
            get { return mContacts.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            if (row == null)
            {
                row = LayoutInflater.From(mContext).Inflate(mLayout, parent, false);
            }

            row.FindViewById<TextView>(Resource.Id.txtName).Text = mContacts[position].Name;
            row.FindViewById<TextView>(Resource.Id.txtNumber).Text = mContacts[position].Number;

            ImageView pic = row.FindViewById<ImageView>(Resource.Id.imgPic);

            if (mContacts[position].Image != null)
            {
                pic.SetImageBitmap(BitmapFactory.DecodeByteArray(mContacts[position].Image, 0, mContacts[position].Image.Length));
            }

            return row;
        }
    }
}