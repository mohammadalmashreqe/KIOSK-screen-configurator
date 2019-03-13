    namespace BusinessLayer
    {
    using System;
    using System.Data;
        using System.Data.SqlClient;
    using System.IO;
    using System.Windows.Forms;

    /// <summary>
    /// Defines the Identification_type
    /// </summary>
    public enum Identification_type
        {
            /// <summary>
            /// Defines the card
            /// </summary>
            card,

            /// <summary>
            /// Defines the mobile
            /// </summary>
            mobile
        };

        /// <summary>
        /// Defines the <see cref="Request_identification" />
        /// </summary>
        public class Request_identification : Activity
        {
            /// <summary>
            /// Defines the _type
            /// </summary>
            Identification_type _type;
     
            /// <summary>
            /// Defines the _is_mandatory
            /// </summary>
            bool _is_mandatory;

            /// <summary>
            /// Initializes a new instance of the <see cref="Request_identification"/> class.
            /// </summary>
            /// <param name="m">The m<see cref="string"/></param>
            /// <param name="t">The t<see cref="Identification_type"/></param>
            /// <param name="im">The im<see cref="bool"/></param>
            public Request_identification(string m, Identification_type t, bool im) : base(m)
            {
                _type = t;
                _is_mandatory = im;
            }

            /// <summary>
            /// Gets or sets the type
            /// </summary>
            public Identification_type type
            {

                set
                {
                    _type = value;
                }

                get
                {
                    return _type;
                }
            }

            /// <summary>
            /// Gets or sets a value indicating whether is_mandatory
            /// </summary>
            public bool is_mandatory
            {
                set
                {
                    _is_mandatory = value;
                }
                get
                {
                    return _is_mandatory;
                }
            }

            /// <summary>
            /// The getIdentificationType
            /// </summary>
            /// <returns>The <see cref="string"/></returns>
            private string getIdentificationType()
            {
            try
            {
                if (_type == Identification_type.card)
                    return "card";
                else
                    return "mobile";
            }
            catch (Exception ex)
            {
                StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + @"\LogFile.txt", true);
                sw.WriteLine(DateTime.Now);
                sw.WriteLine("message : ");
                sw.WriteLine("");
                sw.WriteLine("");
                sw.WriteLine(ex.Message);
                sw.WriteLine("------------------------------------------------------------------------------------");
                sw.WriteLine("");
                sw.WriteLine("");
                sw.WriteLine("stack trace :");
                sw.WriteLine("");
                sw.WriteLine("");
                sw.WriteLine(ex.StackTrace);
                sw.WriteLine("------------------------------------------------------------------------------------");
                sw.WriteLine("");
                sw.WriteLine("");

                MessageBox.Show("exception : " + Environment.NewLine + ex.Message + Environment.NewLine + Environment.NewLine + "for more info : " + Directory.GetCurrentDirectory() + @"\LogFile.txt", "exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sw.Close();
                throw ex;

            }
        }

            /// <summary>
            /// The getRequestActivity
            /// </summary>
            /// <param name="val">The val<see cref="int"/></param>
            /// <returns>The <see cref="DataTable"/></returns>
            public static DataTable getRequestActivity(int val)
            {
            try
            {
                SqlParameter[] p = new SqlParameter[1];
                p[0] = new SqlParameter("@_butId", val);
                DataAccessLayer dal = DataAccessLayer.getConInstance();
                dal.Open();

                return dal.SelectData("getRequestTickActivity", p);
            }
            catch (Exception ex)
            {
                StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + @"\LogFile.txt", true);
                sw.WriteLine(DateTime.Now);
                sw.WriteLine("message : ");
                sw.WriteLine("");
                sw.WriteLine("");
                sw.WriteLine(ex.Message);
                sw.WriteLine("------------------------------------------------------------------------------------");
                sw.WriteLine("");
                sw.WriteLine("");
                sw.WriteLine("stack trace :");
                sw.WriteLine("");
                sw.WriteLine("");
                sw.WriteLine(ex.StackTrace);
                sw.WriteLine("------------------------------------------------------------------------------------");
                sw.WriteLine("");
                sw.WriteLine("");

                MessageBox.Show("exception : " + Environment.NewLine + ex.Message + Environment.NewLine + Environment.NewLine + "for more info : " + Directory.GetCurrentDirectory() + @"\LogFile.txt", "exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sw.Close();
                throw ex;

            }
        }

            /// <summary>
            /// The AddRequestActivity
            /// </summary>
            /// <param name="bt_id">The bt_id<see cref="int"/></param>
            /// <returns>The <see cref="bool"/></returns>
            public bool AddRequestActivity(int bt_id)
            {
            try
            {
                DataAccessLayer dal = DataAccessLayer.getConInstance();
                dal.Open();
                SqlParameter[] p3 = new SqlParameter[5];

                p3[0] = new SqlParameter("@_but_id", bt_id);
                p3[1] = new SqlParameter("@_type", "Request_identification");
                p3[2] = new SqlParameter("@_info_msg", Information_message);
                p3[3] = new SqlParameter("@_Identification_type", getIdentificationType());

                p3[4] = new SqlParameter("@_Is_mandatory", is_mandatory);


                if (dal.myExcute("Add_activity_request", p3))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + @"\LogFile.txt", true);
                sw.WriteLine(DateTime.Now);
                sw.WriteLine("message : ");
                sw.WriteLine("");
                sw.WriteLine("");
                sw.WriteLine(ex.Message);
                sw.WriteLine("------------------------------------------------------------------------------------");
                sw.WriteLine("");
                sw.WriteLine("");
                sw.WriteLine("stack trace :");
                sw.WriteLine("");
                sw.WriteLine("");
                sw.WriteLine(ex.StackTrace);
                sw.WriteLine("------------------------------------------------------------------------------------");
                sw.WriteLine("");
                sw.WriteLine("");

                MessageBox.Show("exception : " + Environment.NewLine + ex.Message + Environment.NewLine + Environment.NewLine + "for more info : " + Directory.GetCurrentDirectory() + @"\LogFile.txt", "exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sw.Close();
                throw ex;

            }
        }

            /// <summary>
            /// The deleteActivity
            /// </summary>
            /// <param name="id">The id<see cref="string"/></param>
            /// <returns>The <see cref="bool"/></returns>
            public static bool deleteActivity(string id)
            {
            try
            {

                DataAccessLayer dal = DataAccessLayer.getConInstance();
                dal.Open();


                SqlParameter[] p = new SqlParameter[1];
                p[0] = new SqlParameter("@_activity_id", id);

                return dal.myExcute("deleteRequestActivity", p);
            }
            catch (Exception ex)
            {
                StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + @"\LogFile.txt", true);
                sw.WriteLine(DateTime.Now);
                sw.WriteLine("message : ");
                sw.WriteLine("");
                sw.WriteLine("");
                sw.WriteLine(ex.Message);
                sw.WriteLine("------------------------------------------------------------------------------------");
                sw.WriteLine("");
                sw.WriteLine("");
                sw.WriteLine("stack trace :");
                sw.WriteLine("");
                sw.WriteLine("");
                sw.WriteLine(ex.StackTrace);
                sw.WriteLine("------------------------------------------------------------------------------------");
                sw.WriteLine("");
                sw.WriteLine("");

                MessageBox.Show("exception : " + Environment.NewLine + ex.Message + Environment.NewLine + Environment.NewLine + "for more info : " + Directory.GetCurrentDirectory() + @"\LogFile.txt", "exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sw.Close();
                throw ex;

            }
        }
        }
    }
