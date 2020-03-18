using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace YandexTranslator
{
    class YandexTranslate
    {
        public string Translate_(string s, string lang)
        {
            Console.WriteLine(s);
            if (s.Length > 0)
            {
                WebRequest request = WebRequest.Create("https://translate.yandex.net/api/v1.5/tr.json/translate?"
                    + "key=trnsl.1.1.20200314T062422Z.2990dbe8793bd109.598c95d78c572b86ae633cfbeaa1d9e7379180ef"
                    + "&text=" + s
                    + "&lang=" + lang);

                WebResponse response = request.GetResponse();

                using (StreamReader stream = new StreamReader(response.GetResponseStream()))
                {
                    string line;

                    Console.WriteLine();
                    if ((line = stream.ReadLine()) != null)
                    {
                        Translation translation = JsonConvert.DeserializeObject<Translation>(line);

                        s = "";

                        foreach (string str in translation.text)
                        {
                            s += str;
                        }
                    }
                }
                Console.WriteLine(s);
                return s.ToString();
            }
            else
                return "";
        }
    }
    class Translation
    {
        public string[] text { get; set; }
    }
}
