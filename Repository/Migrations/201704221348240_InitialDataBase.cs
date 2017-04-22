namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDataBase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agencias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        BancoId = c.Int(nullable: false),
                        Endereco = c.String(),
                        Codigo = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bancoes", t => t.BancoId, cascadeDelete: true)
                .Index(t => t.BancoId);
            
            CreateTable(
                "dbo.Bancoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Codigo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Correntes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreditoPreAprovado = c.Single(nullable: false),
                        AgenciaId = c.Int(nullable: false),
                        UsuarioId = c.Int(nullable: false),
                        Codigo = c.String(),
                        Saldo = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Agencias", t => t.AgenciaId, cascadeDelete: true)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId, cascadeDelete: true)
                .Index(t => t.AgenciaId)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Endereco = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Poupancas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        JurosMensal = c.Single(nullable: false),
                        Codigo = c.String(),
                        AgenciaId = c.Int(nullable: false),
                        UsuarioId = c.Int(nullable: false),
                        Saldo = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Agencias", t => t.AgenciaId, cascadeDelete: true)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId, cascadeDelete: true)
                .Index(t => t.AgenciaId)
                .Index(t => t.UsuarioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Correntes", "UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.Poupancas", "UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.Poupancas", "AgenciaId", "dbo.Agencias");
            DropForeignKey("dbo.Correntes", "AgenciaId", "dbo.Agencias");
            DropForeignKey("dbo.Agencias", "BancoId", "dbo.Bancoes");
            DropIndex("dbo.Poupancas", new[] { "UsuarioId" });
            DropIndex("dbo.Poupancas", new[] { "AgenciaId" });
            DropIndex("dbo.Correntes", new[] { "UsuarioId" });
            DropIndex("dbo.Correntes", new[] { "AgenciaId" });
            DropIndex("dbo.Agencias", new[] { "BancoId" });
            DropTable("dbo.Poupancas");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Correntes");
            DropTable("dbo.Bancoes");
            DropTable("dbo.Agencias");
        }
    }
}
