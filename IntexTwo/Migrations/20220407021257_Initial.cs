using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IntexTwo.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Crashes",
                columns: table => new
                {
                    CRASH_ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CRASH_DATETIME = table.Column<string>(nullable: true),
                    ROUTE = table.Column<int>(nullable: false),
                    MILEPOINT = table.Column<double>(nullable: false),
                    LAT_UTM_Y = table.Column<double>(nullable: false),
                    LONG_UTM_X = table.Column<double>(nullable: false),
                    MAIN_ROAD_NAME = table.Column<string>(nullable: true),
                    CITY = table.Column<string>(nullable: true),
                    COUNTY_NAME = table.Column<string>(nullable: true),
                    CRASH_SEVERITY_ID = table.Column<int>(nullable: false),
                    WORK_ZONE_RELATED = table.Column<bool>(nullable: false),
                    PEDESTRIAN_INVOLVED = table.Column<bool>(nullable: false),
                    BICYCLIST_INVOLVED = table.Column<bool>(nullable: false),
                    MOTORCYCLE_INVOLVED = table.Column<bool>(nullable: false),
                    IMPROPER_RESTRAINT = table.Column<bool>(nullable: false),
                    UNRESTRAINED = table.Column<bool>(nullable: false),
                    DUI = table.Column<bool>(nullable: false),
                    INTERSECTION_RELATED = table.Column<bool>(nullable: false),
                    WILD_ANIMAL_RELATED = table.Column<bool>(nullable: false),
                    DOMESTIC_ANIMAL_RELATED = table.Column<bool>(nullable: false),
                    OVERTURN_ROLLOVER = table.Column<bool>(nullable: false),
                    COMMERCIAL_MOTOR_VEH_INVOLVED = table.Column<bool>(nullable: false),
                    TEENAGE_DRIVER_INVOLVED = table.Column<bool>(nullable: false),
                    OLDER_DRIVER_INVOLVED = table.Column<bool>(nullable: false),
                    NIGHT_DARK_CONDITION = table.Column<bool>(nullable: false),
                    SINGLE_VEHICLE = table.Column<bool>(nullable: false),
                    DISTRACTED_DRIVING = table.Column<bool>(nullable: false),
                    DROWSY_DRIVING = table.Column<bool>(nullable: false),
                    ROADWAY_DEPARTURE = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crashes", x => x.CRASH_ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Crashes");
        }
    }
}
