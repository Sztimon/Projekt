using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DataModels.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Makes (Name) VALUES ('BMW')");
            migrationBuilder.Sql("INSERT INTO Makes (Name) VALUES ('Mercedes')");
            migrationBuilder.Sql("INSERT INTO Makes (Name) VALUES ('Audi')");

            migrationBuilder.Sql("INSERT INTO CarModels (Name, MakeID) VALUES ('BMW M3', (SELECT ID FROM Makes WHERE Name = 'BMW'))");
            migrationBuilder.Sql("INSERT INTO CarModels (Name, MakeID) VALUES ('BMW M5', (SELECT ID FROM Makes WHERE Name = 'BMW'))");
            migrationBuilder.Sql("INSERT INTO CarModels (Name, MakeID) VALUES ('BMW M7', (SELECT ID FROM Makes WHERE Name = 'BMW'))");

            migrationBuilder.Sql("INSERT INTO CarModels (Name, MakeID) VALUES ('Mercedes C', (SELECT ID FROM Makes WHERE Name = 'Mercedes'))");
            migrationBuilder.Sql("INSERT INTO CarModels (Name, MakeID) VALUES ('Mercedes E', (SELECT ID FROM Makes WHERE Name = 'Mercedes'))");
            migrationBuilder.Sql("INSERT INTO CarModels (Name, MakeID) VALUES ('Mercedes S', (SELECT ID FROM Makes WHERE Name = 'Mercedes'))");

            migrationBuilder.Sql("INSERT INTO CarModels (Name, MakeID) VALUES ('Audi A3', (SELECT ID FROM Makes WHERE Name = 'Audi'))");
            migrationBuilder.Sql("INSERT INTO CarModels (Name, MakeID) VALUES ('Audi A4', (SELECT ID FROM Makes WHERE Name = 'Audi'))");
            migrationBuilder.Sql("INSERT INTO CarModels (Name, MakeID) VALUES ('Audi A5', (SELECT ID FROM Makes WHERE Name = 'Audi'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Makes WHERE Name IN ('BMW', 'Mercedes', 'Audi')");
        }
    }
}
