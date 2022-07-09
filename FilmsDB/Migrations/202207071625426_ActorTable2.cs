namespace FilmsDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActorTable2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MyFilms", "Actor_Id", "dbo.Actors");
            DropIndex("dbo.MyFilms", new[] { "Actor_Id" });
            AddColumn("dbo.Actors", "MyFilm_Id", c => c.Int());
            CreateIndex("dbo.Actors", "MyFilm_Id");
            AddForeignKey("dbo.Actors", "MyFilm_Id", "dbo.MyFilms", "Id");
            DropColumn("dbo.MyFilms", "Actor_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MyFilms", "Actor_Id", c => c.Int());
            DropForeignKey("dbo.Actors", "MyFilm_Id", "dbo.MyFilms");
            DropIndex("dbo.Actors", new[] { "MyFilm_Id" });
            DropColumn("dbo.Actors", "MyFilm_Id");
            CreateIndex("dbo.MyFilms", "Actor_Id");
            AddForeignKey("dbo.MyFilms", "Actor_Id", "dbo.Actors", "Id");
        }
    }
}
