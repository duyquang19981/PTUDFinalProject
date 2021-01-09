namespace DataRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dieukhienGT : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DenGT_ThayDoi",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ThoiDiemThayDoi = c.String(),
                        ThoiGianDoi = c.Int(nullable: false),
                        Do_TD = c.Int(nullable: false),
                        Vang_TD = c.Int(nullable: false),
                        Xanh_TD = c.Int(nullable: false),
                        TuDong = c.Int(nullable: false),
                        ThoiGianThucHien = c.DateTime(nullable: false),
                        DenGiaoThong_Id = c.Int(),
                        NguoiQuanLyGT_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DenGiaoThongs", t => t.DenGiaoThong_Id)
                .ForeignKey("dbo.NguoiQuanLyGTs", t => t.NguoiQuanLyGT_Id)
                .Index(t => t.DenGiaoThong_Id)
                .Index(t => t.NguoiQuanLyGT_Id);
            
            CreateTable(
                "dbo.NguoiQuanLyGTs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ten = c.String(),
                        NgaySinh = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.DenGiaoThongs", "TenDuong", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DenGT_ThayDoi", "NguoiQuanLyGT_Id", "dbo.NguoiQuanLyGTs");
            DropForeignKey("dbo.DenGT_ThayDoi", "DenGiaoThong_Id", "dbo.DenGiaoThongs");
            DropIndex("dbo.DenGT_ThayDoi", new[] { "NguoiQuanLyGT_Id" });
            DropIndex("dbo.DenGT_ThayDoi", new[] { "DenGiaoThong_Id" });
            DropColumn("dbo.DenGiaoThongs", "TenDuong");
            DropTable("dbo.NguoiQuanLyGTs");
            DropTable("dbo.DenGT_ThayDoi");
        }
    }
}
