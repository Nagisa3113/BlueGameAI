﻿
using BlueGOAP;

namespace BlueGOAPTest
{
    public class IdleAction : ActionBase<ActionEnum, GoalEnum>
    {
        public override ActionEnum Label { get { return ActionEnum.IDLE; } }
        public override int Cost { get { return 1; } }
        public override int Priority { get { return 0; } }

        public IdleAction(IAgent<ActionEnum, GoalEnum> agent) : base(agent)
        {
        }

        protected override IState InitPreconditions()
        {
            State<KeyNameEnum> effects = new State<KeyNameEnum>();
            effects.SetState(KeyNameEnum.FIND_ENEMY, false);
            effects.SetState(KeyNameEnum.ATTACK, false);
            effects.SetState(KeyNameEnum.MOVE, false);
            return effects;
        }

        protected override IState InitEffects()
        {
            return null;
        }
    }
}
