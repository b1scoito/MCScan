using System;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Diagnostics;

namespace MCScan.ScanHandler
{
    class ScanText
    {
        static WebClient wc = new WebClient();
        static WebProxy wp = new WebProxy();
        private static Random random = new Random();
        public static string strings;
        static Logger dummy = new Logger();

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static string pegapid(string processo)
        {
            string pid = Process.GetProcessesByName(processo)[0].Id.ToString();
            return pid;
        }
        public static void PuxarStrings(string processo)
        {
            string path = Path.Combine(Path.GetTempPath(), "strings2.exe");
            strings = Path.Combine(Path.GetTempPath(), RandomString(5) + ".string");
            string pid = Process.GetProcessesByName(processo)[0].Id.ToString();
            File.WriteAllBytes(path, Properties.Resources.strings2);
            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = "cmd",
                    Arguments = "/C" + path + " -nh -pid " + pid + " > " + strings
                }
            };
            proc.Start();
            proc.WaitForExit();
        }
        public static void deldir()
        {
            if (File.Exists(strings)) File.Delete(strings);
        }
        public static void SText(string type, string url, bool antifiddler, bool verboselog)
        {
            Console.OutputEncoding = Encoding.UTF8;
            #region antifiddler
            if (antifiddler)
            {
                wc.Proxy = wp;
                wc.Encoding = Encoding.UTF8;
            }
            else if (!antifiddler)
            {
                wc.Proxy = null;
                wc.Encoding = Encoding.UTF8;
            }
            else
            {
                dummy.Error("AntiFiddler: Erro Desconhecido.");
            }

            #endregion
            bool checkurl = Uri.TryCreate(url, UriKind.Absolute, out Uri uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
            if (!checkurl)
            {
                dummy.Error("URL Invalida.");
                return;
            }
            if (type == "javaw")
            {
                Process[] pname = Process.GetProcessesByName("javaw");
                if (pname.Length == 0)
                {
                    dummy.Warning("Processo javaw nao encontrado");
                    return;
                }
                dummy.Success("Coletando strings do javaw [" + pegapid("javaw") + "]");
                PuxarStrings("javaw");
                using (Stream stream = wc.OpenRead(url))
                {
                    using (StreamReader streamReader = new StreamReader(stream))
                    {
                        string linha;
                        while ((linha = streamReader.ReadLine()) != null)
                        {
                            string value = linha.Split(new char[]
                            {
                                'ø'
                            })[0];
                            string str = linha.Split(new char[]
                            {
                                'ø'
                            })[1];
                            if (verboselog)
                            {
                                dummy.Info("Testando client: " + str);
                            }
                            string final = File.ReadAllText(strings);
                            if (final.Contains(value))
                            {
                                dummy.Error("Client Encontrado: " + str);
                                deldir();
                                break;
                            }
                        }
                    }
                }
            }
            else if (type == "explorer")
            {
                Process[] pname = Process.GetProcessesByName("explorer");
                if (pname.Length == 0)
                {
                    dummy.Warning("Processo nao encontrado");
                    return;
                }
                dummy.Success("Coletando strings do explorer [" + pegapid("explorer") + "]");
                PuxarStrings("explorer");
                using (Stream stream = wc.OpenRead(url))
                {
                    using (StreamReader streamReader = new StreamReader(stream))
                    {
                        string linha;
                        while ((linha = streamReader.ReadLine()) != null)
                        {
                            string value = linha.Split(new char[]
                            {
                                'ø'
                            })[0];
                            string str = linha.Split(new char[]
                            {
                                'ø'
                            })[1];
                            if (verboselog)
                            {
                                dummy.Info("Testando client: " + str);
                            }
                            string final = File.ReadAllText(strings);
                            if (final.Contains(value))
                            {
                                dummy.Error("Client Encontrado: " + str);
                                deldir();
                                break;
                            }
                        }
                    }
                }
            }
            else if (type == "lsass")
            {
                Process[] pname = Process.GetProcessesByName("lsass");
                if (pname.Length == 0)
                {
                    dummy.Warning("Processo lsass nao encontrado");
                    return;
                }
                dummy.Success("Coletando strings do lsass [" + pegapid("lsass") + "]");
                PuxarStrings("lsass");
                using (Stream stream = wc.OpenRead(url))
                {
                    using (StreamReader streamReader = new StreamReader(stream))
                    {
                        string linha;
                        while ((linha = streamReader.ReadLine()) != null)
                        {
                            string value = linha.Split(new char[]
                            {
                                'ø'
                            })[0];
                            string str = linha.Split(new char[]
                            {
                                'ø'
                            })[1];
                            if (verboselog)
                            {
                                dummy.Info("Testando client: " + str);
                            }
                            string final = File.ReadAllText(strings);
                            if (final.Contains(value))
                            {
                                dummy.Error("Client Encontrado: " + str);
                                break;
                            }
                        }
                    }
                }
            }
            else
            {
                dummy.Error("Tipo Incorreto!");
            }
        }
    }
}
