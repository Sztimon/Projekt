using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DataModels.Migrations
{
    public partial class SeedDataToFeatures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           // 'Klimatyzacja','Elektryczne szyby'
            migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Klimatyzacja')");
            migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Elektryczne szyby')");
            migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('GPS')");
            migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Podgrzewane fotele')");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Makes WHERE Name IN ('Klimatyzacja', 'Elektryczne szyby', 'GPS', 'Podgrzewane fotele')");
        }
    }
}
