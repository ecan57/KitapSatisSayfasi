using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KitapSatisSayfasi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kategoriler",
                columns: table => new
                {
                    KategoriID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategoriAdi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategoriler", x => x.KategoriID);
                });

            migrationBuilder.CreateTable(
                name: "YayinEvleri",
                columns: table => new
                {
                    YayinEviID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YayinEviAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YayinEvleri", x => x.YayinEviID);
                });

            migrationBuilder.CreateTable(
                name: "Yazarlar",
                columns: table => new
                {
                    YazarID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YazarAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Biyografi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yazarlar", x => x.YazarID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Satislar",
                columns: table => new
                {
                    SatisID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UyeID = table.Column<int>(type: "int", nullable: false),
                    SatisTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToplamTutar = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Satislar", x => x.SatisID);
                    table.ForeignKey(
                        name: "FK_Satislar_AspNetUsers_UyeID",
                        column: x => x.UyeID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kitaplar",
                columns: table => new
                {
                    KitapID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KitapAdi = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    YazarID = table.Column<int>(type: "int", nullable: false),
                    YayinEviID = table.Column<int>(type: "int", nullable: false),
                    KapakResmi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ozet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BasimTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TavsiyeSayisi = table.Column<int>(type: "int", nullable: false),
                    StokAdeti = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kitaplar", x => x.KitapID);
                    table.ForeignKey(
                        name: "FK_Kitaplar_YayinEvleri_YayinEviID",
                        column: x => x.YayinEviID,
                        principalTable: "YayinEvleri",
                        principalColumn: "YayinEviID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kitaplar_Yazarlar_YazarID",
                        column: x => x.YazarID,
                        principalTable: "Yazarlar",
                        principalColumn: "YazarID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KitapKategoriler",
                columns: table => new
                {
                    KitapKategoriID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KitapID = table.Column<int>(type: "int", nullable: false),
                    KategoriID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KitapKategoriler", x => x.KitapKategoriID);
                    table.ForeignKey(
                        name: "FK_KitapKategoriler_Kategoriler_KategoriID",
                        column: x => x.KategoriID,
                        principalTable: "Kategoriler",
                        principalColumn: "KategoriID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KitapKategoriler_Kitaplar_KitapID",
                        column: x => x.KitapID,
                        principalTable: "Kitaplar",
                        principalColumn: "KitapID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SatisDetaylar",
                columns: table => new
                {
                    SatisDetayID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SatisID = table.Column<int>(type: "int", nullable: false),
                    KitapID = table.Column<int>(type: "int", nullable: false),
                    Adet = table.Column<int>(type: "int", nullable: false),
                    Fiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SatisDetaylar", x => x.SatisDetayID);
                    table.ForeignKey(
                        name: "FK_SatisDetaylar_Kitaplar_KitapID",
                        column: x => x.KitapID,
                        principalTable: "Kitaplar",
                        principalColumn: "KitapID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SatisDetaylar_Satislar_SatisID",
                        column: x => x.SatisID,
                        principalTable: "Satislar",
                        principalColumn: "SatisID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sepetler",
                columns: table => new
                {
                    SepetID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KitapID = table.Column<int>(type: "int", nullable: false),
                    UyeID = table.Column<int>(type: "int", nullable: false),
                    Adet = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sepetler", x => x.SepetID);
                    table.ForeignKey(
                        name: "FK_Sepetler_AspNetUsers_UyeID",
                        column: x => x.UyeID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sepetler_Kitaplar_KitapID",
                        column: x => x.KitapID,
                        principalTable: "Kitaplar",
                        principalColumn: "KitapID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "45896c50-e5e4-46f2-846c-845e64463619", "Admin", "ADMIN" },
                    { 2, "f5c4f669-d1ab-4cc5-ba75-6a9f82828e4c", "Uye", "UYE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Adres", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 1, 0, "Ümraniye", "94b0515e-9b44-4d38-946a-ea003fa705b6", "zeynelsahin@zeynelsahin.com", true, false, null, "zeynelsahin@zeynelsahin.com", "Zeynel", "AQAAAAEAACcQAAAAEBey7bjaSpCkvHeL9cz2Ln8gKjpJPI3xxCQAxedYkHjJGqApqeUJtoEoxzcRcJV0ZA==", null, false, null, false, "Zeynel" });

            migrationBuilder.InsertData(
                table: "Kategoriler",
                columns: new[] { "KategoriID", "KategoriAdi" },
                values: new object[,]
                {
                    { 1, "Macera" },
                    { 2, "Tarih" },
                    { 3, "Polisiye" },
                    { 4, "Spor" }
                });

            migrationBuilder.InsertData(
                table: "YayinEvleri",
                columns: new[] { "YayinEviID", "Adres", "Telefon", "YayinEviAdi" },
                values: new object[,]
                {
                    { 1, "Avcılar", null, "ABC" },
                    { 2, "Beylikdüzü", null, "CBA" }
                });

            migrationBuilder.InsertData(
                table: "Yazarlar",
                columns: new[] { "YazarID", "Biyografi", "YazarAdi" },
                values: new object[,]
                {
                    { 1, "", "Ahmet Ümit" },
                    { 2, "", "Tolstoy" },
                    { 3, "", "Dostoyevski" },
                    { 4, "", "Cengiz Aymetov" },
                    { 5, "", "İskender Pala" },
                    { 6, "", "Jack London" }
                });

            migrationBuilder.InsertData(
                table: "Kitaplar",
                columns: new[] { "KitapID", "BasimTarihi", "Fiyat", "KapakResmi", "KitapAdi", "Ozet", "StokAdeti", "TavsiyeSayisi", "YayinEviID", "YazarID" },
                values: new object[] { 1, new DateTime(2012, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 45m, "Beyoğlunun En Güzel Abisi", "Beyoğlunun En Güzel Abisi", "....", 10, 0, 1, 1 });

            migrationBuilder.InsertData(
                table: "Kitaplar",
                columns: new[] { "KitapID", "BasimTarihi", "Fiyat", "KapakResmi", "KitapAdi", "Ozet", "StokAdeti", "TavsiyeSayisi", "YayinEviID", "YazarID" },
                values: new object[] { 2, new DateTime(2015, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 55m, "Savaş Ve BARIŞ", "Savaş ve Barış", "....", 10, 0, 1, 2 });

            migrationBuilder.InsertData(
                table: "KitapKategoriler",
                columns: new[] { "KitapKategoriID", "KategoriID", "KitapID" },
                values: new object[] { 1, 3, 1 });

            migrationBuilder.InsertData(
                table: "KitapKategoriler",
                columns: new[] { "KitapKategoriID", "KategoriID", "KitapID" },
                values: new object[] { 2, 2, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_KitapKategoriler_KategoriID",
                table: "KitapKategoriler",
                column: "KategoriID");

            migrationBuilder.CreateIndex(
                name: "IX_KitapKategoriler_KitapID",
                table: "KitapKategoriler",
                column: "KitapID");

            migrationBuilder.CreateIndex(
                name: "IX_Kitaplar_YayinEviID",
                table: "Kitaplar",
                column: "YayinEviID");

            migrationBuilder.CreateIndex(
                name: "IX_Kitaplar_YazarID",
                table: "Kitaplar",
                column: "YazarID");

            migrationBuilder.CreateIndex(
                name: "IX_SatisDetaylar_KitapID",
                table: "SatisDetaylar",
                column: "KitapID");

            migrationBuilder.CreateIndex(
                name: "IX_SatisDetaylar_SatisID",
                table: "SatisDetaylar",
                column: "SatisID");

            migrationBuilder.CreateIndex(
                name: "IX_Satislar_UyeID",
                table: "Satislar",
                column: "UyeID");

            migrationBuilder.CreateIndex(
                name: "IX_Sepetler_KitapID",
                table: "Sepetler",
                column: "KitapID");

            migrationBuilder.CreateIndex(
                name: "IX_Sepetler_UyeID",
                table: "Sepetler",
                column: "UyeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "KitapKategoriler");

            migrationBuilder.DropTable(
                name: "SatisDetaylar");

            migrationBuilder.DropTable(
                name: "Sepetler");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Kategoriler");

            migrationBuilder.DropTable(
                name: "Satislar");

            migrationBuilder.DropTable(
                name: "Kitaplar");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "YayinEvleri");

            migrationBuilder.DropTable(
                name: "Yazarlar");
        }
    }
}
