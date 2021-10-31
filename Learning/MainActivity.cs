using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Android.Widget;
using System;

namespace Learning
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            //Set up
            MyTextView = FindViewById<TextView>(Resource.Id.MyText);
            MyValue = 0;
            ButtonIncrement = FindViewById<Button>(Resource.Id.PleaseIncrement);
            ButtonDecrement = FindViewById<Button>(Resource.Id.PleaseDecrement);
            ButtonNavigateAway = FindViewById<Button>(Resource.Id.NavigateAway);
            EditText_ToSaveToLocal = FindViewById<EditText>(Resource.Id.EditText_ToSaveToLocal);
            Button_SaveToLocal = FindViewById<Button>(Resource.Id.Button_SaveLocalFile);
            TextView_FromLocal = FindViewById<TextView>(Resource.Id.TextView_LocalFileContent);
            Button_RetrieveFromLocal = FindViewById<Button>(Resource.Id.Button_RetrieveFromLocal);

            //Assign
            ButtonIncrement.Click += Inc;
            ButtonDecrement.Click += Dec;
            ButtonNavigateAway.Click += NavigateAwayNow;
            Button_SaveToLocal.Click += SaveToLocal;
            Button_RetrieveFromLocal.Click += RetrieveFromLocal;

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public int MyValue;
        public TextView MyTextView;
        public Button ButtonIncrement;
        public Button ButtonDecrement;
        public Button ButtonNavigateAway;
        public EditText EditText_ToSaveToLocal;
        public Button Button_SaveToLocal;
        public Button Button_RetrieveFromLocal;
        public TextView TextView_FromLocal;
        

        public void Inc(object sender, EventArgs e)
        {
            MyValue = MyValue + 1;
            MyTextView.Text = MyValue.ToString("#,##0");
        }

        public void Dec(object sender, EventArgs e)
        {
            MyValue = MyValue - 1;
            MyTextView.Text = MyValue.ToString("#,##0");
        }

        public void NavigateAwayNow(object sender, EventArgs e)
        {
            SetContentView(Resource.Layout.page2);
        }

        public void SaveToLocal(object sender, EventArgs e)
        {
            string TextToSave = EditText_ToSaveToLocal.Text;

            string Path = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Test.txt");
            System.IO.File.WriteAllText(Path, TextToSave);
            
            Android.App.AlertDialog.Builder ad = new Android.App.AlertDialog.Builder(this);
            ad.SetTitle("Done");
            ad.SetMessage("Success!. I saved that.");
            ad.SetNeutralButton("okay", delegate { ad.Dispose(); });
            ad.Show();
        }

        public void RetrieveFromLocal(object sender, EventArgs e)
        {
            string Path = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Test.txt");
            string content = System.IO.File.ReadAllText(Path);
            TextView_FromLocal.Text = content;
        }
    
    }
}