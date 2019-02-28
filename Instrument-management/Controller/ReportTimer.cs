using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Timers;

namespace InM
{
    class ReportTimer
    {
        List<ProcessLogModel> processLog = new List<ProcessLogModel>();
        List<ProcessLogModel> processExitedLog = new List<ProcessLogModel>();
        List<string> logList = new List<string>();
        public void Start()
        {
            Timer timerRefreshProcess = new Timer(2000);
            timerRefreshProcess.Elapsed += TimerRefreshProcess_Elapsed;
            timerRefreshProcess.Enabled = true;
            Timer timerUploadProcess = new Timer(10000);
            timerUploadProcess.Elapsed += TimerUploadProcess_Elapsed;
            timerUploadProcess.Enabled = true;
        }

        private void TimerRefreshProcess_Elapsed(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("tiktok");
            Process[] processes = Process.GetProcesses();
            DateTime nowTime = DateTime.Now;
            // 取当前与监控列表的并集
            IEnumerable<string> currentList = from x in processes
                                                  where SharedData.processList.Contains(x.ProcessName)
                                              select x.ProcessName;
            logList = (from x in processLog select x.name).ToList();
            // 一共会出现三种情况：
            // 1. 只在当前：新打开
            currentList.Except(logList)
                .ToList()
                .ForEach(x =>
                {
                    processLog.Add(new ProcessLogModel()
                    {
                        name = x,
                        start = nowTime
                    });
                });
            // 2. 两边都在：更新last时间
            (from x in processLog where currentList.Intersect(logList).Contains(x.name) select x)
                .ToList()
                .ForEach(x => x.last = nowTime);
            // 3. 只在log：程序已退出
            var q3 = from x in processLog where logList.Except(currentList).Contains(x.name) select x;
            processExitedLog.AddRange(q3);
            processLog.RemoveAll(x => q3.ToList().Contains(x));
        }

        private void TimerUploadProcess_Elapsed(object sender, ElapsedEventArgs e)
        {
            string json = JsonConvert.SerializeObject(processLog.Concat(processExitedLog));
            Console.WriteLine(json);

            processExitedLog.Clear();
        }
    }
}
