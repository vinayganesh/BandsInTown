using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace BandSettings
{
    public sealed class SettingsHelper
    {
        private static readonly object Locker = new object();
        public static T ParseEnum<T>(string k)
        {
            lock (Locker)
            {
                var settings = ApplicationData.Current.LocalSettings;
                var v = settings.Values[k];
                if (v == null)
                    return default(T);

                return (T)Enum.Parse(typeof(T), v.ToString());
            }
        }

        public static void SetValue<T>(string k, T v)
        {
            try
            {
                lock (Locker)
                {
                    var settings = ApplicationData.Current.LocalSettings;
                    settings.Values[k] = v;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Can't set settings value for '{0}': {1}", k, ex);
            }
        }

        public static T GetValue<T>(string k)
        {
            lock (Locker)
            {
                var settings = ApplicationData.Current.LocalSettings;
                var v = settings.Values[k];
                if (v == null)
                    return default(T);
                try
                {
                    return (T)v;
                }
                catch (InvalidCastException)
                {
                    Debug.WriteLine("Can't get settings value for '{0}'", k);
                    return default(T);
                }
            }
        }
    }
}
