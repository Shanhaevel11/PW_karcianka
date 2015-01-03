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
            
            //pictureBox1.Controls.Add(pictureBox4);
            //pictureBox2.Controls.Add(pictureBox4);
            //pictureBox3.Controls.Add(pictureBox4);



            pictureBox5.BackColor = Color.Transparent;
            pictureBox4.BackColor = Color.Transparent;
            pictureBox3.BackColor = Color.Transparent;
            pictureBox2.BackColor = Color.Transparent;
            pictureBox1.BackColor = Color.Transparent;

            pictureBox1.Image = Image.FromFile(Program.baseDirectory + "\\Images\\background\\demonic.png");
            pictureBox2.Image = Image.FromFile(Program.baseDirectory + "\\Images\\UI\\LeftPanel.png");
            pictureBox3.Image = Image.FromFile(Program.baseDirectory + "\\Images\\UI\\RightPanel_2.png");

        }


        private void buttonImgReload_Click(object sender, EventArgs e)
        {
            if (switchImg == false)
            {
               
                //uncomment line belov if problem with load image
                //label1.Text = baseDirectory;
                pictureBox1.Image = Image.FromFile(Program.baseDirectory + "\\Images\\background\\end2.png");
                switchImg = true;
            }
            else
            {
                pictureBox1.Image = Image.FromFile(Program.baseDirectory + "\\Images\\background\\end1.png");
                switchImg = false;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String[] cardNames = new String[2];
            cardNames[0] = "karta1.png";
            cardNames[1] = "karta1.png";
            if (switchCardsNum == true)
            {
                cardNames[3] = "karta.png";
                pictureBox6.Image = cl.loadCards(cardNames);
                
            }
            else
            {
                pictureBox6.Image = cl.loadCards(cardNames);
                //switchCardsNum = true;
            }
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {

        }



    }
}
