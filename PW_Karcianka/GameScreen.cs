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
        short switchImg = 0;
        bool setAutoLabel = false;
        bool switchCardsNum = false;
        bool enablePlayCards = true;
        CardLoader cl = new CardLoader();
        List<CardBind> cbList = new List<CardBind>();
        public delegate void enableButtonCallback();
        int deckIndex = 0;

        private List<Card> Shuffle(List<Card> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
            return list;
        }

        private void incDeckIndex()
        {
            deckIndex++;
            if (deckIndex == Constants.Deck.Count)
            {
                Shuffle(Constants.Deck);
                deckIndex = 0;
            }
        }

        public GameScreen()
        {
            InitializeComponent();
            ownerClass.Text = "warrior";
            oppClass.Text = "warrior";
            Communicator.OnUpdateGame += new Communicator.GameUpdateHandler(updateGame);
            pictureBox1.Controls.Add(pictureBox5);
            
            //pictureBox1.Controls.Add(pictureBox4);
            //pictureBox2.Controls.Add(pictureBox4);
            //pictureBox3.Controls.Add(pictureBox4);

            //picturebox 14,6 (fuuu 6) ,15,16: 14 - lewy stoi, 6 - prawy stoi, 15 - lewy atakuje, 16 - prawy atakuje 

            pictureBox1.Controls.Add(pictureBox14);
            //pictureBox1.Controls.Add(pictureBox6);
            //pictureBox1.Controls.Add(pictureBox15);
            //pictureBox1.Controls.Add(pictureBox16);

            //pictureBox14.Controls.Add(pictureBox15);
            //pictureBox14.Controls.Add(pictureBox16);
            pictureBox14.Controls.Add(pictureBox6);

            pictureBox6.Controls.Add(pictureBox15);
            //pictureBox6.Controls.Add(pictureBox16);
            //pictureBox6.Controls.Add(pictureBox14);

            pictureBox15.Controls.Add(pictureBox16);

            pictureBox14.Image = Image.FromFile(Program.baseDirectory + "\\Images\\Blanks\\stand_L_blank_4.gif");
            pictureBox6.Image = Image.FromFile(Program.baseDirectory + "\\Images\\Blanks\\stand_R_blank_4.gif");

            pictureBox14.BackColor = Color.Transparent;
            pictureBox6.BackColor = Color.Transparent;
            pictureBox15.BackColor = Color.Transparent;
            pictureBox16.BackColor = Color.Transparent;

            pictureBox5.BackColor = Color.Transparent;
            pictureBox4.BackColor = Color.Transparent;
            pictureBox3.BackColor = Color.Transparent;
            pictureBox2.BackColor = Color.Transparent;
            pictureBox1.BackColor = Color.Transparent;

            pictureBox1.Image = Image.FromFile(Program.baseDirectory + "\\Images\\background\\demonic.png");
            pictureBox2.Image = Image.FromFile(Program.baseDirectory + "\\Images\\UI\\LeftPanel.png");
            pictureBox3.Image = Image.FromFile(Program.baseDirectory + "\\Images\\UI\\RightPanel_2.png");
            pictureBox4.Image = Image.FromFile(Program.baseDirectory + "\\Images\\UI\\BottomPanel.png");

            // picturebox 7 - 13: Miejsca na karty

            pictureBox7.Image = Image.FromFile(Program.baseDirectory + "\\Images\\UI\\EmptyCard.png");
            pictureBox8.Image = Image.FromFile(Program.baseDirectory + "\\Images\\UI\\EmptyCard.png");
            pictureBox9.Image = Image.FromFile(Program.baseDirectory + "\\Images\\UI\\EmptyCard.png");
            pictureBox10.Image = Image.FromFile(Program.baseDirectory + "\\Images\\UI\\EmptyCard.png");
            pictureBox11.Image = Image.FromFile(Program.baseDirectory + "\\Images\\UI\\EmptyCard.png");
            pictureBox12.Image = Image.FromFile(Program.baseDirectory + "\\Images\\UI\\EmptyCard.png");
            pictureBox13.Image = Image.FromFile(Program.baseDirectory + "\\Images\\UI\\EmptyCard.png");

            //picturebox 14,6 (fuuu 6) ,15,17: 14 - lewy stoi, 6 - prawy stoi, 15 - lewy atakuje, 16 - prawy atakuje 
            //(zrobione tak, by ataki zawsze były NAD stojącymi. Jak nie atakuje to dany picturebox powinien być niewidoczny)
            //Są do nich przygotowane blanki. Jak zobaczysz to będziesz wiedział które to które.
            // patrz niżej :P

            pictureBox14.Image = Image.FromFile(Program.baseDirectory + "\\Images\\Blanks\\stand_L_3.gif");
            pictureBox6.Image = Image.FromFile(Program.baseDirectory + "\\Images\\Blanks\\wtf.png"); //wtf to "pusty" obrazek, bo nie wiem jak do cholery wyszyścić ten co jest :P
            pictureBox15.Image = Image.FromFile(Program.baseDirectory + "\\Images\\Blanks\\wtf.png");
            pictureBox16.Image = Image.FromFile(Program.baseDirectory + "\\Images\\Blanks\\attack_R_1050.gif");

        }


        private void buttonImgReload_Click(object sender, EventArgs e)
        {
            if (switchImg == 0)
            {
               
                //uncomment line belov if problem with load image
                //label1.Text = baseDirectory;
                pictureBox1.Image = Image.FromFile(Program.baseDirectory + "\\Images\\background\\end2.png");
                switchImg = 1;
                return;
            }
            if (switchImg == 1)
            {

                //uncomment line belov if problem with load image
                //label1.Text = baseDirectory;
                pictureBox1.Image = Image.FromFile(Program.baseDirectory + "\\Images\\background\\end1.png");
                switchImg = 2;
                return;
            }
            if (switchImg == 2)
            {
                    //uncomment line belov if problem with load image
                    //label1.Text = baseDirectory;
                    pictureBox1.Image = Image.FromFile(Program.baseDirectory + "\\Images\\background\\demonic.png");
                    switchImg = 0;
                    return;
            }

        }

        private void setLabels()
        {
            if (Communicator.Game.players[0].Nickname.Equals(Communicator.owner.Nickname))
            {
                ownerClass.Text = Communicator.Game.players[0].CharacterClass;
                ownerHP.Text = Communicator.Game.players[0].StartHp.ToString();
                ownerLevel.Text = Communicator.Game.players[0].Level.ToString();
                ownerName.Text = Communicator.Game.players[0].Nickname;
                OwnerAtt.Text = Communicator.Game.players[0].Attack.ToString();
                OwnerDef.Text = Communicator.Game.players[0].Defense.ToString();
                OwnerPoison.Text = Communicator.Game.players[0].Poison.ToString();
                OwnerHeal.Text = Communicator.Game.players[0].Heal.ToString();
                ownerMana.Text = Communicator.Game.players[0].Mana.ToString();
                oppClass.Text = Communicator.Game.players[1].CharacterClass;
                oppHp.Text = Communicator.Game.players[1].StartHp.ToString();
                oppLevel.Text = Communicator.Game.players[1].Level.ToString();
                oppName.Text = Communicator.Game.players[1].Nickname;
                OppAttack.Text = Communicator.Game.players[1].Attack.ToString();
                OppDef.Text = Communicator.Game.players[1].Defense.ToString();
                OppPoison.Text = Communicator.Game.players[1].Poison.ToString();
                OppHeal.Text = Communicator.Game.players[1].Heal.ToString();
                oppMana.Text = Communicator.Game.players[1].Mana.ToString();
                if (setAutoLabel == false)
                {
                    Communicator.opponent = Communicator.Game.players[1];
                    Communicator.owner = Communicator.Game.players[0];
                }
                else
                {
                    setAutoLabel = false;
                }
            }
            else
            {
                ownerClass.Text = Communicator.Game.players[1].CharacterClass;
                ownerHP.Text = Communicator.Game.players[1].StartHp.ToString();
                ownerLevel.Text = Communicator.Game.players[1].Level.ToString();
                ownerName.Text = Communicator.Game.players[1].Nickname;
                OwnerAtt.Text = Communicator.Game.players[1].Attack.ToString();
                OwnerDef.Text = Communicator.Game.players[1].Defense.ToString();
                OwnerPoison.Text = Communicator.Game.players[1].Poison.ToString();
                OwnerHeal.Text = Communicator.Game.players[1].Heal.ToString();
                ownerMana.Text = Communicator.Game.players[1].Mana.ToString();
                oppClass.Text = Communicator.Game.players[0].CharacterClass;
                oppHp.Text = Communicator.Game.players[0].StartHp.ToString();
                oppLevel.Text = Communicator.Game.players[0].Level.ToString();
                oppName.Text = Communicator.Game.players[0].Nickname;
                OppAttack.Text = Communicator.Game.players[0].Attack.ToString();
                OppDef.Text = Communicator.Game.players[0].Defense.ToString();
                OppPoison.Text = Communicator.Game.players[0].Poison.ToString();
                OppHeal.Text = Communicator.Game.players[0].Heal.ToString();
                oppMana.Text = Communicator.Game.players[0].Mana.ToString();
                if (setAutoLabel == false)
                {
                    Communicator.opponent = Communicator.Game.players[0];
                    Communicator.owner = Communicator.Game.players[1];
                }
                else
                {
                    setAutoLabel = false;
                }
            }
        }

        public void startGame()
        {
            Communicator.Receive();
            setLabels();
            if (Communicator.Game.turn != Communicator.owner.Nickname)
            {
                button2.Enabled = false;
                enablePlayCards = false;
                turnLabel.Text = "Trwa tura przeciwnika";
            }
            else
            {
                turnLabel.Text = "Trwa twoja tura";
            }
            cbList.Clear();
            deckIndex = 0;
            Constants.Deck = Shuffle(Constants.Deck);
            addCard(Constants.Deck.ElementAt(deckIndex), pictureBox7);
            addCard(Constants.Deck.ElementAt(deckIndex), pictureBox8);
            addCard(Constants.Deck.ElementAt(deckIndex), pictureBox9);
            addCard(Constants.Deck.ElementAt(deckIndex), pictureBox10);
            addCard(Constants.Deck.ElementAt(deckIndex), pictureBox11);
            addCard(Constants.Deck.ElementAt(deckIndex), pictureBox12);
        }

        private void addCard(Card c, PictureBox pb)
        {
            cbList.Add(new CardBind(c, pb));
            pb.Image = c.cardPicture;
            incDeckIndex();
        }

        /*private void enableButton2()
        {
            if (this.button2.InvokeRequired)
            {
                enableButtonCallback sbec = new enableButtonCallback(enableButton2);
                button2.Invoke(sbec, new object[] { this.button2, Enabled, true });
            }
            else
            {
                button2.Enabled = true;
            }
        }*/

        public void updateGame(object sender, EventArgs e)
        {
            if(Communicator.Game.typeOfChange==2){
                enablePlayCards = true;
                button2.Enabled = true;
                turnLabel.Text = "Trwa twoja tura";
                Communicator.Game.typeOfChange = 0;
                setLabels();
                this.Refresh();
            }
            if (Communicator.Game.typeOfChange == 1)
            {
                setLabels();
                //TODO: Animation code
            }
            //Communicator.Receive();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String[] cardNames = new String[2];
            cardNames[0] = "karta1.png";
            cardNames[1] = "karta1.png";
            if (switchCardsNum == true)
            {
                cardNames[3] = "karta.png";
                //pictureBox6.Image = cl.loadCards(cardNames);
                
            }
            else
            {
                //pictureBox6.Image = cl.loadCards(cardNames);
                //switchCardsNum = true;
            }
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {

        }

        private void clickOnCardBox(PictureBox pb)
        {
            if (enablePlayCards == false)
            {
                return;
            }
            foreach(CardBind cb in cbList){
                if (pb == cb.Pb)
                {
                    if (Card.playCard(cb.C, Communicator.owner, Communicator.opponent) == true)
                    {
                        cbList.Remove(cb);
                        pb.Image = Image.FromFile(Program.baseDirectory + "\\Images\\UI\\EmptyCard.png");
                        Communicator.Game.typeOfChange = 1;
                        Communicator.sendGame();
                        setAutoLabel = true;
                        setLabels();
                        break;
                    }
                    else
                    {
                        MessageBox.Show("Nie posiadasz ilości many potrzebnej do zagrania karty. (Wymagana ilość to "+cb.C.cost+" )", "Komunikat");
                    }
                }
            }
        }

        private void GameScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            clickOnCardBox(sender as PictureBox);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            clickOnCardBox(sender as PictureBox);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            enablePlayCards = false;
            bool endloop = false;
            turnLabel.Text = "Trwa tura przeciwnika";
            Communicator.Game.turn = Communicator.opponent.Nickname;
            Communicator.owner.Mana += 3;
            Communicator.Game.typeOfChange = 2;
            Communicator.opponent.StartHp-=Communicator.opponent.Poison;
            Communicator.opponent.StartHp+=Communicator.opponent.Heal;
            foreach(Effect effect in Communicator.opponent.EffectsList){
                effect.Duration--;
            }
            while (endloop == false)
            {
                endloop = true;
                foreach (Effect effect in Communicator.opponent.EffectsList)
                {
                    if (effect.Duration == 0)
                    {
                        endloop = false;
                        if (effect.Power > 0)
                        {
                            Communicator.opponent.Heal -= effect.Power;
                        }
                        else
                        {
                            Communicator.opponent.Poison += effect.Power;
                        }
                        Communicator.opponent.EffectsList.Remove(effect);
                        break;
                    }
                }
            }
            Communicator.sendGame();
            setAutoLabel = true;
            setLabels();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            clickOnCardBox(sender as PictureBox);
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            clickOnCardBox(sender as PictureBox);
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            clickOnCardBox(sender as PictureBox);
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            clickOnCardBox(sender as PictureBox);
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            clickOnCardBox(sender as PictureBox);
        }



    }
}
