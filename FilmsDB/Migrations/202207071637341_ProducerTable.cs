namespace FilmsDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProducerTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Producers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        BDay = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.MyFilms", "Producer_Id", c => c.Int());
            CreateIndex("dbo.MyFilms", "Producer_Id");
            AddForeignKey("dbo.MyFilms", "Producer_Id", "dbo.Producers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MyFilms", "Producer_Id", "dbo.Producers");
            DropIndex("dbo.MyFilms", new[] { "Producer_Id" });
            DropColumn("dbo.MyFilms", "Producer_Id");
            DropTable("dbo.Producers");
        }
    }
}
