using Palmart.Models;

namespace Palmart.IRepo
{
	public interface ILoginRepo
	{
		User GetByEmail(string email);
	}
}
