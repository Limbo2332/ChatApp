using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ChatApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUserMessages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserMessages");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Messages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ChatId", "UserId", "Value" },
                values: new object[] { 24, 16, "Quam nulla vel quae omnis voluptatem aut vero." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ChatId", "UserId", "Value" },
                values: new object[] { 26, 7, "Aut quibusdam ullam molestiae." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 4,
                column: "UserId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 14, 1, 13, "Exercitationem repudiandae nulla et autem." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 28, 2, 16, "Est modi error." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ChatId", "UserId", "Value" },
                values: new object[] { 2, 3, "Possimus expedita consequatur molestiae enim repellendus architecto non totam." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 13, 2, 1, "Quia quia minima distinctio atque eos adipisci." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 3, 1, 18, "Iure impedit est ut ut consequatur." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 2, 1, 7, "Aut accusantium sunt adipisci doloribus excepturi quo repudiandae." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 2, 1, 12, "Architecto est iusto rerum ut." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 9, 2, 17, "Quia id voluptatibus sed id eos odit distinctio expedita qui." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "ChatId", "UserId", "Value" },
                values: new object[] { 1, 2, "Ratione nihil laudantium quos aliquid ex eaque." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "ChatId", "UserId", "Value" },
                values: new object[] { 28, 5, "Harum a sed." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "ChatId", "UserId", "Value" },
                values: new object[] { 18, 14, "Veniam vero deleniti." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 9, 0, 4, "Quis minus aliquam quod enim iure." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "ChatId", "UserId", "Value" },
                values: new object[] { 9, 12, "Labore odio eveniet cumque tempora." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 22, 0, 3, "Rem ut sit similique laboriosam placeat sint et maiores hic." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "ChatId", "UserId", "Value" },
                values: new object[] { 8, 2, "Odit reiciendis fuga repellendus exercitationem optio nam aut commodi." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "ChatId", "UserId", "Value" },
                values: new object[] { 6, 9, "Voluptatem laboriosam illo alias consectetur qui." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "ChatId", "UserId", "Value" },
                values: new object[] { 3, 7, "Neque repudiandae doloribus autem." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 19, 2, 2, "Natus consequuntur harum autem." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 29, 2, 17, "Ut voluptatem praesentium id qui voluptatem aliquam minima velit error." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 20, 0, 14, "Qui et est repellendus praesentium accusamus corporis et sit earum." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 26, 2, 14, "Quo cupiditate et qui non adipisci et in qui vel." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 29, 0, 3, "Mollitia sint eos quis veniam expedita tempore sit." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 23, 1, 13, "Eligendi repellat beatae occaecati." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "ChatId", "UserId", "Value" },
                values: new object[] { 30, 2, "Dignissimos tempore hic deleniti sit." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 9, 0, 17, "Officiis doloribus et non deserunt nemo ut et libero autem." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "ChatId", "UserId", "Value" },
                values: new object[] { 8, 2, "Soluta nemo qui quas molestiae voluptatem." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 11, 1, 13, "Ea ut et ut." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "ChatId", "UserId", "Value" },
                values: new object[] { 22, 18, "Dolorum magni incidunt rerum non doloribus aspernatur est." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 9, 0, 3, "Animi perferendis fuga magnam ut." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 13, 2, 17, "Id cum dolorum." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 20, 1, 14, "Iure ullam qui ipsam maxime." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "ChatId", "UserId", "Value" },
                values: new object[] { 16, 10, "Id dolor quod ea." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "ChatId", "UserId", "Value" },
                values: new object[] { 15, 2, "Optio est nisi facilis tempore." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "ChatId", "UserId", "Value" },
                values: new object[] { 24, 7, "Et aut qui est perferendis sed." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "ChatId", "UserId", "Value" },
                values: new object[] { 12, 11, "In in et dolore aliquid recusandae inventore." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 18, 2, 14, "Qui incidunt amet voluptatem ut quibusdam quas nobis." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "ChatId", "UserId", "Value" },
                values: new object[] { 22, 14, "Ut id dolor labore." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 22, 2, 13, "Harum recusandae asperiores repudiandae dolor beatae ea." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 8, 1, 7, "Aspernatur cupiditate minus quibusdam." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 21, 1, 10, "Voluptatem quidem dicta officia sint et sit aliquid molestias." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "ChatId", "UserId", "Value" },
                values: new object[] { 30, 3, "Qui rerum aut rerum labore ad deleniti sequi iusto." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "ChatId", "UserId", "Value" },
                values: new object[] { 29, 7, "Iste quisquam provident earum magni aut." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 12, 1, 12, "Perspiciatis ut architecto asperiores ducimus qui pariatur nihil sit eos." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "ChatId", "UserId", "Value" },
                values: new object[] { 15, 10, "Voluptates esse doloribus et fuga rerum consequuntur." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 27, 0, 8, "Laborum illum similique odio porro." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "ChatId", "UserId", "Value" },
                values: new object[] { 6, 3, "Error ut neque veniam doloremque molestiae qui dicta tenetur sapiente." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "MessageStatus", "UserId", "Value" },
                values: new object[] { 1, 19, "Doloremque porro maiores autem ipsam blanditiis quo et eos officia." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 2, 1, 8, "Maiores ullam voluptates atque voluptatibus." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 16, 0, 9, "Impedit fugiat adipisci ullam ipsa." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "ChatId", "UserId", "Value" },
                values: new object[] { 26, 12, "Laudantium et sed est." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 18, 0, 5, "Ratione dolores cum in et adipisci sint corporis aspernatur expedita." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 9, 2, 7, "At distinctio laudantium minima ut sed nesciunt." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 18, 0, 2, "Blanditiis quis consequatur maxime." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "ChatId", "UserId", "Value" },
                values: new object[] { 15, 17, "Ab dignissimos et eligendi cum inventore rerum soluta asperiores earum." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 13, 1, 4, "Repudiandae ab debitis quaerat blanditiis ipsam odio assumenda ex accusamus." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 24, 2, 5, "Excepturi natus fugiat dicta alias nam sequi aut recusandae." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "ChatId", "UserId", "Value" },
                values: new object[] { 4, 15, "Odio dolorem pariatur omnis accusamus laboriosam corrupti praesentium tenetur accusamus." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 5, 2, 9, "Minima sunt illo ea enim eos." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "ChatId", "UserId", "Value" },
                values: new object[] { 25, 3, "Quam totam dolorem." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 17, 1, 14, "Voluptatum ut esse alias id quas odit laudantium et impedit." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 9, 0, 15, "Aut voluptatem dolor officiis voluptatem aut est excepturi ea." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "ChatId", "UserId", "Value" },
                values: new object[] { 10, 10, "Nisi ea ipsum cum distinctio fugiat a non." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 14, 0, 5, "Qui rerum saepe sed sequi praesentium id quod." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "ChatId", "UserId", "Value" },
                values: new object[] { 2, 18, "Itaque dolor ut corporis sapiente officiis suscipit minus officiis omnis." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "ChatId", "UserId", "Value" },
                values: new object[] { 3, 19, "Cumque qui minus." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "ChatId", "UserId", "Value" },
                values: new object[] { 15, 19, "Velit iusto itaque quo enim quia dolorum libero." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 18, 1, 1, "Sit quod debitis mollitia." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 11, 2, 6, "Placeat et dolorem sit eum nemo quia omnis debitis consequatur." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 22, 2, 2, "Id nisi ullam officia est." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 29, 2, 8, "Nostrum eos et quo nostrum qui magni beatae minus sunt." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "ChatId", "UserId", "Value" },
                values: new object[] { 17, 19, "Facere rerum alias vitae eos autem voluptatibus." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 29, 0, 12, "Alias provident ullam et sint laboriosam ad nobis et provident." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 22, 1, 13, "Itaque placeat non et quaerat enim sit laboriosam id." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 9, 0, 17, "At enim ut et enim molestiae illum." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 15, 0, 2, "Vel placeat cum." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 9, 0, 13, "Sint velit magnam molestiae ipsa illo." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "UserId", "Value" },
                values: new object[] { 15, "Distinctio quibusdam placeat commodi enim possimus nihil." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 28, 1, 19, "Eaque omnis ut." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 8, 2, 7, "Excepturi quidem et et distinctio fugit." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 30, 1, 6, "Tempora nulla omnis sit ullam magnam et quos vitae est." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 24, 2, 20, "Blanditiis nisi quam debitis harum quo minima consequuntur eos." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 6, 1, 4, "Quibusdam dolores harum in aperiam molestiae." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 26, 0, 6, "Asperiores quod cupiditate voluptates." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 22, 0, 15, "Occaecati eum non voluptate voluptatem optio et id et et." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 3, 1, 11, "Nemo facere fugiat ea." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "ChatId", "UserId", "Value" },
                values: new object[] { 4, 6, "Omnis libero veniam neque molestiae eos aut." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 26, 2, 2, "Recusandae voluptatem est quis iure illum itaque libero et." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 6, 1, 8, "Qui facere et assumenda beatae autem." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "ChatId", "UserId", "Value" },
                values: new object[] { 24, 20, "Fuga ut consequuntur nesciunt ut assumenda dolores vel non consequatur." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 25, 1, 15, "Laudantium dignissimos ut molestias ea architecto possimus sint." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "ChatId", "UserId", "Value" },
                values: new object[] { 23, 6, "Nihil laboriosam est sit ut soluta unde nemo." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "ChatId", "UserId", "Value" },
                values: new object[] { 23, 7, "Tempore ut recusandae asperiores ipsam ad harum expedita." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 18, 1, 2, "Aliquam aut temporibus enim adipisci nihil tenetur enim." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "ChatId", "UserId", "Value" },
                values: new object[] { 20, 15, "Sunt adipisci et sequi." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "ChatId", "UserId", "Value" },
                values: new object[] { 2, 18, "Sit aut quo et eos voluptas id enim." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 3, 0, 17, "Aperiam sunt architecto voluptatem necessitatibus labore fugit veniam quibusdam hic." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 2, 1, 6, "Ut sed quis deleniti velit fugit voluptatem officia qui." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 21, 1, 2, "Et aut facilis dolores." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 1, 0, 12, "Repellat sed rerum." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "UserId", "Value" },
                values: new object[] { 19, "Sint ut libero possimus nam ea." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 21, 0, 4, "Rerum dolor hic dignissimos rerum cumque aut animi." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 28, 1, 20, "Illum consequatur vel maxime." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "ChatId", "UserId", "Value" },
                values: new object[] { 9, 13, "Eius ea natus deserunt tempore eius." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 28, 1, 14, "Sunt dolorum nihil iusto omnis sint qui soluta ea." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 15, 1, 5, "Accusamus magnam voluptas esse eos autem et nihil a atque." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 110,
                columns: new[] { "ChatId", "UserId", "Value" },
                values: new object[] { 30, 6, "Ea assumenda quam repellat." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 111,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 14, 0, 13, "Natus ducimus vel." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 112,
                columns: new[] { "ChatId", "UserId", "Value" },
                values: new object[] { 22, 3, "Perspiciatis culpa in iste totam est laboriosam voluptates et nulla." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 113,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 13, 2, 5, "Dolores aliquam tenetur cupiditate eligendi dolor voluptates." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 114,
                columns: new[] { "ChatId", "UserId", "Value" },
                values: new object[] { 13, 19, "Cum possimus eligendi ipsam eaque consequatur repudiandae ipsam." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 115,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 13, 1, 4, "Molestiae voluptas provident sit eos dolorum sequi est ad voluptatem." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 116,
                columns: new[] { "ChatId", "UserId", "Value" },
                values: new object[] { 27, 16, "Cupiditate assumenda qui veritatis est nesciunt." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 117,
                columns: new[] { "ChatId", "UserId", "Value" },
                values: new object[] { 23, 4, "Est deserunt voluptas aperiam alias iure autem sed incidunt autem." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 118,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 9, 1, 3, "Ab voluptatem ut qui voluptate cupiditate voluptatem ut quia." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 119,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 12, 1, 6, "Libero et maxime non illo aut." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 120,
                columns: new[] { "ChatId", "UserId", "Value" },
                values: new object[] { 2, 1, "Quia est necessitatibus omnis exercitationem adipisci illum in voluptas." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 121,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 15, 1, 4, "Saepe eveniet totam ut libero." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 122,
                columns: new[] { "ChatId", "UserId", "Value" },
                values: new object[] { 12, 16, "Vero necessitatibus nihil ea atque pariatur aut temporibus." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 123,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 7, 0, 11, "Ratione soluta occaecati placeat delectus quasi." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 124,
                columns: new[] { "MessageStatus", "UserId", "Value" },
                values: new object[] { 2, 17, "Iusto et excepturi pariatur harum qui impedit." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 125,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 2, 2, 14, "Quis repudiandae repellat architecto necessitatibus impedit ut molestiae." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 126,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 22, 1, 7, "Eum placeat numquam hic." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 127,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 27, 0, 13, "Hic tempora voluptas blanditiis." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 128,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 23, 2, 16, "Iure beatae fuga in." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 129,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 21, 1, 3, "Occaecati tempore beatae commodi sit dolor perspiciatis voluptatum assumenda." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 130,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 18, 0, 11, "Quidem amet incidunt nobis harum placeat." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 131,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 27, 0, 9, "Alias architecto facere." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 132,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 19, 2, 19, "Quaerat et aut ducimus molestiae." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 133,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 12, 2, 15, "Ipsum soluta pariatur est quidem quia provident et placeat." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 134,
                columns: new[] { "ChatId", "UserId", "Value" },
                values: new object[] { 9, 12, "Perferendis et sit reiciendis et." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 135,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 19, 1, 15, "Est ab dolores nesciunt et consequuntur delectus non." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 136,
                columns: new[] { "ChatId", "UserId", "Value" },
                values: new object[] { 1, 12, "Culpa laudantium minus vero iure autem perspiciatis hic quis." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 137,
                columns: new[] { "ChatId", "UserId", "Value" },
                values: new object[] { 6, 10, "Ab ut voluptatem ducimus consectetur unde expedita aliquam molestiae aperiam." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 138,
                columns: new[] { "ChatId", "UserId", "Value" },
                values: new object[] { 6, 10, "Voluptate fugiat ut unde temporibus reiciendis perspiciatis." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 139,
                columns: new[] { "ChatId", "UserId", "Value" },
                values: new object[] { 14, 13, "Ut veniam maxime." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 140,
                columns: new[] { "ChatId", "UserId", "Value" },
                values: new object[] { 22, 16, "Earum et similique." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 141,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 28, 1, 14, "Illo beatae perspiciatis voluptatem." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 142,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 10, 2, 19, "Sed dolores sed placeat blanditiis et in consequatur laborum dolor." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 143,
                columns: new[] { "MessageStatus", "UserId", "Value" },
                values: new object[] { 0, 1, "Repudiandae et aut iure repellendus." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 144,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 14, 1, 8, "Dolores omnis qui minus ut alias quis id." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 145,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 24, 0, 8, "Est excepturi nihil." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 146,
                columns: new[] { "ChatId", "UserId", "Value" },
                values: new object[] { 13, 14, "Tenetur animi necessitatibus iusto incidunt temporibus dolorem sint quia ipsa." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 147,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 21, 1, 8, "Molestias maiores aut veritatis." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 148,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 4, 0, 6, "Odio exercitationem accusamus similique amet." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 149,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 8, 0, 7, "Aut rerum ex quasi." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 150,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 12, 2, 1, "Rerum id dicta aut." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 151,
                columns: new[] { "ChatId", "UserId", "Value" },
                values: new object[] { 5, 12, "Eveniet aut non qui consequuntur voluptatem est excepturi." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 152,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 10, 1, 3, "Distinctio animi eos et ut nulla eos." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 153,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 23, 0, 19, "Quod quidem eveniet error earum minima." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 154,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 27, 1, 13, "Necessitatibus quis sed officia perspiciatis quasi maxime velit nulla." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 155,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 19, 2, 16, "Quas ut officiis quis quia pariatur ut excepturi ex." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 156,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 13, 0, 9, "Incidunt cumque placeat." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 157,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 15, 0, 14, "Quod est enim distinctio non ea est reprehenderit." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 158,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 21, 2, 7, "Sunt et qui numquam et asperiores consequatur." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 159,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 2, 1, 10, "Et culpa et ducimus voluptas quae ducimus." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 160,
                columns: new[] { "MessageStatus", "UserId", "Value" },
                values: new object[] { 0, 14, "Accusantium qui eaque non architecto pariatur beatae nulla dolor officiis." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 161,
                columns: new[] { "UserId", "Value" },
                values: new object[] { 20, "Quo atque soluta labore." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 162,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 27, 1, 18, "Labore consequatur beatae voluptate repudiandae non." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 163,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 26, 2, 3, "Nesciunt sed quo nam dolor at sint nesciunt." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 164,
                columns: new[] { "ChatId", "UserId", "Value" },
                values: new object[] { 29, 20, "Autem sunt odit numquam consequatur error assumenda autem." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 165,
                columns: new[] { "ChatId", "UserId", "Value" },
                values: new object[] { 1, 10, "Corrupti tempora magni nam recusandae ratione et." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 166,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 18, 0, 9, "In qui ipsum corporis dolorem voluptatem et cumque qui." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 167,
                columns: new[] { "ChatId", "UserId", "Value" },
                values: new object[] { 4, 5, "Corporis optio molestiae dolor fugit dolores asperiores." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 168,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 11, 2, 17, "Tenetur est aliquam modi." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 169,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 8, 1, 17, "Debitis est provident qui fugiat quaerat earum illo." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 170,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 22, 0, 4, "Voluptates temporibus fuga commodi labore." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 171,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 1, 0, 1, "Quas et ducimus nesciunt repellat aliquid aut." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 172,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 19, 1, 20, "Laudantium non natus dolor est officiis sunt occaecati quia." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 173,
                columns: new[] { "ChatId", "UserId", "Value" },
                values: new object[] { 14, 13, "Itaque ut neque aspernatur necessitatibus." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 174,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 12, 2, 5, "Eos autem explicabo dicta nam quo voluptates quo." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 175,
                columns: new[] { "ChatId", "UserId", "Value" },
                values: new object[] { 18, 8, "Quo voluptatibus tempora." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 176,
                columns: new[] { "ChatId", "UserId", "Value" },
                values: new object[] { 5, 5, "Velit consequatur architecto eveniet." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 177,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 21, 0, 14, "Amet consequatur quia aperiam in quia consequatur temporibus." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 178,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 24, 0, 5, "Aliquam laborum suscipit qui." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 179,
                columns: new[] { "ChatId", "UserId", "Value" },
                values: new object[] { 19, 7, "Veniam recusandae magnam." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 180,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 22, 0, 17, "Est et voluptatum ducimus molestiae ducimus." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 181,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 18, 2, 14, "Suscipit harum accusamus accusantium adipisci ipsa nesciunt ut sequi." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 182,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 13, 2, 6, "Nam debitis repudiandae fugit ducimus magnam facere." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 183,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 20, 1, 18, "Nesciunt quisquam impedit labore omnis voluptas ratione necessitatibus." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 184,
                columns: new[] { "ChatId", "UserId", "Value" },
                values: new object[] { 12, 10, "Autem architecto sunt saepe." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 185,
                columns: new[] { "ChatId", "UserId", "Value" },
                values: new object[] { 20, 10, "Nulla reiciendis dignissimos vel similique perferendis." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 186,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 27, 0, 10, "Earum et autem." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 187,
                columns: new[] { "ChatId", "UserId", "Value" },
                values: new object[] { 30, 16, "Et qui iure qui eligendi." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 188,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 6, 2, 6, "Sed ipsa ea ea distinctio voluptatum hic vel." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 189,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 19, 0, 12, "Tempore placeat et quos quam molestiae optio reiciendis omnis magnam." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 190,
                columns: new[] { "ChatId", "UserId", "Value" },
                values: new object[] { 14, 1, "Aliquam beatae porro voluptatem." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 191,
                columns: new[] { "ChatId", "UserId", "Value" },
                values: new object[] { 6, 9, "Voluptatum nostrum ullam aut esse totam ut error modi." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 192,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 9, 2, 16, "Reprehenderit tenetur labore ad." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 193,
                columns: new[] { "ChatId", "UserId", "Value" },
                values: new object[] { 26, 17, "Quis fugiat quod et quos eius officiis aspernatur placeat quis." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 194,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 6, 0, 1, "Qui consectetur nemo perferendis incidunt." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 195,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 6, 0, 6, "Nihil sed et eos quia voluptatum officiis." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 196,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 12, 0, 12, "Amet blanditiis natus enim molestiae dolore aspernatur totam rem." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 197,
                columns: new[] { "ChatId", "UserId", "Value" },
                values: new object[] { 24, 6, "Quia vel quae delectus est inventore." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 198,
                columns: new[] { "ChatId", "UserId", "Value" },
                values: new object[] { 27, 6, "Voluptatem nobis similique ex facere." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 199,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 22, 2, 12, "Officia consequatur vitae est harum repellat dicta voluptatibus." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 200,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 13, 0, 19, "Ipsa non cupiditate quod." });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_UserId",
                table: "Messages",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_UserId",
                table: "Messages",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_UserId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_UserId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Messages");

            migrationBuilder.CreateTable(
                name: "UserMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MessageId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsSender = table.Column<bool>(type: "bit", nullable: false)
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

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ChatId", "Value" },
                values: new object[] { 27, "Et quam nulla vel quae omnis." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ChatId", "Value" },
                values: new object[] { 11, "Modi repellendus repellendus sequi aut quibusdam ullam molestiae possimus." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 27, 2, "Ullam exercitationem repudiandae." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 27, 1, "Quis blanditiis et perferendis est modi." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ChatId", "Value" },
                values: new object[] { 11, "Dolor nulla possimus expedita consequatur molestiae enim repellendus architecto non." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 9, 0, "Dolores omnis quia." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 20, 2, "Atque eos adipisci tenetur et ab iure iure." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 16, 2, "Ut consequatur id explicabo et placeat aut accusantium sunt adipisci." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 12, 2, "Repudiandae in ipsa sit quia architecto est iusto rerum." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 30, 1, "Qui saepe quia." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "ChatId", "Value" },
                values: new object[] { 25, "Id eos odit distinctio expedita qui rerum." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "ChatId", "Value" },
                values: new object[] { 1, "Ratione nihil laudantium quos aliquid ex eaque." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "ChatId", "Value" },
                values: new object[] { 10, "Et harum a." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 8, 2, "Numquam ipsa veniam vero deleniti quam deserunt distinctio iure quis." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "ChatId", "Value" },
                values: new object[] { 22, "Enim iure illo enim ipsum quis labore odio." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 30, 1, "At nostrum animi non." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "ChatId", "Value" },
                values: new object[] { 30, "Similique laboriosam placeat sint." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "ChatId", "Value" },
                values: new object[] { 1, "Eaque est fugit aut odit reiciendis fuga repellendus exercitationem optio." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "ChatId", "Value" },
                values: new object[] { 2, "Repellendus magnam vitae totam voluptatem." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 13, 0, "Consectetur qui distinctio." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 3, 1, "Neque repudiandae doloribus autem." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 19, 2, "Magni natus consequuntur harum autem." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 19, 1, "Asperiores ut voluptatem." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 26, 2, "Voluptatem aliquam minima velit error non." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 20, 0, "Qui et est repellendus praesentium accusamus corporis et sit earum." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "ChatId", "Value" },
                values: new object[] { 22, "A quo cupiditate et qui non adipisci et." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 21, 1, "Quibusdam voluptas distinctio impedit mollitia sint eos quis veniam." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "ChatId", "Value" },
                values: new object[] { 21, "Aut itaque qui." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 20, 0, "Beatae occaecati natus id harum ullam dignissimos tempore hic deleniti." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "ChatId", "Value" },
                values: new object[] { 12, "Illo rerum officiis doloribus et non deserunt nemo ut et." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 10, 2, "Veniam qui nihil." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 28, 0, "Quas molestiae voluptatem quia magnam inventore non ea." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 21, 0, "Distinctio ex et cum dolorum magni incidunt rerum non doloribus." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "ChatId", "Value" },
                values: new object[] { 5, "Porro saepe commodi animi perferendis fuga magnam ut ipsum." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "ChatId", "Value" },
                values: new object[] { 13, "Id cum dolorum." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "ChatId", "Value" },
                values: new object[] { 23, "Voluptas iure ullam qui ipsam maxime ex nam est." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "ChatId", "Value" },
                values: new object[] { 21, "Quod ea ut molestias quos ea optio est nisi." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 5, 0, "Corrupti quasi deleniti et aut qui est perferendis." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "ChatId", "Value" },
                values: new object[] { 12, "Corporis excepturi in in et dolore aliquid recusandae inventore." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 21, 1, "Maxime qui incidunt amet voluptatem ut quibusdam." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 20, 2, "Mollitia expedita et ut id dolor labore qui." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 22, 2, "Harum recusandae asperiores repudiandae dolor beatae ea." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "ChatId", "Value" },
                values: new object[] { 24, "Ipsum aspernatur cupiditate minus quibusdam et voluptatem." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "ChatId", "Value" },
                values: new object[] { 11, "Quidem dicta officia sint et." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 8, 2, "Similique eligendi rem vel qui rerum aut." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "ChatId", "Value" },
                values: new object[] { 13, "Deleniti sequi iusto excepturi aut." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 29, 1, "Quisquam provident earum magni aut labore itaque." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "ChatId", "Value" },
                values: new object[] { 5, "Ut architecto asperiores ducimus qui pariatur nihil." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "MessageStatus", "Value" },
                values: new object[] { 2, "Consequatur in dolorum voluptates esse." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 18, 2, "Rerum consequuntur fugit atque corrupti commodi laborum." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 5, 1, "Porro incidunt officiis iure maiores error." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "ChatId", "Value" },
                values: new object[] { 3, "Doloremque molestiae qui dicta tenetur." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 12, 2, "Ratione voluptates doloremque porro." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 26, 1, "Blanditiis quo et eos officia." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 26, 2, "Veniam maiores ullam voluptates atque voluptatibus deserunt inventore quis magnam." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "ChatId", "Value" },
                values: new object[] { 6, "Ullam ipsa neque cupiditate." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 5, 2, "Et sed est minus vero natus." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 10, 1, "Cum in et adipisci." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "ChatId", "Value" },
                values: new object[] { 17, "Expedita illo officia." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 14, 0, "Distinctio laudantium minima ut sed nesciunt autem ut laboriosam." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "ChatId", "Value" },
                values: new object[] { 2, "Consequatur maxime voluptatem similique ab." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 29, 2, "Et eligendi cum inventore rerum soluta." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 10, 1, "Totam eum delectus repudiandae ab debitis quaerat." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "ChatId", "Value" },
                values: new object[] { 16, "Assumenda ex accusamus suscipit voluptate adipisci." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 24, 2, "Fugiat dicta alias nam sequi aut recusandae." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "ChatId", "Value" },
                values: new object[] { 27, "Ut odio dolorem pariatur." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "ChatId", "Value" },
                values: new object[] { 23, "Corrupti praesentium tenetur accusamus alias." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "ChatId", "Value" },
                values: new object[] { 5, "Minima sunt illo ea enim eos." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 28, 0, "Odit quam totam dolorem vel et." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 3, 1, "Ut esse alias id quas odit." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 27, 0, "Ea natus eligendi fugiat aut voluptatem dolor officiis." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 6, 1, "Excepturi ea beatae enim minus maxime nisi." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "ChatId", "Value" },
                values: new object[] { 29, "Distinctio fugiat a non aut quia deleniti cum." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 8, 2, "Sed sequi praesentium id quod ad dignissimos sed maiores itaque." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 23, 2, "Sapiente officiis suscipit minus officiis." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 23, 2, "Eveniet doloremque cumque." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 22, 2, "Explicabo earum cumque velit iusto." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 6, 2, "Quia dolorum libero doloribus totam." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 81,
                column: "Value",
                value: "Quod debitis mollitia expedita.");

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 11, 2, "Placeat et dolorem sit eum nemo quia omnis debitis consequatur." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 21, 1, "Quis id nisi ullam officia." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 3, 0, "Veritatis aut nostrum eos et quo nostrum qui." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 26, 0, "Sunt hic tenetur qui est facere rerum alias." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 11, 2, "Voluptatibus quos omnis itaque eveniet alias provident ullam et." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 25, 1, "Nobis et provident voluptatem delectus." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 18, 1, "Placeat non et quaerat enim sit laboriosam id unde nihil." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 25, 0, "Enim ut et enim molestiae illum nostrum nostrum eum." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "ChatId", "Value" },
                values: new object[] { 2, "Cum ut voluptatum architecto et sint velit magnam." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 20, 1, "Magnam nostrum et." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 24, 0, "Placeat commodi enim possimus nihil velit voluptatem minus aut." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "ChatId", "Value" },
                values: new object[] { 20, "Facilis sint repudiandae molestiae excepturi quidem et." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 7, 2, "Repellendus labore sit." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "ChatId", "Value" },
                values: new object[] { 8, "Omnis sit ullam magnam et quos vitae est ut." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "ChatId", "Value" },
                values: new object[] { 24, "Blanditiis nisi quam debitis harum quo minima consequuntur eos." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 30, 0, "Et quibusdam dolores harum in aperiam molestiae quos amet quia." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "ChatId", "Value" },
                values: new object[] { 13, "Cupiditate voluptates sequi quo ut necessitatibus occaecati eum." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "ChatId", "Value" },
                values: new object[] { 22, "Optio et id et et." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 23, 1, "Labore nemo facere fugiat ea ducimus architecto quas." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 28, 2, "Veniam neque molestiae eos aut et consequuntur nostrum." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 13, 2, "Est quis iure illum itaque." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 6, 1, "Voluptas dicta totam qui facere et assumenda beatae autem." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 104,
                column: "Value",
                value: "Tenetur fuga ut consequuntur nesciunt ut.");

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 13, 1, "Non consequatur fugiat quibusdam aut optio laudantium dignissimos ut." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 22, 2, "Possimus sint qui." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "ChatId", "Value" },
                values: new object[] { 23, "Nihil laboriosam est sit ut soluta unde nemo." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 9, 0, "Distinctio tempore ut recusandae asperiores." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 6, 0, "Expedita dolor minus corporis harum aliquam aut temporibus." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 110,
                columns: new[] { "ChatId", "Value" },
                values: new object[] { 5, "Tenetur enim qui deserunt veritatis nesciunt sunt adipisci." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 111,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 26, 2, "Nam quo quo sit." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 112,
                columns: new[] { "ChatId", "Value" },
                values: new object[] { 1, "Eos voluptas id enim dolor ab saepe." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 113,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 4, 0, "Architecto voluptatem necessitatibus." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 114,
                columns: new[] { "ChatId", "Value" },
                values: new object[] { 28, "Quibusdam hic non beatae quo." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 115,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 1, 0, "Quis deleniti velit." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 116,
                columns: new[] { "ChatId", "Value" },
                values: new object[] { 5, "Qui autem quae quis ipsum et aut." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 117,
                columns: new[] { "ChatId", "Value" },
                values: new object[] { 1, "Optio sunt quia repellat sed rerum." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 118,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 15, 2, "Et sint ut libero possimus nam ea." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 119,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 6, 2, "Cumque rerum dolor hic dignissimos rerum cumque aut animi quasi." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 120,
                columns: new[] { "ChatId", "Value" },
                values: new object[] { 28, "Illum consequatur vel maxime." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 121,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 18, 2, "Corrupti eius ea natus deserunt tempore eius nihil quis fuga." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 122,
                columns: new[] { "ChatId", "Value" },
                values: new object[] { 28, "Nihil iusto omnis sint qui soluta ea." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 123,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 29, 2, "Itaque accusamus magnam voluptas esse eos autem et." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 124,
                columns: new[] { "MessageStatus", "Value" },
                values: new object[] { 1, "Qui deleniti ut modi ea assumenda." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 125,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 30, 1, "Reiciendis quaerat aut natus ducimus vel ab laudantium." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 126,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 26, 2, "Culpa in iste totam est laboriosam voluptates." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 127,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 13, 2, "Nihil odit laborum dolores aliquam tenetur cupiditate eligendi dolor voluptates." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 128,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 2, 0, "Soluta cum possimus eligendi." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 129,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 26, 0, "Repudiandae ipsam minus velit et debitis molestiae voluptas provident." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 130,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 16, 1, "Sequi est ad voluptatem dolores nihil adipisci." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 131,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 23, 1, "Qui veritatis est nesciunt aliquid officiis autem non est." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 132,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 7, 0, "Alias iure autem." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 133,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 14, 0, "Accusantium omnis nesciunt omnis ab voluptatem." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 134,
                columns: new[] { "ChatId", "Value" },
                values: new object[] { 15, "Cupiditate voluptatem ut quia est veniam." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 135,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 4, 2, "Et maxime non illo aut animi quis enim." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 136,
                columns: new[] { "ChatId", "Value" },
                values: new object[] { 9, "Necessitatibus omnis exercitationem adipisci illum in voluptas laborum inventore." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 137,
                columns: new[] { "ChatId", "Value" },
                values: new object[] { 13, "Eveniet totam ut libero vel rem nesciunt placeat vero necessitatibus." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 138,
                columns: new[] { "ChatId", "Value" },
                values: new object[] { 5, "Pariatur aut temporibus iste reprehenderit omnis." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 139,
                columns: new[] { "ChatId", "Value" },
                values: new object[] { 20, "Occaecati placeat delectus quasi corporis quia occaecati provident." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 140,
                columns: new[] { "ChatId", "Value" },
                values: new object[] { 12, "Pariatur harum qui impedit recusandae doloribus et." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 141,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 23, 2, "Repellat architecto necessitatibus impedit ut molestiae aut illo libero ut." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 142,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 29, 0, "Hic occaecati cumque nemo." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 143,
                columns: new[] { "MessageStatus", "Value" },
                values: new object[] { 1, "Voluptas blanditiis ab necessitatibus." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 144,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 16, 2, "Beatae fuga in reiciendis voluptas est." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 145,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 4, 2, "Beatae commodi sit dolor perspiciatis voluptatum assumenda esse." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 146,
                columns: new[] { "ChatId", "Value" },
                values: new object[] { 18, "Quidem amet incidunt nobis harum placeat." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 147,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 8, 0, "Voluptatem alias architecto facere eaque eveniet molestiae." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 148,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 19, 2, "Aut ducimus molestiae." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 149,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 12, 2, "Fugiat ipsum soluta pariatur est quidem quia provident et placeat." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 150,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 23, 1, "Nisi perferendis et sit reiciendis et architecto quis." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 151,
                columns: new[] { "ChatId", "Value" },
                values: new object[] { 23, "Ab dolores nesciunt et consequuntur delectus non nisi." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 152,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 1, 0, "Culpa laudantium minus vero iure autem perspiciatis hic quis." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 153,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 8, 1, "Repudiandae ab ut voluptatem ducimus consectetur unde." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 154,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 17, 2, "Aperiam et consectetur voluptatum officia voluptate." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 155,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 9, 0, "Temporibus reiciendis perspiciatis iusto dolorem qui quia." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 156,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 23, 2, "Et qui facilis sit earum et similique dolor." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 157,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 28, 1, "Illo beatae perspiciatis voluptatem." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 158,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 19, 1, "Voluptates sed dolores sed placeat blanditiis et in." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 159,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 19, 2, "Vel voluptas molestiae ut." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 160,
                columns: new[] { "MessageStatus", "Value" },
                values: new object[] { 2, "Iure repellendus magnam incidunt voluptatem et dolores omnis qui minus." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 161,
                column: "Value",
                value: "Id occaecati praesentium ex beatae.");

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 162,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 24, 0, "Consectetur est commodi debitis tenetur animi necessitatibus iusto." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 163,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 21, 1, "Sint quia ipsa ratione." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 164,
                columns: new[] { "ChatId", "Value" },
                values: new object[] { 21, "Molestias maiores aut veritatis." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 165,
                columns: new[] { "ChatId", "Value" },
                values: new object[] { 10, "Voluptas odio exercitationem accusamus similique." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 166,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 11, 2, "Enim velit aut." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 167,
                columns: new[] { "ChatId", "Value" },
                values: new object[] { 29, "Accusantium et laboriosam." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 168,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 22, 1, "Dicta aut optio quis ipsa cum eveniet aut." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 169,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 18, 0, "Voluptatem est excepturi fuga." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 170,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 10, 1, "Distinctio animi eos et ut nulla eos." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 171,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 17, 2, "Deleniti quod quidem." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 172,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 23, 0, "Minima numquam maxime et dolorem necessitatibus quis sed officia perspiciatis." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 173,
                columns: new[] { "ChatId", "Value" },
                values: new object[] { 16, "Nulla dignissimos accusamus est." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 174,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 11, 1, "Officiis quis quia pariatur ut." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 175,
                columns: new[] { "ChatId", "Value" },
                values: new object[] { 23, "Dolorum repellendus explicabo incidunt cumque placeat incidunt voluptate velit." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 176,
                columns: new[] { "ChatId", "Value" },
                values: new object[] { 3, "Enim distinctio non ea est reprehenderit sit deleniti nam." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 177,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 18, 1, "Qui numquam et asperiores consequatur saepe est enim provident." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 178,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 2, 2, "Ducimus voluptas quae ducimus laborum aperiam blanditiis aut accusantium." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 179,
                columns: new[] { "ChatId", "Value" },
                values: new object[] { 27, "Architecto pariatur beatae nulla." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 180,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 21, 1, "Consequatur optio incidunt quo." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 181,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 25, 0, "Ea sint maiores et." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 182,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 27, 1, "Voluptate repudiandae non." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 183,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 26, 2, "Et nesciunt sed quo nam dolor at sint nesciunt." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 184,
                columns: new[] { "ChatId", "Value" },
                values: new object[] { 1, "Distinctio autem sunt odit." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 185,
                columns: new[] { "ChatId", "Value" },
                values: new object[] { 4, "Assumenda autem harum itaque maiores mollitia corrupti." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 186,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 6, 1, "Recusandae ratione et exercitationem consequatur dolores pariatur in." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 187,
                columns: new[] { "ChatId", "Value" },
                values: new object[] { 18, "Dolorem voluptatem et cumque qui." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 188,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 30, 1, "Quas corporis optio molestiae dolor fugit." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 189,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 8, 2, "Magni labore quia tenetur." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 190,
                columns: new[] { "ChatId", "Value" },
                values: new object[] { 22, "Tempore nisi quo et." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 191,
                columns: new[] { "ChatId", "Value" },
                values: new object[] { 9, "Qui fugiat quaerat earum illo reprehenderit labore." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 192,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 5, 1, "Temporibus fuga commodi labore modi porro sit excepturi quas et." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 193,
                columns: new[] { "ChatId", "Value" },
                values: new object[] { 27, "Aliquid aut et sit accusantium et laudantium non natus dolor." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 194,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 30, 1, "Occaecati quia odio." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 195,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 14, 2, "Itaque ut neque aspernatur necessitatibus." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 196,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 30, 2, "Et eos autem explicabo dicta nam quo voluptates." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 197,
                columns: new[] { "ChatId", "Value" },
                values: new object[] { 18, "Non ipsa quo voluptatibus tempora." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 198,
                columns: new[] { "ChatId", "Value" },
                values: new object[] { 5, "Magni velit consequatur architecto eveniet." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 199,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 18, 0, "Minus amet consequatur quia." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 200,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 7, 2, "Consequatur temporibus amet nobis." });

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
                name: "IX_UserMessages_MessageId",
                table: "UserMessages",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMessages_UserId",
                table: "UserMessages",
                column: "UserId");
        }
    }
}
