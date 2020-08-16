using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Console = Colorful.Console;
using System.Runtime.CompilerServices;

namespace HypeSquadChanger
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.SetWindowSize(132, 30);
            Console.Title = "HypeSquadChanger";

            Console.WriteLine("Bienvenu Sur Le HypeSquadChanger !", Color.Pink);
            Console.WriteLine("Custom Command = Credit", Color.Pink);
            Console.WriteLine("");
            Console.WriteLine(" ________________________________________", Color.MediumSlateBlue);
            Console.WriteLine("|                                        |", Color.MediumSlateBlue);
            Console.WriteLine("| HypeSquadChanger en c#                 |", Color.Plum);
            Console.WriteLine("|                                        |", Color.MediumSlateBlue);
            Console.WriteLine("| Etat du code : Open Source             |", Color.Plum);
            Console.WriteLine("|                                        |", Color.MediumSlateBlue);
            Console.WriteLine("|________________________________________|", Color.Plum);
            Console.WriteLine("");

            Console.WriteLine("Choisis ta maison :");
            Console.WriteLine("");
            Console.WriteLine("[ 1 ] Bravery", Color.Indigo);
            Console.WriteLine("");
            Console.WriteLine("[ 2 ] Brilliance", Color.Red);
            Console.WriteLine("");
            Console.WriteLine("[ 3 ] Balance", Color.LightGreen);
            Console.WriteLine("");

            string input = Console.ReadLine();

            if (input == "Credit")
            {
                Console.Clear();

                Console.WriteLine(" _________________________________________", ColorTranslator.FromHtml("#8AFFEF"));
                Console.WriteLine("|                                         |", ColorTranslator.FromHtml("#8AFFEF"));
                Console.WriteLine("| Code : OpenSource                       |", ColorTranslator.FromHtml("#FAD6FF"));
                Console.WriteLine("| By   : Seryu                            |", ColorTranslator.FromHtml("#B8DBFF"));
                Console.WriteLine("| Github : https://github.com/Seryu-Ub    |", ColorTranslator.FromHtml("#8AFFEF"));
                Console.WriteLine("|                                         |", ColorTranslator.FromHtml("#FAD6FF"));
                Console.WriteLine("| Help by : Zelly                         |", ColorTranslator.FromHtml("#B8DBFF"));
                Console.WriteLine("| Github : https://github.com/ZelliDev    |", ColorTranslator.FromHtml("#8AFFEF"));
                Console.WriteLine("|_________________________________________|", ColorTranslator.FromHtml("#FAD6FF"));
                int DA = 244;
                int V = 212;
                int ID = 255;
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteAscii("CSharp", Color.FromArgb(DA, V, ID));

                    DA -= 18;
                    V -= 36;
                }
                Console.ReadKey();
            }

            string token = "Token_Here"; // <------ Mettre le token ici !!! Token Here !!!

            var Req = (HttpWebRequest)WebRequest.Create($"https://discordapp.com/api/v8/hypesquad/online");
            var postData = "{⍚house_id⍚:" + input + "}";

            var data = Encoding.ASCII.GetBytes(postData.Replace('⍚', '"'));
            string UserAgent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_6) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/84.0.4147.105 Safari/537.36";
            Req.Method = "POST";
            Req.UserAgent = UserAgent;
            Req.ContentType = "application/json";
            Req.Headers.Add("authorization", token);
            Req.ContentLength = data.Length;

            using (var stream = Req.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)Req.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            Console.WriteLine("");
            Console.WriteLine("Maison Hypesquad changé avec succès", Color.Pink);

            Console.ReadKey();
        }
    }
}
