namespace Slantar.Architecture
{
    public abstract class AbstractFsmTransition : IFsmTransition
    {
        public virtual IFsmState ToState { get; }
        
        protected AbstractFsmTransition(IFsmState toState)
        {
            ToState = toState;
        }
        
        public abstract bool Valid { get; }
    }
}