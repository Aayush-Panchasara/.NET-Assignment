using System;
using System.Collections.Generic;
using System.Text;

namespace OOPS_Day4
{
    public class FileLog
    {
        string filePath;
        public FileLog(string filePath)
        {
            this.filePath = filePath;
        }

        public void Log(string message)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(filePath, append: true))
                {
                    string logMessage = $"{DateTime.Now} : {message}";
                    sw.WriteLine(logMessage);
                }
                //File automatically close here.
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e.Message}");
            }
        }
    }
    internal class IDisposable
    {
        public static void Main()
        {
            FileLog f1 = new FileLog("log.txt"); //These file is located at Day-10\OOPS-Day4\bin\Debug\net10.0
            f1.Log("Hello");
            f1.Log("How are you?");
            f1.Log("Good Morinig");

            Console.WriteLine("Logging is completed.");
        }
    }
}
