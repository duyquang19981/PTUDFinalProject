namespace DataRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteidkhuvuc : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.DenGiaoThongs", "Id_KhuVuc");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DenGiaoThongs", "Id_KhuVuc", c => c.Int(nullable: false));
        }
    }
}
