namespace classProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Aluno",
                c => new
                    {
                        AlunoID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Sobrenome = c.String(),
                        Idade = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AlunoID);
            
            CreateTable(
                "dbo.Matricula",
                c => new
                    {
                        MatriculaID = c.Int(nullable: false, identity: true),
                        CursoID = c.Int(nullable: false),
                        AlunoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MatriculaID)
                .ForeignKey("dbo.Aluno", t => t.AlunoID, cascadeDelete: true)
                .ForeignKey("dbo.Curso", t => t.CursoID, cascadeDelete: true)
                .Index(t => t.CursoID)
                .Index(t => t.AlunoID);
            
            CreateTable(
                "dbo.Curso",
                c => new
                    {
                        CursoID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        CargaHoraria = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CursoID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Matricula", "CursoID", "dbo.Curso");
            DropForeignKey("dbo.Matricula", "AlunoID", "dbo.Aluno");
            DropIndex("dbo.Matricula", new[] { "AlunoID" });
            DropIndex("dbo.Matricula", new[] { "CursoID" });
            DropTable("dbo.Curso");
            DropTable("dbo.Matricula");
            DropTable("dbo.Aluno");
        }
    }
}
