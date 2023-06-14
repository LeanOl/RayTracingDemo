namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientId = c.Guid(nullable: false),
                        Username = c.String(),
                        Password = c.String(),
                        RegisterDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ClientId);
            
            CreateTable(
                "dbo.Figures",
                c => new
                    {
                        FigureId = c.Guid(nullable: false),
                        Name = c.String(),
                        Radius = c.Decimal(precision: 18, scale: 2),
                        Proprietary_ClientId = c.Guid(),
                    })
                .PrimaryKey(t => t.FigureId)
                .ForeignKey("dbo.Clients", t => t.Proprietary_ClientId)
                .Index(t => t.Proprietary_ClientId);
            
            CreateTable(
                "dbo.Materials",
                c => new
                    {
                        MaterialId = c.Guid(nullable: false),
                        ColorR = c.Int(nullable: false),
                        ColorG = c.Int(nullable: false),
                        ColorB = c.Int(nullable: false),
                        Name = c.String(),
                        Roughness = c.Decimal(precision: 18, scale: 2),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Proprietary_ClientId = c.Guid(),
                    })
                .PrimaryKey(t => t.MaterialId)
                .ForeignKey("dbo.Clients", t => t.Proprietary_ClientId)
                .Index(t => t.Proprietary_ClientId);
            
            CreateTable(
                "dbo.Models",
                c => new
                    {
                        ModelId = c.Guid(nullable: false),
                        Name = c.String(),
                        Preview = c.String(),
                        Figure_FigureId = c.Guid(nullable:false),
                        Material_MaterialId = c.Guid(nullable: false),
                        Proprietary_ClientId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ModelId)
                .ForeignKey("dbo.Figures", t => t.Figure_FigureId)
                .ForeignKey("dbo.Materials", t => t.Material_MaterialId)
                .ForeignKey("dbo.Clients", t => t.Proprietary_ClientId)
                .Index(t => t.Figure_FigureId)
                .Index(t => t.Material_MaterialId)
                .Index(t => t.Proprietary_ClientId);
            
            CreateTable(
                "dbo.Scenes",
                c => new
                    {
                        SceneId = c.Guid(nullable: false),
                        Preview = c.String(),
                        Name = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        CameraFov = c.Int(nullable: false),
                        CameraLookFrom_X = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CameraLookFrom_Y = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CameraLookFrom_Z = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CameraLookAt_X = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CameraLookAt_Y = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CameraLookAt_Z = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CameraAperture = c.Double(nullable: false),
                        LastModified = c.DateTime(nullable: false),
                        LastRendered = c.DateTime(nullable: false),
                        Proprietary_ClientId = c.Guid(),
                    })
                .PrimaryKey(t => t.SceneId)
                .ForeignKey("dbo.Clients", t => t.Proprietary_ClientId)
                .Index(t => t.Proprietary_ClientId);
            
            CreateTable(
                "dbo.PositionedModels",
                c => new
                    {
                        PositionedModelId = c.Guid(nullable: false),
                        Position_X = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Position_Y = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Position_Z = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Model_ModelId = c.Guid(),
                        Scene_SceneId = c.Guid(),
                    })
                .PrimaryKey(t => t.PositionedModelId)
                .ForeignKey("dbo.Models", t => t.Model_ModelId)
                .ForeignKey("dbo.Scenes", t => t.Scene_SceneId)
                .Index(t => t.Model_ModelId)
                .Index(t => t.Scene_SceneId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Scenes", "Proprietary_ClientId", "dbo.Clients");
            DropForeignKey("dbo.PositionedModels", "Scene_SceneId", "dbo.Scenes");
            DropForeignKey("dbo.PositionedModels", "Model_ModelId", "dbo.Models");
            DropForeignKey("dbo.Models", "Proprietary_ClientId", "dbo.Clients");
            DropForeignKey("dbo.Models", "Material_MaterialId", "dbo.Materials");
            DropForeignKey("dbo.Models", "Figure_FigureId", "dbo.Figures");
            DropForeignKey("dbo.Materials", "Proprietary_ClientId", "dbo.Clients");
            DropForeignKey("dbo.Figures", "Proprietary_ClientId", "dbo.Clients");
            DropIndex("dbo.PositionedModels", new[] { "Scene_SceneId" });
            DropIndex("dbo.PositionedModels", new[] { "Model_ModelId" });
            DropIndex("dbo.Scenes", new[] { "Proprietary_ClientId" });
            DropIndex("dbo.Models", new[] { "Proprietary_ClientId" });
            DropIndex("dbo.Models", new[] { "Material_MaterialId" });
            DropIndex("dbo.Models", new[] { "Figure_FigureId" });
            DropIndex("dbo.Materials", new[] { "Proprietary_ClientId" });
            DropIndex("dbo.Figures", new[] { "Proprietary_ClientId" });
            DropTable("dbo.PositionedModels");
            DropTable("dbo.Scenes");
            DropTable("dbo.Models");
            DropTable("dbo.Materials");
            DropTable("dbo.Figures");
            DropTable("dbo.Clients");
        }
    }
}
