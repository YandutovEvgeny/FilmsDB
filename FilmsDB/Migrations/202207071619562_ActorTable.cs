namespace FilmsDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActorTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        BDay = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.MyFilms", "Actor_Id", c => c.Int());
            CreateIndex("dbo.MyFilms", "Actor_Id");
            AddForeignKey("dbo.MyFilms", "Actor_Id", "dbo.Actors", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MyFilms", "Actor_Id", "dbo.Actors");
            DropIndex("dbo.MyFilms", new[] { "Actor_Id" });
            DropColumn("dbo.MyFilms", "Actor_Id");
            DropTable("dbo.Actors");
        }
    }
}
