
namespace Slantar.Architecture
{
	public interface IPool<T>
	{
		T Pick();
		void Release(T instance);
		void ReleaseAll();
	}
}
