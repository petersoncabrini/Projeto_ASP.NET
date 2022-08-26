namespace classProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRequiredCamposTabelaAlunos : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Aluno", "Nome", c => c.String(nullable: false));
            AlterColumn("dbo.Aluno", "Sobrenome", c => c.String(nullable: false));
            AlterColumn("dbo.Aluno", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Aluno", "Email", c => c.String());
            AlterColumn("dbo.Aluno", "Sobrenome", c => c.String());
            AlterColumn("dbo.Aluno", "Nome", c => c.String());
        }
    }
}
