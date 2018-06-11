using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace ISET2018_MesControles
{
    public partial class BoutonColore: Button
    {
        private Color cGauche = Color.LightGreen, cDroit = Color.DarkBlue;
        private int tGauche = 64, tDroit = 64;
        [Category("Apparence")]
        [Description("Couleur sur la gauche du bouton")]
        public Color CouleurGaucheBouton
        {
            get { return cGauche;  }
            set { cGauche = value; Invalidate(); }
        }
        [Category("Apparence")]
        [Description("Couleur sur la droite du bouton")]
        public Color CouleurDroiteBouton
        {
            get { return cDroit; }
            set { cDroit = value; Invalidate(); }
        }
        [Category("Apparence")]
        [Description("Transparence de la couleur sur la gauche du bouton")]
        public int TransparenceGaucheBouton
        {
            get { return tGauche; }
            set
            {
                if (value < 0) tGauche = 0;
                else if (value > 255) tGauche = 255;
                else tGauche = value;
                Invalidate();
            }
        }
        [Category("Apparence")]
        [Description("Transparence de la couleur sur la droite du bouton")]
        public int TransparenceDroiteBouton
        {
            get { return tDroit; }
            set
            {
                if (value < 0) tDroit = 0;
                else if (value > 255) tDroit = 255;
                else tDroit = value;
                Invalidate();
            }
        }

        public BoutonColore()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            Color cg = Color.FromArgb(TransparenceGaucheBouton, CouleurGaucheBouton);
            Color cd = Color.FromArgb(TransparenceDroiteBouton, CouleurDroiteBouton);
            Brush br = new LinearGradientBrush(ClientRectangle, cg, cd, 0f);
            pevent.Graphics.FillRectangle(br, ClientRectangle);
        }
    }
}
