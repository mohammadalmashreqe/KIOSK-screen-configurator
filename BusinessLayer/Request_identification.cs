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
        /// Defines the _IDtype
        /// </summary>
        private IdentificationType _iDtype;
     
            /// <summary>
            /// Defines the _is_mandatory
            /// </summary>
            private bool _isMandatory;

            /// <inheritdoc />
            /// <summary>
            /// Initializes a new instance of the <see cref="T:BusinessLayer.RequestIdentification" /> class.
            /// </summary>
            /// <param name="m">The m<see cref="T:System.String" /></param>
            /// <param name="t">The t<see cref="T:BusinessLayer.IdentificationType" /></param>
            /// <param name="im">The im<see cref="T:System.Boolean" /></param>
            public RequestIdentification(string m, IdentificationType t, bool im) : base(m)
            {
                IdType = t;
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
            /// Defines the _IDtype
            /// </summary>
            public  IdentificationType IdType
            {
                get => _iDtype;
            set => _iDtype = value;
        }

        /// <summary>
        /// The getIdentificationType
        /// </summary>
        /// <returns>The <see cref="string"/></returns>
        private string GetIdentificationType()
            {
            try
            {
                if (IdType == IdentificationType.Card)
                    return "card";
                else
                    return "mobile";
            }
            catch (Exception ex)
            {
                ErrorLogger.ErrorLog(ex);

               // MessageBox.Show("exception : " + Environment.NewLine + ex.Message + Environment.NewLine + Environment.NewLine + "for more info : " + Directory.GetCurrentDirectory() + @"\LogFile.txt", "exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                ErrorLogger.ErrorLog(ex);
             //   MessageBox.Show("exception : " + Environment.NewLine + ex.Message + Environment.NewLine + Environment.NewLine + "for more info : " + Directory.GetCurrentDirectory() + @"\LogFile.txt", "exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                p3[1] = new SqlParameter("@_type", "Request identification");
                p3[2] = new SqlParameter("@_info_msg", InformationMessage);
                p3[3] = new SqlParameter("@_Identification_type", GetIdentificationType());

                p3[4] = new SqlParameter("@_Is_mandatory", IsMandatory);


                return dal.MyExcute("Add_activity_request", p3);
            }
            catch (Exception ex)
            {
                ErrorLogger.ErrorLog(ex);

                    // MessageBox.Show("exception : " + Environment.NewLine + ex.Message + Environment.NewLine + Environment.NewLine + "for more info : " + Directory.GetCurrentDirectory() + @"\LogFile.txt", "exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                ErrorLogger.ErrorLog(ex);
               // MessageBox.Show("exception : " + Environment.NewLine + ex.Message + Environment.NewLine + Environment.NewLine + "for more info : " + Directory.GetCurrentDirectory() + @"\LogFile.txt", "exception", MessageBoxButtons.OK, MessageBoxIcon.Error);

                throw; 

            }
        }


            public static RequestIdentification GetInfoById(int id)
            {
                DataAccessLayer dal = DataAccessLayer.GetConInstance();
                dal.Open();
                DataTable dt = dal.SelectData("getrequestActByid", new[] { new SqlParameter("@_id", id) });
                DataRow row = dt.Rows[0];
                IdentificationType r = row["Identification_type"].ToString() == "card"
                    ? IdentificationType.Card
                    : IdentificationType.Mobile;

                RequestIdentification t = new RequestIdentification(row["info_msg"].ToString(), r,
                    bool.Parse(row["Is_mandatory"].ToString()))
                {
                    Id = int.Parse(row["activity_id"].ToString()), Type = "Request Identification"
                };
                return t;
            }

            

            public bool UpdateActivity()
            {

                try
                {
                    DataAccessLayer dal = DataAccessLayer.GetConInstance();
                    dal.Open();
                    SqlParameter[] p = new SqlParameter[4];
                    p[0] = new SqlParameter("@_id", Id);
                    p[1] = new SqlParameter("@_Identification_type", IdType.ToString());
                    p[2] = new SqlParameter("@_info_msg ", InformationMessage);
                    p[3]= new SqlParameter("@_Is_mandatory",IsMandatory);
                    return dal.MyExcute("UpdateRequestID", p);
                }
                catch (Exception ex)
                {
                    ErrorLogger.ErrorLog(ex);
                    return false;
                }


            }
    }
    }
