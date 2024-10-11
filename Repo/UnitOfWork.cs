using Palmart.Data;
using Palmart.IRepo;
using Palmart.Models;

namespace Palmart.Repo
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly AppDbContext _db;
        public UnitOfWork(AppDbContext db)
        {
            _db = db;
			users=new BasicRepo<User>(_db);
			employees=new BasicRepo<Employee>(_db);
			orders=new BasicRepo<Order>(_db);
			brands=new BasicRepo<Brand>(_db);
			clothesProducts=new BasicRepo<ClothesProduct>(_db);
			makeupProducts=new BasicRepo<MakeupProduct>(_db);
			skinCareProducts=new BasicRepo<SkinCareProduct>(_db);
			wishlists=new BasicRepo<Wishlist>(_db);
			reviews=new BasicRepo<Review>(_db);
			reports=new BasicRepo<Report>(_db);
			payments=new BasicRepo<Payment>(_db);
			discounts=new BasicRepo<Discount>(_db);
        }
		public IBasicRepo<User> users { get; private set; }

		public IBasicRepo<Employee> employees { get; private set; }

		public IBasicRepo<Order> orders { get; private set; }

		public IBasicRepo<Brand> brands { get; private set; }

		public IBasicRepo<Discount> discounts { get; private set; }

		public IBasicRepo<ClothesProduct> clothesProducts { get; private set; }

		public IBasicRepo<MakeupProduct> makeupProducts { get; private set; }

		public IBasicRepo<SkinCareProduct> skinCareProducts { get; private set; }

		public IBasicRepo<Wishlist> wishlists { get; private set; }

		public IBasicRepo<Review> reviews { get; private set; }

		public IBasicRepo<Report> reports { get; private set; }

		public IBasicRepo<Payment> payments { get; private set; }

		public int CommitChanges()
		{
			return _db.SaveChanges();
		}

		public void Dispose()
		{
			_db.Dispose();
		}
	}
}
