﻿
using System;

namespace BlueGOAP
{
    public abstract class ActionHandlerBase<TAction, TGoal> : IActionHandler<TAction>
    {
        /// <summary>
        /// 动作
        /// </summary>
        public IAction<TAction> Action { get; private set; }

        public TAction Label
        {
            get { return Action.Label; }
        }

        public ActionExcuteState ExcuteState { get; private set; }

        protected IAgent<TAction, TGoal> _agent;
        private IAction<TAction> action;
        protected System.Action _onFinishAction;

        public ActionHandlerBase(IAgent<TAction, TGoal> agent, IAction<TAction> action)
        {
            _agent = agent;
            Action = action;
            ExcuteState = ActionExcuteState.INIT;
            _onFinishAction = null;
        }

        private void SetAgentData(IState state)
        {
            _agent.AgentState.Set(state);
        }

        protected void SetAgentState<TKey>(TKey key,bool value)
        {
            _agent.AgentState.Set(key.ToString(),value);
        }

        protected void OnComplete()
        {
           Exit();

            if (_onFinishAction != null)
                _onFinishAction();

            SetAgentData(Action.Effects);
            SetAgentData(Action.Preconditions.InversionValue());
        }

        public bool CanPerformAction()
        {
            DebugMsg.Log("Action:"+ Action.Label);
            return Action.VerifyPreconditions();
        }

        public void AddFinishCallBack(Action onFinishAction)
        {
            _onFinishAction = onFinishAction;
        }

        public virtual void Enter()
        {
            ExcuteState = ActionExcuteState.ENTER;
        }

        public virtual void Execute()
        {
            ExcuteState = ActionExcuteState.EXCUTE;
        }

        public virtual void Exit()
        {
            ExcuteState = ActionExcuteState.EXIT;
        }

    }
}
