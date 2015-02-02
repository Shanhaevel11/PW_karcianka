using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PW_Karcianka
{
    [Serializable]
    class Player
    {
        String nickname;

        public String Nickname
        {
            get { return nickname; }
            set { nickname = value; }
        }
        String characterClass;

        public String CharacterClass
        {
            get { return characterClass; }
            set { characterClass = value; }
        }
        System.Drawing.Image avatar;

        public System.Drawing.Image Avatar
        {
            get { return avatar; }
            set { avatar = value; }
        }
        short startHp;

        public short StartHp
        {
            get { return startHp; }
            set { startHp = value; }
        }
        short level;

        public short Level
        {
            get { return level; }
            set { level = value; }
        }

        short attack;

        public short Attack
        {
            get { return attack; }
            set { attack = value; }
        }
        short defense;

        public short Defense
        {
            get { return defense; }
            set { defense = value; }
        }

        short poison;

        public short Poison
        {
            get { return poison; }
            set { poison = value; }
        }

        short heal;

        public short Heal
        {
            get { return heal; }
            set { heal = value; }
        }

        short mana;
        public short Mana
        {
            get { return mana; }
            set { mana = value; }
        }

        List<Effect> effectsList;
        public List<Effect> EffectsList
        {
            get { return effectsList; }
            set { effectsList = value; }
        }


        public Player(String nickname, String characterClass)
        {
            this.nickname = nickname;
            this.characterClass = characterClass;
            this.level = 1;
            this.startHp = 15;
            this.attack = 0;
            this.defense = 0;
            this.poison = 0;
            this.heal = 0;
            this.mana = 3;
            effectsList = new List<Effect>();
        }
    }
}
