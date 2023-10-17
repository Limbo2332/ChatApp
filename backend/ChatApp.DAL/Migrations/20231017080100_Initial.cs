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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ChatId = table.Column<int>(type: "int", nullable: false),
                    IsSender = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserChats", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "UserMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    MessageId = table.Column<int>(type: "int", nullable: false),
                    IsSender = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserMessages_Messages_MessageId",
                        column: x => x.MessageId,
                        principalTable: "Messages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserMessages_Users_UserId",
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
                    { 30, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "ImagePath", "Password", "UserName" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Junior14@hotmail.com", null, "lwhrmF3n3U/fUvJJxw9a7sfr5bdtbshOyPj0cDq1XgA=", "Erwin_Jenkins" },
                    { 2, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Monique_Schneider@gmail.com", null, "lpsUbsg6Ci7+VxIvDOW60ppdnaJKjJM3TJLJIk92+Ak=", "Taya73" },
                    { 3, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trever_Ledner10@gmail.com", null, "rsJDVz7aubJOC7krUyp08x609xi5QsysXvVWA5apuxU=", "Hazle36" },
                    { 4, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Treva_Abernathy@yahoo.com", null, "1Ga/eMKkkJ40K6cjt6bewT2XjRDMdbJqHK/2QQn0Mm0=", "Anastasia.Kuhlman" },
                    { 5, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dino17@gmail.com", null, "Hg5krs87MCNHoK32vJs+IrvgBbvQh/YA7JUalNJAvRI=", "Coty_Bergnaum" },
                    { 6, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Monserrate_Kuhlman88@gmail.com", null, "qBucaiT+vGl6P9LKTuDtvprEU0gLQgkYr6PYl3EylyQ=", "Jamar72" },
                    { 7, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Conor23@yahoo.com", null, "zuMYd8t2ZrxkOzUxyws8Y1PIXCQFN47VG5/9daiHRAQ=", "Austin_Johnson" },
                    { 8, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mauricio.Padberg68@hotmail.com", null, "MgkcgqQrhUnjBCB2gyK1pslZni+2w8E+xUywWirVsig=", "Johnathan62" },
                    { 9, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vada61@hotmail.com", null, "/1tPphLylBea7qQt+tDtKl5Ow/OlreKCape08/KrzA4=", "Karianne.Durgan11" },
                    { 10, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Darien66@gmail.com", null, "FBUugg+qfqkV92bg54WxEY5JdXCjdtTQ2YKSi02AGRs=", "Steve_Jacobi51" },
                    { 11, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Danika.Satterfield@yahoo.com", null, "Bqmmi9fvp5Z/KIEJd48J7+fz4W1YQPRBVyGYxi7R5nM=", "Orlo.Rau" },
                    { 12, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Damion_Moen25@hotmail.com", null, "9lDl5FCEIrmuACTTqzk8GSna2BHyoRSV4g5JzWV/hX0=", "Tad.Mills" },
                    { 13, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lazaro.Wehner@hotmail.com", null, "zycTTgIW/N6APTYA9sdtXIlIIfB3zghPnDd/xU65y6s=", "Doug.Legros" },
                    { 14, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andrew.Lueilwitz@yahoo.com", null, "uVYBkf0C29WNiHCN296jDhJmF2ezc8pNEz4J6zDX2uQ=", "Danny.Mayert49" },
                    { 15, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dejuan_Blick@hotmail.com", null, "lewDb/3SjyKKLZF19A2AeR7Pczvts0Lk2e845xHlMD8=", "Gabriel.Strosin33" },
                    { 16, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gilda_Shanahan@hotmail.com", null, "TPYMfKxODH/gWV+7GBpysc7ImYj0FAz9WeG9US4YgBI=", "Triston.Doyle" },
                    { 17, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bonnie80@yahoo.com", null, "hiPKuQgjsxOlE5jKR/xY/93/mNTA8zWylZ8Bfo4/Jrk=", "Whitney_Ankunding" },
                    { 18, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mariah63@yahoo.com", null, "dCKmR/6d/ISB+Tq8hQ8P9R8Pz+MyHsZZrISeRuRkOF0=", "Dylan.Ryan8" },
                    { 19, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Darren_Halvorson@gmail.com", null, "hkuqWbjFa53SPlzbzt+yO0VykC9Jc1ptBKvHWwCAmBg=", "Kiana4" },
                    { 20, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jerad_Will52@hotmail.com", null, "X2uda1noU0bTQgJ0wobC3PLnrXgZtEbMKGxj6uQ5Eeo=", "Sienna_Hahn" }
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "ChatId", "CreatedAt", "MessageStatus", "Value" },
                values: new object[,]
                {
                    { 1, 20, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Laudantium dignissimos ut expedita quasi necessitatibus facilis illo vitae consequuntur." },
                    { 2, 27, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Et quam nulla vel quae omnis." },
                    { 3, 11, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Modi repellendus repellendus sequi aut quibusdam ullam molestiae possimus." },
                    { 4, 29, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "In quos autem deleniti consequatur facilis mollitia natus." },
                    { 5, 27, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Ullam exercitationem repudiandae." },
                    { 6, 27, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Quis blanditiis et perferendis est modi." },
                    { 7, 11, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Dolor nulla possimus expedita consequatur molestiae enim repellendus architecto non." },
                    { 8, 9, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Dolores omnis quia." },
                    { 9, 20, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Atque eos adipisci tenetur et ab iure iure." },
                    { 10, 16, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Ut consequatur id explicabo et placeat aut accusantium sunt adipisci." },
                    { 11, 12, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Repudiandae in ipsa sit quia architecto est iusto rerum." },
                    { 12, 30, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Qui saepe quia." },
                    { 13, 25, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Id eos odit distinctio expedita qui rerum." },
                    { 14, 1, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Ratione nihil laudantium quos aliquid ex eaque." },
                    { 15, 10, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Et harum a." },
                    { 16, 8, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Numquam ipsa veniam vero deleniti quam deserunt distinctio iure quis." },
                    { 17, 22, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Enim iure illo enim ipsum quis labore odio." },
                    { 18, 30, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "At nostrum animi non." },
                    { 19, 30, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Similique laboriosam placeat sint." },
                    { 20, 1, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Eaque est fugit aut odit reiciendis fuga repellendus exercitationem optio." },
                    { 21, 2, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Repellendus magnam vitae totam voluptatem." },
                    { 22, 13, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Consectetur qui distinctio." },
                    { 23, 3, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Neque repudiandae doloribus autem." },
                    { 24, 19, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Magni natus consequuntur harum autem." },
                    { 25, 19, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Asperiores ut voluptatem." },
                    { 26, 26, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Voluptatem aliquam minima velit error non." },
                    { 27, 20, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Qui et est repellendus praesentium accusamus corporis et sit earum." },
                    { 28, 22, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "A quo cupiditate et qui non adipisci et." },
                    { 29, 21, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Quibusdam voluptas distinctio impedit mollitia sint eos quis veniam." },
                    { 30, 21, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Aut itaque qui." },
                    { 31, 20, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Beatae occaecati natus id harum ullam dignissimos tempore hic deleniti." },
                    { 32, 12, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Illo rerum officiis doloribus et non deserunt nemo ut et." },
                    { 33, 10, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Veniam qui nihil." },
                    { 34, 28, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Quas molestiae voluptatem quia magnam inventore non ea." },
                    { 35, 21, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Distinctio ex et cum dolorum magni incidunt rerum non doloribus." },
                    { 36, 5, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Porro saepe commodi animi perferendis fuga magnam ut ipsum." },
                    { 37, 13, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Id cum dolorum." },
                    { 38, 23, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Voluptas iure ullam qui ipsam maxime ex nam est." },
                    { 39, 21, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Quod ea ut molestias quos ea optio est nisi." },
                    { 40, 5, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Corrupti quasi deleniti et aut qui est perferendis." },
                    { 41, 12, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Corporis excepturi in in et dolore aliquid recusandae inventore." },
                    { 42, 21, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Maxime qui incidunt amet voluptatem ut quibusdam." },
                    { 43, 20, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Mollitia expedita et ut id dolor labore qui." },
                    { 44, 22, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Harum recusandae asperiores repudiandae dolor beatae ea." },
                    { 45, 24, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ipsum aspernatur cupiditate minus quibusdam et voluptatem." },
                    { 46, 11, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Quidem dicta officia sint et." },
                    { 47, 8, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Similique eligendi rem vel qui rerum aut." },
                    { 48, 13, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Deleniti sequi iusto excepturi aut." },
                    { 49, 29, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Quisquam provident earum magni aut labore itaque." },
                    { 50, 5, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Ut architecto asperiores ducimus qui pariatur nihil." },
                    { 51, 26, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Consequatur in dolorum voluptates esse." },
                    { 52, 18, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Rerum consequuntur fugit atque corrupti commodi laborum." },
                    { 53, 5, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Porro incidunt officiis iure maiores error." },
                    { 54, 3, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Doloremque molestiae qui dicta tenetur." },
                    { 55, 12, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Ratione voluptates doloremque porro." },
                    { 56, 26, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Blanditiis quo et eos officia." },
                    { 57, 26, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Veniam maiores ullam voluptates atque voluptatibus deserunt inventore quis magnam." },
                    { 58, 6, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ullam ipsa neque cupiditate." },
                    { 59, 5, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Et sed est minus vero natus." },
                    { 60, 10, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Cum in et adipisci." },
                    { 61, 17, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Expedita illo officia." },
                    { 62, 14, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Distinctio laudantium minima ut sed nesciunt autem ut laboriosam." },
                    { 63, 2, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Consequatur maxime voluptatem similique ab." },
                    { 64, 29, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Et eligendi cum inventore rerum soluta." },
                    { 65, 10, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Totam eum delectus repudiandae ab debitis quaerat." },
                    { 66, 16, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Assumenda ex accusamus suscipit voluptate adipisci." },
                    { 67, 24, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Fugiat dicta alias nam sequi aut recusandae." },
                    { 68, 27, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Ut odio dolorem pariatur." },
                    { 69, 23, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Corrupti praesentium tenetur accusamus alias." },
                    { 70, 5, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Minima sunt illo ea enim eos." },
                    { 71, 28, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Odit quam totam dolorem vel et." },
                    { 72, 3, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ut esse alias id quas odit." },
                    { 73, 27, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Ea natus eligendi fugiat aut voluptatem dolor officiis." },
                    { 74, 6, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Excepturi ea beatae enim minus maxime nisi." },
                    { 75, 29, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Distinctio fugiat a non aut quia deleniti cum." },
                    { 76, 8, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Sed sequi praesentium id quod ad dignissimos sed maiores itaque." },
                    { 77, 23, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Sapiente officiis suscipit minus officiis." },
                    { 78, 23, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Eveniet doloremque cumque." },
                    { 79, 22, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Explicabo earum cumque velit iusto." },
                    { 80, 6, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Quia dolorum libero doloribus totam." },
                    { 81, 1, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Quod debitis mollitia expedita." },
                    { 82, 11, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Placeat et dolorem sit eum nemo quia omnis debitis consequatur." },
                    { 83, 21, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Quis id nisi ullam officia." },
                    { 84, 3, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Veritatis aut nostrum eos et quo nostrum qui." },
                    { 85, 26, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Sunt hic tenetur qui est facere rerum alias." },
                    { 86, 11, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Voluptatibus quos omnis itaque eveniet alias provident ullam et." },
                    { 87, 25, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Nobis et provident voluptatem delectus." },
                    { 88, 18, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Placeat non et quaerat enim sit laboriosam id unde nihil." },
                    { 89, 25, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Enim ut et enim molestiae illum nostrum nostrum eum." },
                    { 90, 2, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Cum ut voluptatum architecto et sint velit magnam." },
                    { 91, 20, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Magnam nostrum et." },
                    { 92, 24, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Placeat commodi enim possimus nihil velit voluptatem minus aut." },
                    { 93, 20, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Facilis sint repudiandae molestiae excepturi quidem et." },
                    { 94, 7, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Repellendus labore sit." },
                    { 95, 8, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Omnis sit ullam magnam et quos vitae est ut." },
                    { 96, 24, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Blanditiis nisi quam debitis harum quo minima consequuntur eos." },
                    { 97, 30, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Et quibusdam dolores harum in aperiam molestiae quos amet quia." },
                    { 98, 13, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Cupiditate voluptates sequi quo ut necessitatibus occaecati eum." },
                    { 99, 22, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Optio et id et et." },
                    { 100, 23, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Labore nemo facere fugiat ea ducimus architecto quas." },
                    { 101, 28, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Veniam neque molestiae eos aut et consequuntur nostrum." },
                    { 102, 13, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Est quis iure illum itaque." },
                    { 103, 6, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Voluptas dicta totam qui facere et assumenda beatae autem." },
                    { 104, 15, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Tenetur fuga ut consequuntur nesciunt ut." },
                    { 105, 13, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Non consequatur fugiat quibusdam aut optio laudantium dignissimos ut." },
                    { 106, 22, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Possimus sint qui." },
                    { 107, 23, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Nihil laboriosam est sit ut soluta unde nemo." },
                    { 108, 9, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Distinctio tempore ut recusandae asperiores." },
                    { 109, 6, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Expedita dolor minus corporis harum aliquam aut temporibus." },
                    { 110, 5, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Tenetur enim qui deserunt veritatis nesciunt sunt adipisci." },
                    { 111, 26, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Nam quo quo sit." },
                    { 112, 1, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Eos voluptas id enim dolor ab saepe." },
                    { 113, 4, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Architecto voluptatem necessitatibus." },
                    { 114, 28, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Quibusdam hic non beatae quo." },
                    { 115, 1, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Quis deleniti velit." },
                    { 116, 5, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Qui autem quae quis ipsum et aut." },
                    { 117, 1, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Optio sunt quia repellat sed rerum." },
                    { 118, 15, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Et sint ut libero possimus nam ea." },
                    { 119, 6, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Cumque rerum dolor hic dignissimos rerum cumque aut animi quasi." },
                    { 120, 28, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Illum consequatur vel maxime." },
                    { 121, 18, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Corrupti eius ea natus deserunt tempore eius nihil quis fuga." },
                    { 122, 28, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Nihil iusto omnis sint qui soluta ea." },
                    { 123, 29, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Itaque accusamus magnam voluptas esse eos autem et." },
                    { 124, 30, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Qui deleniti ut modi ea assumenda." },
                    { 125, 30, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Reiciendis quaerat aut natus ducimus vel ab laudantium." },
                    { 126, 26, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Culpa in iste totam est laboriosam voluptates." },
                    { 127, 13, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Nihil odit laborum dolores aliquam tenetur cupiditate eligendi dolor voluptates." },
                    { 128, 2, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Soluta cum possimus eligendi." },
                    { 129, 26, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Repudiandae ipsam minus velit et debitis molestiae voluptas provident." },
                    { 130, 16, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sequi est ad voluptatem dolores nihil adipisci." },
                    { 131, 23, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Qui veritatis est nesciunt aliquid officiis autem non est." },
                    { 132, 7, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Alias iure autem." },
                    { 133, 14, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Accusantium omnis nesciunt omnis ab voluptatem." },
                    { 134, 15, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Cupiditate voluptatem ut quia est veniam." },
                    { 135, 4, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Et maxime non illo aut animi quis enim." },
                    { 136, 9, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Necessitatibus omnis exercitationem adipisci illum in voluptas laborum inventore." },
                    { 137, 13, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Eveniet totam ut libero vel rem nesciunt placeat vero necessitatibus." },
                    { 138, 5, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Pariatur aut temporibus iste reprehenderit omnis." },
                    { 139, 20, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Occaecati placeat delectus quasi corporis quia occaecati provident." },
                    { 140, 12, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Pariatur harum qui impedit recusandae doloribus et." },
                    { 141, 23, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Repellat architecto necessitatibus impedit ut molestiae aut illo libero ut." },
                    { 142, 29, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Hic occaecati cumque nemo." },
                    { 143, 7, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Voluptas blanditiis ab necessitatibus." },
                    { 144, 16, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Beatae fuga in reiciendis voluptas est." },
                    { 145, 4, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Beatae commodi sit dolor perspiciatis voluptatum assumenda esse." },
                    { 146, 18, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Quidem amet incidunt nobis harum placeat." },
                    { 147, 8, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Voluptatem alias architecto facere eaque eveniet molestiae." },
                    { 148, 19, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Aut ducimus molestiae." },
                    { 149, 12, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Fugiat ipsum soluta pariatur est quidem quia provident et placeat." },
                    { 150, 23, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Nisi perferendis et sit reiciendis et architecto quis." },
                    { 151, 23, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ab dolores nesciunt et consequuntur delectus non nisi." },
                    { 152, 1, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Culpa laudantium minus vero iure autem perspiciatis hic quis." },
                    { 153, 8, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Repudiandae ab ut voluptatem ducimus consectetur unde." },
                    { 154, 17, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Aperiam et consectetur voluptatum officia voluptate." },
                    { 155, 9, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Temporibus reiciendis perspiciatis iusto dolorem qui quia." },
                    { 156, 23, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Et qui facilis sit earum et similique dolor." },
                    { 157, 28, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Illo beatae perspiciatis voluptatem." },
                    { 158, 19, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Voluptates sed dolores sed placeat blanditiis et in." },
                    { 159, 19, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Vel voluptas molestiae ut." },
                    { 160, 1, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Iure repellendus magnam incidunt voluptatem et dolores omnis qui minus." },
                    { 161, 16, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Id occaecati praesentium ex beatae." },
                    { 162, 24, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Consectetur est commodi debitis tenetur animi necessitatibus iusto." },
                    { 163, 21, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sint quia ipsa ratione." },
                    { 164, 21, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Molestias maiores aut veritatis." },
                    { 165, 10, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Voluptas odio exercitationem accusamus similique." },
                    { 166, 11, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Enim velit aut." },
                    { 167, 29, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Accusantium et laboriosam." },
                    { 168, 22, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Dicta aut optio quis ipsa cum eveniet aut." },
                    { 169, 18, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Voluptatem est excepturi fuga." },
                    { 170, 10, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Distinctio animi eos et ut nulla eos." },
                    { 171, 17, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Deleniti quod quidem." },
                    { 172, 23, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Minima numquam maxime et dolorem necessitatibus quis sed officia perspiciatis." },
                    { 173, 16, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Nulla dignissimos accusamus est." },
                    { 174, 11, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Officiis quis quia pariatur ut." },
                    { 175, 23, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Dolorum repellendus explicabo incidunt cumque placeat incidunt voluptate velit." },
                    { 176, 3, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Enim distinctio non ea est reprehenderit sit deleniti nam." },
                    { 177, 18, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Qui numquam et asperiores consequatur saepe est enim provident." },
                    { 178, 2, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Ducimus voluptas quae ducimus laborum aperiam blanditiis aut accusantium." },
                    { 179, 27, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Architecto pariatur beatae nulla." },
                    { 180, 21, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Consequatur optio incidunt quo." },
                    { 181, 25, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Ea sint maiores et." },
                    { 182, 27, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Voluptate repudiandae non." },
                    { 183, 26, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Et nesciunt sed quo nam dolor at sint nesciunt." },
                    { 184, 1, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Distinctio autem sunt odit." },
                    { 185, 4, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Assumenda autem harum itaque maiores mollitia corrupti." },
                    { 186, 6, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Recusandae ratione et exercitationem consequatur dolores pariatur in." },
                    { 187, 18, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Dolorem voluptatem et cumque qui." },
                    { 188, 30, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Quas corporis optio molestiae dolor fugit." },
                    { 189, 8, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Magni labore quia tenetur." },
                    { 190, 22, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Tempore nisi quo et." },
                    { 191, 9, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Qui fugiat quaerat earum illo reprehenderit labore." },
                    { 192, 5, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Temporibus fuga commodi labore modi porro sit excepturi quas et." },
                    { 193, 27, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Aliquid aut et sit accusantium et laudantium non natus dolor." },
                    { 194, 30, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Occaecati quia odio." },
                    { 195, 14, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Itaque ut neque aspernatur necessitatibus." },
                    { 196, 30, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Et eos autem explicabo dicta nam quo voluptates." },
                    { 197, 18, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Non ipsa quo voluptatibus tempora." },
                    { 198, 5, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Magni velit consequatur architecto eveniet." },
                    { 199, 18, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Minus amet consequatur quia." },
                    { 200, 7, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Consequatur temporibus amet nobis." }
                });

            migrationBuilder.InsertData(
                table: "UserChats",
                columns: new[] { "Id", "ChatId", "CreatedAt", "IsSender", "UserId" },
                values: new object[,]
                {
                    { 28, 20, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 20 },
                    { 30, 4, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 1 },
                    { 66, 13, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 15 },
                    { 68, 20, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 4 },
                    { 74, 25, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 12 },
                    { 89, 25, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 16 },
                    { 93, 13, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 5 },
                    { 95, 4, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1 }
                });

            migrationBuilder.InsertData(
                table: "UserMessages",
                columns: new[] { "Id", "CreatedAt", "IsSender", "MessageId", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 175, 16 },
                    { 2, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 59, 15 },
                    { 3, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 160, 4 },
                    { 4, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 87, 1 },
                    { 5, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 55, 15 },
                    { 6, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 136, 5 },
                    { 7, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 126, 1 },
                    { 8, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 14, 16 },
                    { 9, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 135, 15 },
                    { 10, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 132, 16 },
                    { 11, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 93, 5 },
                    { 12, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 18, 15 },
                    { 13, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 143, 20 },
                    { 14, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 148, 20 },
                    { 15, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 174, 20 },
                    { 16, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 185, 1 },
                    { 17, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 148, 5 },
                    { 18, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 156, 16 },
                    { 19, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 191, 5 },
                    { 20, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 191, 5 },
                    { 21, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 69, 4 },
                    { 22, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 124, 1 },
                    { 23, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 185, 16 },
                    { 24, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 117, 4 },
                    { 25, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 75, 5 },
                    { 26, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 183, 15 },
                    { 27, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 45, 1 },
                    { 28, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 34, 12 },
                    { 29, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 143, 1 },
                    { 30, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 189, 4 },
                    { 31, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 71, 5 },
                    { 32, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 185, 1 },
                    { 33, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 129, 1 },
                    { 34, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 77, 1 },
                    { 35, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 107, 15 },
                    { 36, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 44, 1 },
                    { 37, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 29, 16 },
                    { 38, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 85, 15 },
                    { 39, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 72, 12 },
                    { 40, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 190, 4 },
                    { 41, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 151, 1 },
                    { 42, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 100, 20 },
                    { 43, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 91, 4 },
                    { 44, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 10, 1 },
                    { 45, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 169, 16 },
                    { 46, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 62, 12 },
                    { 47, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 21, 12 },
                    { 48, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 69, 1 },
                    { 49, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 14, 20 },
                    { 50, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 80, 20 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ChatId",
                table: "Messages",
                column: "ChatId");

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
                name: "IX_UserChats_UserId",
                table: "UserChats",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMessages_MessageId",
                table: "UserMessages",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMessages_UserId",
                table: "UserMessages",
                column: "UserId");

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
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "UserChats");

            migrationBuilder.DropTable(
                name: "UserMessages");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Chats");
        }
    }
}
