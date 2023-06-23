using Blazor.Core.Src;
using BlazorDAL;
using BlazorDAL.Models;
using Microsoft.Extensions.Configuration;
using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace L3Service.Com.Src
{
    public class L3ComService
    {
        readonly System.Timers.Timer timerRead = new();
        readonly int countMinute = 1;//Dakikada 1 okuma isteği.
        
        private void TMR_CYCREAD_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                timerRead.Interval = countMinute == 0 ? 1 * 60 * 1000 : countMinute * 60 * 1000;
                timerRead.Enabled = false;
                CheckL3Database();
            }
            catch { }
            finally
            {
                timerRead.Enabled = true;
            }
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            timerRead.Interval = countMinute == 0 ? 1 * 60 * 1000 : countMinute * 60 * 1000;
            timerRead.Elapsed += TMR_CYCREAD_Elapsed;
            timerRead.Enabled = true;
            return Task.CompletedTask;
        }
        private void CheckL3Database()
        {
            try
            {
                using var db = new Database(ConnectionString.PostGre, DbProviders.PostSql);
                var data = db.Fetch<CustomerOrder>("SELECT * FROM \"CustomerOrder\" LIMIT 5");
                foreach (var item in data)
                {
                    Console.WriteLine(item);
                }
            }
            catch(Exception ex)
            {
                var args = new EvtAlmDto
                {
                    log_description=ex.StackTrace,
                    machine_name=Environment.MachineName,
                };
                FireEventAlarm(this, args);
            }
        }
        private async void FireEventAlarm(object sender, EvtAlmDto eventAlm, [CallerMemberName] string callerName = "", [CallerLineNumber] int lineNumber = 0)
        {
            using var db = new Database(ConnectionString.PostGre, DbProviders.PostSql);
            var evtAlm = new event_alarm
            {
                dati=DateTime.Now,
                log_description=eventAlm.log_description,
                machine_name=eventAlm.machine_name,
                log_method=callerName,
                user_name="L3ComService"

            };
            db.Insert(evtAlm);
        }
        public Task StopAsync(CancellationToken cancellationToken)
        {
            Dispose();
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            try
            {
                timerRead.Enabled = false;
                timerRead?.Dispose();
            }
            catch { }
        }
    }
}
