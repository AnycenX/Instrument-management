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
    public class ReportUploadArgs
    {
        public ReportUploadArgs(IEnumerable<ProcessUplogModel> processUplogModelsIn)
        {
            processUplogModels = processUplogModelsIn;
        }
        public IEnumerable<ProcessUplogModel> processUplogModels;
    }
    public class ReportTimer
    {
        List<ProcessUplogModel> processLog = new List<ProcessUplogModel>();
        List<ProcessUplogModel> processExitedLog = new List<ProcessUplogModel>();
        List<string> logList = new List<string>();

        Timer timerRefreshProcess;
        Timer timerUploadProcess;

        public delegate void ReportUploadHandler(object sender, ReportUploadArgs e);
        public event ReportUploadHandler ReportUpload;

        public void Start()
        {
            timerRefreshProcess = new Timer(2000);
            timerRefreshProcess.Elapsed += TimerRefreshProcess_Elapsed;
            timerRefreshProcess.Enabled = true;
            timerUploadProcess = new Timer(10000);
            timerUploadProcess.Elapsed += TimerUploadProcess_Elapsed;
            timerUploadProcess.Enabled = true;
        }

        public void Stop()
        {
            timerRefreshProcess.Stop();
            timerUploadProcess.Stop();
            processLog.Clear();
            processExitedLog.Clear();
            logList.Clear();
        }

        private void TimerRefreshProcess_Elapsed(object sender, ElapsedEventArgs e)
        {
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
                    processLog.Add(new ProcessUplogModel()
                    {
                        name = x,
                        friendlyName = (from y in SharedData.processInfo where y.process == x select y.name)?.First() ?? "",
                        start = nowTime
                    });
                });
            // 2. 两边都在：更新last时间
            (from x in processLog where currentList.Intersect(logList).Contains(x.name) select x)
                .ToList()
                .ForEach(x => x.stop = nowTime);
            // 3. 只在log：程序已退出
            var q3 = from x in processLog where logList.Except(currentList).Contains(x.name) select x;
            processExitedLog.AddRange(q3);
            processLog.RemoveAll(x => q3.ToList().Contains(x));
        }

        private void TimerUploadProcess_Elapsed(object sender, ElapsedEventArgs e)
        {
            ReportUpload?.Invoke(this, new ReportUploadArgs(processLog.Concat(processExitedLog)));
            processExitedLog.Clear();
        }
    }
}
