using System;
using System.IO;

namespace BusinessLayer
{
    public class ErrorLogger

    {
    

        public static void ErrorLog(Exception ex)
        {
            try
            {

                StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + @"\LogFile.txt", true);

                sw.WriteLine(DateTime.Now);
                sw.WriteLine("message : ");
                sw.WriteLine("");

                sw.WriteLine(ex.Message);
                sw.WriteLine("------------------------------------------------------------------------------------");
                sw.WriteLine("");

                sw.WriteLine("stack trace :");
                sw.WriteLine("");
                sw.WriteLine("");
                sw.WriteLine(ex.StackTrace);
                sw.WriteLine("------------------------------------------------------------------------------------");

                sw.WriteLine("");


                sw.Flush();
                sw.Close();
            }
            catch (Exception ex2)
            {
                ErrorLog(ex2);
            }
        }
    }
}
