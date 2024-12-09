using DevExpress.XtraSplashScreen;

namespace TestDynamicListLayout
{
    public static class OverlaySplashScreenHelper
    {
        public static IOverlaySplashScreenHandle ShowProgressPanel(this Control control)
        {
            IOverlaySplashScreenHandle handle;
            if (control.Tag != null) return null;
            handle = SplashScreenManager.ShowOverlayForm(control);            
            control.Tag = handle;
            return handle;
        }

        public static void CloseProgressPanel(this Control control)
        {
            var handle = control.Tag as IOverlaySplashScreenHandle;
            if (handle != null) SplashScreenManager.CloseOverlayForm(handle);
            control.Tag = null;
        }
    }
}
