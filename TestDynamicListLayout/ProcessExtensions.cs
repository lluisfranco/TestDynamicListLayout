using System.Diagnostics;

namespace TestDynamicListLayout
{
    public static class ProcessExtensions
    {
        public static void Open(string processStartInfo)
        {
            var p = new Process
            {
                StartInfo = new ProcessStartInfo(processStartInfo)
                {
                    UseShellExecute = true
                }
            };
            p.Start();
        }
    }
}
