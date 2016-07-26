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
using SQLite;
using Android.Graphics;
using System.IO;
using Android.Preferences;

namespace AlcoStoper
{
    [Activity(Label = "AlcoControl")]
    public class AlcoControl : Activity
    {
        int count = 0;
        int limit = 0;
        private ISharedPreferences prefs;
        string path = "/storage/emulated/0/Android/data/" + "alcohole.db";
        private ListView mListView;
        private BaseAdapter<Alcohole> mAdapter;
        private List<Alcohole> mAlcohole;
        private TextView label;
        private Button restart;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            
            SetContentView(Resource.Layout.alco_control);

            mListView = (ListView)FindViewById(Resource.Id.listViewAlcohole);
            restart = (Button)FindViewById(Resource.Id.restart);
            label = (TextView)FindViewById(Resource.Id.label);
            mAlcohole = new List<Alcohole>();

            createDatabase(path);
            mAlcohole = findAll(path);

            mAdapter = new ListAlcoholeAdapter(this, Resource.Layout.row_alcohole, mAlcohole);
            mListView.Adapter = mAdapter;

            limit = Intent.GetIntExtra("limit" , 0);

            if (bundle != null)
            {
                count = bundle.GetInt("count");
                limit = bundle.GetInt("limit");
            }

            if (limit == 0)
            {
                loadText();

            }
            loadCount();
            label.Text = string.Format("{0} of {1}", count, limit);

            mListView.ItemLongClick += listView_ItemLongClick;
            mListView.ItemClick += listView_ItemClick;

            restart.Click += delegate
            {
                count = 0;
                label.Text = string.Format("{0} of {1}", count, limit);
            };
        }

        private void listView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            if (mAlcohole[e.Position].Percent <= 10) { count += 1; }
            else if (mAlcohole[e.Position].Percent > 10 & mAlcohole[e.Position].Percent <= 20) { count += 2; }
            else if (mAlcohole[e.Position].Percent > 20 & mAlcohole[e.Position].Percent <= 30) { count += 3; }
            else if (mAlcohole[e.Position].Percent > 30 & mAlcohole[e.Position].Percent <= 40) { count += 4; }
            else if (mAlcohole[e.Position].Percent > 40 & mAlcohole[e.Position].Percent <= 50) { count += 5; }
            else if (mAlcohole[e.Position].Percent > 50 & mAlcohole[e.Position].Percent <= 60) { count += 6; }
            else if (mAlcohole[e.Position].Percent > 60 & mAlcohole[e.Position].Percent <= 70) { count += 7; }
            else if (mAlcohole[e.Position].Percent > 70 & mAlcohole[e.Position].Percent <= 80) { count += 8; }
            else if (mAlcohole[e.Position].Percent > 80 & mAlcohole[e.Position].Percent <= 90) { count += 9; }
            else if (mAlcohole[e.Position].Percent > 90 & mAlcohole[e.Position].Percent <= 100) { count += 10; }

            isAllarm();
        }

        private bool isAllarm()
        {

            label.Text = string.Format("{0} of {1}", count, limit);
            if (count >= limit)
            {
                new AlertDialog.Builder(this).SetTitle("WARNING!").SetMessage("STOP!! It's enough for you!").Show();
                return true;
            }
            else
            {
                return false;
            }
        }

        private void listView_ItemLongClick(object sender, AdapterView.ItemLongClickEventArgs e)
        {
            PopupMenu menu = new PopupMenu(this, mListView.GetChildAt(e.Position), GravityFlags.Bottom);
            menu.Inflate(Resource.Menu.popup_menu_alcohole);
            menu.MenuItemClick += (s, a) =>
            {
                var db = new SQLiteConnection(path);
                db.Delete<Alcohole>(mAlcohole[e.Position].Id);
                mAlcohole = findAll(path);
                mAdapter = new ListAlcoholeAdapter(this, Resource.Layout.row_alcohole, mAlcohole);
                mListView.Adapter = mAdapter;
            };
            menu.Show();
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.actionbar_alcohole, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.addAlcohole:
                    saveText();
                    StartActivityForResult(typeof(AddNewAlcohole), 0);
                    return true;
                case Resource.Id.contacts:
                    StartActivity(typeof(MainActivity));
                    return true;
                default:
                    return base.OnOptionsItemSelected(item);
            }

        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (resultCode == Result.Ok)
            {
                mAlcohole = findAll(path);

                mAdapter = new ListAlcoholeAdapter(this, Resource.Layout.row_alcohole, mAlcohole);
                mListView.Adapter = mAdapter;
            }
        }

        private void createDatabase(string path)
        {
            var connection = new SQLiteConnection(path);
            {
                connection.CreateTable<Alcohole>();
            }
        }

        private void insertUpdateData(Contact data, string path)
        {
            var db = new SQLiteConnection(path);
            if (db.Insert(data) != 0)
                db.Update(data);
        }

        private List<Alcohole> findAll(string path)
        {
            var db = new SQLiteConnection(path);
            var allAlcohole = db.Query<Alcohole>("SELECT * FROM Alcohole");
            return allAlcohole;
        }

        private byte[] codeToBase64(Bitmap bitmap)
        {
            byte[] imageBytes;
                using (var stream = new MemoryStream())
                {
                    bitmap.Compress(Bitmap.CompressFormat.Png, 0, stream);

                    var bytes = stream.ToArray();
                    string str = Convert.ToBase64String(bytes);
                    imageBytes = Convert.FromBase64String(str);
                    return imageBytes;
                }
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {

            outState.PutInt("count", count);
            outState.PutInt("limit", limit);

            // always call the base implementation!
            base.OnSaveInstanceState(outState);
        }

        void saveText()
        {
            prefs = PreferenceManager.GetDefaultSharedPreferences(this);
            ISharedPreferencesEditor editor = prefs.Edit();
            editor.PutInt("count", count);
            editor.PutInt("limit", limit);
            editor.Apply();
        }

        void loadText()
        {
            prefs = PreferenceManager.GetDefaultSharedPreferences(this);
            count = prefs.GetInt("count", 0);
            limit = prefs.GetInt("limit", 0);
        }

        void loadCount()
        {
            prefs = PreferenceManager.GetDefaultSharedPreferences(this);
            count = prefs.GetInt("count", 0);
        }
    }
}