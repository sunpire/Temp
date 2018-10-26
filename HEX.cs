using System;
using System.Text;

namespace VSCode
{
    class Program
    {
        static void Main(string[] args)
        {
            string rawText = @"\u0002You m\ux04ay only use the Microsoft .NET Core Debugger (vsdbg) with
Visual Studio Code, Visual Studio or Visual Studio for Mac software
to help you develop and test your applications.
-------------------------------------------------------------------
Loaded 'C:\Program Files\dotnet\shared\Microsoft.NETCore.App\2.1.2\System.Private.CoreLib.dll'. Skipped loading symbols. Module is optimized and the debugger option 'Just My Code' is enabled.
Loaded 'D:\新的开发\VSCode\bin\Debug\netcoreapp2.1\VSCode.dll'. Symbols loaded.
Loaded 'C:\Program Files\dotnet\shared\Microsoft.NETCore.App\2.1.2\System.Runtime.dll'. Skipped loading symbols. Module is optimized and the debugger option 'Just My Code' is enabled.
Loaded 'C:\Program Files\dotnet\shared\Microsoft.NETCore.App\2.1.2\System.Console.dll'. Skipped loading symbols. Module is optimized and the debugger option 'Just My Code' is enabled.
Loaded 'C:\Program Files\dotnet\shared\Microsoft.NETCore.App\2.1.2\System.Threading.dll'. Skipped loading symbols. Module is optimized and the debugger option 'Just My Code' is enabled.
Loaded 'C:\Program Files\dotnet\shared\Microsoft.NETCore.App\2.1.2\System.Runtime.Extensions.dll'. Skipped loading symbols. Module is optimized and the debugger option 'Just My Code' is enabled.
Hello World! 0";
            //rawText = @"Loaded 'D:\VSCode\新的开发\VSCode\bin\Debug\netcoreapp2.1\VSCode.dll'. Symbols loaded.";

            byte[] rawData = Encoding.UTF8.GetBytes(rawText);
            StringBuilder sb = new StringBuilder();
            StringBuilder sbTxt = new StringBuilder();

            for (int i = 0; i < rawData.Length; i++)
            {
                sb.Append(rawData[i].ToString("X2"));
                sb.Append(" ");
                if(rawData[i] <= 127)
                {
                    sbTxt.Append((char)rawData[i]);
                    sbTxt.Append("  ");
                }
                else
                {
                    sb.Append(rawData[i+1].ToString("X2"));
                    sb.Append(" ");
                    sb.Append(rawData[i+2].ToString("X2"));
                    sb.Append(" ");
                    sbTxt.Append(  Encoding.UTF8.GetString(new[]{rawData[i], rawData[i+1], rawData[i+2]}) );
                    sbTxt.Append("       ");
                    i += 2;
                }   

                if(i%40==39)
                {
                    sb.AppendLine();
                    sbTxt.AppendLine();
                } 
                
            }

            Console.WriteLine(sb.ToString());
            Console.WriteLine(sbTxt.ToString());
            // int i=0;
            // while(i<10)
            // {
            //     Console.WriteLine($"Hello World! {i}");
            //     i++;
            // }
        }
    }
}
