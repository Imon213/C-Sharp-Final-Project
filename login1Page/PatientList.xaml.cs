using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
    /// Interaction logic for PatientList.xaml
    /// </summary>
    public partial class PatientList : Window
    {
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Shutdown();
        }
        public PatientList()
        {
            InitializeComponent();
        }

        private void list_Click(object sender, RoutedEventArgs e)
        {
            System.Data.SqlClient.SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-2T0JPGM\SQLEXPRESS;Initial Catalog=loginPage;Integrated Security=True");
            try
            {
                if(patient.Text=="")
                {
                    MessageBox.Show("Consultation Name Required");
                }
                else
                {
                    
                    con.Open();
                    string query2 = "select count (*) from [Consultation] where  ConName='" + patient.Text + "' and  id='"+id.Text+"' ";
                    SqlCommand sqlcom2 = new SqlCommand(query2, con);
                    int a = Convert.ToInt32(sqlcom2.ExecuteScalar());
                    

                    if(a==1)
                    {
                        string query = "select ConName as ConsultationName, PtName as PatientName, PtAge as Age, PtGender as Gender, PtPhone as Phone, Comment as Status from [bpatientList] where ConName='" + patient.Text + "'  and DrId='" + id.Text + "'";


                        SqlCommand sqlcom = new SqlCommand(query, con);
                        sqlcom.CommandType = CommandType.Text;
                        DataTable dt = new DataTable();
                        SqlDataAdapter sda = new SqlDataAdapter(sqlcom);
                        sda.Fill(dt);
                        pgrid.ItemsSource = dt.DefaultView;
                    }
                    else
                    {
                        MessageBox.Show("Invalid Consultation Name");
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

        private void back_Click(object sender, RoutedEventArgs e)
        {
            loginpage1 uv1 = new loginpage1();
            uv1.Show();
            this.Hide();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=DESKTOP-2T0JPGM\SQLEXPRESS;Initial Catalog=loginPage;Integrated Security=True");
           
                sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand("select count (*) from  [bpatientList] where PtPhone='" + ms1.Text + "' ", sqlcon);
            int a = Convert.ToInt32(sqlcmd.ExecuteScalar());

            sqlcmd.ExecuteNonQuery();
            if (a==1)
            {
                SqlCommand smd;
                smd = new SqlCommand("update [bpatientList] set Comment='" + ms2.Text + "' where PtPhone='" + ms1.Text + "'", sqlcon);

                smd.ExecuteNonQuery();
                MessageBox.Show(ms1.Text+ " select as " +ms2.Text);
            }
            else
            {
                MessageBox.Show("Invalid Mobile number");
            }
                
            }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            SqlConnection sqlcon = new SqlConnection(@"Data Source=DESKTOP-2T0JPGM\SQLEXPRESS;Initial Catalog=loginPage;Integrated Security=True");



            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand("select count (*) from  [bpatientList] where (ConName='" + patient.Text + "' and Comment='" + ms4.Text + "') and DrId='"+id.Text+"'  ", sqlcon);

            int a = Convert.ToInt32(sqlcmd.ExecuteScalar());

            sqlcmd.ExecuteNonQuery();
            if (a == 1)

            { 
            SqlCommand smd;
            smd = new SqlCommand("Delete from [bpatientList] where(ConName='" + patient.Text + "' and Comment='" + ms4.Text + "')  and DrId='" + id.Text + "'", sqlcon);

            smd.ExecuteNonQuery();
                MessageBox.Show("Successfuly Removed");
            }
            else
            {
                MessageBox.Show("Invalid Consultation Name or no more " +ms4.Text+ " Status");
            }
        }
    }
}
