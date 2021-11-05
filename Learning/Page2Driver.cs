using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Android.Widget;
using System;
using Android.Content;
using Android.Views;

namespace Learning
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = false)]
    public class Page2Driver : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.page2);

            //View v = FindViewById<View>(Resource.Id.Include_Row1);
            //TextView col1 = v.FindViewById<TextView>(Resource.Id.TextView_Col1);
            //col1.Text = "bmw g310r";

            TextView col1 = FindViewById<TextView>(Resource.Id.TextView_Col1);
            col1.Text = "bmw g310r";


        }
    }
}