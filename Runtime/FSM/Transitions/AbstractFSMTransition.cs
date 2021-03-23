namespace Slantar.Architecture
{
    public abstract class AbstractFSMTransition : IFSMTransition
    {
        public virtual IFSMState ToState { get; }
        
        protected AbstractFSMTransition(IFSMState toState)
        {
            ToState = toState;
        }
        
        public abstract bool Valid { get; }
    }
}