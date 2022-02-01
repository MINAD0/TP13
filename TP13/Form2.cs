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
namespace TP13
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-U561OEJ;Initial Catalog=bibliotheque;Integrated Security=True;Pooling=False");
        SqlCommand Cmd = new SqlCommand();
        DataSet ds = new DataSet();
        SqlDataAdapter da;
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bibliothequeDataSet2.Adherent' table. You can move, or remove it, as needed.
            this.adherentTableAdapter.Fill(this.bibliothequeDataSet2.Adherent);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public void aff()
        {

            dataGridView1.DataSource = null;
            da = new SqlDataAdapter("select CodeA,Livre.CodeL,Titre,Date_Emprunt,Date_Retour from Livre join Emprunt on Livre.CodeL = Emprunt.CodeL ", con);


            da.Fill(ds, "Emprunt");

            dataGridView1.DataSource = ds.Tables["Emprunt"];

            dataGridView1.Columns[0].Visible = false;

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string req = "select * from Adherent where CodeA = " + comboBox1.SelectedValue + "";
            da = new SqlDataAdapter(req, con);




            if (ds.Tables["Adherent"] != null)
            {
                ds.Tables["Adherent"].Clear();
            }

            da.Fill(ds, "Adherent");

            textBox1.Text = " ";
            textBox1.Text = ds.Tables["Adherent"].Rows[0][1].ToString();

            aff();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        
            
            da = new SqlDataAdapter("select * from Emprunt", con);
            da.Fill(ds, "Emprunt");

            SqlCommandBuilder scb = new SqlCommandBuilder(da);
            da.Update(ds, "Emprunt");
        }
    }
}
