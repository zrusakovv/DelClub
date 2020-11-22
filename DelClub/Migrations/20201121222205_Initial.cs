using Microsoft.EntityFrameworkCore.Migrations;

namespace DelClub.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BKOrders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Shipped = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    Entrance = table.Column<string>(nullable: false),
                    Number = table.Column<string>(nullable: false),
                    Apartment = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BKOrders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BurgerKings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    Category = table.Column<string>(nullable: true),
                    Img = table.Column<string>(nullable: true),
                    Time = table.Column<string>(nullable: true),
                    DeliveryPrice = table.Column<string>(nullable: true),
                    DeliveryPriceFrom = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BurgerKings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DominoPizzas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    Category = table.Column<string>(nullable: true),
                    Img = table.Column<string>(nullable: true),
                    Time = table.Column<string>(nullable: true),
                    DeliveryPrice = table.Column<string>(nullable: true),
                    DeliveryPriceFrom = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DominoPizzas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DPOrders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Shipped = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    Entrance = table.Column<string>(nullable: false),
                    Number = table.Column<string>(nullable: false),
                    Apartment = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DPOrders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KfcOrders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Shipped = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    Entrance = table.Column<string>(nullable: false),
                    Number = table.Column<string>(nullable: false),
                    Apartment = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KfcOrders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kfcs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    Category = table.Column<string>(nullable: true),
                    Img = table.Column<string>(nullable: true),
                    Time = table.Column<string>(nullable: true),
                    DeliveryPrice = table.Column<string>(nullable: true),
                    DeliveryPriceFrom = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kfcs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Makdonalds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    Category = table.Column<string>(nullable: true),
                    Img = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Makdonalds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MBOrders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Shipped = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    Entrance = table.Column<string>(nullable: false),
                    Number = table.Column<string>(nullable: false),
                    Apartment = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MBOrders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MDOrders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Shipped = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    Entrance = table.Column<string>(nullable: false),
                    Number = table.Column<string>(nullable: false),
                    Apartment = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MDOrders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MyBoxes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    Category = table.Column<string>(nullable: true),
                    Img = table.Column<string>(nullable: true),
                    Time = table.Column<string>(nullable: true),
                    DeliveryPrice = table.Column<string>(nullable: true),
                    DeliveryPriceFrom = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyBoxes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    Img = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SBOrders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Shipped = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    Entrance = table.Column<string>(nullable: false),
                    Number = table.Column<string>(nullable: false),
                    Apartment = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SBOrders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SushiBoxes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    Category = table.Column<string>(nullable: true),
                    Img = table.Column<string>(nullable: true),
                    Time = table.Column<string>(nullable: true),
                    DeliveryPrice = table.Column<string>(nullable: true),
                    DeliveryPriceFrom = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SushiBoxes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BKCartLine",
                columns: table => new
                {
                    CartLineId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BurgerKingId = table.Column<int>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    BKOrderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BKCartLine", x => x.CartLineId);
                    table.ForeignKey(
                        name: "FK_BKCartLine_BKOrders_BKOrderId",
                        column: x => x.BKOrderId,
                        principalTable: "BKOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BKCartLine_BurgerKings_BurgerKingId",
                        column: x => x.BurgerKingId,
                        principalTable: "BurgerKings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DPCartLine",
                columns: table => new
                {
                    CartLineId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DominoPizzaId = table.Column<int>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    DPOrderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DPCartLine", x => x.CartLineId);
                    table.ForeignKey(
                        name: "FK_DPCartLine_DPOrders_DPOrderId",
                        column: x => x.DPOrderId,
                        principalTable: "DPOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DPCartLine_DominoPizzas_DominoPizzaId",
                        column: x => x.DominoPizzaId,
                        principalTable: "DominoPizzas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KFCCartLine",
                columns: table => new
                {
                    CartLineId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KfcId = table.Column<int>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    KfcOrderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KFCCartLine", x => x.CartLineId);
                    table.ForeignKey(
                        name: "FK_KFCCartLine_Kfcs_KfcId",
                        column: x => x.KfcId,
                        principalTable: "Kfcs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KFCCartLine_KfcOrders_KfcOrderId",
                        column: x => x.KfcOrderId,
                        principalTable: "KfcOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MDCartLine",
                columns: table => new
                {
                    CartLineId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MakdonaldsId = table.Column<int>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    MDOrderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MDCartLine", x => x.CartLineId);
                    table.ForeignKey(
                        name: "FK_MDCartLine_MDOrders_MDOrderId",
                        column: x => x.MDOrderId,
                        principalTable: "MDOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MDCartLine_Makdonalds_MakdonaldsId",
                        column: x => x.MakdonaldsId,
                        principalTable: "Makdonalds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MBCartLine",
                columns: table => new
                {
                    CartLineId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MyBoxId = table.Column<int>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    MBOrderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MBCartLine", x => x.CartLineId);
                    table.ForeignKey(
                        name: "FK_MBCartLine_MBOrders_MBOrderId",
                        column: x => x.MBOrderId,
                        principalTable: "MBOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MBCartLine_MyBoxes_MyBoxId",
                        column: x => x.MyBoxId,
                        principalTable: "MyBoxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SBCartLine",
                columns: table => new
                {
                    CartLineId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SushiBoxId = table.Column<int>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    SBOrderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SBCartLine", x => x.CartLineId);
                    table.ForeignKey(
                        name: "FK_SBCartLine_SBOrders_SBOrderId",
                        column: x => x.SBOrderId,
                        principalTable: "SBOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SBCartLine_SushiBoxes_SushiBoxId",
                        column: x => x.SushiBoxId,
                        principalTable: "SushiBoxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BKCartLine_BKOrderId",
                table: "BKCartLine",
                column: "BKOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_BKCartLine_BurgerKingId",
                table: "BKCartLine",
                column: "BurgerKingId");

            migrationBuilder.CreateIndex(
                name: "IX_DPCartLine_DPOrderId",
                table: "DPCartLine",
                column: "DPOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_DPCartLine_DominoPizzaId",
                table: "DPCartLine",
                column: "DominoPizzaId");

            migrationBuilder.CreateIndex(
                name: "IX_KFCCartLine_KfcId",
                table: "KFCCartLine",
                column: "KfcId");

            migrationBuilder.CreateIndex(
                name: "IX_KFCCartLine_KfcOrderId",
                table: "KFCCartLine",
                column: "KfcOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_MBCartLine_MBOrderId",
                table: "MBCartLine",
                column: "MBOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_MBCartLine_MyBoxId",
                table: "MBCartLine",
                column: "MyBoxId");

            migrationBuilder.CreateIndex(
                name: "IX_MDCartLine_MDOrderId",
                table: "MDCartLine",
                column: "MDOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_MDCartLine_MakdonaldsId",
                table: "MDCartLine",
                column: "MakdonaldsId");

            migrationBuilder.CreateIndex(
                name: "IX_SBCartLine_SBOrderId",
                table: "SBCartLine",
                column: "SBOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_SBCartLine_SushiBoxId",
                table: "SBCartLine",
                column: "SushiBoxId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BKCartLine");

            migrationBuilder.DropTable(
                name: "DPCartLine");

            migrationBuilder.DropTable(
                name: "KFCCartLine");

            migrationBuilder.DropTable(
                name: "MBCartLine");

            migrationBuilder.DropTable(
                name: "MDCartLine");

            migrationBuilder.DropTable(
                name: "Restaurants");

            migrationBuilder.DropTable(
                name: "SBCartLine");

            migrationBuilder.DropTable(
                name: "BKOrders");

            migrationBuilder.DropTable(
                name: "BurgerKings");

            migrationBuilder.DropTable(
                name: "DPOrders");

            migrationBuilder.DropTable(
                name: "DominoPizzas");

            migrationBuilder.DropTable(
                name: "Kfcs");

            migrationBuilder.DropTable(
                name: "KfcOrders");

            migrationBuilder.DropTable(
                name: "MBOrders");

            migrationBuilder.DropTable(
                name: "MyBoxes");

            migrationBuilder.DropTable(
                name: "MDOrders");

            migrationBuilder.DropTable(
                name: "Makdonalds");

            migrationBuilder.DropTable(
                name: "SBOrders");

            migrationBuilder.DropTable(
                name: "SushiBoxes");
        }
    }
}
