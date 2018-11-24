using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Sha1
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = new List<byte[]>(){
                new byte[]{ 01, 01, 0x05, 0x08, 0x0A, 0x12, 0x13, 0x14, 0x15, 0x18, 0xDA } ,
                //new byte[]{ 01, 01, 05, 08, 0x0A, 0x12, 0x13, 0x14, 0x15, 0x18 } ,
            };

            data.ForEach(x => Sha1(x));
            
            Console.ReadKey();
        }
        public static void Sha1(byte[] data)
        {
            PrintMessage(data);
            SHA1 sha = new SHA1CryptoServiceProvider();
            var sign = sha.ComputeHash(data);
            PrintMessage(sign);
        }

        public static void PrintMessage(byte[] buffer)
        {
            var sb = new StringBuilder();
            foreach (var b in buffer)
            {
                sb.Append($"{Convert.ToString(b, 16).PadLeft(2, '0').ToUpper()} ");
            }
            var fc = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{sb}");
            Console.ForegroundColor = fc;
        }
    }
}
