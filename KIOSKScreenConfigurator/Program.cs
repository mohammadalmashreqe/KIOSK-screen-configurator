using KIOSKScreenConfigurator.presentation_layer;

namespace KIOSKScreenConfigurator
{
    using BusinessLayer;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Windows.Forms;

    /// <summary>
    /// Defines the <see cref="Program" />
    /// </summary>
    static class Program
    {
        /// <summary>
        /// Defines the myListPrint
        /// </summary>
        public static List<PrintTicketType> MyListPrint = new List<PrintTicketType>();

        /// <summary>
        /// Defines the myListConfirm
        /// </summary>
        public static List<ConfirmationActivity> MyListConfirm = new List<ConfirmationActivity>();

        /// <summary>
        /// Defines the myList-request
        /// </summary>
        public static List<RequestIdentification> MyListrequest = new List<RequestIdentification>();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
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

            if (content == "T")
            {


                Application.Run(new Config());

            }
            else
            {
                DataAccessLayer.GetConInstance();
                Application.Run(new Form1());
            }
        }
    }
}
