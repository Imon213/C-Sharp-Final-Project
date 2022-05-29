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


namespace login1Page
{
    /// <summary>
    /// Interaction logic for loginpage1.xaml
    /// </summary>
    public partial class loginpage1 : Window
    {
        string nameerror;
        string passerror;
        

        //public loginpage1(String email, string address, string gender, string dept)
        //{
        //    InitializeComponent();
        //    login.emil = email;
        //    login.address = address;
        //    login.gender = gender;
        //    login.dept = dept;
        //}
        public loginpage1()
        {
            InitializeComponent();
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Shutdown();
        }
        private void ubutton_Click(object sender, RoutedEventArgs e)

        {
            if (uname.Text == "")
            {
                nameerror = "User Name required";
                namerr.Content = nameerror;
            }
            else
            {
                namerr.Content = "";
            }
             if (upass.Password == "")
            {
                passerror = "User Password required";
                paserr.Content = passerror;
            }
             else
            {
                paserr.Content = "";
            }
             if (uname.Text != "" && upass.Password != "")
            {


                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-2T0JPGM\SQLEXPRESS;Initial Catalog=loginPage;Integrated Security=True");
                try
                {
                    con.Open();
                    string query = "Select count (*)from [LoginPage] where UserName='" + uname.Text + "' AND Password='" + upass.Password + "' ";
                    SqlCommand sqlcom = new SqlCommand(query, con);
                    int a = Convert.ToInt32(sqlcom.ExecuteScalar());
                    if (a == 1)
                    {
                        // MessageBox.Show("Valid");
                       
                        string userName = uname.Text.ToString();
                        string userPassword = upass.Password.ToString();
                      
                      userView uV = new userView(userName);
                        uV.Show();
                        this.Hide();
                        //  loginpage1 lg = new loginpage1();



                    }
                    else
                    {
                        MessageBox.Show("Invalid User Name or User Password");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    con.Close();
                   
                }
            }
        }

        private void createbutton_Click(object sender, RoutedEventArgs e)
        {
            regPage rgp = new regPage();
            rgp.Show();
            this.Hide();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            HomePage hp = new HomePage();
            hp.Show();
            this.Hide();
        }
    }
}
