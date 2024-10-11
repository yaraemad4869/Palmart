using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Palmart.Data.Enums;
using Palmart.Models;

namespace Palmart.Data
{
	public class AppDbContext : DbContext
	{
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {
            
        }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().ToTable("User");
			modelBuilder.Entity<Order>().ToTable("Order");
			modelBuilder.Entity<Brand>().ToTable("Brand");
			modelBuilder.Entity<Employee>().ToTable("Employee");
			modelBuilder.Entity<Discount>().ToTable("Discount");
			modelBuilder.Entity<ClothesColorSize>().ToTable("ClothesColorSize");
			modelBuilder.Entity<DiscountProduct>().ToTable("DiscountProduct");
			modelBuilder.Entity<OrderProduct>().ToTable("OrderProduct");
			modelBuilder.Entity<Report>().ToTable("Report");
			modelBuilder.Entity<Review>().ToTable("Review");
			modelBuilder.Entity<Payment>().ToTable("Payment");
			modelBuilder.Entity<Wishlist>().ToTable("Wishlist");
			

			modelBuilder.Entity<Product>().ToTable("Product");  // Base class mapped to the "Products" table
			modelBuilder.Entity<ClothesProduct>().ToTable("ClothesProduct");            // Derived class mapped to the "ClothesProducts" table


			modelBuilder.Entity<OrderProduct>().HasKey(op => new { op.OrderID, op.ProductID });
			modelBuilder.Entity<OrderProduct>()
		   .HasOne(op => op.order)
		   .WithMany(o => o.OrderProducts)
		   .HasForeignKey(op => op.OrderID);

			modelBuilder.Entity<OrderProduct>()
				.HasOne(op => op.product)
				.WithMany(p => p.OrderProducts)
				.HasForeignKey(op => op.ProductID);

			modelBuilder.Entity<DiscountProduct>().HasKey(op => new { op.DiscountID, op.ProductID });
			modelBuilder.Entity<DiscountProduct>()
		   .HasOne(dp => dp.discount)
		   .WithMany(d => d.discountProducts)
		   .HasForeignKey(op => op.DiscountID);

			modelBuilder.Entity<DiscountProduct>()
				.HasOne(dp => dp.product)
				.WithMany(p => p.DiscountProducts)
				.HasForeignKey(op => op.ProductID);

			modelBuilder.Entity<Wishlist>().HasKey(op => new { op.UserID, op.ProductID });
			modelBuilder.Entity<Wishlist>()
		   .HasOne(w => w.user)
		   .WithMany(u => u.wishlist)
		   .HasForeignKey(w => w.UserID);

			modelBuilder.Entity<Wishlist>()
				.HasOne(w => w.product)
				.WithMany(p => p.wishlists)
				.HasForeignKey(w => w.ProductID);

			modelBuilder.Entity<Review>().HasKey(op => new { op.UserID, op.ProductID });
			modelBuilder.Entity<Review>()
		   .HasOne(r => r.user)
		   .WithMany(u => u.reviews)
		   .HasForeignKey(r => r.UserID);

			modelBuilder.Entity<Review>()
				.HasOne(r => r.product)
				.WithMany(p => p.reviews)
				.HasForeignKey(r => r.ProductID);

			modelBuilder.Entity<Report>().HasKey(op => new { op.UserID, op.ProductID });
			modelBuilder.Entity<Report>()
		   .HasOne(r => r.user)
		   .WithMany(u => u.reports)
		   .HasForeignKey(r => r.UserID);

			modelBuilder.Entity<Report>()
				.HasOne(r => r.product)
				.WithMany(p => p.reports)
				.HasForeignKey(r => r.ProductID);

			#region User Data
			modelBuilder.Entity<User>()
				.HasData(
					new User { ID = 1, FName = "Yara", LName = "Emad Eldien", Username = "Yara_Emad4869", PhoneNumber = "+201127769084", Email = "Yara.Emad4869@gmail.com", Password = "YaraEmad4869", Gender = Gender.Female, UserType = UserType.Client, Address = "Al-Rawda Street, Off the Nile Courniche, Beni Suef" }
				);
			#endregion
			#region Brand Data
			modelBuilder.Entity<Brand>()
			.HasData(
				new Brand { ID = 1, Name = "Khaadi", Description = "Traditional and modern fashion", CountryOfOrigin = "Pakistan", Category = Category.Clothes, BrandStatus = BrandStatus.Accepted, NotAppropiate = false, Boycott = false },
				new Brand { ID = 2, Name = "Bonanza Satrangi", Description = "Clothing and textiles", CountryOfOrigin = "Pakistan", Category = Category.Clothes, BrandStatus = BrandStatus.Accepted, NotAppropiate = false, Boycott = false },
				new Brand { ID = 3, Name = "J.", Description = "Eastern wear and fashion", CountryOfOrigin = "Pakistan", Category = Category.Clothes, BrandStatus = BrandStatus.Accepted, NotAppropiate = false, Boycott = false },
				new Brand { ID = 4, Name = "Wardah", Description = "Halal cosmetics and skincare", CountryOfOrigin = "Pakistan", Category = Category.Makeup, BrandStatus = BrandStatus.Accepted, NotAppropiate = false, Boycott = false },
				new Brand { ID = 5, Name = "Amouage", Description = "Luxury perfumes", CountryOfOrigin = "Oman", Category = Category.Makeup, BrandStatus = BrandStatus.Accepted, NotAppropiate = false, Boycott = false },
				new Brand { ID = 6, Name = "Daraz", Description = "Online clothing and accessories", CountryOfOrigin = "Pakistan", Category = Category.Clothes, BrandStatus = BrandStatus.Accepted, NotAppropiate = false, Boycott = false },
				new Brand { ID = 7, Name = "Chanelle", Description = "Fashion accessories and clothing", CountryOfOrigin = "Egypt", Category = Category.Clothes, BrandStatus = BrandStatus.Accepted, NotAppropiate = false, Boycott = false },
				new Brand { ID = 8, Name = "Mumuso", Description = "Lifestyle and beauty products", CountryOfOrigin = "South Korea", Category = Category.Makeup, BrandStatus = BrandStatus.Pending, NotAppropiate = false, Boycott = false },
				new Brand { ID = 9, Name = "Skinfood", Description = "Korean skincare products", CountryOfOrigin = "South Korea", Category = Category.Skincare, BrandStatus = BrandStatus.Accepted, NotAppropiate = false, Boycott = false },
				new Brand { ID = 10, Name = "Sulwhasoo", Description = "Luxury Korean skincare", CountryOfOrigin = "South Korea", Category = Category.Skincare, BrandStatus = BrandStatus.Accepted, NotAppropiate = false, Boycott = false },
				new Brand { ID = 11, Name = "Tonymoly", Description = "Korean cosmetics and beauty", CountryOfOrigin = "South Korea", Category = Category.Makeup, BrandStatus = BrandStatus.Accepted, NotAppropiate = false, Boycott = false },
				new Brand { ID = 12, Name = "Kose", Description = "Japanese skincare and makeup", CountryOfOrigin = "Japan", Category = Category.Skincare, BrandStatus = BrandStatus.Accepted, NotAppropiate = false, Boycott = false },
				new Brand { ID = 13, Name = "Hada Labo", Description = "Japanese skincare", CountryOfOrigin = "Japan", Category = Category.Skincare, BrandStatus = BrandStatus.Accepted, NotAppropiate = false, Boycott = false },
				new Brand { ID = 14, Name = "Yasmeen", Description = "Fashion and lifestyle brand", CountryOfOrigin = "Jordan", Category = Category.Clothes, BrandStatus = BrandStatus.Accepted, NotAppropiate = false, Boycott = false },
				new Brand { ID = 15, Name = "Naelofar", Description = "Modest fashion", CountryOfOrigin = "Malaysia", Category = Category.Clothes, BrandStatus = BrandStatus.Accepted, NotAppropiate = false, Boycott = false },
				new Brand { ID = 16, Name = "Safi", Description = "Halal beauty and skincare products", CountryOfOrigin = "Malaysia", Category = Category.Skincare, BrandStatus = BrandStatus.Accepted, NotAppropiate = false, Boycott = false },
				new Brand { ID = 17, Name = "Miniso", Description = "Affordable beauty and household items", CountryOfOrigin = "China", Category = Category.Makeup, BrandStatus = BrandStatus.Accepted, NotAppropiate = false, Boycott = false },
				new Brand { ID = 18, Name = "FILA", Description = "Sportswear and fashion", CountryOfOrigin = "South Korea", Category = Category.Clothes, BrandStatus = BrandStatus.Accepted, NotAppropiate = false, Boycott = false },
				new Brand { ID = 19, Name = "Mizuno", Description = "Sports equipment and fashion", CountryOfOrigin = "Japan", Category = Category.Clothes, BrandStatus = BrandStatus.Accepted, NotAppropiate = false, Boycott = false },
				new Brand { ID = 20, Name = "Infinix", Description = "Mobile electronics and accessories", CountryOfOrigin = "China", Category = Category.Clothes, BrandStatus = BrandStatus.Accepted, NotAppropiate = false, Boycott = false },
				new Brand { ID = 21, Name = "Xiomi", Description = "Electronics and gadgets", CountryOfOrigin = "China", Category = Category.Makeup, BrandStatus = BrandStatus.Accepted, NotAppropiate = false, Boycott = false },
				new Brand { ID = 22, Name = "Laneige", Description = "Korean luxury skincare", CountryOfOrigin = "South Korea", Category = Category.Skincare, BrandStatus = BrandStatus.Accepted, NotAppropiate = false, Boycott = false },
				new Brand { ID = 23, Name = "Mamonde", Description = "Floral-based skincare products", CountryOfOrigin = "South Korea", Category = Category.Skincare, BrandStatus = BrandStatus.Accepted, NotAppropiate = false, Boycott = false },
				new Brand { ID = 24, Name = "Huda Beauty", Description = "Luxury makeup brand", CountryOfOrigin = "UAE", Category = Category.Makeup, BrandStatus = BrandStatus.Accepted, NotAppropiate = false, Boycott = false },
				new Brand { ID = 25, Name = "Ajmal", Description = "Perfumes and cosmetics", CountryOfOrigin = "UAE", Category = Category.Makeup, BrandStatus = BrandStatus.Accepted, NotAppropiate = false, Boycott = false },
				new Brand { ID = 26, Name = "Al Haramain", Description = "Luxury perfumes", CountryOfOrigin = "UAE", Category = Category.Makeup, BrandStatus = BrandStatus.Accepted, NotAppropiate = false, Boycott = false },
				new Brand { ID = 27, Name = "Ahmed Perfumes", Description = "Traditional perfumes", CountryOfOrigin = "UAE", Category = Category.Makeup, BrandStatus = BrandStatus.Accepted, NotAppropiate = false, Boycott = false },
				new Brand { ID = 28, Name = "Muji", Description = "Minimalist fashion and household products", CountryOfOrigin = "Japan", Category = Category.Clothes, BrandStatus = BrandStatus.Accepted, NotAppropiate = false, Boycott = false },
				new Brand { ID = 29, Name = "Mina", Description = "Modest clothing and fashion", CountryOfOrigin = "Egypt", Category = Category.Clothes, BrandStatus = BrandStatus.Accepted, NotAppropiate = false, Boycott = false },
				new Brand { ID = 30, Name = "Nefertari", Description = "Egyptian organic skincare", CountryOfOrigin = "Egypt", Category = Category.Skincare, BrandStatus = BrandStatus.Accepted, NotAppropiate = false, Boycott = false },
				new Brand { ID = 31, Name = "Emirates Apparel", Description = "Clothing brand", CountryOfOrigin = "UAE", Category = Category.Clothes, BrandStatus = BrandStatus.Accepted, NotAppropiate = false, Boycott = false },
				new Brand { ID = 32, Name = "Splash", Description = "Affordable fashion", CountryOfOrigin = "UAE", Category = Category.Clothes, BrandStatus = BrandStatus.Accepted, NotAppropiate = false, Boycott = false },
				new Brand { ID = 33, Name = "Aldo", Description = "Footwear and accessories", CountryOfOrigin = "Canada", Category = Category.Clothes, BrandStatus = BrandStatus.Pending, NotAppropiate = false, Boycott = false },
				new Brand { ID = 34, Name = "Balmain Hair Couture", Description = "Luxury hair care", CountryOfOrigin = "South Korea", Category = Category.Skincare, BrandStatus = BrandStatus.Accepted, NotAppropiate = false, Boycott = false },
				new Brand { ID = 35, Name = "Natura", Description = "Brazilian skincare and cosmetics", CountryOfOrigin = "Brazil", Category = Category.Skincare, BrandStatus = BrandStatus.Accepted, NotAppropiate = false, Boycott = false },
				new Brand { ID = 36, Name = "Granado", Description = "Brazilian cosmetics", CountryOfOrigin = "Brazil", Category = Category.Skincare, BrandStatus = BrandStatus.Accepted, NotAppropiate = false, Boycott = false },
				new Brand { ID = 37, Name = "O Boticário", Description = "Brazilian perfumes and cosmetics", CountryOfOrigin = "Brazil", Category = Category.Skincare, BrandStatus = BrandStatus.Accepted, NotAppropiate = false, Boycott = false },
				new Brand { ID = 38, Name = "Farmasi", Description = "Halal cosmetics", CountryOfOrigin = "Turkey", Category = Category.Makeup, BrandStatus = BrandStatus.Accepted, NotAppropiate = false, Boycott = false },
				new Brand { ID = 39, Name = "Flormar", Description = "Turkish makeup and skincare", CountryOfOrigin = "Turkey", Category = Category.Makeup, BrandStatus = BrandStatus.Accepted, NotAppropiate = false, Boycott = false },
				new Brand { ID = 40, Name = "Koton", Description = "Fashion and textiles", CountryOfOrigin = "Turkey", Category = Category.Clothes, BrandStatus = BrandStatus.Accepted, NotAppropiate = false, Boycott = false },
				new Brand { ID = 41, Name = "LC Waikiki", Description = "Fashion and lifestyle", CountryOfOrigin = "Turkey", Category = Category.Clothes, BrandStatus = BrandStatus.Accepted, NotAppropiate = false, Boycott = false },
				new Brand { ID = 42, Name = "Vakko", Description = "Luxury fashion", CountryOfOrigin = "Turkey", Category = Category.Clothes, BrandStatus = BrandStatus.Accepted, NotAppropiate = false, Boycott = false },
				new Brand { ID = 43, Name = "L'Oréal Türkiye", Description = "Cosmetics and personal care", CountryOfOrigin = "Turkey", Category = Category.Skincare, BrandStatus = BrandStatus.Accepted, NotAppropiate = false, Boycott = false },
				new Brand { ID = 44, Name = "Muslim Pro", Description = "Halal skincare", CountryOfOrigin = "Malaysia", Category = Category.Skincare, BrandStatus = BrandStatus.Accepted, NotAppropiate = false, Boycott = false },
				new Brand { ID = 45, Name = "Isetan", Description = "Luxury fashion and cosmetics", CountryOfOrigin = "Japan", Category = Category.Clothes, BrandStatus = BrandStatus.Accepted, NotAppropiate = false, Boycott = false },
				new Brand { ID = 46, Name = "Shu Uemura", Description = "Luxury Japanese cosmetics", CountryOfOrigin = "Japan", Category = Category.Makeup, BrandStatus = BrandStatus.Accepted, NotAppropiate = false, Boycott = false },
				new Brand { ID = 47, Name = "Dr. Jart+", Description = "Korean skincare", CountryOfOrigin = "South Korea", Category = Category.Skincare, BrandStatus = BrandStatus.Accepted, NotAppropiate = false, Boycott = false },
				new Brand { ID = 48, Name = "Shiseido", Description = "Luxury Japanese skincare", CountryOfOrigin = "Japan", Category = Category.Skincare, BrandStatus = BrandStatus.Accepted, NotAppropiate = false, Boycott = false },
				new Brand { ID = 49, Name = "Clio", Description = "Korean makeup", CountryOfOrigin = "South Korea", Category = Category.Makeup, BrandStatus = BrandStatus.Accepted, NotAppropiate = false, Boycott = false },
				new Brand { ID = 50, Name = "Banila Co", Description = "Korean beauty", CountryOfOrigin = "South Korea", Category = Category.Makeup, BrandStatus = BrandStatus.Accepted, NotAppropiate = false, Boycott = false },
				new Brand { ID = 51, Name = "Junaid Jamshed", Description = "Traditional clothing", CountryOfOrigin = "Pakistan", Category = Category.Clothes, BrandStatus = BrandStatus.Accepted, NotAppropiate = false, Boycott = false },
				new Brand { ID = 52, Name = "Gul Ahmed", Description = "Textiles and fashion clothing", CountryOfOrigin = "Pakistan", Category = Category.Clothes, BrandStatus = BrandStatus.Accepted, NotAppropiate = false, Boycott = false },
				new Brand { ID = 53, Name = "Oriflame", Description = "Beauty and skincare products", CountryOfOrigin = "Sweden", Category = Category.Makeup, BrandStatus = BrandStatus.Accepted, NotAppropiate = false, Boycott = false },
				new Brand { ID = 54, Name = "Nature Republic", Description = "Korean skincare products", CountryOfOrigin = "South Korea", Category = Category.Skincare, BrandStatus = BrandStatus.Accepted, NotAppropiate = false, Boycott = false },
				new Brand { ID = 55, Name = "Missha", Description = "Affordable Korean cosmetics", CountryOfOrigin = "South Korea", Category = Category.Makeup, BrandStatus = BrandStatus.Accepted, NotAppropiate = false, Boycott = false },
				new Brand { ID = 56, Name = "Innisfree", Description = "Natural Korean beauty products", CountryOfOrigin = "South Korea", Category = Category.Skincare, BrandStatus = BrandStatus.Accepted, NotAppropiate = false, Boycott = false },
				new Brand { ID = 57, Name = "Etude House", Description = "Korean makeup and skincare", CountryOfOrigin = "South Korea", Category = Category.Makeup, BrandStatus = BrandStatus.Accepted, NotAppropiate = false, Boycott = false },
				new Brand { ID = 58, Name = "COSRX", Description = "Korean skincare solutions", CountryOfOrigin = "South Korea", Category = Category.Skincare, BrandStatus = BrandStatus.Accepted, NotAppropiate = false, Boycott = false },
				new Brand { ID = 59, Name = "Muji", Description = "Minimalist fashion and household products", CountryOfOrigin = "Japan", Category = Category.Clothes, BrandStatus = BrandStatus.Accepted, NotAppropiate = false, Boycott = false },
				new Brand { ID = 60, Name = "Mina", Description = "Modest clothing and fashion", CountryOfOrigin = "Egypt", Category = Category.Clothes, BrandStatus = BrandStatus.Accepted, NotAppropiate = false, Boycott = false },
				new Brand { ID = 61, Name = "Nefertari", Description = "Egyptian organic skincare", CountryOfOrigin = "Egypt", Category = Category.Skincare, BrandStatus = BrandStatus.Accepted, NotAppropiate = false, Boycott = false }
			);
			#endregion
			foreach (var rel in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
			{
				rel.DeleteBehavior = DeleteBehavior.Restrict;
			}
		}

		public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Brand> Brands { get; set; }
		public DbSet<Discount> Discounts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }
        public DbSet<Report>Reports { get; set; }
        public DbSet<Review>Reviews { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<DiscountProduct> DiscountProducts { get; set; }
		public DbSet<ClothesProduct> ClosthesProducts { get; set; }
		public DbSet<ClothesColorSize> ClothesColorSizes { get; set; }
	}
}
