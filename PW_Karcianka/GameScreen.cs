using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PW_Karcianka
{
    public partial class GameScreen : Form
    {
        bool switchImg = false;
        bool switchCardsNum = false;
        CardLoader cl = new CardLoader();
        public GameScreen()
        {
            InitializeComponent();
            pictureBox1.Controls.Add(pictureBox5);
            pictureBox5.BackColor = Color.Transparent;
            pictureBox4.BackColor = Color.Transparent;
            pictureBox3.BackColor = Color.Transparent;
            pictureBox2.BackColor = Color.Transparent;
            pictureBox1.BackColor = Color.Transparent;
        }


        private void buttonImgReload_Click(object sender, EventArgs e)
        {
            if (switchImg == false)
            {
               
                //uncomment line belov if problem with load image
                //label1.Text = baseDirectory;
                pictureBox1.Image = Image.FromFile(Program.baseDirectory + "\\Images\\takietam.gif");
                switchImg = true;
            }
            else
            {
                pictureBox1.Image = Image.FromFile(Program.baseDirectory + "\\Images\\bck.jpg");
                switchImg = false;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String[] cardNames = new String[2];
            cardNames[0] = "karta.png";
            cardNames[1] = "karta.png";
            //cardNames[2] = "karta.png";
            if (switchCardsNum == true)
            {
                cardNames[3] = "karta.png";
                cardNames[4] = "karta.png";
                pictureBox4.Image = cl.loadCards(cardNames);
                
            }
            else
            {
                pictureBox4.Image = cl.loadCards(cardNames);
                //switchCardsNum = true;
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }
    }
}
