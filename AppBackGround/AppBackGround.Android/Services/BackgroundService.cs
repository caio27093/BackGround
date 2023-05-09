using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace AppBackGround.Droid.Services
{
    [Service(Name = "com.caioapp.BackgroundService", Permission = "android.permission.BIND_JOB_SERVICE")]
    public class BackgroundService : Service
    {
        private bool _isRunning;

        public override void OnCreate()
        {
            base.OnCreate();
        }
        void CreateNotificationChannel()
        {
            if (Build.VERSION.SdkInt < BuildVersionCodes.O)
            {
                // Código para versões anteriores ao Android Oreo
                return;
            }

            var channelName = "Conexao";
            var channelDescription = "Canal para manter conexão";
            var channel = new NotificationChannel("433090452800", channelName, NotificationImportance.Low)
            {
                Description = channelDescription
            };

            var notificationManager = (NotificationManager)GetSystemService(NotificationService);
            notificationManager.CreateNotificationChannel(channel);
        }

        public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
        {
            if (!_isRunning)
            {
                _isRunning = true;

                CreateNotificationChannel();

                // Configure a notificação para ser exibida como serviço em primeiro plano
                var notification = new Notification.Builder(this, "433090452800")
                    .SetContentTitle("My App Background Service")
                    .SetContentText("Estou em execução em segundo plano")
                    //.SetSmallIcon(Resource.Drawable.icon)
                    .SetOngoing(true)
                    .Build();

                // Inicie o serviço em primeiro plano
                StartForeground(1, notification);

                Thread t = new Thread(() =>
                {
                    while (_isRunning)
                    {
                        // Sua lógica aqui
                        Console.WriteLine("Inicio da execução em segundo plano");

                        Thread.Sleep(5000);
                    }
                });
                t.Start();
            }

            // Garante que o serviço continue em execução em segundo plano
            return StartCommandResult.Sticky;
        }
        public override void OnDestroy()
        {
            // Para a lógica do serviço em segundo plano
            _isRunning = false;

            base.OnDestroy();
        }

        //quando o serviço não é vinculado a nenhuma atividade o retorno é nullo
        public override IBinder OnBind(Intent intent)
        {
            return null;
        }
    }
}