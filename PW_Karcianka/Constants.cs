﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PW_Karcianka
{
    class Constants
    {
        public static List <Card> Deck;

        public static void initConstants()
        {
            Deck = new List<Card>();
            Card attack = new Card();
            attack.cardPicture = Image.FromFile(Program.baseDirectory + "\\Images\\Cards\\attack.png");
            attack.cost = 5;
            attack.cardActivity = new Activity(0, null, "opp", 5);
            Card attack1 = new Card();
            attack1.cardPicture = Image.FromFile(Program.baseDirectory + "\\Images\\Cards\\attack.png");
            attack1.cost = 1;
            attack1.cardActivity = new Activity(0, null, "opp", 1);
            Card attack2 = new Card();
            attack2.cardPicture = Image.FromFile(Program.baseDirectory + "\\Images\\Cards\\attack.png");
            attack2.cost = 7;
            attack2.cardActivity = new Activity(0, null, "opp", 8);
            Card attack3 = new Card();
            attack3.cardPicture = Image.FromFile(Program.baseDirectory + "\\Images\\Cards\\attack.png");
            attack3.cost = 3;
            attack3.cardActivity = new Activity(0, null, "own", 3);
            Card defup = new Card();
            defup.cardPicture = Image.FromFile(Program.baseDirectory + "\\Images\\Cards\\defense.png");
            defup.cost = 6;
            defup.cardActivity = new Activity(2, null, "own", 3);
            Card defup1 = new Card();
            defup1.cardPicture = Image.FromFile(Program.baseDirectory + "\\Images\\Cards\\defense.png");
            defup1.cost = 4;
            defup1.cardActivity = new Activity(2, null, "own", 2);
            Card defup2 = new Card();
            defup2.cardPicture = Image.FromFile(Program.baseDirectory + "\\Images\\Cards\\defense.png");
            defup2.cost = 2;
            defup2.cardActivity = new Activity(2, null, "own", 1);
            Card defdown = new Card();
            defdown.cardPicture = Image.FromFile(Program.baseDirectory + "\\Images\\Cards\\defense_down.png");
            defdown.cost = 2;
            defdown.cardActivity = new Activity(3, null, "opp", 1);
            Card defdown1 = new Card();
            defdown1.cardPicture = Image.FromFile(Program.baseDirectory + "\\Images\\Cards\\defense_down.png");
            defdown1.cost = 4;
            defdown1.cardActivity = new Activity(3, null, "opp", 2);
            Card defdown2 = new Card();
            defdown2.cardPicture = Image.FromFile(Program.baseDirectory + "\\Images\\Cards\\defense_down.png");
            defdown2.cost = 6;
            defdown2.cardActivity = new Activity(3, null, "opp", 3);
            Card heal = new Card();
            heal.cardPicture = Image.FromFile(Program.baseDirectory + "\\Images\\Cards\\heal.png");
            heal.cost = 1;
            heal.cardActivity = new Activity(1, null, "opp", 2);
            Card heal1 = new Card();
            heal1.cardPicture = Image.FromFile(Program.baseDirectory + "\\Images\\Cards\\heal.png");
            heal1.cost = 3;
            heal1.cardActivity = new Activity(1, null, "opp", 5);
            Card heal2 = new Card();
            heal2.cardPicture = Image.FromFile(Program.baseDirectory + "\\Images\\Cards\\heal.png");
            heal2.cost = 6;
            heal2.cardActivity = new Activity(1, null, "opp", 8);
            Card powup = new Card();
            powup.cardPicture = Image.FromFile(Program.baseDirectory + "\\Images\\Cards\\power_up.png");
            powup.cost = 6;
            powup.cardActivity = new Activity(4, null, "own", 3);
            Card powup1 = new Card();
            powup1.cardPicture = Image.FromFile(Program.baseDirectory + "\\Images\\Cards\\power_up.png");
            powup1.cost = 4;
            powup1.cardActivity = new Activity(4, null, "own", 2);
            Card powup2 = new Card();
            powup2.cardPicture = Image.FromFile(Program.baseDirectory + "\\Images\\Cards\\power_up.png");
            powup2.cost = 2;
            powup2.cardActivity = new Activity(4, null, "own", 1);
            Card powdown = new Card();
            powdown.cardPicture = Image.FromFile(Program.baseDirectory + "\\Images\\Cards\\power_down.png");
            powdown.cost = 2;
            powdown.cardActivity = new Activity(5, null, "opp", 1);
            Card powdown1 = new Card();
            powdown1.cardPicture = Image.FromFile(Program.baseDirectory + "\\Images\\Cards\\power_down.png");
            powdown1.cost = 4;
            powdown1.cardActivity = new Activity(5, null, "opp", 2);
            Card powdown2 = new Card();
            powdown2.cardPicture = Image.FromFile(Program.baseDirectory + "\\Images\\Cards\\power_down.png");
            powdown2.cost = 6;
            powdown2.cardActivity = new Activity(5, null, "opp", 2);
            Card purify = new Card();
            purify.cardPicture = Image.FromFile(Program.baseDirectory + "\\Images\\Cards\\purify.png");
            purify.cost = 5;
            purify.cardActivity = new Activity(6, null, "opp", 2);
            Card poison = new Card();
            poison.cardPicture = Image.FromFile(Program.baseDirectory + "\\Images\\Cards\\poison.png");
            poison.cost = 5;
            poison.cardActivity = new Activity(-1, new Effect("opp",-2,4), "opp", 2);
            Card regeneration = new Card();
            regeneration.cardPicture = Image.FromFile(Program.baseDirectory + "\\Images\\Cards\\heal.png");
            regeneration.cost = 7;
            regeneration.cardActivity = new Activity(-1, new Effect("own", 3, 4), "opp", 2);
            Card regeneration2 = new Card();
            regeneration2.cardPicture = Image.FromFile(Program.baseDirectory + "\\Images\\Cards\\heal.png");
            regeneration2.cost = 3;
            regeneration2.cardActivity = new Activity(-1, new Effect("own", 1, 7), "opp", 2);

            Deck.Add(attack);
            Deck.Add(attack);
            Deck.Add(attack);
            Deck.Add(attack1);
            Deck.Add(attack1);
            Deck.Add(attack2);
            Deck.Add(attack2);
            Deck.Add(attack3);
            Deck.Add(defup);
            Deck.Add(defup1);
            Deck.Add(defup2);
            Deck.Add(defdown);
            Deck.Add(defdown1);
            Deck.Add(defdown2);
            Deck.Add(purify);
            Deck.Add(purify);
            Deck.Add(purify);
            Deck.Add(poison);
            Deck.Add(poison);
            Deck.Add(regeneration);
            Deck.Add(regeneration2);
            Deck.Add(heal);
            Deck.Add(heal);
            Deck.Add(heal1);
            Deck.Add(heal1);
            Deck.Add(heal2);
            Deck.Add(powup);
            Deck.Add(powup1);
            Deck.Add(powup2);
            Deck.Add(powdown);
            Deck.Add(powdown1);
            Deck.Add(powdown2);
            }
    }
}
