namespace classProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColunaDataMatriculaNaTabelaMatricula : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Matricula", "DataMatricula", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Matricula", "DataMatricula");
        }
    }
}
