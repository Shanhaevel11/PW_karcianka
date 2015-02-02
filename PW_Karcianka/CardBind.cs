using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PW_Karcianka
{
    class CardBind
    {
        private Card c;

        public Card C
        {
            get { return c; }
            set { c = value; }
        }
        private PictureBox pb;

        public PictureBox Pb
        {
            get { return pb; }
            set { pb = value; }
        }
        public CardBind(Card cd, PictureBox p)
        {
            c = cd;
            pb = p;
        }
    }
}
