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
                ViewStub vs = new ViewStub(this);
                vs.LayoutResource = Resource.Layout.Component_SessionSelector;
                FindViewById<LinearLayout>(Resource.Id.LinearLayout_AddHere).AddView(vs);
                View v = vs.Inflate();
                v.FindViewById<TextView>(Resource.Id.TextView_Title).Text = "Row number " + t.ToString();

                Button b = v.FindViewById<Button>(Resource.Id.Button_Select);
                b.Click += RowSelected;
            }


        }

        private void RowSelected(object sender, EventArgs e)
        {
            UpdateStatus("Got a click!");
            Button b = (Button)sender;
            View v = (View)b.Parent;
            TextView tv = v.FindViewById<TextView>(Resource.Id.TextView_Title);
            UpdateStatus(tv.Text);
        }

        private void UpdateStatus(string txt)
        {
            FindViewById<TextView>(Resource.Id.TextView_Status).Text = txt;
        }
    }
}