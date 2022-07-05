namespace FilmsDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class film1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MyFilms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Annotation = c.String(),
                        Status = c.String(),
                        Photo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MyFilms");
        }
    }
}
