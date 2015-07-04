using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using Windows.Storage;

namespace BandsInTown.Helpers.BackgroundTask
{
    public static class BackgroundTaskConfiguration
    {
        //register the Timer Trigger Task
        public static async Task<BackgroundTaskRegistration> RegisterBackgroundTask(String taskEntryPoint, String name, IBackgroundTrigger trigger, IBackgroundCondition condition)                                                                     
        {
            BackgroundAccessStatus accessStatus = await BackgroundExecutionManager.RequestAccessAsync();
            BackgroundTaskRegistration task = null;

            if (accessStatus != BackgroundAccessStatus.Denied)
            {
                var builder = new BackgroundTaskBuilder { Name = name, TaskEntryPoint = taskEntryPoint };

                builder.SetTrigger(trigger);

                if (condition != null)
                {
                    builder.AddCondition(condition);
                    //
                    // If the condition changes while the background task is executing then it will
                    // be canceled.
                    //
                    builder.CancelOnConditionLoss = true;
                }

                task = builder.Register();

                // Remove previous completion status from local settings.
                //
                var settings = ApplicationData.Current.LocalSettings;
                settings.Values.Remove(name);
            }
            else
            {
                Debug.WriteLine("Background access denied");
            }

            return task;
        }

        //unregister the background task
        public static void UnregisterBackgroundTasks(string name)
        {
            //
            // Loop through all background tasks and unregister any with SampleBackgroundTaskName or
            // SampleBackgroundTaskWithConditionName.
            //
            foreach (var cur in BackgroundTaskRegistration.AllTasks.Where(cur => cur.Value.Name == name))
            {
                cur.Value.Unregister(true);
            }
        }
    }
}
