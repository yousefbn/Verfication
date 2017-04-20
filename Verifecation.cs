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

namespace VerificationCodeTask
{
    [Activity(Label = "Verifecation")]
    public class Verifecation : Activity
    {
        EditText et1, et2, et3, et4, et5;
        Button btCheck;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.VerificationActivity);
            et1 = FindViewById<EditText>(Resource.Id.editText1);
            et2 = FindViewById<EditText>(Resource.Id.editText2);
            et3 = FindViewById<EditText>(Resource.Id.editText3);
            et4 = FindViewById<EditText>(Resource.Id.editText4);
            et5 = FindViewById<EditText>(Resource.Id.editText5);
            btCheck = FindViewById<Button>(Resource.Id.button1);

            btCheck.Click += BtCheck_Click;
        }

        private void BtCheck_Click(object sender, EventArgs e)
        {
            StringBuilder b = new StringBuilder();
            b.Append(et1.Text);
            b.Append(et2.Text);
            b.Append(et3.Text);
            b.Append(et4.Text);
            b.Append(et5.Text);

            string verCode = Intent.GetStringExtra("Code") ?? "Data not available";

            if (b.ToString() == verCode)
            {

                Toast.MakeText(this, "Valid Code", ToastLength.Long).Show();
                
            }
            else
            {

                AlertDialog.Builder inValid = new AlertDialog.Builder(this);
                inValid.SetTitle("inValid");
                inValid.SetMessage("Your Code is inCorrect");
                inValid.SetCancelable(true);
                inValid.SetNegativeButton("Ok", delegate { SetContentView(Resource.Layout.VerificationActivity); });
                inValid.Show();

            }
                



           /* if (b.ToString() == verCode)
                Toast.MakeText(this, "Code is Correct", ToastLength.Long).Show();
            else
                Toast.MakeText(this, "Code is incoreect", ToastLength.Long).Show();*/

        }
    }
}