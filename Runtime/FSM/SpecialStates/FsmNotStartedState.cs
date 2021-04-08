namespace Slantar.Architecture
{
    internal class FsmNotStartedState : IFsmState
    {
        public void Enter()
        {
        }

        public void Update()
        {
            throw new FsmNotStartedException("The FSM wasn't started, call Start() method one time");
        }

        public void Exit()
        {
        }
    }
}