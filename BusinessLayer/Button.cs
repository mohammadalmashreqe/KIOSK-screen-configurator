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
        /// Defines the text
        /// </summary>
        private string _text;

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
        public string Text { get => _text; set => _text = value; }

        /// <summary>
        /// Gets or sets the ID
        /// </summary>
        public int Id { get => _id; set => _id = value; }

    

     

      

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
        /// The AddButton
        /// </summary>
        /// <returns>The <see cref="bool"/></returns>
        public bool AddButton()
        {
            try
            {
                SqlParameter[] p = new SqlParameter[3];
                p[0] = new SqlParameter("@_name", Name);
                p[1] = new SqlParameter("@_text", Text);
                p[2] = new SqlParameter("@_order", Order);
                DataAccessLayer dal = DataAccessLayer.GetConInstance();
                dal.Open();
                if (dal.MyExcute("AddButton", p))
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
        /// The GetId
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        public int GetId()
        {
            try
            {
                DataAccessLayer dal = DataAccessLayer.GetConInstance();
                dal.Open();
                SqlParameter[] p5 = new SqlParameter[3];
                p5[0] = new SqlParameter("@_name", Name);
                p5[1] = new SqlParameter("@_text", Text);
                p5[2] = new SqlParameter("@_order", Order);
                DataTable dt = dal.SelectData("GetId", p5);
                int btId = dt.Rows[0].Field<int>(0);

                return btId;
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
        /// The updateButton
        /// </summary>
        /// <returns>The <see cref="bool"/></returns>
        public bool UpdateButton()
        {
            try
            {
                DataAccessLayer dal = DataAccessLayer.GetConInstance();
                dal.Open();
                SqlParameter[] p = new SqlParameter[4];
                p[0] = new SqlParameter("@_id", Id);
                p[1] = new SqlParameter("@_name", Name);

                p[2] = new SqlParameter("@_text", Text);

                p[3] = new SqlParameter("@_order", Order);

                return dal.MyExcute("EditButton", p);



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

                return false;

            }
        }
    }
}
