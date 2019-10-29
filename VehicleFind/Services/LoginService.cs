using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using VehicleFind.Entities.DatabaseContext;

namespace VehicleFind.Services
{
    public static class LoginService
    {
        public static bool LoginCheck(string Email, string Password)
        {
            var dbFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var fileName = "VehicleFind.db";
            var dbFullPath = Path.Combine(dbFolder, fileName);
            try
            {
                using (var db = new DatabaseContext(dbFullPath))
                {
                    var findUser = db.User.Where(u => u.Email == Email && u.Password == Password).FirstOrDefault();
                    if (findUser != null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }               
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                return false;
            }
        }
    }
}