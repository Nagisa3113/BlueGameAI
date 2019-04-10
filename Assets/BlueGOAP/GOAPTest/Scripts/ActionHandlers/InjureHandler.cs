﻿
using System;
using System.Threading.Tasks;
using BlueGOAP;

namespace BlueGOAPTest
{
    public class InjureHandler : ActionHandlerBase<ActionEnum, GoalEnum>
    {
        public InjureHandler(IAgent<ActionEnum, GoalEnum> agent, IAction<ActionEnum> action) : base(agent,action)
        {
        }

        public async override void Enter()
        {
            DebugMsg.Log("进入受伤状态");
            await Task.Delay(TimeSpan.FromSeconds(2));
            OnComplete();
        }
    }
}
