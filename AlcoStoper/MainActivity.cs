using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using SQLite;
using Android.Graphics;
using System.IO;

namespace AlcoStoper
{
    [Activity(Label = "AlcoControl", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private ListView mListView;
        private BaseAdapter<Contact> mAdapter;
        private List<Contact> mContacts;
        string pathFile;
        string path = "/storage/emulated/0/Android/data/" + "sql.db";
        byte[] image;
        ImageView pic;

        protected override void OnCreate(Bundle bundle)
        {

            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            createDatabase(path);

            mListView = FindViewById<ListView>(Resource.Id.listViewContacts);
            mContacts = new List<Contact>();

            mContacts = findAll(path);

            mAdapter = new ContactListAdapter(this, Resource.Layout.row_contact, mContacts);
            mListView.Adapter = mAdapter;

            pic = (ImageView)FindViewById(Resource.Id.imgPic);

            mListView.ItemLongClick += listView_ItemLongClick;
        }

        void listView_ItemLongClick(object sender, AdapterView.ItemLongClickEventArgs e)
        {
            PopupMenu menu = new PopupMenu(this, mListView.GetChildAt(e.Position), GravityFlags.Bottom);
            menu.Inflate(Resource.Menu.popup_menu);
            menu.MenuItemClick += (s, a) =>
            {
                var db = new SQLiteConnection(path);
                db.Delete<Contact>(mContacts[e.Position].Id);
                mContacts = findAll(path);
                mAdapter = new ContactListAdapter(this, Resource.Layout.row_contact, mContacts);
                mListView.Adapter = mAdapter;
            };
            menu.Show();
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (resultCode == Result.Ok)
            {
                ImageView pic = (ImageView)FindViewById(Resource.Id.imgPic);
                pathFile = data.GetStringExtra("path");
                int height = Resources.DisplayMetrics.HeightPixels;
                int width = 180;

                Bitmap bitmap = pathFile.LoadAndResizeBitmap(width, height);
                image = codeToBase64(bitmap);
            }
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.actionbar, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.add:
                    try
                    {
                        var myIntent = new Intent(this, typeof(CameraActivity));
                        StartActivityForResult(myIntent, 0);
                    }
                    catch { }

                    CreateContactDialog dialog = new CreateContactDialog();
                    FragmentTransaction transaction = FragmentManager.BeginTransaction();

                    //Subscribe to event
                    dialog.OnCreateContact += dialog_OnCreateContact;
                    dialog.Show(transaction, "create contact");
                    return true;
                case Resource.Id.search:
                    StartActivity(typeof(AlcoLevel));
                    return true;
                default:
                    return base.OnOptionsItemSelected(item);
            }

        }

        void dialog_OnCreateContact(object sender, CreateContactEventArgs e)
        {
            Contact contact = new Contact() { Name = e.Name, Number = e.Number, Image = image };
            mContacts.Add(contact);
            insertUpdateData(contact, path);
            mAdapter.NotifyDataSetChanged();
        }

        private void createDatabase(string path)
        {
            var connection = new SQLiteConnection(path);
            {
                connection.CreateTable<Contact>();
            }
        }

        private void insertUpdateData(Contact data, string path)
        {
            var db = new SQLiteConnection(path);
            if (db.Insert(data) != 0)
                db.Update(data);
        }

        private List<Contact> findAll(string path)
        {
            var db = new SQLiteConnection(path);
            var allContacts = db.Query<Contact>("SELECT * FROM Contact");
            return allContacts;
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

