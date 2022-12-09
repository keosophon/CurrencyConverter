using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Android.Widget;

namespace CurrencyConverter
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Spinner fromCurrencies;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            fromCurrencies = FindViewById<Spinner>(Resource.Id.spnFromCurrency);
            ArrayAdapter adapter = ArrayAdapter.CreateFromResource(this, Resource.Array.currencies, Android.Resource.Layout.SimpleSpinnerDropDownItem);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerItem);
            fromCurrencies.Adapter = adapter;

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}