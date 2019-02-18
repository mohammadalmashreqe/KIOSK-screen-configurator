using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace KIOSKScreenConfigurator
{
    static class Program
    {
     
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {   Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (!File.Exists(Directory.GetCurrentDirectory() + @"\FIrstTimeCheck.txt"))
            {

                StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + @"\FIrstTimeCheck.txt", true);
                sw.Write("T");
                sw.Close();
            }
            StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + @"\FIrstTimeCheck.txt");

            string content = sr.ReadLine();
            sr.Close();
            if (content=="T")
            {
                StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + @"\FIrstTimeCheck.txt");
                sw.Write("F");
                sw.Close();

                Application.Run(new KIOSKScreenConfigurator.presentation_layer.Config());

            }
            else 
                                                       Application.Run(new Form1());
        }
        public static bool firstime = true;
    }
}
