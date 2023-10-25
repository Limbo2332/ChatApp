using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ReadMessages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MessageStatus",
                table: "Messages");

            migrationBuilder.AddColumn<bool>(
                name: "IsRead",
                table: "Messages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ChatId", "IsRead", "UserId" },
                values: new object[] { 26, true, 31 });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ChatId", "IsRead", "UserId", "Value" },
                values: new object[] { 36, true, 6, "Et quam nulla vel quae omnis." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "IsRead", "Value" },
                values: new object[] { true, "Modi repellendus repellendus sequi aut quibusdam ullam molestiae possimus." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ChatId", "IsRead", "UserId" },
                values: new object[] { 38, true, 28 });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ChatId", "IsRead", "UserId", "Value" },
                values: new object[] { 35, true, 34, "Ullam exercitationem repudiandae." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ChatId", "IsRead", "UserId", "Value" },
                values: new object[] { 35, true, 23, "Quis blanditiis et perferendis est modi." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ChatId", "IsRead", "UserId", "Value" },
                values: new object[] { 14, true, 19, "Dolor nulla possimus expedita consequatur molestiae enim repellendus architecto non." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ChatId", "IsRead", "UserId", "Value" },
                values: new object[] { 12, true, 7, "Dolores omnis quia." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ChatId", "IsRead", "UserId", "Value" },
                values: new object[] { 26, true, 29, "Atque eos adipisci tenetur et ab iure iure." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ChatId", "IsRead", "UserId", "Value" },
                values: new object[] { 21, true, 40, "Ut consequatur id explicabo et placeat aut accusantium sunt adipisci." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ChatId", "IsRead", "UserId", "Value" },
                values: new object[] { 16, true, 37, "Repudiandae in ipsa sit quia architecto est iusto rerum." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "ChatId", "IsRead", "UserId", "Value" },
                values: new object[] { 40, true, 25, "Qui saepe quia." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "ChatId", "IsRead", "UserId", "Value" },
                values: new object[] { 33, true, 11, "Id eos odit distinctio expedita qui rerum." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "ChatId", "IsRead", "UserId", "Value" },
                values: new object[] { 1, true, 2, "Ratione nihil laudantium quos aliquid ex eaque." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "ChatId", "IsRead", "UserId", "Value" },
                values: new object[] { 13, true, 22, "Et harum a." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "ChatId", "IsRead", "UserId", "Value" },
                values: new object[] { 11, true, 30, "Numquam ipsa veniam vero deleniti quam deserunt distinctio iure quis." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "ChatId", "IsRead", "UserId", "Value" },
                values: new object[] { 29, true, 36, "Enim iure illo enim ipsum quis labore odio." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "ChatId", "IsRead", "UserId", "Value" },
                values: new object[] { 39, true, 19, "At nostrum animi non." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "ChatId", "IsRead", "UserId", "Value" },
                values: new object[] { 40, true, 37, "Similique laboriosam placeat sint." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "ChatId", "IsRead", "UserId", "Value" },
                values: new object[] { 1, true, 27, "Eaque est fugit aut odit reiciendis fuga repellendus exercitationem optio." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "ChatId", "IsRead", "UserId", "Value" },
                values: new object[] { 3, true, 14, "Repellendus magnam vitae totam voluptatem." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "ChatId", "IsRead", "UserId", "Value" },
                values: new object[] { 17, true, 8, "Consectetur qui distinctio." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "ChatId", "IsRead", "UserId", "Value" },
                values: new object[] { 3, true, 20, "Neque repudiandae doloribus autem." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "ChatId", "IsRead", "UserId", "Value" },
                values: new object[] { 25, true, 29, "Magni natus consequuntur harum autem." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "ChatId", "IsRead", "UserId", "Value" },
                values: new object[] { 25, true, 19, "Asperiores ut voluptatem." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "ChatId", "IsRead", "Value" },
                values: new object[] { 34, true, "Voluptatem aliquam minima velit error non." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "ChatId", "IsRead", "UserId", "Value" },
                values: new object[] { 27, true, 2, "Qui et est repellendus praesentium accusamus corporis et sit earum." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "ChatId", "IsRead", "UserId", "Value" },
                values: new object[] { 30, true, 16, "A quo cupiditate et qui non adipisci et." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "ChatId", "IsRead", "UserId", "Value" },
                values: new object[] { 27, true, 27, "Quibusdam voluptas distinctio impedit mollitia sint eos quis veniam." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "ChatId", "IsRead", "UserId", "Value" },
                values: new object[] { 28, true, 9, "Aut itaque qui." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "ChatId", "IsRead", "UserId", "Value" },
                values: new object[] { 27, true, 1, "Beatae occaecati natus id harum ullam dignissimos tempore hic deleniti." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "ChatId", "IsRead", "UserId", "Value" },
                values: new object[] { 15, true, 27, "Illo rerum officiis doloribus et non deserunt nemo ut et." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "ChatId", "IsRead", "UserId", "Value" },
                values: new object[] { 13, true, 28, "Veniam qui nihil." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "ChatId", "IsRead", "UserId", "Value" },
                values: new object[] { 37, true, 11, "Quas molestiae voluptatem quia magnam inventore non ea." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "IsRead", "UserId", "Value" },
                values: new object[] { true, 4, "Distinctio ex et cum dolorum magni incidunt rerum non doloribus." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "ChatId", "IsRead", "UserId", "Value" },
                values: new object[] { 6, true, 12, "Porro saepe commodi animi perferendis fuga magnam ut ipsum." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "ChatId", "IsRead", "UserId", "Value" },
                values: new object[] { 17, true, 38, "Id cum dolorum." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "ChatId", "IsRead", "UserId", "Value" },
                values: new object[] { 30, true, 8, "Voluptas iure ullam qui ipsam maxime ex nam est." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "ChatId", "IsRead", "UserId", "Value" },
                values: new object[] { 27, true, 26, "Quod ea ut molestias quos ea optio est nisi." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "ChatId", "IsRead", "UserId", "Value" },
                values: new object[] { 6, true, 5, "Corrupti quasi deleniti et aut qui est perferendis." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "ChatId", "IsRead", "UserId", "Value" },
                values: new object[] { 16, true, 22, "Corporis excepturi in in et dolore aliquid recusandae inventore." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "ChatId", "IsRead", "UserId", "Value" },
                values: new object[] { 28, true, 21, "Maxime qui incidunt amet voluptatem ut quibusdam." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "ChatId", "IsRead", "UserId", "Value" },
                values: new object[] { 27, true, 29, "Mollitia expedita et ut id dolor labore qui." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "ChatId", "IsRead", "UserId", "Value" },
                values: new object[] { 29, true, 40, "Harum recusandae asperiores repudiandae dolor beatae ea." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "ChatId", "IsRead", "UserId", "Value" },
                values: new object[] { 32, true, 14, "Ipsum aspernatur cupiditate minus quibusdam et voluptatem." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "ChatId", "IsRead", "UserId", "Value" },
                values: new object[] { 15, true, 14, "Quidem dicta officia sint et." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "ChatId", "IsRead", "UserId", "Value" },
                values: new object[] { 10, true, 36, "Similique eligendi rem vel qui rerum aut." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "ChatId", "IsRead", "UserId", "Value" },
                values: new object[] { 18, true, 5, "Deleniti sequi iusto excepturi aut." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "ChatId", "IsRead", "UserId", "Value" },
                values: new object[] { 39, true, 14, "Quisquam provident earum magni aut labore itaque." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "IsRead", "UserId", "Value" },
                values: new object[] { true, 1, "Ut architecto asperiores ducimus qui pariatur nihil." });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRead",
                table: "Messages");

            migrationBuilder.AddColumn<int>(
                name: "MessageStatus",
                table: "Messages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ChatId", "MessageStatus", "UserId" },
                values: new object[] { 18, 2, 26 });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 32, 0, 32, "Quam nulla vel quae omnis voluptatem aut vero." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "MessageStatus", "Value" },
                values: new object[] { 2, "Aut quibusdam ullam molestiae." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ChatId", "MessageStatus", "UserId" },
                values: new object[] { 5, 2, 38 });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 26, 1, 19, "Exercitationem repudiandae nulla et autem." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 32, 2, 37, "Est modi error." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 6, 1, 2, "Possimus expedita consequatur molestiae enim repellendus architecto non totam." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 2, 2, 18, "Quia quia minima distinctio atque eos adipisci." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 35, 1, 4, "Iure impedit est ut ut consequatur." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 14, 1, 2, "Aut accusantium sunt adipisci doloribus excepturi quo repudiandae." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 24, 1, 3, "Architecto est iusto rerum ut." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 33, 2, 11, "Quia id voluptatibus sed id eos odit distinctio expedita qui." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 3, 0, 1, "Ratione nihil laudantium quos aliquid ex eaque." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 9, 0, 37, "Harum a sed." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 27, 1, 24, "Veniam vero deleniti." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 7, 0, 11, "Quis minus aliquam quod enim iure." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 24, 2, 12, "Labore odio eveniet cumque tempora." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 5, 0, 30, "Rem ut sit similique laboriosam placeat sint et maiores hic." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 4, 2, 10, "Odit reiciendis fuga repellendus exercitationem optio nam aut commodi." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 17, 1, 8, "Voluptatem laboriosam illo alias consectetur qui." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 13, 1, 3, "Neque repudiandae doloribus autem." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 3, 2, 25, "Natus consequuntur harum autem." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 34, 2, 38, "Ut voluptatem praesentium id qui voluptatem aliquam minima velit error." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 28, 0, 27, "Qui et est repellendus praesentium accusamus corporis et sit earum." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 27, 2, 34, "Quo cupiditate et qui non adipisci et in qui vel." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "ChatId", "MessageStatus", "Value" },
                values: new object[] { 6, 0, "Mollitia sint eos quis veniam expedita tempore sit." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 26, 1, 30, "Eligendi repellat beatae occaecati." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 3, 1, 40, "Dignissimos tempore hic deleniti sit." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 33, 0, 12, "Officiis doloribus et non deserunt nemo ut et libero autem." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 3, 0, 11, "Soluta nemo qui quas molestiae voluptatem." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 26, 1, 15, "Ea ut et ut." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 36, 2, 29, "Dolorum magni incidunt rerum non doloribus aspernatur est." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 6, 0, 12, "Animi perferendis fuga magnam ut." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 34, 2, 17, "Id cum dolorum." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "MessageStatus", "UserId", "Value" },
                values: new object[] { 1, 27, "Iure ullam qui ipsam maxime." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 20, 0, 21, "Id dolor quod ea." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 3, 2, 20, "Optio est nisi facilis tempore." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 13, 0, 31, "Et aut qui est perferendis sed." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 22, 1, 16, "In in et dolore aliquid recusandae inventore." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 27, 2, 24, "Qui incidunt amet voluptatem ut quibusdam quas nobis." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 27, 1, 29, "Ut id dolor labore." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 25, 2, 29, "Harum recusandae asperiores repudiandae dolor beatae ea." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 14, 1, 11, "Aspernatur cupiditate minus quibusdam." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 19, 1, 28, "Voluptatem quidem dicta officia sint et sit aliquid molestias." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 5, 1, 39, "Qui rerum aut rerum labore ad deleniti sequi iusto." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 14, 0, 38, "Iste quisquam provident earum magni aut." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 24, 1, 15, "Perspiciatis ut architecto asperiores ducimus qui pariatur nihil sit eos." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 20, 0, 20, "Voluptates esse doloribus et fuga rerum consequuntur." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "ChatId", "MessageStatus", "UserId", "Value" },
                values: new object[] { 16, 0, 35, "Laborum illum similique odio porro." });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "MessageStatus", "UserId", "Value" },
                values: new object[] { 0, 8, "Error ut neque veniam doloremque molestiae qui dicta tenetur sapiente." });
        }
    }
}
