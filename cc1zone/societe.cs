using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace cc1zone
{
    [Serializable]
    public class societe
    {
        public static int n = 1;
        int numero;
        int code;
        string nom;
        string raison;
        string domaine;
        double chiffre;

        public int Numero
        {
            get { return numero; }
        }
        public int Code
        {
            get { return code; }
            set
            {
                if (value > 0)
                {
                    code = value;
                }
                else
                {
                    MessageBox.Show("le code doit etre positif!");
                }
            }
        }

        public string Raison
        {
            get { return raison; }
            set
            {
                Regex r = new Regex(@"^(SAS|SARL|SA| SNC)$");
                if (r.IsMatch(value))
                {
                    raison = value;
                }
                else
                {
                    MessageBox.Show(" La raison sociale de la société doit avoir les valeurs : SAS (Société anonyme simplifiée), SARL(Société à responsabilité limitée), SA(Sociétéanonyme), SNC(Société en nom collectif).");
                }
            }
        }

        public string Nom { get => nom; set => nom = value; }
        public string Domaine { get => domaine; set => domaine = value; }
        public double Chiffre { get => chiffre; set => chiffre = value; }

        public societe() { }
        public societe(int numero, int code, string nom, string raison, string domaine, double chiffre)
        {
            this.code = code;
            this.nom = nom;
            this.raison = raison;
            this.domaine = domaine;
            this.chiffre = chiffre;
            this.numero = n;
            n++;
        }

        public override string ToString()
        {
            return "Société [" + code + "] : [" + nom + "," + raison + "," + domaine + "," + chiffre + "].";
        }



    }
}
