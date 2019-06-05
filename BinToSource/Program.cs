using System;
using System.IO;
using System.Text;

namespace BinToSource
{
    class Program
    {
        private static readonly string Template = @"namespace {0} 
{{
    partial class R
    {{
        public static readonly byte[] {1} = new byte[]
        {{
{2}
        }};
    }}
}}
";

        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("usage: BinToSource.exe namespace input");
                Environment.Exit(-1);
                return;
            }

            var ns = args[0];
            var input = args[1];

            var property = Path.GetFileName(input).Replace(".", "_");
            var bytesStr = ToBytesString(File.ReadAllBytes(input));
            Console.Write(string.Format(Template, ns, property, bytesStr));
        }

        private static string ToBytesString(byte[] bytes)
        {
            const int newLineBytesCount = 1000;
            var sb = new StringBuilder(bytes.Length * 3 + (bytes.Length / newLineBytesCount) * Environment.NewLine.Length);

            for (var i = 0; i < bytes.Length; i++)
            {
                if (i > 0 && i % newLineBytesCount == 0)
                {
                    sb.Append(Environment.NewLine);
                }
                sb.Append((int)bytes[i]);
                sb.Append(',');
            }

            return sb.ToString();
        }
    }
}
