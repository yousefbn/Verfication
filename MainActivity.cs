using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using System;
using Android.Telephony.Gsm;

namespace VerificationCodeTask
{
    [Activity(Label = "VerificationCodeTask", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        Button b;
        EditText phone;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);


            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            b = FindViewById<Button>(Resource.Id.myButton);
            phone = FindViewById<EditText>(Resource.Id.etphone);

            b.Click += B_Click;
         
        }

        private void B_Click(object sender, System.EventArgs e)
        {
            if (phone.Text == "")
            {
                Toast.MakeText(this, "Enter Your phone number", ToastLength.Long).Show();
            }

            else
            {
                var phoneNum = phone.Text;
                string msg = GenerateRandomNo();

                var piSent = PendingIntent.GetBroadcast(this, 0, new Intent("SMS_SENT"), 0);
                var piDelivered = PendingIntent.GetBroadcast(this, 0, new Intent("SMS_DELIVERED"), 0);

#pragma warning disable CS0618 // Type or member is obsolete
                SmsManager.Default.SendTextMessage(phoneNum, null,
#pragma warning restore CS0618 // Type or member is obsolete
                msg, null, null);

               


              var intent = new Intent(this, typeof(Verifecation));
                intent.PutExtra("Code", msg);
                StartActivity(intent);




            }
            
            
            
        
    }
        

        public string GenerateRandomNo()
        {
            int _min = 00000;
            int _max = 99999;
            Random _rdm = new Random();
            return _rdm.Next(_min, _max)+"";
        }

    }
}

