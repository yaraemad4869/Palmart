using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Palmart.Migrations
{
    /// <inheritdoc />
    public partial class PalmartV1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Discount",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DisValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discount", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    EmployeeRole = table.Column<int>(type: "int", nullable: false),
                    HiringDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    UserType = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    CountryOfOrigin = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    BrandStatus = table.Column<int>(type: "int", nullable: false),
                    NotAppropiate = table.Column<bool>(type: "bit", nullable: true),
                    Boycott = table.Column<bool>(type: "bit", nullable: true),
                    EmpID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Brand_Employee_EmpID",
                        column: x => x.EmpID,
                        principalTable: "Employee",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Brand_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Contact_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DeliveryFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiscountCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    OrderAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OrderStatus = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    EmpID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Order_Employee_EmpID",
                        column: x => x.EmpID,
                        principalTable: "Employee",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentMethod = table.Column<int>(type: "int", nullable: false),
                    PaymentStatus = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Payment_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Image = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AdditionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BrandID = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Product_Brand_BrandID",
                        column: x => x.BrandID,
                        principalTable: "Brand",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeContact",
                columns: table => new
                {
                    ContactID = table.Column<int>(type: "int", nullable: false),
                    EmpID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeContact", x => new { x.ContactID, x.EmpID });
                    table.ForeignKey(
                        name: "FK_EmployeeContact_Contact_ContactID",
                        column: x => x.ContactID,
                        principalTable: "Contact",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeContact_Employee_EmpID",
                        column: x => x.EmpID,
                        principalTable: "Employee",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClothesProduct",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Material = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    AgeGroup = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Season = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClothesProduct", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ClothesProduct_Product_ID",
                        column: x => x.ID,
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiscountProduct",
                columns: table => new
                {
                    DiscountID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountProduct", x => new { x.DiscountID, x.ProductID });
                    table.ForeignKey(
                        name: "FK_DiscountProduct_Discount_DiscountID",
                        column: x => x.DiscountID,
                        principalTable: "Discount",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DiscountProduct_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderProduct",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProduct", x => new { x.OrderID, x.ProductID });
                    table.ForeignKey(
                        name: "FK_OrderProduct_Order_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Order",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderProduct_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Report",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    ReportReason = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ReportDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Report", x => new { x.UserID, x.ProductID });
                    table.ForeignKey(
                        name: "FK_Report_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Report_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<float>(type: "real", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ReviewDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => new { x.UserID, x.ProductID });
                    table.ForeignKey(
                        name: "FK_Review_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Review_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Wishlist",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    AdditionDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wishlist", x => new { x.UserID, x.ProductID });
                    table.ForeignKey(
                        name: "FK_Wishlist_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Wishlist_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClothesColorSize",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Size = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClothesColorSize", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ClothesColorSize_ClothesProduct_ID",
                        column: x => x.ID,
                        principalTable: "ClothesProduct",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brand",
                columns: new[] { "ID", "Boycott", "BrandStatus", "Category", "CountryOfOrigin", "Description", "EmpID", "Name", "NotAppropiate", "UserID" },
                values: new object[,]
                {
                    { 1, false, 1, 0, "Pakistan", "Traditional and modern fashion", 0, "Khaadi", false, 0 },
                    { 2, false, 1, 0, "Pakistan", "Clothing and textiles", 0, "Bonanza Satrangi", false, 0 },
                    { 3, false, 1, 0, "Pakistan", "Eastern wear and fashion", 0, "J.", false, 0 },
                    { 4, false, 1, 1, "Pakistan", "Halal cosmetics and skincare", 0, "Wardah", false, 0 },
                    { 5, false, 1, 1, "Oman", "Luxury perfumes", 0, "Amouage", false, 0 },
                    { 6, false, 1, 0, "Pakistan", "Online clothing and accessories", 0, "Daraz", false, 0 },
                    { 7, false, 1, 0, "Egypt", "Fashion accessories and clothing", 0, "Chanelle", false, 0 },
                    { 8, false, 0, 1, "South Korea", "Lifestyle and beauty products", 0, "Mumuso", false, 0 },
                    { 9, false, 1, 2, "South Korea", "Korean skincare products", 0, "Skinfood", false, 0 },
                    { 10, false, 1, 2, "South Korea", "Luxury Korean skincare", 0, "Sulwhasoo", false, 0 },
                    { 11, false, 1, 1, "South Korea", "Korean cosmetics and beauty", 0, "Tonymoly", false, 0 },
                    { 12, false, 1, 2, "Japan", "Japanese skincare and makeup", 0, "Kose", false, 0 },
                    { 13, false, 1, 2, "Japan", "Japanese skincare", 0, "Hada Labo", false, 0 },
                    { 14, false, 1, 0, "Jordan", "Fashion and lifestyle brand", 0, "Yasmeen", false, 0 },
                    { 15, false, 1, 0, "Malaysia", "Modest fashion", 0, "Naelofar", false, 0 },
                    { 16, false, 1, 2, "Malaysia", "Halal beauty and skincare products", 0, "Safi", false, 0 },
                    { 17, false, 1, 1, "China", "Affordable beauty and household items", 0, "Miniso", false, 0 },
                    { 18, false, 1, 0, "South Korea", "Sportswear and fashion", 0, "FILA", false, 0 },
                    { 19, false, 1, 0, "Japan", "Sports equipment and fashion", 0, "Mizuno", false, 0 },
                    { 20, false, 1, 0, "China", "Mobile electronics and accessories", 0, "Infinix", false, 0 },
                    { 21, false, 1, 1, "China", "Electronics and gadgets", 0, "Xiomi", false, 0 },
                    { 22, false, 1, 2, "South Korea", "Korean luxury skincare", 0, "Laneige", false, 0 },
                    { 23, false, 1, 2, "South Korea", "Floral-based skincare products", 0, "Mamonde", false, 0 },
                    { 24, false, 1, 1, "UAE", "Luxury makeup brand", 0, "Huda Beauty", false, 0 },
                    { 25, false, 1, 1, "UAE", "Perfumes and cosmetics", 0, "Ajmal", false, 0 },
                    { 26, false, 1, 1, "UAE", "Luxury perfumes", 0, "Al Haramain", false, 0 },
                    { 27, false, 1, 1, "UAE", "Traditional perfumes", 0, "Ahmed Perfumes", false, 0 },
                    { 28, false, 1, 0, "Japan", "Minimalist fashion and household products", 0, "Muji", false, 0 },
                    { 29, false, 1, 0, "Egypt", "Modest clothing and fashion", 0, "Mina", false, 0 },
                    { 30, false, 1, 2, "Egypt", "Egyptian organic skincare", 0, "Nefertari", false, 0 },
                    { 31, false, 1, 0, "UAE", "Clothing brand", 0, "Emirates Apparel", false, 0 },
                    { 32, false, 1, 0, "UAE", "Affordable fashion", 0, "Splash", false, 0 },
                    { 33, false, 0, 0, "Canada", "Footwear and accessories", 0, "Aldo", false, 0 },
                    { 34, false, 1, 2, "South Korea", "Luxury hair care", 0, "Balmain Hair Couture", false, 0 },
                    { 35, false, 1, 2, "Brazil", "Brazilian skincare and cosmetics", 0, "Natura", false, 0 },
                    { 36, false, 1, 2, "Brazil", "Brazilian cosmetics", 0, "Granado", false, 0 },
                    { 37, false, 1, 2, "Brazil", "Brazilian perfumes and cosmetics", 0, "O Boticário", false, 0 },
                    { 38, false, 1, 1, "Turkey", "Halal cosmetics", 0, "Farmasi", false, 0 },
                    { 39, false, 1, 1, "Turkey", "Turkish makeup and skincare", 0, "Flormar", false, 0 },
                    { 40, false, 1, 0, "Turkey", "Fashion and textiles", 0, "Koton", false, 0 },
                    { 41, false, 1, 0, "Turkey", "Fashion and lifestyle", 0, "LC Waikiki", false, 0 },
                    { 42, false, 1, 0, "Turkey", "Luxury fashion", 0, "Vakko", false, 0 },
                    { 43, false, 1, 2, "Turkey", "Cosmetics and personal care", 0, "L'Oréal Türkiye", false, 0 },
                    { 44, false, 1, 2, "Malaysia", "Halal skincare", 0, "Muslim Pro", false, 0 },
                    { 45, false, 1, 0, "Japan", "Luxury fashion and cosmetics", 0, "Isetan", false, 0 },
                    { 46, false, 1, 1, "Japan", "Luxury Japanese cosmetics", 0, "Shu Uemura", false, 0 },
                    { 47, false, 1, 2, "South Korea", "Korean skincare", 0, "Dr. Jart+", false, 0 },
                    { 48, false, 1, 2, "Japan", "Luxury Japanese skincare", 0, "Shiseido", false, 0 },
                    { 49, false, 1, 1, "South Korea", "Korean makeup", 0, "Clio", false, 0 },
                    { 50, false, 1, 1, "South Korea", "Korean beauty", 0, "Banila Co", false, 0 },
                    { 51, false, 1, 0, "Pakistan", "Traditional clothing", 0, "Junaid Jamshed", false, 0 },
                    { 52, false, 1, 0, "Pakistan", "Textiles and fashion clothing", 0, "Gul Ahmed", false, 0 },
                    { 53, false, 1, 1, "Sweden", "Beauty and skincare products", 0, "Oriflame", false, 0 },
                    { 54, false, 1, 2, "South Korea", "Korean skincare products", 0, "Nature Republic", false, 0 },
                    { 55, false, 1, 1, "South Korea", "Affordable Korean cosmetics", 0, "Missha", false, 0 },
                    { 56, false, 1, 2, "South Korea", "Natural Korean beauty products", 0, "Innisfree", false, 0 },
                    { 57, false, 1, 1, "South Korea", "Korean makeup and skincare", 0, "Etude House", false, 0 },
                    { 58, false, 1, 2, "South Korea", "Korean skincare solutions", 0, "COSRX", false, 0 },
                    { 59, false, 1, 0, "Japan", "Minimalist fashion and household products", 0, "Muji", false, 0 },
                    { 60, false, 1, 0, "Egypt", "Modest clothing and fashion", 0, "Mina", false, 0 },
                    { 61, false, 1, 2, "Egypt", "Egyptian organic skincare", 0, "Nefertari", false, 0 }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "ID", "Address", "Email", "FName", "Gender", "LName", "Password", "PhoneNumber", "RegistrationDate", "UserType", "Username" },
                values: new object[] { 1, "Al-Rawda Street, Off the Nile Courniche, Beni Suef", "Yara.Emad4869@gmail.com", "Yara", 1, "Emad Eldien", "YaraEmad4869", "+201127769084", new DateTime(2024, 10, 12, 5, 34, 6, 475, DateTimeKind.Local).AddTicks(8259), 0, "Yara_Emad4869" });

            migrationBuilder.CreateIndex(
                name: "IX_Brand_EmpID",
                table: "Brand",
                column: "EmpID");

            migrationBuilder.CreateIndex(
                name: "IX_Brand_UserID",
                table: "Brand",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_UserID",
                table: "Contact",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountProduct_ProductID",
                table: "DiscountProduct",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeContact_EmpID",
                table: "EmployeeContact",
                column: "EmpID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_EmpID",
                table: "Order",
                column: "EmpID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserID",
                table: "Order",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_ProductID",
                table: "OrderProduct",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_UserID",
                table: "Payment",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_BrandID",
                table: "Product",
                column: "BrandID");

            migrationBuilder.CreateIndex(
                name: "IX_Report_ProductID",
                table: "Report",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Review_ProductID",
                table: "Review",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Wishlist_ProductID",
                table: "Wishlist",
                column: "ProductID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClothesColorSize");

            migrationBuilder.DropTable(
                name: "DiscountProduct");

            migrationBuilder.DropTable(
                name: "EmployeeContact");

            migrationBuilder.DropTable(
                name: "OrderProduct");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Report");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "Wishlist");

            migrationBuilder.DropTable(
                name: "ClothesProduct");

            migrationBuilder.DropTable(
                name: "Discount");

            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
