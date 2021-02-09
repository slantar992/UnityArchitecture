
namespace Slantar.Architecture
{
	internal interface IEventSubscriber
	{
		void Trigger(object data);
	}
}