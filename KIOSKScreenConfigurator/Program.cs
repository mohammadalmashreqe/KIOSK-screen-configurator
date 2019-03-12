using BusinessLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace KIOSKScreenConfigurator
{
    static class Program
    {
     public static    List<Print_ticket_type> myListPrint = new List<Print_ticket_type>();
        public static List<Confirmation_activity> myListConfirm = new List<Confirmation_activity>();
        public static List<Request_identification> myListrequest = new List<Request_identification>();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {   Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            #region check first run 
            if (!File.Exists(Directory.GetCurrentDirectory() + @"\FIrstTimeCheck.txt"))
            {

                StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + @"\FIrstTimeCheck.txt", true);
                sw.Write("T");
                sw.Close();
            }
            StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + @"\FIrstTimeCheck.txt");

            string content = sr.ReadLine();
            sr.Close();
          
            if (content == "T")
            {


                Application.Run(new KIOSKScreenConfigurator.presentation_layer.Config());

            }
            else
            {
                DAL.DataAccessLayer.getConInstance();
                Application.Run(new Form1());
            }

            #endregion
        }

    }
}
