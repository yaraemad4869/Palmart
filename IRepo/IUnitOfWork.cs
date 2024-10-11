using Palmart.Models;

namespace Palmart.IRepo
{
	public interface IUnitOfWork : IDisposable
	{
		IBasicRepo<User> users {  get; }
		IBasicRepo<Employee> employees { get; }
		IBasicRepo<Order> orders { get; }
		IBasicRepo<Brand> brands { get; }
		IBasicRepo<ClothesProduct> clothesProducts { get; }
		IBasicRepo<MakeupProduct> makeupProducts { get; }
		IBasicRepo<SkinCareProduct> skinCareProducts { get; }
		IBasicRepo<Wishlist> wishlists { get; }
		IBasicRepo<Review> reviews { get; }
		IBasicRepo<Report> reports { get; }
		IBasicRepo<Payment> payments { get; }
		int CommitChanges();

	}
}
