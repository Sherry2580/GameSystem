using GameSystem.RPG.Enums;
using GameSystem.RPG.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSystem.RPG
{
    internal class AttackFactory
    {
        public static Skill CreateSkill(AttackType attackType)
        {
            Skill skill = null;
            switch (attackType)
            {
                case AttackType.Physical:
                    skill = new PhysicalAttack();
                    break;
                case AttackType.Ice:
                    skill = new IceAttack();
                    break;
                case AttackType.Fire:
                    skill = new FireAttack();
                    break;
            }
            return skill;
        }
    }
}
