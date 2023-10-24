using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ChatApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    MessageStatus = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ChatId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Chats_ChatId",
                        column: x => x.ChatId,
                        principalTable: "Chats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Messages_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Expires = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserChats",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ChatId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserChats", x => new { x.UserId, x.ChatId });
                    table.ForeignKey(
                        name: "FK_UserChats_Chats_ChatId",
                        column: x => x.ChatId,
                        principalTable: "Chats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserChats_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Chats",
                columns: new[] { "Id", "CreatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 26, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 27, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 28, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 29, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 30, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 31, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 32, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 33, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 34, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 35, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 36, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 37, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 38, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 39, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 40, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "ImagePath", "Password", "Salt", "UserName" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Junior14@hotmail.com", null, "lwhrmF3n3U/fUvJJxw9a7sfr5bdtbshOyPj0cDq1XgA=", "SkApdc90bA/0vsJNHgTrS7WY/qhGtWohhkaC/hDkhBo=", "Erwin_Jenkins" },
                    { 2, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Monique_Schneider@gmail.com", null, "lpsUbsg6Ci7+VxIvDOW60ppdnaJKjJM3TJLJIk92+Ak=", "SkApdc90bA/0vsJNHgTrS7WY/qhGtWohhkaC/hDkhBo=", "Taya73" },
                    { 3, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trever_Ledner10@gmail.com", null, "rsJDVz7aubJOC7krUyp08x609xi5QsysXvVWA5apuxU=", "SkApdc90bA/0vsJNHgTrS7WY/qhGtWohhkaC/hDkhBo=", "Hazle36" },
                    { 4, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Treva_Abernathy@yahoo.com", null, "1Ga/eMKkkJ40K6cjt6bewT2XjRDMdbJqHK/2QQn0Mm0=", "SkApdc90bA/0vsJNHgTrS7WY/qhGtWohhkaC/hDkhBo=", "Anastasia.Kuhlman" },
                    { 5, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dino17@gmail.com", null, "Hg5krs87MCNHoK32vJs+IrvgBbvQh/YA7JUalNJAvRI=", "SkApdc90bA/0vsJNHgTrS7WY/qhGtWohhkaC/hDkhBo=", "Coty_Bergnaum" },
                    { 6, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Monserrate_Kuhlman88@gmail.com", null, "qBucaiT+vGl6P9LKTuDtvprEU0gLQgkYr6PYl3EylyQ=", "SkApdc90bA/0vsJNHgTrS7WY/qhGtWohhkaC/hDkhBo=", "Jamar72" },
                    { 7, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Conor23@yahoo.com", null, "zuMYd8t2ZrxkOzUxyws8Y1PIXCQFN47VG5/9daiHRAQ=", "SkApdc90bA/0vsJNHgTrS7WY/qhGtWohhkaC/hDkhBo=", "Austin_Johnson" },
                    { 8, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mauricio.Padberg68@hotmail.com", null, "MgkcgqQrhUnjBCB2gyK1pslZni+2w8E+xUywWirVsig=", "SkApdc90bA/0vsJNHgTrS7WY/qhGtWohhkaC/hDkhBo=", "Johnathan62" },
                    { 9, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vada61@hotmail.com", null, "/1tPphLylBea7qQt+tDtKl5Ow/OlreKCape08/KrzA4=", "SkApdc90bA/0vsJNHgTrS7WY/qhGtWohhkaC/hDkhBo=", "Karianne.Durgan11" },
                    { 10, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Darien66@gmail.com", null, "FBUugg+qfqkV92bg54WxEY5JdXCjdtTQ2YKSi02AGRs=", "SkApdc90bA/0vsJNHgTrS7WY/qhGtWohhkaC/hDkhBo=", "Steve_Jacobi51" },
                    { 11, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Danika.Satterfield@yahoo.com", null, "Bqmmi9fvp5Z/KIEJd48J7+fz4W1YQPRBVyGYxi7R5nM=", "SkApdc90bA/0vsJNHgTrS7WY/qhGtWohhkaC/hDkhBo=", "Orlo.Rau" },
                    { 12, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Damion_Moen25@hotmail.com", null, "9lDl5FCEIrmuACTTqzk8GSna2BHyoRSV4g5JzWV/hX0=", "SkApdc90bA/0vsJNHgTrS7WY/qhGtWohhkaC/hDkhBo=", "Tad.Mills" },
                    { 13, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lazaro.Wehner@hotmail.com", null, "zycTTgIW/N6APTYA9sdtXIlIIfB3zghPnDd/xU65y6s=", "SkApdc90bA/0vsJNHgTrS7WY/qhGtWohhkaC/hDkhBo=", "Doug.Legros" },
                    { 14, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andrew.Lueilwitz@yahoo.com", null, "uVYBkf0C29WNiHCN296jDhJmF2ezc8pNEz4J6zDX2uQ=", "SkApdc90bA/0vsJNHgTrS7WY/qhGtWohhkaC/hDkhBo=", "Danny.Mayert49" },
                    { 15, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dejuan_Blick@hotmail.com", null, "lewDb/3SjyKKLZF19A2AeR7Pczvts0Lk2e845xHlMD8=", "SkApdc90bA/0vsJNHgTrS7WY/qhGtWohhkaC/hDkhBo=", "Gabriel.Strosin33" },
                    { 16, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gilda_Shanahan@hotmail.com", null, "TPYMfKxODH/gWV+7GBpysc7ImYj0FAz9WeG9US4YgBI=", "SkApdc90bA/0vsJNHgTrS7WY/qhGtWohhkaC/hDkhBo=", "Triston.Doyle" },
                    { 17, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bonnie80@yahoo.com", null, "hiPKuQgjsxOlE5jKR/xY/93/mNTA8zWylZ8Bfo4/Jrk=", "SkApdc90bA/0vsJNHgTrS7WY/qhGtWohhkaC/hDkhBo=", "Whitney_Ankunding" },
                    { 18, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mariah63@yahoo.com", null, "dCKmR/6d/ISB+Tq8hQ8P9R8Pz+MyHsZZrISeRuRkOF0=", "SkApdc90bA/0vsJNHgTrS7WY/qhGtWohhkaC/hDkhBo=", "Dylan.Ryan8" },
                    { 19, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Darren_Halvorson@gmail.com", null, "hkuqWbjFa53SPlzbzt+yO0VykC9Jc1ptBKvHWwCAmBg=", "SkApdc90bA/0vsJNHgTrS7WY/qhGtWohhkaC/hDkhBo=", "Kiana4" },
                    { 20, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jerad_Will52@hotmail.com", null, "X2uda1noU0bTQgJ0wobC3PLnrXgZtEbMKGxj6uQ5Eeo=", "SkApdc90bA/0vsJNHgTrS7WY/qhGtWohhkaC/hDkhBo=", "Sienna_Hahn" },
                    { 21, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Friedrich.Padberg@gmail.com", null, "wQDOsyXUyLpe03u58+PCYGQfc8faE9ygrJpS04FwbrU=", "SkApdc90bA/0vsJNHgTrS7WY/qhGtWohhkaC/hDkhBo=", "Brionna_Hilll11" },
                    { 22, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lulu_Ondricka41@gmail.com", null, "boYmn9iuSl0KRxjDAyPLNB2KVAyLlQYmTjTs9gYuJcI=", "SkApdc90bA/0vsJNHgTrS7WY/qhGtWohhkaC/hDkhBo=", "Aliyah_Bartoletti39" },
                    { 23, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rahsaan82@hotmail.com", null, "EukefFXMQCk3fCETPL+BXrSBXKHAtFDOCXLumkeKnGc=", "SkApdc90bA/0vsJNHgTrS7WY/qhGtWohhkaC/hDkhBo=", "Madyson.Hessel" },
                    { 24, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ali_Swaniawski@gmail.com", null, "njjoPY0EbGrfPS+OrD4jzXrXYeDvfH88bgGR9l0tsmo=", "SkApdc90bA/0vsJNHgTrS7WY/qhGtWohhkaC/hDkhBo=", "Theresa.Hagenes" },
                    { 25, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marilie_Cassin78@hotmail.com", null, "S1JDoPkbXeT4tFCFWZKvUUL+opmaLaSzvDTuaaOHcUs=", "SkApdc90bA/0vsJNHgTrS7WY/qhGtWohhkaC/hDkhBo=", "Stephanie.Runolfsdottir" },
                    { 26, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Frieda.Lebsack@hotmail.com", null, "g52W+mkjpOWBWH3lU0doJz9lYTyzDIeIJkpHqyqwAiM=", "SkApdc90bA/0vsJNHgTrS7WY/qhGtWohhkaC/hDkhBo=", "Margie.DuBuque" },
                    { 27, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Reyna.Koelpin74@gmail.com", null, "MLiUnYLGqNH/7gddVrBFg/jMNIAPFYdsaZ+BfcjXkPU=", "SkApdc90bA/0vsJNHgTrS7WY/qhGtWohhkaC/hDkhBo=", "Adam92" },
                    { 28, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jordon49@yahoo.com", null, "fznVrLr46z4LziQPnk/VYb4HHQn/3bzwdhn49nMtvF0=", "SkApdc90bA/0vsJNHgTrS7WY/qhGtWohhkaC/hDkhBo=", "Henri_Jacobson6" },
                    { 29, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Muhammad.Gottlieb@gmail.com", null, "oWkat6NPwyY2ql8WVt2LgfHpYb5HQ/IMxvpHXa5WUyI=", "SkApdc90bA/0vsJNHgTrS7WY/qhGtWohhkaC/hDkhBo=", "Eldred_West" },
                    { 30, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sandrine87@yahoo.com", null, "62XuR9XDe2JbQ0vFZHbJaU7dA/zgaVbODz0WxHVBh0U=", "SkApdc90bA/0vsJNHgTrS7WY/qhGtWohhkaC/hDkhBo=", "Carmel.Gaylord" },
                    { 31, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jodie78@hotmail.com", null, "G4PInBM9ZuogJJUhkI1WNerweSf3H0k676Vb9wsAkvQ=", "SkApdc90bA/0vsJNHgTrS7WY/qhGtWohhkaC/hDkhBo=", "Lou46" },
                    { 32, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dino22@yahoo.com", null, "T9RDnMJzS95wUbhOZouh3rK/kZ8kqhJAdqWIAK2xMSg=", "SkApdc90bA/0vsJNHgTrS7WY/qhGtWohhkaC/hDkhBo=", "Linwood25" },
                    { 33, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anita23@gmail.com", null, "WgpgS2KgToBclpdQkUjjWeHuChbZd/3vint87LmXu3s=", "SkApdc90bA/0vsJNHgTrS7WY/qhGtWohhkaC/hDkhBo=", "Lavonne.Konopelski" },
                    { 34, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Selmer45@hotmail.com", null, "4m137u/irqn7ip4B9qtAjS8IpZMNRwqQsVFM8RKaipM=", "SkApdc90bA/0vsJNHgTrS7WY/qhGtWohhkaC/hDkhBo=", "Rod.Smitham" },
                    { 35, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kory_Rodriguez@hotmail.com", null, "kcIeST+0Pr4UryL23GzBjKibKJNqiVwnk0ycsYblyJQ=", "SkApdc90bA/0vsJNHgTrS7WY/qhGtWohhkaC/hDkhBo=", "Cecile89" },
                    { 36, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Estefania96@gmail.com", null, "g2NmtOMTg0VCQacC08YMvcZg54z2/wFgkQzm/sbUwQc=", "SkApdc90bA/0vsJNHgTrS7WY/qhGtWohhkaC/hDkhBo=", "Doug_Buckridge88" },
                    { 37, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jalyn_Goldner@yahoo.com", null, "StimVdskm+C3I+GkDdFTHOueI7cK4itL9RqyFSnt61U=", "SkApdc90bA/0vsJNHgTrS7WY/qhGtWohhkaC/hDkhBo=", "Rahul.Mitchell68" },
                    { 38, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jaunita_Hintz@hotmail.com", null, "Fvdq2ECdAp0mpPOtZe5Jb6bjKnpMHZQKhd1HO4Fb1R8=", "SkApdc90bA/0vsJNHgTrS7WY/qhGtWohhkaC/hDkhBo=", "Garry.Goodwin14" },
                    { 39, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Renee_Medhurst85@gmail.com", null, "5bYTW7Ds9DJ+xGafWph+gcQWbpBTndBawve2OUOz6sU=", "SkApdc90bA/0vsJNHgTrS7WY/qhGtWohhkaC/hDkhBo=", "Roosevelt.Dooley22" },
                    { 40, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Waylon_Jones39@hotmail.com", null, "yCDFlCim+uOfnnCtimrCX4G3lkOmWhfiS8m4yr5BgvE=", "SkApdc90bA/0vsJNHgTrS7WY/qhGtWohhkaC/hDkhBo=", "Deven13" }
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "ChatId", "CreatedAt", "MessageStatus", "UserId", "Value" },
                values: new object[,]
                {
                    { 1, 18, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 26, "Laudantium dignissimos ut expedita quasi necessitatibus facilis illo vitae consequuntur." },
                    { 2, 32, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 32, "Quam nulla vel quae omnis voluptatem aut vero." },
                    { 3, 14, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 34, "Aut quibusdam ullam molestiae." },
                    { 4, 5, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 38, "In quos autem deleniti consequatur facilis mollitia natus." },
                    { 5, 26, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 19, "Exercitationem repudiandae nulla et autem." },
                    { 6, 32, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 37, "Est modi error." },
                    { 7, 6, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, "Possimus expedita consequatur molestiae enim repellendus architecto non totam." },
                    { 8, 2, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 18, "Quia quia minima distinctio atque eos adipisci." },
                    { 9, 35, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, "Iure impedit est ut ut consequatur." },
                    { 10, 14, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, "Aut accusantium sunt adipisci doloribus excepturi quo repudiandae." },
                    { 11, 24, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, "Architecto est iusto rerum ut." },
                    { 12, 33, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 11, "Quia id voluptatibus sed id eos odit distinctio expedita qui." },
                    { 13, 3, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 1, "Ratione nihil laudantium quos aliquid ex eaque." },
                    { 14, 9, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 37, "Harum a sed." },
                    { 15, 27, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 24, "Veniam vero deleniti." },
                    { 16, 7, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 11, "Quis minus aliquam quod enim iure." },
                    { 17, 24, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 12, "Labore odio eveniet cumque tempora." },
                    { 18, 5, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 30, "Rem ut sit similique laboriosam placeat sint et maiores hic." },
                    { 19, 4, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 10, "Odit reiciendis fuga repellendus exercitationem optio nam aut commodi." },
                    { 20, 17, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 8, "Voluptatem laboriosam illo alias consectetur qui." },
                    { 21, 13, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, "Neque repudiandae doloribus autem." },
                    { 22, 3, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 25, "Natus consequuntur harum autem." },
                    { 23, 34, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 38, "Ut voluptatem praesentium id qui voluptatem aliquam minima velit error." },
                    { 24, 28, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 27, "Qui et est repellendus praesentium accusamus corporis et sit earum." },
                    { 25, 27, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 34, "Quo cupiditate et qui non adipisci et in qui vel." },
                    { 26, 6, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 38, "Mollitia sint eos quis veniam expedita tempore sit." },
                    { 27, 26, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 30, "Eligendi repellat beatae occaecati." },
                    { 28, 3, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 40, "Dignissimos tempore hic deleniti sit." },
                    { 29, 33, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 12, "Officiis doloribus et non deserunt nemo ut et libero autem." },
                    { 30, 3, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 11, "Soluta nemo qui quas molestiae voluptatem." },
                    { 31, 26, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 15, "Ea ut et ut." },
                    { 32, 36, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 29, "Dolorum magni incidunt rerum non doloribus aspernatur est." },
                    { 33, 6, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 12, "Animi perferendis fuga magnam ut." },
                    { 34, 34, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 17, "Id cum dolorum." },
                    { 35, 28, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 27, "Iure ullam qui ipsam maxime." },
                    { 36, 20, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 21, "Id dolor quod ea." },
                    { 37, 3, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 20, "Optio est nisi facilis tempore." },
                    { 38, 13, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 31, "Et aut qui est perferendis sed." },
                    { 39, 22, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 16, "In in et dolore aliquid recusandae inventore." },
                    { 40, 27, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 24, "Qui incidunt amet voluptatem ut quibusdam quas nobis." },
                    { 41, 27, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 29, "Ut id dolor labore." },
                    { 42, 25, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 29, "Harum recusandae asperiores repudiandae dolor beatae ea." },
                    { 43, 14, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 11, "Aspernatur cupiditate minus quibusdam." },
                    { 44, 19, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 28, "Voluptatem quidem dicta officia sint et sit aliquid molestias." },
                    { 45, 5, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 39, "Qui rerum aut rerum labore ad deleniti sequi iusto." },
                    { 46, 14, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 38, "Iste quisquam provident earum magni aut." },
                    { 47, 24, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 15, "Perspiciatis ut architecto asperiores ducimus qui pariatur nihil sit eos." },
                    { 48, 20, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 20, "Voluptates esse doloribus et fuga rerum consequuntur." },
                    { 49, 16, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 35, "Laborum illum similique odio porro." },
                    { 50, 6, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 8, "Error ut neque veniam doloremque molestiae qui dicta tenetur sapiente." }
                });

            migrationBuilder.InsertData(
                table: "UserChats",
                columns: new[] { "ChatId", "UserId" },
                values: new object[,]
                {
                    { 30, 7 },
                    { 8, 15 },
                    { 8, 22 },
                    { 4, 28 },
                    { 30, 34 },
                    { 4, 37 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ChatId",
                table: "Messages",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_UserId",
                table: "Messages",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserChats_ChatId",
                table: "UserChats",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "UserChats");

            migrationBuilder.DropTable(
                name: "Chats");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
