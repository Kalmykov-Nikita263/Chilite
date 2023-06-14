using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Chilite.Migrations
{
    /// <inheritdoc />
    public partial class ManyToManyCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interviews_AspNetUsers_UserId",
                table: "Interviews");

            migrationBuilder.DropIndex(
                name: "IX_Interviews_UserId",
                table: "Interviews");

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: new Guid("58261a29-f393-42eb-9436-1f5657fcdeb4"));

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: new Guid("5faa2834-1e68-4117-ae5a-d28c6187a220"));

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: new Guid("8bc88d6e-9982-43c8-b2e1-84a8a33877b4"));

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Interviews");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Interviews",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserInterviews",
                columns: table => new
                {
                    UserInterviewId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    InterviewId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInterviews", x => x.UserInterviewId);
                    table.ForeignKey(
                        name: "FK_UserInterviews_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserInterviews_Interviews_InterviewId",
                        column: x => x.InterviewId,
                        principalTable: "Interviews",
                        principalColumn: "InterviewId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "AnswerId", "QuestionId", "Text" },
                values: new object[,]
                {
                    { new Guid("186a8ed6-cad8-4d7b-8287-0454fdb20286"), new Guid("b9edad52-a404-4d8b-96d1-190dd8aa054a"), "В течение моей карьеры в киноиндустрии, несколько фильмов и режиссеров оказали существенное влияние на мое творчество. Они вдохновляли меня своим стилем, техническим мастерством и подходом к кинематографу.\r\n\r\nОдин из таких режиссеров, который оказал глубокое влияние на меня, - Стэнли Кубрик. Его фильмы, такие как \"Сияние\", \"Заводной апельсин\", \"Барри Линдон\" и \"Сияние\", впечатлили меня своим неповторимым стилем снятия и уникальной визуальной эстетикой. Я был(а) восхищен(а) его аккуратностью в деталях и дерзкими решениями в кинематографической режиссуре, которые сделали его фильмы настоящими произведениями искусства.\r\n\r\nЕще одним режиссером, который оказал влияние на мое творчество, - Кристофер Нолан. Его фильмы, такие как \"Начало\", \"Темный рыцарь\" и \"Интерстеллар\", являются примерами сложной структуры сюжета и инновационных режиссерских приемов. Я восхищался(ась) его способностью создавать глубокие и захватывающие истории, сочетая фантастику с философскими и эмоциональными аспектами.\r\n\r\nТакже стоит отметить фильмы \"Бесславные ублюдки\" Квентина Тарантино и \"Драйв\" Николаса Виндинга Рефна, которые оказали влияние на меня своим ярким стилем, отличной режиссурой и уникальным подходом к кинематографу.\r\n\r\nЭти режиссеры и их фильмы вдохновляют меня в моем творческом процессе и влияют на мой подход к созданию фильмов" },
                    { new Guid("5ab6b566-c7b7-478f-bcb4-075672a0e89e"), new Guid("598f908c-c02d-4e1b-904f-1da660c3bccd"), "Когда я выбираю проекты, над которыми хочу работать, я придерживаюсь нескольких принципов. Прежде всего, я уделяю внимание сценарию. Для меня важно, чтобы история была интересной, оригинальной и вызывала эмоциональный отклик. Я также обращаю внимание на режиссера и его/ее предыдущий опыт, стиль и подход к кинематографу.\r\n\r\nДалее, я анализирую бюджет и ресурсы проекта. Это включает оценку финансовых аспектов, продолжительности съемок, условий работы и других практических факторов. Я стараюсь выбирать проекты, которые предлагают адекватное финансовое вознаграждение и условия работы, соответствующие моим профессиональным навыкам и ожиданиям.\r\n\r\nТакже я учитываю команду проекта. Важно работать с профессионалами, которые разделяют мои ценности и подходы к работе. Команда должна быть сплоченной и иметь опыт в реализации аналогичных проектов.\r\n\r\nЯ также обращаю внимание на потенциал проекта. Если проект предлагает новые вызовы, возможность для профессионального роста, расширения моих навыков или участия в уникальных и значимых проектах, это может стать решающим фактором в выборе проекта.\r\n\r\nНаконец, я также учитываю свою личную мотивацию и интерес к проекту. Если история или концепция проекта вызывают у меня эмоциональное влечение или внутреннюю мотивацию, это может стать дополнительным стимулом для выбора проекта.\r\n\r\nКороче говоря, при выборе проектов, над которыми хочу работать, я учитываю сценарий, режиссера, бюджет и ресурсы проекта, команду, потенциал проекта и свою личную мотивацию. Эти факторы взвешиваются вместе, чтобы определить, какие проекты соответствуют моим профессиональным и личным целям." },
                    { new Guid("d829fbef-9c6f-4590-a035-94a00c3a13b0"), new Guid("9f52e4cc-1fdd-4e68-bd08-e619929d7b4f"), "Я начал свою карьеру в киноиндустрии с огромным интересом к миру кино и желанием внести свой вклад в создание качественных фильмов. Мои первые работы в этой отрасли были связаны с обучением и приобретением опыта, чтобы развиваться как профессионал.\r\n\r\nМоя первая работа в киноиндустрии была стажером на съемочной площадке фильма независимого производства, где я получил первоначальный опыт в организации съемочного процесса и взаимодействии с командой профессионалов. Затем, я работал на различных проектах в качестве ассистента режиссера и продюсера, где приобрел опыт в планировании и организации съемок, взаимодействии с актерами и экипажем, а также в постановке сцен.\r\n\r\nС течением времени и с накоплением опыта, я продвигался в своей карьере в киноиндустрии, работая на более крупных проектах и занимая более ответственные роли, такие как ассистент режиссера, продюсер, или другие специализированные должности. Мои первые работы в киноиндустрии были важным этапом моего профессионального развития, помогая мне приобрести ценный опыт и знания в этой индустрии, которые я успешно применяю и сегодня в своей карьере в киноиндустрии." }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "CEE0ABB0-E53A-44E2-8287-87A3DCE8E7E2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8234d031-e5f4-4d82-9426-b9e450a6e890", "AQAAAAIAAYagAAAAEFvOc1boEQkM7mtmx2dwN1FbvH26tKCVKnxiSlhUPuOBO6fSuCkNfjK7bBq6uLB1iA==" });

            migrationBuilder.UpdateData(
                table: "Interviews",
                keyColumn: "InterviewId",
                keyValue: new Guid("607ed998-da08-11ed-afa1-0242ac120002"),
                columns: new[] { "ApplicationUserId", "EndDate", "StartDate" },
                values: new object[] { null, new DateTime(2023, 6, 14, 3, 47, 48, 84, DateTimeKind.Local).AddTicks(5827), new DateTime(2023, 6, 14, 2, 47, 48, 84, DateTimeKind.Local).AddTicks(5814) });

            migrationBuilder.InsertData(
                table: "UserInterviews",
                columns: new[] { "UserInterviewId", "InterviewId", "UserId" },
                values: new object[,]
                {
                    { new Guid("15c1aceb-fb64-4cef-a207-748366a4e430"), new Guid("607ed998-da08-11ed-afa1-0242ac120002"), "6051a3d6-2e16-48a6-bd8b-224dd8b4bf71" },
                    { new Guid("71cfabf6-74ff-4791-9274-6343d65e02b0"), new Guid("607ed998-da08-11ed-afa1-0242ac120002"), "CEE0ABB0-E53A-44E2-8287-87A3DCE8E7E2" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Interviews_ApplicationUserId",
                table: "Interviews",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInterviews_InterviewId",
                table: "UserInterviews",
                column: "InterviewId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInterviews_UserId",
                table: "UserInterviews",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Interviews_AspNetUsers_ApplicationUserId",
                table: "Interviews",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interviews_AspNetUsers_ApplicationUserId",
                table: "Interviews");

            migrationBuilder.DropTable(
                name: "UserInterviews");

            migrationBuilder.DropIndex(
                name: "IX_Interviews_ApplicationUserId",
                table: "Interviews");

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: new Guid("186a8ed6-cad8-4d7b-8287-0454fdb20286"));

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: new Guid("5ab6b566-c7b7-478f-bcb4-075672a0e89e"));

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: new Guid("d829fbef-9c6f-4590-a035-94a00c3a13b0"));

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Interviews");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Interviews",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "AnswerId", "QuestionId", "Text" },
                values: new object[,]
                {
                    { new Guid("58261a29-f393-42eb-9436-1f5657fcdeb4"), new Guid("9f52e4cc-1fdd-4e68-bd08-e619929d7b4f"), "Я начал свою карьеру в киноиндустрии с огромным интересом к миру кино и желанием внести свой вклад в создание качественных фильмов. Мои первые работы в этой отрасли были связаны с обучением и приобретением опыта, чтобы развиваться как профессионал.\r\n\r\nМоя первая работа в киноиндустрии была стажером на съемочной площадке фильма независимого производства, где я получил первоначальный опыт в организации съемочного процесса и взаимодействии с командой профессионалов. Затем, я работал на различных проектах в качестве ассистента режиссера и продюсера, где приобрел опыт в планировании и организации съемок, взаимодействии с актерами и экипажем, а также в постановке сцен.\r\n\r\nС течением времени и с накоплением опыта, я продвигался в своей карьере в киноиндустрии, работая на более крупных проектах и занимая более ответственные роли, такие как ассистент режиссера, продюсер, или другие специализированные должности. Мои первые работы в киноиндустрии были важным этапом моего профессионального развития, помогая мне приобрести ценный опыт и знания в этой индустрии, которые я успешно применяю и сегодня в своей карьере в киноиндустрии." },
                    { new Guid("5faa2834-1e68-4117-ae5a-d28c6187a220"), new Guid("b9edad52-a404-4d8b-96d1-190dd8aa054a"), "В течение моей карьеры в киноиндустрии, несколько фильмов и режиссеров оказали существенное влияние на мое творчество. Они вдохновляли меня своим стилем, техническим мастерством и подходом к кинематографу.\r\n\r\nОдин из таких режиссеров, который оказал глубокое влияние на меня, - Стэнли Кубрик. Его фильмы, такие как \"Сияние\", \"Заводной апельсин\", \"Барри Линдон\" и \"Сияние\", впечатлили меня своим неповторимым стилем снятия и уникальной визуальной эстетикой. Я был(а) восхищен(а) его аккуратностью в деталях и дерзкими решениями в кинематографической режиссуре, которые сделали его фильмы настоящими произведениями искусства.\r\n\r\nЕще одним режиссером, который оказал влияние на мое творчество, - Кристофер Нолан. Его фильмы, такие как \"Начало\", \"Темный рыцарь\" и \"Интерстеллар\", являются примерами сложной структуры сюжета и инновационных режиссерских приемов. Я восхищался(ась) его способностью создавать глубокие и захватывающие истории, сочетая фантастику с философскими и эмоциональными аспектами.\r\n\r\nТакже стоит отметить фильмы \"Бесславные ублюдки\" Квентина Тарантино и \"Драйв\" Николаса Виндинга Рефна, которые оказали влияние на меня своим ярким стилем, отличной режиссурой и уникальным подходом к кинематографу.\r\n\r\nЭти режиссеры и их фильмы вдохновляют меня в моем творческом процессе и влияют на мой подход к созданию фильмов" },
                    { new Guid("8bc88d6e-9982-43c8-b2e1-84a8a33877b4"), new Guid("598f908c-c02d-4e1b-904f-1da660c3bccd"), "Когда я выбираю проекты, над которыми хочу работать, я придерживаюсь нескольких принципов. Прежде всего, я уделяю внимание сценарию. Для меня важно, чтобы история была интересной, оригинальной и вызывала эмоциональный отклик. Я также обращаю внимание на режиссера и его/ее предыдущий опыт, стиль и подход к кинематографу.\r\n\r\nДалее, я анализирую бюджет и ресурсы проекта. Это включает оценку финансовых аспектов, продолжительности съемок, условий работы и других практических факторов. Я стараюсь выбирать проекты, которые предлагают адекватное финансовое вознаграждение и условия работы, соответствующие моим профессиональным навыкам и ожиданиям.\r\n\r\nТакже я учитываю команду проекта. Важно работать с профессионалами, которые разделяют мои ценности и подходы к работе. Команда должна быть сплоченной и иметь опыт в реализации аналогичных проектов.\r\n\r\nЯ также обращаю внимание на потенциал проекта. Если проект предлагает новые вызовы, возможность для профессионального роста, расширения моих навыков или участия в уникальных и значимых проектах, это может стать решающим фактором в выборе проекта.\r\n\r\nНаконец, я также учитываю свою личную мотивацию и интерес к проекту. Если история или концепция проекта вызывают у меня эмоциональное влечение или внутреннюю мотивацию, это может стать дополнительным стимулом для выбора проекта.\r\n\r\nКороче говоря, при выборе проектов, над которыми хочу работать, я учитываю сценарий, режиссера, бюджет и ресурсы проекта, команду, потенциал проекта и свою личную мотивацию. Эти факторы взвешиваются вместе, чтобы определить, какие проекты соответствуют моим профессиональным и личным целям." }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "CEE0ABB0-E53A-44E2-8287-87A3DCE8E7E2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "db621e3a-1da3-423f-b9ae-5710e41da1a7", "AQAAAAIAAYagAAAAEJ3dKknes/2u/YLgOuhFeMhMnWz2ymZmeAsHi+lymw181ctl1lbQ0wpUfliatSG81Q==" });

            migrationBuilder.UpdateData(
                table: "Interviews",
                keyColumn: "InterviewId",
                keyValue: new Guid("607ed998-da08-11ed-afa1-0242ac120002"),
                columns: new[] { "EndDate", "StartDate", "UserId" },
                values: new object[] { new DateTime(2023, 6, 14, 3, 11, 50, 521, DateTimeKind.Local).AddTicks(5809), new DateTime(2023, 6, 14, 2, 11, 50, 521, DateTimeKind.Local).AddTicks(5797), "CEE0ABB0-E53A-44E2-8287-87A3DCE8E7E2" });

            migrationBuilder.CreateIndex(
                name: "IX_Interviews_UserId",
                table: "Interviews",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Interviews_AspNetUsers_UserId",
                table: "Interviews",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
