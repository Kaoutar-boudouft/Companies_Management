using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace cc1zone
{
    public partial class Form1 : Form
    {
        zone z = new zone("franche", "gzenaya");
        int pos = 0;
        public void naviguer()
        {
            if (dataGridView1.RowCount != 0)
            {
                code.Text = z.Societes[pos].Code.ToString();
                nom.Text = z.Societes[pos].Nom;
                raison.Text = z.Societes[pos].Raison;
                domaine.Text = z.Societes[pos].Domaine;
                chiffre.Text = z.Societes[pos].Chiffre.ToString();
                dataGridView1.ClearSelection();
                dataGridView1.Rows[pos].Selected = true;
            }

        }
        public void actualizer()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = z.Societes;

        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            raison.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int r = z.Rechercher(int.Parse(code.Text));
            if (r != -1)
            {
                nom.Text = z.Societes[r].Nom;
                raison.Text = z.Societes[r].Raison;
                domaine.Text = z.Societes[r].Domaine;
                chiffre.Text = z.Societes[r].Chiffre.ToString();

            }
            else
            {
                MessageBox.Show("la societe correspandant n'exist pas!!");
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            code.Clear();
            nom.Clear();
            raison.SelectedIndex = 0;
            domaine.Clear();
            chiffre.Clear();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            bool r = z.Ajouter(new societe(societe.n,int.Parse(code.Text), nom.Text, raison.Text, domaine.Text, double.Parse(chiffre.Text)));
            if (r == true)
            {
                MessageBox.Show("la societe a ete bien ajoutee!");
                code.Clear();
                nom.Clear();
                raison.SelectedIndex = 0;
                domaine.Clear();
                chiffre.Clear();
                actualizer();
                pos = z.Societes.Count - 1;
                naviguer();
            }
            else
            {
                MessageBox.Show("la societe avec ce code la est existe deje!!");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            z.Modifier(int.Parse(code.Text), nom.Text, raison.Text, domaine.Text, double.Parse(chiffre.Text));
            actualizer();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            z.Supprimer(int.Parse(code.Text));
            code.Clear();
            nom.Clear();
            raison.SelectedIndex = 0;
            domaine.Clear();
            chiffre.Clear();
            actualizer();
            if (dataGridView1.RowCount > 1)
            {
                naviguer();
            }
            else if (dataGridView1.RowCount == 1)
            {
                pos = 0;
                naviguer();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pos = 0;
            naviguer();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pos = z.Societes.Count - 1;
            naviguer();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (pos > 0)
            { pos--; }
            else { pos = z.Societes.Count - 1; }
            naviguer();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (pos < z.Societes.Count - 1)
            {
                pos++;
            }
            else { pos = 0; }
            naviguer();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(@"D:\kaoutar\societes.dat", FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, z.Societes);
            fs.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(@"D:\kaoutar\societes.dat", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            List<societe> l = (List<societe>)bf.Deserialize(fs);
            fs.Close();

            dataGridView2.DataSource = null;
            dataGridView2.DataSource = l;
        }
    }
}
