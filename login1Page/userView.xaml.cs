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
using System.Data;

namespace login1Page
{
    /// <summary>
    /// Interaction logic for userView.xaml
    /// </summary>
    /// 
     
    
    public partial class userView : Window
    {
        string userName;
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Shutdown();
        }

        public userView()
        {
           
            InitializeComponent();



        }
        public userView( string un)
        {
            this.userName = un;
            InitializeComponent();
           



        }
        
        //public userView(string eml, string add, string dep, string gen)
        //{


        //    login.emil = eml;
        //    login.address = add;
        //    login.gender = gen;
        //    login.dept = dep;
           
        //}

        private void show_Click(object sender, RoutedEventArgs e)
        {
            //InitializeComponent();
            //dremail_Copy.Content = login.emil;
            //draddress_copy.Content = login.address;
            //drdept_copy.Content = login.dept;
            //drgender_Copy.Content = login.gender;
            ////  DR.Content = userNamer;
            ///


            System.Data.SqlClient.SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-2T0JPGM\SQLEXPRESS;Initial Catalog=loginPage;Integrated Security=True");
            try
            {
                con.Open();
                string query = "Select id as ID, UserName as NAME, Email as EMAIL, Address as ADDRESS, Gender as GENDER, Dept as DEPERTMENT from [LoginPage] where UserName='"+userName+"'";
                SqlCommand sqlcom = new SqlCommand(query, con);
                sqlcom.CommandType = CommandType.Text;
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(sqlcom);
                sda.Fill(dt);
                profileshow.ItemsSource = dt.DefaultView;
               

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

        private void addcon_Click(object sender, RoutedEventArgs e)
        {
            ConsultationForm con = new ConsultationForm();
            con.Show();
            this.Hide();
        }

        private void showcon_Click(object sender, RoutedEventArgs e)
        {
            System.Data.SqlClient.SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-2T0JPGM\SQLEXPRESS;Initial Catalog=loginPage;Integrated Security=True");
            try
            {
                con.Open();
                string query = "select id as ID, Name, ConName as ConsultationName, ConTime as ConsultationTime, ConLocation as ConsultationLocation, ConSpeciality as ConsultationSpeciality, ConFee as ConsultationFee, ConDay as ConsultationDay from [Consultation] where Name='"+userName+"'";


                SqlCommand sqlcom = new SqlCommand(query, con);
                sqlcom.CommandType = CommandType.Text;
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(sqlcom);
                sda.Fill(dt);
                grid1.ItemsSource = dt.DefaultView;


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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            HomePage hp = new HomePage();
            hp.Show();
            this.Hide();
        }

        private void pList_Click(object sender, RoutedEventArgs e)
        {
            PatientList pl = new PatientList();
            pl.Show();
            this.Hide();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           
            
            System.Data.SqlClient.SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-2T0JPGM\SQLEXPRESS;Initial Catalog=loginPage;Integrated Security=True");
            try
            {
                con.Open();
                if(mb6.Text=="" && mb7.Password=="")
                {
                    l1.Content = "User Name Required";
                    l2.Content = "User Password Required";
                }
                else
                {
                    string query3 = "select count (*) from [LoginPage] where UserName='" + mb6.Text + "' and Password='" + mb7.Password + "' ";
                    SqlCommand sqlcmd3 = new SqlCommand(query3, con);
                 
                    int a = Convert.ToInt32(sqlcmd3.ExecuteScalar());
                    sqlcmd3.ExecuteNonQuery();
                    if(a==1)
                    {
                        string query = "update [LoginPage] set UserName='" + mb1.Text + "' where UserName='" + mb6.Text + "' and Password='" + mb7.Password + "'";
                        SqlCommand sqlcom = new SqlCommand(query, con);
                        sqlcom.ExecuteNonQuery();
                        String query2 = "update [Consultation] set Name='" + mb1.Text + "' where Name='" + mb6.Text + "' ";
                        SqlCommand sqlcom2 = new SqlCommand(query2, con);
                        sqlcom2.ExecuteNonQuery();
                        MessageBox.Show("Username Successfuly Updated\nReturn Login Page");
                        HomePage hm = new HomePage();
                        hm.Show();
                        this.Hide();
                       
                    }
                   else
                    {
                        MessageBox.Show("Invalid User Name or User Password. Please try again");
                    }



                }
              
              
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
               
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            System.Data.SqlClient.SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-2T0JPGM\SQLEXPRESS;Initial Catalog=loginPage;Integrated Security=True");
            try
            {
                con.Open();
                if (mb6.Text == "" && mb7.Password == "")
                {
                    l1.Content = "User Name Required";
                    l2.Content = "User Password Required";
                }
                else
                {

                    string query3 = "select count (*) from [LoginPage] where UserName='" + mb6.Text + "' and Password='" + mb7.Password + "' ";
                    SqlCommand sqlcmd3 = new SqlCommand(query3, con);

                    int a = Convert.ToInt32(sqlcmd3.ExecuteScalar());
                    sqlcmd3.ExecuteNonQuery();
                    if(a==1)
                    {
                        string query = "update [LoginPage] set id='" + mb2.Text + "' where UserName='" + mb6.Text + "' and Password='" + mb7.Password + "'";
                        SqlCommand sqlcom = new SqlCommand(query, con);


                        sqlcom.ExecuteNonQuery();
                        String query2 = "update [Consultation] set id='" + mb2.Text + "' where Name='" + mb6.Text + "' ";
                        SqlCommand sqlcom2 = new SqlCommand(query2, con);
                        sqlcom2.ExecuteNonQuery();
                        MessageBox.Show("ID successfuly Updated");
                    }
                    else
                    {
                        MessageBox.Show("Invalid User Name or Password. Please try again");
                    }
                   



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

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            System.Data.SqlClient.SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-2T0JPGM\SQLEXPRESS;Initial Catalog=loginPage;Integrated Security=True");
            try
            {
                con.Open();
                if (mb6.Text == "" && mb7.Password == "")
                {
                    l1.Content = "User Name Required";
                    l2.Content = "User Password Required";
                }
                else
                {
                    string query3 = "select count (*) from [LoginPage] where UserName='" + mb6.Text + "' and Password='" + mb7.Password + "' ";
                    SqlCommand sqlcmd3 = new SqlCommand(query3, con);

                    int a = Convert.ToInt32(sqlcmd3.ExecuteScalar());
                    sqlcmd3.ExecuteNonQuery();
                    if (a == 1)
                    {
                        string query = "update [LoginPage] set Email='" + mb3.Text + "' where UserName='" + mb6.Text + "' and Password='" + mb7.Password + "'";
                        SqlCommand sqlcom = new SqlCommand(query, con);


                        sqlcom.ExecuteNonQuery();
                        MessageBox.Show("Email Successfuly Updated");
                    }

                     else
                    {
                        MessageBox.Show("Invalid User Name or User Password. Please try again");
                    }


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

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            System.Data.SqlClient.SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-2T0JPGM\SQLEXPRESS;Initial Catalog=loginPage;Integrated Security=True");
            try
            {
                con.Open();
                if (mb6.Text == "" && mb7.Password == "")
                {
                    l1.Content = "User Name Required";
                    l2.Content = "User Password Required";
                }
                else
                {
                    string query3 = "select count (*) from [LoginPage] where UserName='" + mb6.Text + "' and Password='" + mb7.Password + "' ";
                    SqlCommand sqlcmd3 = new SqlCommand(query3, con);

                    int a = Convert.ToInt32(sqlcmd3.ExecuteScalar());
                    sqlcmd3.ExecuteNonQuery();
                    if (a == 1)
                    {
                        string query = "update [LoginPage] set Gender='" + cb1.Text + "' where UserName='" + mb6.Text + "' and Password='" + mb7.Password + "'";
                        SqlCommand sqlcom = new SqlCommand(query, con);


                        sqlcom.ExecuteNonQuery();
                        MessageBox.Show("Gender Successfuly updated");


                    }
                    else
                    {
                        MessageBox.Show("Invalid User name or user password. please try again");
                    }
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

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {

            System.Data.SqlClient.SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-2T0JPGM\SQLEXPRESS;Initial Catalog=loginPage;Integrated Security=True");
            try
            {
                con.Open();
                if (mb6.Text == "" && mb7.Password == "")
                {
                    l1.Content = "User Name Required";
                    l2.Content = "User Password Required";
                }
                else
                {

                    string query3 = "select count (*) from [LoginPage] where UserName='" + mb6.Text + "' and Password='" + mb7.Password + "' ";
                    SqlCommand sqlcmd3 = new SqlCommand(query3, con);

                    int a = Convert.ToInt32(sqlcmd3.ExecuteScalar());
                    sqlcmd3.ExecuteNonQuery();
                    if (a == 1)
                    {
                        string query = "update [LoginPage] set Address='" + mb4.Text + "' where UserName='" + mb6.Text + "' and Password='" + mb7.Password + "'";
                        SqlCommand sqlcom = new SqlCommand(query, con);


                        sqlcom.ExecuteNonQuery();
                        MessageBox.Show("Address  Successfuly Updated");
                    }
                    else
                    {
                        MessageBox.Show("Invalid User Name or User Password. Please try again");
                    }

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

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {

            System.Data.SqlClient.SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-2T0JPGM\SQLEXPRESS;Initial Catalog=loginPage;Integrated Security=True");
            try
            {
                con.Open();
                if (mb6.Text == "" && mb7.Password == "")
                {
                    l1.Content = "User Name Required";
                    l2.Content = "User Password Required";
                }
                else
                {

                    string query3 = "select count (*) from [LoginPage] where UserName='" + mb6.Text + "' and Password='" + mb7.Password + "' ";
                    SqlCommand sqlcmd3 = new SqlCommand(query3, con);

                    int a = Convert.ToInt32(sqlcmd3.ExecuteScalar());
                    sqlcmd3.ExecuteNonQuery();
                    if (a == 1)
                    {
                        string query = "update [LoginPage] set Dept='" + mb5.Text + "' where UserName='" + mb6.Text + "' and Password='" + mb7.Password + "'";
                        SqlCommand sqlcom = new SqlCommand(query, con);


                        sqlcom.ExecuteNonQuery();
                        String query2 = "update [Consultation] set ConSpeciality='" + mb5.Text + "' where Name='" + mb6.Text + "' ";
                        SqlCommand sqlcom2 = new SqlCommand(query2, con);
                        sqlcom2.ExecuteNonQuery();
                        MessageBox.Show("Department Successfully Updated");

                    }
                    else
                    {
                        MessageBox.Show("Invalid User Name or User Password. Please try again");
                    }
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
}
