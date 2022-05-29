using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for doctorSearch.xaml
    /// </summary>
    public partial class doctorSearch : Window
    {
        String PtName;
        int PtAge;
        String PtGender;
        String PtPhone;

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Shutdown();
        }
        public doctorSearch( string ptName, int ptAge, string ptGender, string PtPhone)
           
        {
            this.PtName = ptName;
            this.PtAge = ptAge;
            this.PtGender =ptGender;
            this.PtPhone = PtPhone;
            InitializeComponent();

            name.Content = this.PtName;
            age.Content = this.PtAge;
            gender.Content = this.PtGender;
            phn.Content = this.PtPhone;
        }
       

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=DESKTOP-2T0JPGM\SQLEXPRESS;Initial Catalog=loginPage;Integrated Security=True");
            try
            {
                sqlcon.Open();
                SqlCommand sqlcmd2 = new SqlCommand("select count (*) from [bpatientList] where PtPhone='" + PtPhone + "' ", sqlcon);
                int ab = Convert.ToInt32(sqlcmd2.ExecuteScalar());
                sqlcmd2.ExecuteNonQuery();
                if (ab == 1)
                {
                    MessageBox.Show("This phone Number is already Exist. Please try to use different Phone Number ");
                }
                else
                {
                    SqlCommand sqlcmd = new SqlCommand("Select count (*) from [Consultation] where (ConName='" + conName.Text + "'  and id='" + drId.Text + "') and Name='" + drName.Text + "' ", sqlcon);
                    int a = Convert.ToInt32(sqlcmd.ExecuteScalar());


                    sqlcmd.ExecuteNonQuery();
                    if (a == 1)
                    {
                        SqlCommand smd;

                        smd = new SqlCommand("insert into bpatientList(DrName, DrId, ConName, PtName, PtAge, PtGender, PtPhone) values('" + drName.Text + "', '" + drId.Text + "', '" + conName.Text + "', '" + PtName + "', '" + PtAge + "', '" + PtGender + "', '" + PtPhone + "')", sqlcon);
                        // smd.Parameters.Add("@PtName",PtName);


                        smd.ExecuteNonQuery();
                        MessageBox.Show(" সাক্ষাৎ  নিশ্চিত হয়েছে  ");

                    }
                    else
                    {
                        MessageBox.Show("তথ্য যথাযথভাবে প্রদান  করা হয় নি। পুনরায়  সঠিক  তথ্য  প্রদান করে সাক্ষাৎ নিশ্চিত  করুন।");

                    }
                }
               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlcon.Close();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Patient1 p1 = new Patient1();
            p1.Show();
            this.Hide();
        }
    }
}
