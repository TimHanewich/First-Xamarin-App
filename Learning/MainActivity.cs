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

            //Assign
            ButtonIncrement.Click += Inc;
            ButtonDecrement.Click += Dec;
            ButtonNavigateAway.Click += NavigateAwayNow;

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
    
    }
}