namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestOnMSSQL : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM Movies WHERE Name='Superman'");
        }
        
        public override void Down()
        {
        }
    }
}
