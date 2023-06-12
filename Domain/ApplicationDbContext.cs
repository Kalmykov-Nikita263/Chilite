﻿using Chilite.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Chilite.Domain;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Interview> Interviews { get; set; }

    public DbSet<Question> Questions { get; set; }

    public DbSet<Answer> Answers { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<IdentityRole>().HasData(new IdentityRole
        {
            Id = "332A0729-7DA8-4BFA-BC76-E26889B0A8C6",
            Name = "admin",
            NormalizedName = "ADMIN"
        });

        builder.Entity<IdentityUser>().HasData(new IdentityUser
        {
            Id = "CEE0ABB0-E53A-44E2-8287-87A3DCE8E7E2",
            UserName = "admin",
            NormalizedUserName = "ADMIN",
            Email = "InterView@email.com",
            NormalizedEmail = "INTERVIEW@EMAIL.COM",
            EmailConfirmed = true,
            PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "superpassword"),
            SecurityStamp = string.Empty
        });

        builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = "332A0729-7DA8-4BFA-BC76-E26889B0A8C6",
            UserId = "CEE0ABB0-E53A-44E2-8287-87A3DCE8E7E2"
        });

        builder.Entity<Interview>()
            .HasOne(i => i.User)
            .WithMany(u => u.Interviews)
            .HasForeignKey(i => i.UserId)
            .IsRequired();

        builder.Entity<Interview>()
            .HasOne(i => i.Room)
            .WithMany(r => r.Interviews)
            .HasForeignKey(i => i.RoomId)
            .IsRequired();

        builder.Entity<Answer>().HasData(
            new Answer
            {
                AnswerId = Guid.NewGuid(),
                QuestionId = new Guid("9f52e4cc-1fdd-4e68-bd08-e619929d7b4f"),
                Text = "Я начал свою карьеру в киноиндустрии с огромным интересом к миру кино и желанием внести свой вклад в создание качественных фильмов. Мои первые работы в этой отрасли были связаны с обучением и приобретением опыта, чтобы развиваться как профессионал.\r\n\r\nМоя первая работа в киноиндустрии была стажером на съемочной площадке фильма независимого производства, где я получил первоначальный опыт в организации съемочного процесса и взаимодействии с командой профессионалов. Затем, я работал на различных проектах в качестве ассистента режиссера и продюсера, где приобрел опыт в планировании и организации съемок, взаимодействии с актерами и экипажем, а также в постановке сцен.\r\n\r\nС течением времени и с накоплением опыта, я продвигался в своей карьере в киноиндустрии, работая на более крупных проектах и занимая более ответственные роли, такие как ассистент режиссера, продюсер, или другие специализированные должности. Мои первые работы в киноиндустрии были важным этапом моего профессионального развития, помогая мне приобрести ценный опыт и знания в этой индустрии, которые я успешно применяю и сегодня в своей карьере в киноиндустрии."
            },
            new Answer
            {
                AnswerId = Guid.NewGuid(),
                QuestionId = new Guid("b9edad52-a404-4d8b-96d1-190dd8aa054a"),
                Text = "В течение моей карьеры в киноиндустрии, несколько фильмов и режиссеров оказали существенное влияние на мое творчество. Они вдохновляли меня своим стилем, техническим мастерством и подходом к кинематографу.\r\n\r\nОдин из таких режиссеров, который оказал глубокое влияние на меня, - Стэнли Кубрик. Его фильмы, такие как \"Сияние\", \"Заводной апельсин\", \"Барри Линдон\" и \"Сияние\", впечатлили меня своим неповторимым стилем снятия и уникальной визуальной эстетикой. Я был(а) восхищен(а) его аккуратностью в деталях и дерзкими решениями в кинематографической режиссуре, которые сделали его фильмы настоящими произведениями искусства.\r\n\r\nЕще одним режиссером, который оказал влияние на мое творчество, - Кристофер Нолан. Его фильмы, такие как \"Начало\", \"Темный рыцарь\" и \"Интерстеллар\", являются примерами сложной структуры сюжета и инновационных режиссерских приемов. Я восхищался(ась) его способностью создавать глубокие и захватывающие истории, сочетая фантастику с философскими и эмоциональными аспектами.\r\n\r\nТакже стоит отметить фильмы \"Бесславные ублюдки\" Квентина Тарантино и \"Драйв\" Николаса Виндинга Рефна, которые оказали влияние на меня своим ярким стилем, отличной режиссурой и уникальным подходом к кинематографу.\r\n\r\nЭти режиссеры и их фильмы вдохновляют меня в моем творческом процессе и влияют на мой подход к созданию фильмов"
            },
            new Answer
            {
                AnswerId = Guid.NewGuid(),
                QuestionId = new Guid("598f908c-c02d-4e1b-904f-1da660c3bccd"),
                Text = "Когда я выбираю проекты, над которыми хочу работать, я придерживаюсь нескольких принципов. Прежде всего, я уделяю внимание сценарию. Для меня важно, чтобы история была интересной, оригинальной и вызывала эмоциональный отклик. Я также обращаю внимание на режиссера и его/ее предыдущий опыт, стиль и подход к кинематографу.\r\n\r\nДалее, я анализирую бюджет и ресурсы проекта. Это включает оценку финансовых аспектов, продолжительности съемок, условий работы и других практических факторов. Я стараюсь выбирать проекты, которые предлагают адекватное финансовое вознаграждение и условия работы, соответствующие моим профессиональным навыкам и ожиданиям.\r\n\r\nТакже я учитываю команду проекта. Важно работать с профессионалами, которые разделяют мои ценности и подходы к работе. Команда должна быть сплоченной и иметь опыт в реализации аналогичных проектов.\r\n\r\nЯ также обращаю внимание на потенциал проекта. Если проект предлагает новые вызовы, возможность для профессионального роста, расширения моих навыков или участия в уникальных и значимых проектах, это может стать решающим фактором в выборе проекта.\r\n\r\nНаконец, я также учитываю свою личную мотивацию и интерес к проекту. Если история или концепция проекта вызывают у меня эмоциональное влечение или внутреннюю мотивацию, это может стать дополнительным стимулом для выбора проекта.\r\n\r\nКороче говоря, при выборе проектов, над которыми хочу работать, я учитываю сценарий, режиссера, бюджет и ресурсы проекта, команду, потенциал проекта и свою личную мотивацию. Эти факторы взвешиваются вместе, чтобы определить, какие проекты соответствуют моим профессиональным и личным целям."
            }
        );

        builder.Entity<Interview>().HasData(
            new Interview
            {
                InterviewId = new Guid("607ed998-da08-11ed-afa1-0242ac120002"),
                Title = "За кадром: жизнь и карьера режиссера",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddHours(1),
                UserId = "CEE0ABB0-E53A-44E2-8287-87A3DCE8E7E2",
                RoomId = new Guid().ToString()
            }
        );

        builder.Entity<Question>().HasData(
            new Question
            {
                QuestionId = new Guid("9f52e4cc-1fdd-4e68-bd08-e619929d7b4f"),
                Text = "Как вы начали свою карьеру в киноиндустрии и какие были ваши первые работы?",
                InterviewId = new Guid("607ed998-da08-11ed-afa1-0242ac120002")
            },
            new Question
            {
                QuestionId = new Guid("b9edad52-a404-4d8b-96d1-190dd8aa054a"),
                Text = "Какие фильмы или режиссеры оказали влияние на ваше творчество?",
                InterviewId = new Guid("607ed998-da08-11ed-afa1-0242ac120002")
            },
            new Question
            {
                QuestionId = new Guid("598f908c-c02d-4e1b-904f-1da660c3bccd"),
                Text = "Как вы выбираете проекты, над которыми хотите работать?",
                InterviewId = new Guid("607ed998-da08-11ed-afa1-0242ac120002")
            }
        );
    }
}