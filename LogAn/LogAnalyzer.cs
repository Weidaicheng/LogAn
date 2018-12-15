using System;

namespace LogAn
{
    public class LogAnalyzer
    {
        private IExtensionManager _manager;

        public LogAnalyzer()
        {
            _manager = new FileExtensionManager();
        }

        public bool WasLastFileNameValid { get; set; }

        public IExtensionManager ExtensionManager
        {
            get
            {
                return _manager;
            }
            set
            {
                _manager = value;
            }
        }

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
