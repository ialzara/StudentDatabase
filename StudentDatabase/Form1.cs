using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentDatabase
{
    public partial class Form1 : Form
    {
        string str;
        string str2;
        SqlConnection conn;
        public Form1()
        {
            InitializeComponent();
            monthCalendar1.MaxDate = DateTime.Now;
            foreach(GradeEntry grade in Grade.ToList())
            {
                comboBox2.Items.Add(grade);
            }
            /*
             * 
             * foreach(CountryEntry country in Countries.ToList())
            {
                comboBox3.Items.Add(country);
            }
             * 
             */

            try
            {
                conn = new SqlConnection("Server = localhost; Database = Educational; Trusted_Connection = True");
                str = "SELECT * FROM SCHOOL";
                SqlCommand cmd = new SqlCommand(str, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    comboBox1.Items.Add(new School(reader[1].ToString(), reader[0].ToString()));
                }
                conn.Close();
            }catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != String.Empty && textBox2.Text != String.Empty && comboBox1.SelectedItem is School && comboBox2.SelectedItem is GradeEntry && monthCalendar1.SelectionRange.Start.ToShortDateString() != String.Empty
                && textBox3.Text != String.Empty && textBox5.Text != String.Empty && textBox6.Text != String.Empty && textBox7.Text != String.Empty && textBox8.Text != String.Empty)
            {
                School school = comboBox1.SelectedItem as School;
                GradeEntry gradeEntry = comboBox2.SelectedItem as GradeEntry;
                string studentGu = Guid.NewGuid().ToString();
                //CountryEntry countryEntry = comboBox3.SelectedItem as CountryEntry;
                try
                {
                    conn = new SqlConnection("Server = localhost; Database = Educational; Trusted_Connection = True");
                    str = "INSERT INTO STUDENT (STUDENT_GU, SCHOOL_GU, FIRST_NAME, LAST_NAME, GRADE, DOB) VALUES (@STUDENT_GU, @SCHOOL_GU, @FIRST_NAME, @LAST_NAME, @GRADE, @DOB)";
                    SqlCommand cmd = new SqlCommand(str, conn);
                    conn.Open();
                    cmd.Parameters.Add("@STUDENT_GU", studentGu);
                    cmd.Parameters.Add("@SCHOOL_GU", school.SchoolGu);
                    cmd.Parameters.Add("@FIRST_NAME", textBox1.Text);
                    cmd.Parameters.Add("@LAST_NAME", textBox2.Text);
                    cmd.Parameters.Add("@GRADE", gradeEntry.key);
                    cmd.Parameters.Add("@DOB", monthCalendar1.SelectionRange.Start.ToShortDateString());
                    cmd.ExecuteNonQuery();
                    str2 = "INSERT INTO ADDRESS (ADDRESS_GU, STUDENT_GU, STREET1, STREET2, CITY, STATE, ZIP, COUNTRY) VALUES (@ADDRESS_GU, @STUDENT_GU, @STREET1, @STREET2, @CITY, @STATE, @ZIP, @COUNTRY)";
                    cmd = new SqlCommand(str2, conn);
                    cmd.Parameters.Add("@ADDRESS_GU", Guid.NewGuid().ToString());
                    cmd.Parameters.Add("@STUDENT_GU", studentGu);
                    cmd.Parameters.Add("@STREET1", textBox3.Text);
                    cmd.Parameters.Add("@STREET2", textBox4.Text);
                    cmd.Parameters.Add("@CITY", textBox5.Text);
                    cmd.Parameters.Add("@STATE", textBox6.Text);
                    cmd.Parameters.Add("@ZIP", textBox7.Text);
                    cmd.Parameters.Add("@COUNTRY", textBox8.Text);
                    cmd.ExecuteNonQuery();


                    conn.Close();
                    MessageBox.Show("Student Added Successfully");
                    Dispose();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }else if (textBox7.Text.Length != 2)
            {
                MessageBox.Show("State should be only 2 letters");
            }
            else
            {
                MessageBox.Show("Please fill up all the fields");
            }
        }
    }
}
