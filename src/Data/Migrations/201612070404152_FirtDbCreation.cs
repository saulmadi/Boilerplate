namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirtDbCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Personas",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Nombre = c.String(),
                        Apellido = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Personas");
        }
    }
}
