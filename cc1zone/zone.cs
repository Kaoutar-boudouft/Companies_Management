using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace cc1zone
{
    [Serializable]
    public class zone
    {
        string nom;
        List<societe> societes;
        string adresse;


        public string Nom { get => nom; set => nom = value; }
        public string Adresse { get => adresse; set => adresse = value; }
        public List<societe> Societes { get => societes; set => societes = value; }

        public zone() { }
        public zone(string nom, string adresse)
        {
            this.nom = nom;
            this.adresse = adresse;
            this.societes = new List<societe>();

        }

        public int Rechercher(int code)
        {
            for (int i = 0; i < societes.Count; i++)
            {
                if (societes[i].Code == code)
                {
                    return i;
                }
            }
            return -1;
        }

        public bool Ajouter(societe societe)
        {
            int r = Rechercher(societe.Code);
            if (r == -1)
            {
                societes.Add(societe);
                return true;
            }
            return false;
        }

        public void Supprimer(int code)
        {
            int r = Rechercher(code);
            if (r != -1)
            {
                societes.RemoveAt(r);
                MessageBox.Show("la societe a ete supprimee!");
            }
            else
            {
                MessageBox.Show("la societe n'existe pas dans la zone!!");
            }
        }

        public void Modifier(int code, string nom, string raison_sociale, string domaine, double chiffre_affaire)
        {
            int r = Rechercher(code);
            if (r != -1)
            {
                societes[r].Nom = nom;
                societes[r].Raison = raison_sociale;
                societes[r].Domaine = domaine;
                societes[r].Chiffre = chiffre_affaire;

                MessageBox.Show("la societe a ete modifier!");

            }
            else
            {
                MessageBox.Show("la societe n'existe pas dans la zone!!");
            }
        }

        public void Chercher(string raison_sociale)
        {
            string s = "";
            foreach (societe so in societes)
            {
                if (so.Raison == raison_sociale)
                {
                    s = s + "\n" + so.ToString();
                }
            }
            if (s != "")
            {
                MessageBox.Show(s);
            }
            else
            {
                MessageBox.Show("il n'existe auccun societe avec ce raison la!!");
            }
        }

        public int Chiffre_Affaire_Plus_Bas()
        {
            double ch = societes[0].Chiffre;
            int c = societes[0].Code;
            foreach (societe s in societes)
            {
                if (s.Chiffre < c)
                {
                    ch = s.Chiffre;
                    c = s.Code;
                }
            }
            return c;
        }

        public List<societe> Trier()
        {
            List<societe> l = societes;
            societe s;
            for (int i = 0; i < societes.Count - 1; i++)
            {
                for (int j = i; j < societes.Count; j++)
                {
                    if (l[i].Chiffre > l[j].Chiffre)
                    {
                        s = l[i];
                        l[i] = l[j];
                        l[j] = s;
                    }
                }
            }
            return l;
        }

        public override string ToString()
        {
            string s = "le nom de la zone est: " + nom + "l'adresse de la zone est: " + adresse + "les societes de cette zone sont: ";
            foreach (societe so in societes)
            {
                s = s + " " + so.ToString();
            }
            return s;
        }

    }
}
