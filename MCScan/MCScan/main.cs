using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using MCScan.ScanHandler;
namespace MCScan
{
    class main
    {
        public static double ConvertMillisecondsToMinutes(double milliseconds)
        {
            return TimeSpan.FromMilliseconds(milliseconds).TotalMinutes;
        }
        static void Main(string[] args)
        {
            new Logger().ASCII("MCScan 1.0.0");
            Logger dummy = new Logger();
            dummy.Success("Escanenado");
            var watch = Stopwatch.StartNew();
            ScanText.SText("javaw", "https://exemplo.com/MCScan/lsass.txt", true, false);
            ScanText.SText("explorer", "https://exemplo.com/MCScan/lsass.txt", true, false);
            ScanText.SText("lsass", "https://exemplo.com/MCScan/lsass.txt", true, false);
            watch.Stop();
            var elapsedMs = watch.Elapsed;
            string lol = string.Format("{0}:{1}", Math.Floor(elapsedMs.TotalMinutes), elapsedMs.ToString("ss\\."));
            dummy.Success("Scan terminado, tempo decorrido: " + lol);
            if (File.Exists(Path.GetTempPath() + "strings2.exe")) File.Delete(Path.GetTempPath() + "strings2.exe");
            DirectoryInfo di = new DirectoryInfo(Path.GetTempPath());
            FileInfo[] files = di.GetFiles("*.string").Where(p => p.Extension == ".string").ToArray();
            foreach (FileInfo file in files)
                try
                {
                    file.Attributes = FileAttributes.Normal;
                    File.Delete(file.FullName);
                }
                catch
                {
                    dummy.Error("Erro ao deletar ultimos arquivos.");
                }
            Console.ReadKey();
        }
    }
}