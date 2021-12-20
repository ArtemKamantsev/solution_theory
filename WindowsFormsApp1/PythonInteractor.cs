using System.Diagnostics;
using System.IO;
using System.Text;

namespace WindowsFormsApp1
{
    public class PythonInteractor
    {
        public static string ReadPyhonFile(string methodName, StringBuilder data)
        {
            ProcessStartInfo start = new ProcessStartInfo();

            string curDir = Directory.GetCurrentDirectory();
            start.FileName = curDir + @"\core\dist\api.exe";

            start.UseShellExecute = false;
            start.RedirectStandardInput = true;
            start.RedirectStandardOutput = true;
            start.CreateNoWindow = true;
            start.WindowStyle = ProcessWindowStyle.Hidden;
            using (Process process = Process.Start(start))
            {
                StreamWriter writer = process.StandardInput;
                writer.WriteLine(methodName);
                writer.WriteLine(data);
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadLine();
                    return result;
                }
            }
        }
    }
}