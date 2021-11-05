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

            for (int t = 0; t < 10; t++)
            {
                TextView tv = new TextView(this);
                tv.Text = "Simpsons " + t.ToString();
                FindViewById<LinearLayout>(Resource.Id.LinearLayout_AddHere).AddView(tv);
            }

            ViewStub vs = new ViewStub(this);
            vs.LayoutResource = Resource.Layout.Component_LineItem;
            FindViewById<LinearLayout>(Resource.Id.LinearLayout_AddHere).AddView(vs);
            View v = vs.Inflate();

            //Change vs column 1
            TextView col1 = v.FindViewById<TextView>(Resource.Id.TextView_Col1);
            col1.Text = "HIT & RUN!";


        }
    }
}