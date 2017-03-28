using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CoderCampsMentor.Migrations
{
    public partial class addInbox : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inboxes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateSent = table.Column<DateTime>(nullable: false),
                    HasBeenViewed = table.Column<bool>(nullable: false),
                    Msg = table.Column<string>(nullable: true),
                    RecId = table.Column<string>(nullable: true),
                    ReceivingUserId = table.Column<string>(nullable: true),
                    SendingUserId = table.Column<string>(nullable: true),
                    Subject = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inboxes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inboxes_AspNetUsers_ReceivingUserId",
                        column: x => x.ReceivingUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inboxes_AspNetUsers_SendingUserId",
                        column: x => x.SendingUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CommType = table.Column<string>(nullable: true),
                    DateSent = table.Column<DateTime>(nullable: false),
                    HasBeenViewed = table.Column<bool>(nullable: false),
                    InboxId = table.Column<int>(nullable: true),
                    Msg = table.Column<string>(nullable: true),
                    RecId = table.Column<string>(nullable: true),
                    ReceivingUserId = table.Column<string>(nullable: true),
                    SendingUserId = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Subject = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comms_Inboxes_InboxId",
                        column: x => x.InboxId,
                        principalTable: "Inboxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comms_AspNetUsers_ReceivingUserId",
                        column: x => x.ReceivingUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comms_AspNetUsers_SendingUserId",
                        column: x => x.SendingUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comms_InboxId",
                table: "Comms",
                column: "InboxId");

            migrationBuilder.CreateIndex(
                name: "IX_Comms_ReceivingUserId",
                table: "Comms",
                column: "ReceivingUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comms_SendingUserId",
                table: "Comms",
                column: "SendingUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Inboxes_ReceivingUserId",
                table: "Inboxes",
                column: "ReceivingUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Inboxes_SendingUserId",
                table: "Inboxes",
                column: "SendingUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comms");

            migrationBuilder.DropTable(
                name: "Inboxes");
        }
    }
}
