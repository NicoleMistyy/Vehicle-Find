using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using Android;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.Content;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using VehicleFind.Entities.DatabaseContext;
using Xamarin.Essentials;

namespace VehicleFind
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = false)]
    public class MainActivity : AppCompatActivity
    {


        List<String> ID;
        List<String> Name;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);


            Name = new List<String>();
            ID = new List<String>();

            var dbFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var fileName = "VehicleFind.db";
            var dbFullPath = Path.Combine(dbFolder, fileName);
            try
            {
                using (var db = new DatabaseContext(dbFullPath))
                {
                    var models = db.Models.ToList();
                    foreach (var item in models)
                    {
                        Name.Add((string)item.Name);
                        ID.Add((string)item.Id.ToString());
                    }
                }

                Spinner spinner = FindViewById<Spinner>(Resource.Id.spinner);

                var adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, Name);

                spinner.Adapter = adapter;
                spinner.ItemSelected += Spinner1_ItemSelected;

            }
            catch (Exception ex)
            {
            }

            try
            {
                SetContentView(Resource.Layout.activity_main);
            }
            catch (Exception ex)
            {

            }
        }



        private void Spinner1_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            int position = Convert.ToInt16(ID[e.Position].ToString());
            var dbFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var fileName = "VehicleFind.db";
            var dbFullPath = Path.Combine(dbFolder, fileName);
            try
            {
                using (var db = new DatabaseContext(dbFullPath))
                {
                    var model = db.Models.Where(m => m.Id == position).FirstOrDefault();
                    var specificationsList = db.Specifications.Where(s => s.ModelId == model.Id);

                    TextView textView = FindViewById<TextView>(Resource.Id.brand);
                    textView.Text += "Brand: " + model.Name + System.Environment.NewLine;
                    textView.Text += "Range: " + model.Name + System.Environment.NewLine;

                    foreach (var spec in specificationsList)
                    {
                        textView.Text += $"{spec.Name}: {spec.Value}" + System.Environment.NewLine;
                    }
                }




            }
            catch (Exception ex)
            {

            }


        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        async void OnButtonClicked(object sender, EventArgs args)
        {
            string locationResult = "";

            if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.AccessFineLocation) == Permission.Granted)
            {
                //Configure the gps
                var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                var location =  Geolocation.GetLocationAsync(request);
                if (location != null)
                {
                    locationResult = location.Result.Longitude.ToString() + "," + location.Result.Latitude.ToString();
                }
            }
            else
            {
                // The app does not have permission ACCESS_FINE_LOCATION 
            }

            //Retrieve cross page shared data
            var userEmail = Intent.GetStringExtra("user");

            SendEmail(locationResult, userEmail);
        }

        private void SendEmail(string LocationResult, string Email)
        {

            string subject = "Vehicle Enquiry";
            string body = "";
            Spinner spinner = FindViewById<Spinner>(Resource.Id.spinner);

            long selectedItem = spinner.SelectedItemId;

            var dbFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var fileName = "VehicleFind.db";
            var dbFullPath = Path.Combine(dbFolder, fileName);
            try
            {
                using (var db = new DatabaseContext(dbFullPath))
                {
                    var user = db.User.Where(u => u.Email == Email).FirstOrDefault();
                    var vehicle = db.Models.Where(m => m.Id == selectedItem).FirstOrDefault();

                    body = body + "<p style=\"font-size:13px;\"> The following person " + user.FirstName + " is making an enquiry about the below vehicle</p></br>";  

                    body = body + "<p style=\"font-size:13px;\">Name:" + vehicle.Name + "</p></br>";
                    body = body + "<p style=\"font-size:13px;\">Name:" + vehicle.Range + "</p></br>";

                    foreach (var item in vehicle.Specifications)
                    {
                        body = body + "<p style=\"font-size:13px;\">" + item.Name + ": " + item.Value + "</p></br>";
                    }
                }

            }
            catch (Exception ex)
            {

            }


            try
            {
                var mail = new MailMessage();
                var smtpServer = new SmtpClient("smtp.gmail.com", 587);
                mail.From = new MailAddress("myEmailAddress@gmail.com");
                mail.To.Add(Email);
                mail.Subject = subject;
                mail.Body = body;
                smtpServer.Credentials = new NetworkCredential("username", "pass");
                smtpServer.UseDefaultCredentials = false;
                smtpServer.EnableSsl = true;
                smtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);

            }
        }
    }
}

