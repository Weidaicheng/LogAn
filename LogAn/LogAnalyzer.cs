using System;

namespace LogAn
{
    public class LogAnalyzer
    {
        private IExtensionManager _manager;

        public LogAnalyzer(IExtensionManager manager)
        {
            _manager = manager;
        }

        public bool WasLastFileNameValid { get; set; }

        public bool IsValidLogFileName(string fileName)
        {
            try
            {
                return _manager.IsValid(fileName);
            }
            catch
            {
                return false;
            }
        }
    }
}
