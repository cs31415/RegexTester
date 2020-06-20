using System;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace RegexTester
{
    /// <summary>
    /// Persist UI settings between app runs
    /// </summary>
    public class SettingsManager<T>
    {
        readonly string _settingsFileName;
        private readonly Action<T> _onLoadSettings;
        private readonly Func<T> _onSaveSettings;

        public SettingsManager(Action<T> onLoadSettings, Func<T> onSaveSettings)
        {
            _onLoadSettings = onLoadSettings;
            _onSaveSettings = onSaveSettings;
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            _settingsFileName = $@"{path}\settings.txt";
        }

        public void LoadSettings()
        {
            if (!File.Exists(_settingsFileName))
                return;

            var settingsText = File.ReadAllText(_settingsFileName);
            var settings = JsonConvert.DeserializeObject<T>(settingsText);
            if (settings != null)
            {
                _onLoadSettings(settings);
            }
        }

        public void SaveSettings()
        {
            var settings = _onSaveSettings();
            File.WriteAllText(_settingsFileName, JsonConvert.SerializeObject(settings));
        }
    }
}