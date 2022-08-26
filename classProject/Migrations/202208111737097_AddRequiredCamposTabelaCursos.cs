namespace classProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRequiredCamposTabelaCursos : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Curso", "Nome", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Curso", "Nome", c => c.String());
        }
    }
}
