using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class FormGiris : Form
    {
        public FormGiris()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-23T2RIK\\SQLEXPRESS;Initial Catalog=musadeneme;Integrated Security=True");

        private void btngiris_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("Select * from Table_Yonetici where KullaniciAd=@p1 and Sifre=@p2",baglanti);
            cmd.Parameters.AddWithValue("@p1", txtkullanıcıad.Text);
            cmd.Parameters.AddWithValue("@p2", txtsifre.Text);
            SqlDataReader reader = cmd.ExecuteReader();
            if(reader.Read())
            {
                Form1 frm= new Form1();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı veya Şifre!");
            }
            baglanti.Close();
        }
    }
}
