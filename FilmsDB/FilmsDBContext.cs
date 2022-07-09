using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmsDB
{
    class FilmsDBContext : DbContext
    {
        //таблица по строке подключения связывается с базой
        public FilmsDBContext() : base("DefaultConnection") { }

        //Создаём таблицу
        //DbSet - связь между таблицой и C#
        public DbSet<MyFilm> Films { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Producer> Producers { get; set; }
        
        //Команды для миграции
        //1. enable-migrations - Включает возможность мигрироватся
        //2. add-migration имя_миграции - добавляем миграцию
        //3. update-database - добавляем таблицу в базу данных(после этого шага она отобразится в бд)
    }
}
