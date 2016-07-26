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
using Java.Lang;

namespace AlcoStoper
{
    class ListAlcoholeAdapter : BaseAdapter<Alcohole>
    {
        private Context mContext;
        private int mLayout;
        private List<Alcohole> mAlcohole;

        public ListAlcoholeAdapter(Context context, int layout, List<Alcohole> alcohole)
        {
            mContext = context;
            mLayout = layout;
            mAlcohole = alcohole;
        }

        public override Alcohole this[int position]
        {
            get { return mAlcohole[position]; }
        }

        public override int Count
        {
            get { return mAlcohole.Count; }
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
            row.FindViewById<TextView>(Resource.Id.alcoholeName).Text = mAlcohole[position].Name;
            row.FindViewById<TextView>(Resource.Id.alcoholePercent).Text = mAlcohole[position].Percent.ToString();

            ImageView pic = row.FindViewById<ImageView>(Resource.Id.imgAlcohole);

            if (mAlcohole[position].Image != null)
            {
                pic.SetImageBitmap(BitmapFactory.DecodeByteArray(mAlcohole[position].Image, 0, mAlcohole[position].Image.Length));
            }

            return row;
        }
    }
}