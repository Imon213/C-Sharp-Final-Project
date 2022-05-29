using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.Sql;

namespace login1Page
{
    /// <summary>
    /// Interaction logic for regPage.xaml
    /// </summary>
    public partial class regPage : Window
    {
        SqlCommand smd;
      
        SqlDataAdapter sadp;
       
        public regPage()
        {
            InitializeComponent();
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Shutdown();
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void signin_Click(object sender, RoutedEventArgs e)
        {
            loginpage1 lg = new loginpage1();
            lg.Show();
            this.Hide();
        }

        private void submit_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=DESKTOP-2T0JPGM\SQLEXPRESS;Initial Catalog=loginPage;Integrated Security=True");
           try
            {
                sqlcon.Open();
                SqlCommand sqlcmd = new SqlCommand("select count (*) from [LoginPage] where id='"+idno.Text+"' ", sqlcon);
                int a = Convert.ToInt32(sqlcmd.ExecuteScalar());
                sqlcmd.ExecuteNonQuery();
                if(a==1)
                {
                    MessageBox.Show("This ID is almost Exist. Please write another ID");
                }
               else
                {
                    if(idno.Text=="" || usname.Text=="" || password.Password=="" || email.Text=="" || address.Text=="" || dept.Text=="" || gender.Text=="" )
                    {
                        MessageBox.Show("Information Missing. Please check");
                    }
                   else
                    {
                        smd = new SqlCommand("insert into LoginPage(id,UserName, Password, Email, Address, Dept, Gender) values('" + idno.Text + "',@UserName, @Password, @Email, @Address," + " @Dept, '" + gender.Text + "')", sqlcon);
                        smd.Parameters.Add("@UserName", usname.Text);
                        smd.Parameters.Add("@Password", password.Password);
                        smd.Parameters.Add("@Email", email.Text);
                        smd.Parameters.Add("@Address", address.Text);
                        smd.Parameters.Add("@Dept", dept.Text);


                        smd.ExecuteNonQuery();


                        string eml = email.Text.ToString();
                        string add = address.Text.ToString();
                        string dep = dept.Text.ToString();
                        string gend = gender.SelectedItem.ToString();
                        MessageBox.Show("Registration Complete");
                        this.Hide();
                        loginpage1 lp1 = new loginpage1();
                        lp1.Show();
                    }

                }
                // userView us = new userView(eml, add, dep, gend);
                // us.Show();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlcon.Close();
               
            }
            
        }
        
        

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
