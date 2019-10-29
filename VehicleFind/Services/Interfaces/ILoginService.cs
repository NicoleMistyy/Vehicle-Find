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

namespace VehicleFind.Services.Interfaces
{
    public interface ILoginService
    {
        /// <summary>
        /// Check if user has login access
        /// </summary>
        /// <param name="Email">User Email</param>
        /// <param name="Password">User Password</param>
        /// <returns></returns>
        bool LoginCheck(string Email, string Password);
    }
}