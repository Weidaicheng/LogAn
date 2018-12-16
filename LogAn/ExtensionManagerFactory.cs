namespace LogAn
{
    public class ExtensionManagerFactory
    {
        private static IExtensionManager customManager = null;

        public static IExtensionManager Create()
        {
            if (customManager != null)
                return customManager;

            return new FileExtensionManager();
        }

#if DEBUG
        public static void SetManager(IExtensionManager mgr)
        {
            customManager = mgr;
        }
#endif
    }
}
