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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-U561OEJ;Initial Catalog=bibliotheque;Integrated Security=True;Pooling=False");
        SqlCommand Cmd = new SqlCommand();
        DataSet ds = new DataSet();
        SqlDataAdapter da;
        private void Form1_Load(object sender, EventArgs e)
        {
            
            // TODO: This line of code loads data into the 'bibliothequeDataSet1.Adherent' table. You can move, or remove it, as needed.
            this.adherentTableAdapter.Fill(this.bibliothequeDataSet1.Adherent);
            // TODO: This line of code loads data into the 'bibliothequeDataSet.Thème' table. You can move, or remove it, as needed.
            this.thèmeTableAdapter.Fill(this.bibliothequeDataSet.Thème);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f = new Form2();
            f.Show();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ds.Tables["Livre"] != null)
            {
                ds.Tables["Livre"].Clear();
            }

            string req = "select * from Livre where CodeTh = " + comboBox1.SelectedValue + "";
            da = new SqlDataAdapter(req, con);
            ds = new DataSet();
            da.Fill(ds, "Livre");



            listBox1.DataSource = null;
            listBox1.Items.Clear();

            listBox1.DataSource = ds.Tables[0];

            //listBox1.DataSource = ds.Tables["Livre1"];

            listBox1.DisplayMember = "Titre";
            listBox1.ValueMember = "CodeL";

        }
        public void insertion()
        {

            con.Open();
            string req = "insert into Emprunt values (" + comboBox1.SelectedValue + "," + listBox1.SelectedValue + ",'" + dateTimePicker1.Value + "',null)";
            Cmd = new SqlCommand(req, con);
            Cmd.ExecuteNonQuery();

            MessageBox.Show("ajoute bien fait");

            con.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            da = new SqlDataAdapter("select Titre,CodeA,Date_Emprunt,Date_Retour from Livre join Emprunt on Livre.CodeL = Emprunt.CodeL ", con);
            

            if (ds.Tables["Emprunt"] != null)
            {
                ds.Tables["Emprunt"].Clear();
            }


            da.Fill(ds, "Emprunt");

            dataGridView1.DataSource = ds.Tables["Emprunt"];

            dataGridView1.Columns[1].Visible = false;


            insertion();

        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string req = "select * from Adherent where CodeA = " + comboBox1.SelectedValue + "";
            da = new SqlDataAdapter(req, con);




            if (ds.Tables["Adherent2"] != null)
            {
                ds.Tables["Adherent2"].Clear();
            }

            da.Fill(ds, "Adherent2");

            textBox1.Text = " ";
            textBox1.Text = ds.Tables["Adherent2"].Rows[0][1].ToString();
        }
    }
}
