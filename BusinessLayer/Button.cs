namespace BusinessLayer
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.IO;
    using System.Windows.Forms;

    /// <summary>
    /// Defines the <see cref="Button" />
    /// </summary>
    public class Button
    {
        /// <summary>
        /// Defines the name
        /// </summary>
        private string _name;

        /// <summary>
        /// Defines the id
        /// </summary>
        private int _id;

        /// <summary>
        /// Defines the order
        /// </summary>
        private int _order;

      

        /// <summary>
        /// Defines the activities
        /// </summary>
        // ReSharper disable once UnusedMember.Local
        private List<Activity> _activities = new List<Activity>();

        /// <summary>
        /// Gets or sets the Name
        /// </summary>
        public string Name { get => _name; set => _name = value; }

        /// <summary>
        /// Gets or sets the Order
        /// </summary>
        public int Order { get => _order; set => _order = value; }

        /// <summary>
        /// Gets or sets the Text
        /// </summary>

        /// <summary>
        /// Gets or sets the ID
        /// </summary>
        public int Id { get => _id; set => _id = value; }

        /// <summary>
        /// Defines the activities
        /// </summary>
        public List<Activity> Activities
        {
            get => _activities;
            set => _activities = value;
        }


        /// <summary>
        /// The getButtons
        /// </summary>
        /// <returns>The <see cref="DataTable"/></returns>
        public static DataTable GetButtons()
        {
            try
            {
                DataAccessLayer dal = DataAccessLayer.GetConInstance();
                dal.Open();
                DataTable dt = dal.SelectData("getButtons", null);
                return dt;
            }
            catch (Exception ex)
            {
               
               ErrorLogger.ErrorLog(ex);

                MessageBox.Show("exception : " + Environment.NewLine + ex.Message + Environment.NewLine + Environment.NewLine + "for more info : " + Directory.GetCurrentDirectory() + @"\LogFile.txt", "exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;


            }
            
        }

        /// <summary>
        /// The DeleteButton
        /// </summary>
        /// <returns>The <see cref="bool"/></returns>
        public bool DeleteButton()
        {
            try
            {
                DataAccessLayer dal = DataAccessLayer.GetConInstance();
                dal.Open();
                SqlParameter[] p = new SqlParameter[1];
                p[0] = new SqlParameter("@_id", Id);
                if (dal.MyExcute("deleteButton", p))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {

                ErrorLogger.ErrorLog(ex);

                MessageBox.Show("exception : " + Environment.NewLine + ex.Message + Environment.NewLine + Environment.NewLine + "for more info : " + Directory.GetCurrentDirectory() + @"\LogFile.txt", "exception", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false; 


            }
        }

        /// <summary>
        /// The AddButton
        /// </summary>
        /// <returns>The <see cref="bool"/></returns>
        public bool AddButton()
        {
            try
            {
                SqlParameter[] p = new SqlParameter[2];
                p[0] = new SqlParameter("@_name", Name);
               
                p[1] = new SqlParameter("@_order", Order);
                DataAccessLayer dal = DataAccessLayer.GetConInstance();
                dal.Open();
                if (dal.MyExcute("AddButton", p))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                ErrorLogger.ErrorLog(ex);

                MessageBox.Show("exception : " + Environment.NewLine + ex.Message + Environment.NewLine + Environment.NewLine + "for more info : " + Directory.GetCurrentDirectory() + @"\LogFile.txt", "exception", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false; 

            }
        }

        /// <summary>
        /// The GetId
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        public int GetId()
        {
            try
            {
                int btId = -1;
                DataAccessLayer dal = DataAccessLayer.GetConInstance();
                dal.Open();
                SqlParameter[] p5 = new SqlParameter[2];
                p5[0] = new SqlParameter("@_name", Name);
          
                p5[1] = new SqlParameter("@_order", Order);
                DataTable dt = dal.SelectData("GetId", p5);
                if (dt.Rows.Count > 0)
                {
                    btId = dt.Rows[0].Field<int>(0);
                }

                return btId;
            }
            catch (Exception ex)
            {
                ErrorLogger.ErrorLog(ex);

                MessageBox.Show("exception : " + Environment.NewLine + ex.Message + Environment.NewLine + Environment.NewLine + "for more info : " + Directory.GetCurrentDirectory() + @"\LogFile.txt", "exception", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return -1;
            }

        }

        /// <summary>
        /// The updateButton
        /// </summary>
        /// <returns>The <see cref="bool"/></returns>
        public bool UpdateButton()
        {
            try
            {
                DataAccessLayer dal = DataAccessLayer.GetConInstance();
                dal.Open();
                SqlParameter[] p = new SqlParameter[3];
                p[0] = new SqlParameter("@_id", Id);
                p[1] = new SqlParameter("@_name", Name);

        

                p[2] = new SqlParameter("@_order", Order);

                return dal.MyExcute("EditButton", p);



            }
            catch (Exception ex)
            {
                ErrorLogger.ErrorLog(ex);

                MessageBox.Show("exception : " + Environment.NewLine + ex.Message + Environment.NewLine + Environment.NewLine + "for more info : " + Directory.GetCurrentDirectory() + @"\LogFile.txt", "exception", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;

            }
        }
    }
}
