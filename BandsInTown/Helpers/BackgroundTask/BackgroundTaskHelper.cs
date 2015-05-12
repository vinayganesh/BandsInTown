using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;

namespace BandsInTown.Helpers.BackgroundTask
{
    internal class CommonBackgroundTaskHelper
    {
        private const string EntryPoint = "Backgrounder.TimerTriggerTask";
        private const string TaskName = "TimerTriggerTask";
        private const int TimeInterval = 30; // In minutes.

        public async Task Register()
        {
            BackgroundTaskConfiguration.UnregisterBackgroundTasks(TaskName);

            await BackgroundTaskConfiguration.RegisterBackgroundTask(EntryPoint, TaskName, new TimeTrigger(TimeInterval, false),
                new SystemCondition(SystemConditionType.InternetAvailable));
        }

        public IBackgroundTaskRegistration Task
        {
            get
            {
                return BackgroundTaskRegistration.AllTasks.Select(kv => kv.Value).SingleOrDefault(i => i.Name == TaskName);
            }
        }
    }
}
