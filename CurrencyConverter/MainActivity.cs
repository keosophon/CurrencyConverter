using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Android.Widget;
//using Android.Graphics;

namespace CurrencyConverter
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private TextView txtRate;
        private double rate;
        private TextView txtAmount;
        private double amount;
        private Spinner fromCurrencies;
        private Spinner toCurrencies;
        private TextView txtResult;
        private double result;
        private Button btnConvert;
        private Button btnClear;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            //map variables to UI elements
            txtRate = FindViewById<TextView>(Resource.Id.txtInputRate);
            txtAmount = FindViewById<TextView>(Resource.Id.txtInputAmount);
            fromCurrencies = FindViewById<Spinner>(Resource.Id.spnFromCurrency);
            toCurrencies = FindViewById<Spinner>(Resource.Id.spnToCurrency);
            txtResult = FindViewById<TextView>(Resource.Id.txtResultValue);
            btnConvert = FindViewById<Button>(Resource.Id.btnConvert);
            btnClear = FindViewById<Button>(Resource.Id.btnClear);

            //adapter is the bridge between spinner and data.
            //adapter needs both data and its data drop down layout
            ArrayAdapter adapter = ArrayAdapter.CreateFromResource(this, Resource.Array.currencies, Android.Resource.Layout.SimpleSpinnerDropDownItem);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            fromCurrencies.Adapter = adapter;
            toCurrencies.Adapter = adapter;
            

            //link Click event to event handler
            btnConvert.Click += BtnConvert_Click;
            btnClear.Click += BtnClear_Click;
            txtRate.RequestFocus();
        }

        private void BtnClear_Click(object sender, System.EventArgs e)
        {
            txtRate.Text = "";
            txtAmount.Text = "";
            txtResult.Text = "";
            txtRate.RequestFocus();
        }

        private void BtnConvert_Click(object sender, System.EventArgs e)
        {

            if (txtRate.Text == "")
            {
                txtRate.Text = "Please input a proper exchange rate";
                
                
            }
            else
            {
                try
                {
                    rate = System.Convert.ToDouble(txtRate.Text);
                }
                catch
                {
                    txtRate.Text = "Please input a proper exchange rate";
                }
            }
            if (txtAmount.Text == "")
            {
                txtAmount.Text = "Please input a proper exchange amount";
            }
            else
            {
                try
                {
                    amount = System.Convert.ToDouble(txtAmount.Text);
                }
                catch
                {
                    txtAmount.Text = "Please input a proper exchange amount";
                }
            }
            string from = fromCurrencies.SelectedItem.ToString();
            string to = toCurrencies.SelectedItem.ToString();

            txtResult.Text = "";
            if (from==to)
            {
                txtResult.Text = System.Convert.ToString(amount);
            }
            else
            {
                result = rate * amount;
                txtResult.Text = System.Convert.ToString(result);
            }
        }

        
       
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}