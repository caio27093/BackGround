using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AppBackGround.Droid.Implementations;
using AppBackGround.Droid.Services;
using AppBackGround.Services;
using Java.Lang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

[assembly: Xamarin.Forms.Dependency(typeof(ForegroundServiceImplementation))]
namespace AppBackGround.Droid.Implementations
{
    public class ForegroundServiceImplementation : IForegroundService
    {
        private readonly Context _context;
        private readonly Intent _serviceIntent;
        public ForegroundServiceImplementation()
        {
            _context = Android.App.Application.Context;
            _serviceIntent = new Intent(_context, typeof(BackgroundService));
        }
        public ForegroundServiceImplementation(Context context)
        {
            _context = context;
            _serviceIntent = new Intent(_context, typeof(BackgroundService));
        }

        public void StartService()
        {
            _context.StartForegroundService(_serviceIntent);
            //_context.StartService(_serviceIntent);
        }

        public void StopService()
        {
            _context.StopService(_serviceIntent);
        }
    }
}