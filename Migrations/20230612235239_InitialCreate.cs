using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Chilite.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    RoomId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.RoomId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Interviews",
                columns: table => new
                {
                    InterviewId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoomId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interviews", x => x.InterviewId);
                    table.ForeignKey(
                        name: "FK_Interviews_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Interviews_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    QuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InterviewId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.QuestionId);
                    table.ForeignKey(
                        name: "FK_Questions_Interviews_InterviewId",
                        column: x => x.InterviewId,
                        principalTable: "Interviews",
                        principalColumn: "InterviewId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    AnswerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.AnswerId);
                    table.ForeignKey(
                        name: "FK_Answers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "332A0729-7DA8-4BFA-BC76-E26889B0A8C6", null, "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "CEE0ABB0-E53A-44E2-8287-87A3DCE8E7E2", 0, "2ae9644f-e619-4149-8470-660b7a37a347", "IdentityUser", "InterView@email.com", true, false, null, "INTERVIEW@EMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAEO6RKQH17nfAx2e1xPSs3qvawVZSqrCA9azNIUx7E7+rHmg3cgHIgK9muCXazYFlLQ==", null, false, "", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "332A0729-7DA8-4BFA-BC76-E26889B0A8C6", "CEE0ABB0-E53A-44E2-8287-87A3DCE8E7E2" });

            migrationBuilder.InsertData(
                table: "Interviews",
                columns: new[] { "InterviewId", "EndDate", "RoomId", "StartDate", "Title", "UserId" },
                values: new object[] { new Guid("607ed998-da08-11ed-afa1-0242ac120002"), new DateTime(2023, 6, 13, 4, 52, 38, 828, DateTimeKind.Local).AddTicks(3373), "00000000-0000-0000-0000-000000000000", new DateTime(2023, 6, 13, 3, 52, 38, 828, DateTimeKind.Local).AddTicks(3360), "За кадром: жизнь и карьера режиссера", "CEE0ABB0-E53A-44E2-8287-87A3DCE8E7E2" });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "QuestionId", "InterviewId", "Text" },
                values: new object[,]
                {
                    { new Guid("598f908c-c02d-4e1b-904f-1da660c3bccd"), new Guid("607ed998-da08-11ed-afa1-0242ac120002"), "Как вы выбираете проекты, над которыми хотите работать?" },
                    { new Guid("9f52e4cc-1fdd-4e68-bd08-e619929d7b4f"), new Guid("607ed998-da08-11ed-afa1-0242ac120002"), "Как вы начали свою карьеру в киноиндустрии и какие были ваши первые работы?" },
                    { new Guid("b9edad52-a404-4d8b-96d1-190dd8aa054a"), new Guid("607ed998-da08-11ed-afa1-0242ac120002"), "Какие фильмы или режиссеры оказали влияние на ваше творчество?" }
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "AnswerId", "QuestionId", "Text" },
                values: new object[,]
                {
                    { new Guid("1ee0de84-4a6a-4cc7-b963-0d75b2c58719"), new Guid("598f908c-c02d-4e1b-904f-1da660c3bccd"), "Когда я выбираю проекты, над которыми хочу работать, я придерживаюсь нескольких принципов. Прежде всего, я уделяю внимание сценарию. Для меня важно, чтобы история была интересной, оригинальной и вызывала эмоциональный отклик. Я также обращаю внимание на режиссера и его/ее предыдущий опыт, стиль и подход к кинематографу.\r\n\r\nДалее, я анализирую бюджет и ресурсы проекта. Это включает оценку финансовых аспектов, продолжительности съемок, условий работы и других практических факторов. Я стараюсь выбирать проекты, которые предлагают адекватное финансовое вознаграждение и условия работы, соответствующие моим профессиональным навыкам и ожиданиям.\r\n\r\nТакже я учитываю команду проекта. Важно работать с профессионалами, которые разделяют мои ценности и подходы к работе. Команда должна быть сплоченной и иметь опыт в реализации аналогичных проектов.\r\n\r\nЯ также обращаю внимание на потенциал проекта. Если проект предлагает новые вызовы, возможность для профессионального роста, расширения моих навыков или участия в уникальных и значимых проектах, это может стать решающим фактором в выборе проекта.\r\n\r\nНаконец, я также учитываю свою личную мотивацию и интерес к проекту. Если история или концепция проекта вызывают у меня эмоциональное влечение или внутреннюю мотивацию, это может стать дополнительным стимулом для выбора проекта.\r\n\r\nКороче говоря, при выборе проектов, над которыми хочу работать, я учитываю сценарий, режиссера, бюджет и ресурсы проекта, команду, потенциал проекта и свою личную мотивацию. Эти факторы взвешиваются вместе, чтобы определить, какие проекты соответствуют моим профессиональным и личным целям." },
                    { new Guid("4c86e0d0-84c4-42f9-81dd-ae8a9fe0b7e3"), new Guid("b9edad52-a404-4d8b-96d1-190dd8aa054a"), "В течение моей карьеры в киноиндустрии, несколько фильмов и режиссеров оказали существенное влияние на мое творчество. Они вдохновляли меня своим стилем, техническим мастерством и подходом к кинематографу.\r\n\r\nОдин из таких режиссеров, который оказал глубокое влияние на меня, - Стэнли Кубрик. Его фильмы, такие как \"Сияние\", \"Заводной апельсин\", \"Барри Линдон\" и \"Сияние\", впечатлили меня своим неповторимым стилем снятия и уникальной визуальной эстетикой. Я был(а) восхищен(а) его аккуратностью в деталях и дерзкими решениями в кинематографической режиссуре, которые сделали его фильмы настоящими произведениями искусства.\r\n\r\nЕще одним режиссером, который оказал влияние на мое творчество, - Кристофер Нолан. Его фильмы, такие как \"Начало\", \"Темный рыцарь\" и \"Интерстеллар\", являются примерами сложной структуры сюжета и инновационных режиссерских приемов. Я восхищался(ась) его способностью создавать глубокие и захватывающие истории, сочетая фантастику с философскими и эмоциональными аспектами.\r\n\r\nТакже стоит отметить фильмы \"Бесславные ублюдки\" Квентина Тарантино и \"Драйв\" Николаса Виндинга Рефна, которые оказали влияние на меня своим ярким стилем, отличной режиссурой и уникальным подходом к кинематографу.\r\n\r\nЭти режиссеры и их фильмы вдохновляют меня в моем творческом процессе и влияют на мой подход к созданию фильмов" },
                    { new Guid("92be4e29-8e75-4ca3-9fe3-d6425b1287bb"), new Guid("9f52e4cc-1fdd-4e68-bd08-e619929d7b4f"), "Я начал свою карьеру в киноиндустрии с огромным интересом к миру кино и желанием внести свой вклад в создание качественных фильмов. Мои первые работы в этой отрасли были связаны с обучением и приобретением опыта, чтобы развиваться как профессионал.\r\n\r\nМоя первая работа в киноиндустрии была стажером на съемочной площадке фильма независимого производства, где я получил первоначальный опыт в организации съемочного процесса и взаимодействии с командой профессионалов. Затем, я работал на различных проектах в качестве ассистента режиссера и продюсера, где приобрел опыт в планировании и организации съемок, взаимодействии с актерами и экипажем, а также в постановке сцен.\r\n\r\nС течением времени и с накоплением опыта, я продвигался в своей карьере в киноиндустрии, работая на более крупных проектах и занимая более ответственные роли, такие как ассистент режиссера, продюсер, или другие специализированные должности. Мои первые работы в киноиндустрии были важным этапом моего профессионального развития, помогая мне приобрести ценный опыт и знания в этой индустрии, которые я успешно применяю и сегодня в своей карьере в киноиндустрии." }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionId",
                table: "Answers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Interviews_RoomId",
                table: "Interviews",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Interviews_UserId",
                table: "Interviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_InterviewId",
                table: "Questions",
                column: "InterviewId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Interviews");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Room");
        }
    }
}
