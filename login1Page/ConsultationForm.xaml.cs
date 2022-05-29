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
    /// Interaction logic for ConsultationForm.xaml
    /// </summary>
    public partial class ConsultationForm : Window
    {
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Shutdown();
        }
        public ConsultationForm()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            SqlConnection sqlcon = new SqlConnection(@"Data Source=DESKTOP-2T0JPGM\SQLEXPRESS;Initial Catalog=loginPage;Integrated Security=True");
            try
            {
                sqlcon.Open();
                SqlCommand sqlcmd = new SqlCommand("select count (*) from [LoginPage] where id='"+idno1.Text+"' and UserName='"+consname.Text+"' and Dept='"+sepciality.Text+"'", sqlcon);
                int a = Convert.ToInt32(sqlcmd.ExecuteScalar());
                sqlcmd.ExecuteNonQuery();
                if(a==1)
                {
                    if(idno1.Text=="" || consname.Text=="" || name.Text=="" || time.Text=="" || sepciality.Text=="" || fee.Text=="" || day.Text=="" || location.Text=="")
                    {
                        MessageBox.Show("Information Missing. Please check");
                    }
                    else
                    {
                        SqlCommand smd;

                        smd = new SqlCommand("insert into Consultation (id,Name, ConName, ConTime, ConLocation, ConSpeciality, ConFee, ConDay) values('" + idno1.Text + "',@Name, @ConName,@ConTime, @ConLocation, @ConSpeciality , @ConFee, @ConDay)", sqlcon);

                        smd.Parameters.Add("@Name", consname.Text);
                        smd.Parameters.Add("@ConName", name.Text);
                        smd.Parameters.Add("@ConTime", time.Text);
                        smd.Parameters.Add("@ConLocation", location.Text);
                        smd.Parameters.Add("@ConSpeciality", sepciality.Text);
                        smd.Parameters.Add("@ConFee", fee.Text);
                        smd.Parameters.Add("@ConDay", day.Text);

                        smd.ExecuteNonQuery();
                    }
                   
                }
                else
                {
                    MessageBox.Show("Your provided information is not matched with your profile Information");
                }


               



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlcon.Close();
                MessageBox.Show("Information Submitted");
            }
        }

        private void TextBox_TextChanged_2(object sender, TextChangedEventArgs e)
        {

        }

        private void Frame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            loginpage1 lg1 = new loginpage1();
            lg1.Show();
            this.Hide();
        }

        private void idno1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void time_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
