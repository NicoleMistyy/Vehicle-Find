﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace VehicleFind.Services.Interfaces
{
    public interface IDatabaseService
    {
        /// <summary>
        /// Creates the database if it doesn't exist
        /// </summary>
        /// <returns></returns>
        Task<bool> CreateDatabase();
    }
}