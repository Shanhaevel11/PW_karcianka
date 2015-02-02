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

        public Player(String nickname, String characterClass)
        {
            this.nickname = nickname;
            this.characterClass = characterClass;
            this.level = 1;
            this.startHp = 15;
        }
    }
}
