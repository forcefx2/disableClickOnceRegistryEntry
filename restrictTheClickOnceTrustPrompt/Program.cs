using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.IO;

namespace restrictTheClickOnceTrustPrompt
{
    class Program
    {
        static void Main(string[] args)
        {
            Microsoft.Win32.RegistryKey key;
            //key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey("SOFTWARE\\MICROSOFT\\.NETFramework\\Security\\TrustManager\\PromptingLevel");
            //key.SetValue("MyComputer", "AuthenticodeRequired");
            //key.SetValue("LocalIntranet", "AuthenticodeRequired");
            //key.SetValue("Internet", "AuthenticodeRequired");
            //key.SetValue("TrustedSites", "AuthenticodeRequired");
            //key.SetValue("UntrustedSites", "Disabled");
            try
            {
                key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\test");
                //key = Microsoft.Win32.Registry.LocalMachine.SetValue()
                key.SetValue("StringValue", "TestString", RegistryValueKind.String);
                key.SetValue("DWordValue", 42, RegistryValueKind.DWord);
                key.SetValue("MultipleStringValue", new string[] {"One", "Two", "Three"},
                    RegistryValueKind.MultiString);
                key.SetValue("BinaryValue", new byte[] {10, 43, 44, 45, 14, 255}, RegistryValueKind.Binary);
                key.SetValue("StringValue", "The path is %PATH%", RegistryValueKind.String);
                key.Close();
            }
            catch (IOException e)
            {
                // Extract some information from this exception, and then   
                // throw it to the parent method.  
                // From https://docs.microsoft.com/en-us/dotnet/articles/csharp/language-reference/keywords/try-catch
                if (e.Source != null)
                    Console.WriteLine("IOException source: {0}", e.Source);
                throw;
            }



            //More from: /* https://msdn.microsoft.com/en-us/library/k23f0345(v=vs.110).aspx*/

            //    using System;
            //    using Microsoft.Win32;

            //public class Example
            //{
            //    public static void Main()
            //    {
            //        // Delete and recreate the test key.
            //        Registry.CurrentUser.DeleteSubKey("RegistryValueKindExample", false);
            //        RegistryKey rk = Registry.CurrentUser.CreateSubKey("RegistryValueKindExample");

            //        // Create name/value pairs.

            //        // This overload supports QWord (long) values.
            //        rk.SetValue("QuadWordValue", 42, RegistryValueKind.QWord);

            //        // The following SetValue calls have the same effect as using the
            //        // SetValue overload that does not specify RegistryValueKind.
            //        //
            //        rk.SetValue("DWordValue", 42, RegistryValueKind.DWord);
            //        rk.SetValue("MultipleStringValue", new string[] { "One", "Two", "Three" }, RegistryValueKind.MultiString);
            //        rk.SetValue("BinaryValue", new byte[] { 10, 43, 44, 45, 14, 255 }, RegistryValueKind.Binary);
            //        rk.SetValue("StringValue", "The path is %PATH%", RegistryValueKind.String);

            //        // This overload supports setting expandable string values. Compare
            //        // the output from this value with the previous string value.
            //        rk.SetValue("ExpandedStringValue", "The path is %PATH%", RegistryValueKind.ExpandString);


            //        // Display all name/value pairs stored in the test key, with each
            //        // registry data type in parentheses.
            //        //
            //        string[] valueNames = rk.GetValueNames();
            //        foreach (string s in valueNames)
            //        {
            //            RegistryValueKind rvk = rk.GetValueKind(s);
            //            switch (rvk)
            //            {
            //                case RegistryValueKind.MultiString:
            //                    string[] values = (string[])rk.GetValue(s);
            //                    Console.Write("\r\n {0} ({1}) =", s, rvk);
            //                    for (int i = 0; i < values.Length; i++)
            //                    {
            //                        if (i != 0) Console.Write(",");
            //                        Console.Write(" \"{0}\"", values[i]);
            //                    }
            //                    Console.WriteLine();
            //                    break;

            //                case RegistryValueKind.Binary:
            //                    byte[] bytes = (byte[])rk.GetValue(s);
            //                    Console.Write("\r\n {0} ({1}) =", s, rvk);
            //                    for (int i = 0; i < bytes.Length; i++)
            //                    {
            //                        // Display each byte as two hexadecimal digits.
            //                        Console.Write(" {0:X2}", bytes[i]);
            //                    }
            //                    Console.WriteLine();
            //                    break;

            //                default:
            //                    Console.WriteLine("\r\n {0} ({1}) = {2}", s, rvk, rk.GetValue(s));
            //                    break;
            //            }
            //        }
            //    }
            //}
            //*

            //This code example produces the following output:
            // QuadWordValue (QWord) = 42

            // DWordValue (DWord) = 42

            // MultipleStringValue (MultiString) =, "One", "Two", "Three"

            // BinaryValue (Binary) = 0A 2B 2C 2D 0E FF

            // StringValue (String) = The path is %PATH%

            // ExpandedStringValue (ExpandString) = The path is C:\Program Files\Microsoft.NET\SDK\v2.0\Bin;
            // [***The remainder of this output is omitted.***]

            //*/


        }
    }
}
