namespace Slantar.Architecture
{
    internal class EmptyFsmState : IFsmState
    {
        public void Enter()
        {
            
        }

        public void Update()
        {
            throw new EmptyFsmException("The FSM hasn't states registered");
        }

        public void Exit()
        {
            
        }
    }
}