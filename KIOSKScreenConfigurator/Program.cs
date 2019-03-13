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
        public static List<Print_ticket_type> myListPrint = new List<Print_ticket_type>();

        /// <summary>
        /// Defines the myListConfirm
        /// </summary>
        public static List<Confirmation_activity> myListConfirm = new List<Confirmation_activity>();

        /// <summary>
        /// Defines the myListrequest
        /// </summary>
        public static List<Request_identification> myListrequest = new List<Request_identification>();

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


                Application.Run(new KIOSKScreenConfigurator.presentation_layer.Config());

            }
            else
            {
                DataAccessLayer.getConInstance();
                Application.Run(new Form1());
            }
        }
    }
}
