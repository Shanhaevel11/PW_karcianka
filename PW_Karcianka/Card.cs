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

        public static bool playCard(Card c, Player owner, Player opponent)
        {
            if (c.cost <= owner.Mana)
            {
                owner.Mana -= c.cost;
                switch (c.cardActivity.Type)
                {
                    case 0:
                        short result = c.cardActivity.Power;
                        result+=owner.Attack;
                        result-=opponent.Defense;
                        if(result>0){
                            opponent.StartHp -= result;
                        }
                        break;
                    case 1:
                        owner.StartHp += c.cardActivity.Power;
                        break;
                    case 2:
                        owner.Defense += c.cardActivity.Power;
                        break;
                    case 3:
                        opponent.Defense -= c.cardActivity.Power;
                        break;
                    case 4:
                        owner.Attack += c.cardActivity.Power;
                        break;
                    case 5:
                        opponent.Attack -= c.cardActivity.Power;
                        break;
                    case 6:
                        opponent.EffectsList.Clear();
                        opponent.Poison = 0;
                        opponent.Heal = 0;
                        owner.Poison = 0;
                        owner.Heal = 0;
                        opponent.Attack = 0;
                        opponent.Defense = 0;
                        owner.Attack = 0;
                        owner.Defense = 0;
                        owner.EffectsList.Clear();
                        break;
                    case -1:
                        if (c.cardActivity.Effect.Power < 0)
                        {
                            opponent.EffectsList.Add(c.cardActivity.Effect);
                            opponent.Poison -= c.cardActivity.Effect.Power;
                        }
                        else
                        {
                            owner.EffectsList.Add(c.cardActivity.Effect);
                            owner.Heal += c.cardActivity.Effect.Power;
                        }
                        break;
                }
                return true;
            }
            return false;
        }
    }
}
