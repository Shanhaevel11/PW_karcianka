using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PW_Karcianka
{
    [Serializable]
    class Card
    {
        public short cost;
        public Image cardPicture;
        public Activity cardActivity;
    }
}
