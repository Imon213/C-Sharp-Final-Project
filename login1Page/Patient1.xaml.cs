using System;
using System.Collections.Generic;
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
using System.Data.SqlClient;
using System.Data;

namespace login1Page
{
    
    /// <summary>
    /// Interaction logic for Patient1.xaml
    /// </summary>
    public partial class Patient1 : Window
    {
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Shutdown();
        }
        public Patient1()
        {
            InitializeComponent();
        }
        private void ComboBox_Loaded1(object sender, RoutedEventArgs e)
        {
            CB1.Items.Add("medicine");
            CB1.Items.Add("orthopedic");
            CB1.Items.Add("cardiology");
        }
        private void ComboBox_Loaded2(object sender, RoutedEventArgs e)
        {
            CB2.Items.Add("saturday");
            CB2.Items.Add("sunday");
            CB2.Items.Add("monday");
            CB2.Items.Add("tuesday");
            CB2.Items.Add("wednesday");
            CB2.Items.Add("thursday");
            CB2.Items.Add("friday");
        }
        private void Btn6(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-2T0JPGM\SQLEXPRESS;Initial Catalog=loginPage;Integrated Security=True");
            con.Open();
           if(CB1.Text=="" && CB2.Text=="")
            {
                MessageBox.Show("ডাক্তার পাওয়া যায় নি");
            }
           else
            {
                string query2 = "select count (*) from [Consultation]  where ConSpeciality='" + CB1.Text + "'" + " AND ConDay ='" + CB2.Text + "'";
                SqlCommand sqlcmd = new SqlCommand(query2, con);
                int a = Convert.ToInt32(sqlcmd.ExecuteScalar());
                if (a == 1)
                {
                    string query = "Select id as আইডি, name as নাম, ConTime as সময়, ConLocation as চেম্বার, ConFee as ফি, ConName as সাক্ষাতের_নাম    from [Consultation]  where ConSpeciality='" + CB1.Text + "'" + " AND ConDay ='" + CB2.Text + "' ";
                    SqlCommand sqlcom = new SqlCommand(query, con);
                    sqlcom.CommandType = CommandType.Text;
                    DataTable dt = new DataTable();
                    SqlDataAdapter sdap = new SqlDataAdapter(sqlcom);
                    sdap.Fill(dt);
                    datagrid1.ItemsSource = dt.DefaultView;
                }
                else
                {
                    MessageBox.Show("ডাক্তার পাওয়া যায় নি");
                }
            }
         
        }

        private void Btn7(object sender, RoutedEventArgs e)
        {
            if(ptName.Text==""||PtAge.Text==""||ptPhone.Text=="")
            {
                MessageBox.Show("তথ্য যথাযথভাবে প্রদান  করা হয় নি। পুনরায়  সঠিক  তথ্য  প্রদান করুন।");
            }
            else 
            {
                String name = ptName.Text.ToString();
                int age = Convert.ToInt32(PtAge.Text);
                String gender = ptGender.Text;
                String phone = ptPhone.Text.ToString();

                doctorSearch ds = new doctorSearch(name, age, gender, phone);
                ds.Show();
                this.Hide();
            }
           
        }

        private void datagrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)

        {
            HomePage hp = new HomePage();
            hp.Show();
            this.Hide();
        }

        private void ptGender_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void PtName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(ptPhone.Text=="")
            {
                MessageBox.Show("আপনার  প্রদত্ত মোবাইল নাম্বারটি প্রদান করুন");
            }
            if(ptPhone.Text!="")
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-2T0JPGM\SQLEXPRESS;Initial Catalog=loginPage;Integrated Security=True");
                con.Open();
                string query = "select count (*) from [bpatientList] where ptName='"+ptPhone.Text+"'";
                SqlCommand sqlcom = new SqlCommand(query, con);
                int a = Convert.ToInt32(sqlcom.ExecuteScalar());
                if(a==1)
                {
                    MessageBox.Show("found");
                }
            }
            else
            {
                MessageBox.Show("Invalid");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if(ms1.Text=="")
            {
                L1.Content = "নাম প্রদান করুন";
            }
           else
            {
                L1.Content = "";
            }
          
            if(ms4.Text == "")
            {
                Lu.Content = "আপনার বর্তমান মোবাইল নাম্বার প্রদান করুন";
            }
            else
            {
                Lu.Content = "";
            }


            if (ms1.Text != "" && ms4.Text!="")

            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-2T0JPGM\SQLEXPRESS;Initial Catalog=loginPage;Integrated Security=True");
                try
                {
                    con.Open();
                   
                    string query = "Select count (*)from [bpatientList] where  PtPhone='" + ms4.Text + "' ";
                    

                  
                    SqlCommand sqlcom2 = new SqlCommand(query, con);
                    sqlcom2.ExecuteNonQuery();
                    int a = Convert.ToInt32(sqlcom2.ExecuteScalar());
                    sqlcom2.ExecuteNonQuery();
                    if (a == 1)
                      
                    {
                      
                        string update = "UPDATE [bpatientList] SET PtName='" + ms1.Text + "' WHERE PtPhone='" + ms4.Text + "'";
                        SqlCommand sqlcom = new SqlCommand(update, con);
                        sqlcom.ExecuteNonQuery();
                        MessageBox.Show("নাম পরিবর্তন  সম্পূর্ন  হয়েছে");
                    }

                    else
                    {
                        Lu.Content = "মোবাইল নাম্বার সঠিক নয়";
                        MessageBox.Show(" মোবাইল নাম্বার সঠিক নয়");
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

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {


            if (ms4.Text == "")
            {
                Lu.Content = "আপনার বর্তমান মোবাইল নাম্বার প্রদান করুন";
            }
            else
            {
                Lu.Content = "";
            }
            if (ms4.Text != "")
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-2T0JPGM\SQLEXPRESS;Initial Catalog=loginPage;Integrated Security=True");
                con.Open();
                string query2 = "select count (*) from [bpatientList] where PtPhone='" + ms4.Text + "'";
                SqlCommand sqlcom = new SqlCommand(query2, con);
                int a = Convert.ToInt32(sqlcom.ExecuteScalar());
                sqlcom.ExecuteNonQuery();
                if (a == 1)
                {
                    string query = "select PtName as Name, PtAge as Age, PtGender as Gender, PtPhone as Mobile, Comment as Status from [bpatientList] where PtPhone='" + ms4.Text + "'";
                    SqlCommand sqlcom2 = new SqlCommand(query, con);
                    sqlcom2.CommandType = CommandType.Text;
                    DataTable dt = new DataTable();
                    SqlDataAdapter sdap = new SqlDataAdapter(sqlcom2);
                    sdap.Fill(dt);
                    dgrid1.ItemsSource = dt.DefaultView;
                  
                }
                else
                {
                    Lu.Content = "মোবাইল নাম্বার সঠিক নয়";
                    MessageBox.Show(" মোবাইল নাম্বার সঠিক নয়");
                }
            }
            

           
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

            if (ms2.Text == "")
            {
                l3.Content = "বয়স প্রদান করুন";
            }
            else
            {
                l3.Content = "";
            }

            if (ms4.Text == "")
            {
                Lu.Content = "আপনার বর্তমান মোবাইল নাম্বার প্রদান করুন";
            }
            else
            {
                Lu.Content = "";
            }


            if (ms2.Text != "" && ms4.Text != "")

            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-2T0JPGM\SQLEXPRESS;Initial Catalog=loginPage;Integrated Security=True");
                try
                {
                    con.Open();

                    string query = "Select count (*)from [bpatientList] where  PtPhone='" + ms4.Text + "' ";



                    SqlCommand sqlcom2 = new SqlCommand(query, con);
                    sqlcom2.ExecuteNonQuery();
                    int a = Convert.ToInt32(sqlcom2.ExecuteScalar());
                    sqlcom2.ExecuteNonQuery();
                    if (a == 1)

                    {

                        string update = "UPDATE [bpatientList] SET PtAge='" + ms2.Text + "' WHERE PtPhone='" + ms4.Text + "'";
                        SqlCommand sqlcom = new SqlCommand(update, con);
                        sqlcom.ExecuteNonQuery();
                        MessageBox.Show("বয়স পরিবর্তন  সম্পূর্ন  হয়েছে");

                    }

                    else
                    {
                        Lu.Content = "মোবাইল নাম্বার সঠিক নয়";
                        MessageBox.Show(" মোবাইল নাম্বার সঠিক নয়");
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

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
          

            if (ms4.Text == "")
            {
                Lu.Content = "আপনার বর্তমান মোবাইল নাম্বার প্রদান করুন";
            }
            else
            {
                Lu.Content = "";
            }


            if (ms4.Text != "")

            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-2T0JPGM\SQLEXPRESS;Initial Catalog=loginPage;Integrated Security=True");
                try
                {
                    con.Open();

                    string query = "Select count (*)from [bpatientList] where  PtPhone='" + ms4.Text + "' ";



                    SqlCommand sqlcom2 = new SqlCommand(query, con);
                    sqlcom2.ExecuteNonQuery();
                    int a = Convert.ToInt32(sqlcom2.ExecuteScalar());
                    sqlcom2.ExecuteNonQuery();
                    if (a == 1)

                    {

                      
                        string update = "UPDATE [bpatientList] SET PtGender='" + cm1.Text + "' WHERE PtPhone='" + ms4.Text + "'";
                        SqlCommand sqlcom = new SqlCommand(update, con);
                        sqlcom.ExecuteNonQuery();

                        MessageBox.Show("লিঙ্গ পরিবর্তন  সম্পূর্ন  হয়েছে");


                    }

                    else
                    {
                        Lu.Content = "মোবাইল নাম্বার সঠিক নয়";
                        MessageBox.Show(" মোবাইল নাম্বার সঠিক নয়");
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

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {

            if (ms3.Text == "")
            {
                l4.Content = "মোবাইল নাম্বার প্রদান করুন";
            }
            else
            {
                l4.Content = "";
            }

            if (ms4.Text == "")
            {
                Lu.Content = "আপনার বর্তমান মোবাইল নাম্বার প্রদান করুন";
            }
            else
            {
                Lu.Content = "";
            }


            if (ms3.Text != "" && ms4.Text != "")

            {

                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-2T0JPGM\SQLEXPRESS;Initial Catalog=loginPage;Integrated Security=True");
                try
                {
                    con.Open();

                    string query = "Select count (*)from [bpatientList] where  PtPhone='" + ms4.Text + "' ";



                    SqlCommand sqlcom2 = new SqlCommand(query, con);
                    sqlcom2.ExecuteNonQuery();
                    int a = Convert.ToInt32(sqlcom2.ExecuteScalar());
                    sqlcom2.ExecuteNonQuery();
                    if (a == 1)

                    {

                        string update = "UPDATE [bpatientList] SET PtPhone='" + ms3.Text + "' WHERE PtPhone='" + ms4.Text + "'";
                        SqlCommand sqlcom = new SqlCommand(update, con);
                        sqlcom.ExecuteNonQuery();
                        MessageBox.Show("মোবাইল নাম্বার পরিবর্তন  সম্পূর্ন  হয়েছে");

                    }

                    else
                    {
                        Lu.Content = "মোবাইল নাম্বার সঠিক নয়";
                        MessageBox.Show(" মোবাইল নাম্বার সঠিক নয়");
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

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            About ab = new About();
            ab.Show();
            this.Hide();
        }
    }
}
