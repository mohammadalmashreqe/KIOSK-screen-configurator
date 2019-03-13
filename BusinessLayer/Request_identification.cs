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
    public enum IdentificationType
        {
            /// <summary>
            /// Defines the card
            /// </summary>
            Card,

            /// <summary>
            /// Defines the mobile
            /// </summary>
            Mobile
        };

        /// <inheritdoc />
        /// <summary>
        /// Defines the <see cref="T:BusinessLayer.RequestIdentification" />
        /// </summary>
        public class RequestIdentification : Activity
        {
            /// <summary>
            /// Defines the _type
            /// </summary>
             IdentificationType _type;
     
            /// <summary>
            /// Defines the _is_mandatory
            /// </summary>
            bool _isMandatory;

            /// <inheritdoc />
            /// <summary>
            /// Initializes a new instance of the <see cref="T:BusinessLayer.RequestIdentification" /> class.
            /// </summary>
            /// <param name="m">The m<see cref="T:System.String" /></param>
            /// <param name="t">The t<see cref="T:BusinessLayer.IdentificationType" /></param>
            /// <param name="im">The im<see cref="T:System.Boolean" /></param>
            public RequestIdentification(string m, IdentificationType t, bool im) : base(m)
            {
                Type = t;
                _isMandatory = im;
            }

            /// <summary>
            /// Gets or sets a value indicating whether is_mandatory
            /// </summary>
            public bool IsMandatory
            {
                set =>_isMandatory = value;
                
                get=>_isMandatory;
                
            }

            /// <summary>
            /// Defines the _type
            /// </summary>
            public IdentificationType Type
            {
                get => _type;
            set => _type = value;
        }

        /// <summary>
        /// The getIdentificationType
        /// </summary>
        /// <returns>The <see cref="string"/></returns>
        private string GetIdentificationType()
            {
            try
            {
                if (Type == IdentificationType.Card)
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
                throw;

            }
        }

            /// <summary>
            /// The getRequestActivity
            /// </summary>
            /// <param name="val">The val<see cref="int"/></param>
            /// <returns>The <see cref="DataTable"/></returns>
            public static DataTable GetRequestActivity(int val)
            {
            try
            {
                SqlParameter[] p = new SqlParameter[1];
                p[0] = new SqlParameter("@_butId", val);
                DataAccessLayer dal = DataAccessLayer.GetConInstance();
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
                throw;

            }
        }

            /// <summary>
            /// The AddRequestActivity
            /// </summary>
            /// <param name="btId">The bt_id<see cref="int"/></param>
            /// <returns>The <see cref="bool"/></returns>
            public bool AddRequestActivity(int btId)
            {
            try
            {
                DataAccessLayer dal = DataAccessLayer.GetConInstance();
                dal.Open();
                SqlParameter[] p3 = new SqlParameter[5];

                p3[0] = new SqlParameter("@_but_id", btId);
                p3[1] = new SqlParameter("@_type", "Request_identification");
                p3[2] = new SqlParameter("@_info_msg", InformationMessage);
                p3[3] = new SqlParameter("@_Identification_type", GetIdentificationType());

                p3[4] = new SqlParameter("@_Is_mandatory", IsMandatory);


                if (dal.MyExcute("Add_activity_request", p3))
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
                throw;

            }
        }

            /// <summary>
            /// The deleteActivity
            /// </summary>
            /// <param name="id">The id<see cref="string"/></param>
            /// <returns>The <see cref="bool"/></returns>
            public static bool DeleteActivity(string id)
            {
            try
            {

                DataAccessLayer dal = DataAccessLayer.GetConInstance();
                dal.Open();


                SqlParameter[] p = new SqlParameter[1];
                p[0] = new SqlParameter("@_activity_id", id);

                return dal.MyExcute("deleteRequestActivity", p);
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
                throw;

            }
        }
        }
    }
