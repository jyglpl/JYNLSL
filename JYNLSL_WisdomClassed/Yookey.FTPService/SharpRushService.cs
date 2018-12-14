using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Timers;
using System.Configuration;

namespace Yookey.FTPService
{
    partial class SharpRushService : ServiceBase
    {
        Timer _timer = new Timer();
        public SharpRushService()
        {
            InitializeComponent();
            _timer.Elapsed += new ElapsedEventHandler(_timer_Elapsed);
        }

        void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (ScanJob())
            {
                DoJob();
            }
        }

        protected override void OnStart(string[] args)
        {
            // TODO: 在此处添加代码以启动服务。

            _timer.Interval = Convert.ToInt32(ConfigurationManager.AppSettings["TimerInterval"].ToString());
            _timer.Start();
        }

        protected override void OnStop()
        {
            // TODO: 在此处添加代码以执行停止服务所需的关闭操作。

            _timer.Stop();
        }

        public bool ScanJob()
        {

            return true;
        }

        public void DoJob()
        {
            ExecuteManager ExecuteM = new ExecuteManager();
            ExecuteM.Transfer();

        }                     
    }
}
