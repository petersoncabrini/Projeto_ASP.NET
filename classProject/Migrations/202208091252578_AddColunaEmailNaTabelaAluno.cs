namespace classProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColunaEmailNaTabelaAluno : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Aluno", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Aluno", "Email");
        }
    }
}
