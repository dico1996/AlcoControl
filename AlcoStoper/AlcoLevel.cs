using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using System;

namespace AlcoStoper
{
    [Activity(Label = "AlcoLevel")]
    public class AlcoLevel : Activity
    {
        ImageView sad, happy1, happy, shouting;
        int LIMIT_FOR_SAD = 25;
        int LIMIT_FOR_HAPPY1 = 50;
        int LIMIT_FOR_HAPPY = 75;
        int LIMIT_FOR_SHOUTING = 100;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.alco_level);
            sad = (ImageView)FindViewById(Resource.Id.sad);
            happy1 = (ImageView)FindViewById(Resource.Id.happy1);
            happy = (ImageView)FindViewById(Resource.Id.happy);
            shouting = (ImageView)FindViewById(Resource.Id.shouting);

            sad.Click += sadClick;
            happy1.Click += happyOneClick;
            happy.Click += happyClick;
            shouting.Click += shoutingClick;
        }

        void sadClick(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(AlcoControl));
            intent.PutExtra("limit", LIMIT_FOR_SAD);
            StartActivity(intent);
        }

        void happyOneClick(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(AlcoControl));
            intent.PutExtra("limit", LIMIT_FOR_HAPPY1);
            StartActivity(intent);
        }

        void happyClick(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(AlcoControl));
            intent.PutExtra("limit", LIMIT_FOR_HAPPY);
            StartActivity(intent);
        }

        void shoutingClick(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(AlcoControl));
            intent.PutExtra("limit", LIMIT_FOR_SHOUTING);
            StartActivity(intent);
        }
    }
}