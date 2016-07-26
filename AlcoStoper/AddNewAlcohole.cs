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
using SQLite;
using static AlcoStoper.Resource;
using Android.Graphics;
using System.IO;

namespace AlcoStoper
{
    [Activity(Label = "AddNewAlcohole")]
    public class AddNewAlcohole : Activity
    {
        string path = "/storage/emulated/0/Android/data/" + "alcohole.db";
        int percent;
        EditText nameAlco;
        TextView persentText;
        ImageView resultImage;
        ImageButton alco1, alco2, alco3, alco4, alco5, alco6, alco7;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.add_alcohole);

            nameAlco = (EditText)FindViewById(Resource.Id.etNameAlcohole);
            SeekBar seecBarPercent = (SeekBar)FindViewById(Resource.Id.sbPercent);
            persentText = (TextView)FindViewById(Resource.Id.tvPercentNumber);
            alco1 = (ImageButton)FindViewById(Resource.Id.alco1);
            alco2 = (ImageButton)FindViewById(Resource.Id.alco2);
            alco3 = (ImageButton)FindViewById(Resource.Id.alco3);
            alco4 = (ImageButton)FindViewById(Resource.Id.alco4);
            alco5 = (ImageButton)FindViewById(Resource.Id.alco5);
            alco6 = (ImageButton)FindViewById(Resource.Id.alco6);
            alco7 = (ImageButton)FindViewById(Resource.Id.alco7);
            resultImage = (ImageView)FindViewById(Resource.Id.resultImage);
            RadioButton rbWhite = (RadioButton)FindViewById(Resource.Id.rbWhite);
            RadioButton rbRed = (RadioButton)FindViewById(Resource.Id.rbRed);
            RadioButton rbYellow = (RadioButton)FindViewById(Resource.Id.rbYellow);
            Button save = (Button)FindViewById(Resource.Id.save);

            createDatabase(path);

            save.Click += saveAlcohol;
            
            seecBarPercent.ProgressChanged += seecBarProgress;
            rbWhite.Click += whiteIcons;
            rbRed.Click += redIcons;
            rbYellow.Click += yellowIcons;

            alco1.Click += delegate {
                resultImageSelect(alco1.Drawable);
            };

            alco2.Click += delegate {
                resultImageSelect(alco2.Drawable);
            };

            alco3.Click += delegate {
                resultImageSelect(alco3.Drawable);
            };

            alco4.Click += delegate {
                resultImageSelect(alco4.Drawable);
            };

            alco5.Click += delegate {
                resultImageSelect(alco5.Drawable);
            };

            alco6.Click += delegate {
                resultImageSelect(alco6.Drawable);
            };

            alco7.Click += delegate {
                resultImageSelect(alco7.Drawable);
            };
        }
        
        private void yellowIcons(object sender, EventArgs e)
        {
            alco1.SetImageDrawable(GetDrawable(Resource.Drawable.beery1));
            alco2.SetImageDrawable(GetDrawable(Resource.Drawable.beery2));
            alco3.SetImageDrawable(GetDrawable(Resource.Drawable.beery));
            alco4.SetImageDrawable(GetDrawable(Resource.Drawable.cocktaily1));
            alco5.SetImageDrawable(GetDrawable(Resource.Drawable.cocktaily2));
            alco6.SetImageDrawable(GetDrawable(Resource.Drawable.cocktaily));
            alco7.SetImageDrawable(GetDrawable(Resource.Drawable.glassy));
        }

        private void redIcons(object sender, EventArgs e)
        {
            alco1.SetImageDrawable(GetDrawable(Resource.Drawable.beerr1));
            alco2.SetImageDrawable(GetDrawable(Resource.Drawable.beerr2));
            alco3.SetImageDrawable(GetDrawable(Resource.Drawable.beerr));
            alco4.SetImageDrawable(GetDrawable(Resource.Drawable.cocktailr1));
            alco5.SetImageDrawable(GetDrawable(Resource.Drawable.cocktailr2));
            alco6.SetImageDrawable(GetDrawable(Resource.Drawable.cocktailr));
            alco7.SetImageDrawable(GetDrawable(Resource.Drawable.glassr));
        }

        private void whiteIcons(object sender, EventArgs e)
        {
            alco1.SetImageDrawable(GetDrawable(Resource.Drawable.beer1));
            alco2.SetImageDrawable(GetDrawable(Resource.Drawable.beer2));
            alco3.SetImageDrawable(GetDrawable(Resource.Drawable.beer));
            alco4.SetImageDrawable(GetDrawable(Resource.Drawable.cocktail1));
            alco5.SetImageDrawable(GetDrawable(Resource.Drawable.cocktail2));
            alco6.SetImageDrawable(GetDrawable(Resource.Drawable.cocktail));
            alco7.SetImageDrawable(GetDrawable(Resource.Drawable.glass));
        }

        private void resultImageSelect(Android.Graphics.Drawables.Drawable drawable)
        {
            resultImage.SetImageDrawable(drawable);
        }

        void saveAlcohol(object sender, EventArgs e)
        {
            string name = nameAlco.Text;
            if (percent == 0 || name == null)
            {
                Toast.MakeText(this, "Fill in all the fields", ToastLength.Short).Show();
            } else { 
            Bitmap resultBitmap = ((BitmapDrawable)resultImage.Drawable).Bitmap;
            Alcohole alcohole = new Alcohole() { Name = name, Percent = percent, Image = codeToBase64(resultBitmap) };
            insertUpdateData(alcohole, path);
            StartActivity(typeof(AlcoControl));
            }
        }


        void seecBarProgress(object sender, SeekBar.ProgressChangedEventArgs e)
        {
            if (e.FromUser)
            {
                persentText.Text = string.Format("The value of the SeekBar is {0}", e.Progress);
                percent = e.Progress;
            }
        }

        private void createDatabase(string path)
        {
            var connection = new SQLiteConnection(path);
            {
                connection.CreateTable<Alcohole>();
            }
        }

        private void insertUpdateData(Alcohole data, string path)
        {
            var db = new SQLiteConnection(path);
            if (db.Insert(data) != 0)
                db.Update(data);
        }

        private byte[] codeToBase64(Bitmap bitmap)
        {
            byte[] imageBytes;
            try
            {
                using (var stream = new MemoryStream())
                {
                    bitmap.Compress(Bitmap.CompressFormat.Png, 0, stream);

                    var bytes = stream.ToArray();
                    string str = Convert.ToBase64String(bytes);
                    imageBytes = Convert.FromBase64String(str);
                    return imageBytes;
                }
            }
            catch (NullReferenceException ex)
            {
                Toast.MakeText(this, "Error", ToastLength.Short).Show();
                StartActivity(typeof(MainActivity));
                return imageBytes = null;
            }
        }
    }
}