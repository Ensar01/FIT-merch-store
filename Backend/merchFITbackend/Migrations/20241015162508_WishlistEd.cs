﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace merchFITbackend.Migrations
{
    /// <inheritdoc />
    public partial class WishlistEd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DatumKreiranja",
                table: "Wishlist");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DatumKreiranja",
                table: "Wishlist",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
