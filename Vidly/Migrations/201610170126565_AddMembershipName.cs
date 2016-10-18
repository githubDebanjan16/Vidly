namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMembershipName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "MembershipName", c => c.String());
            Sql("Update MembershipTypes set MembershipName='PayAsYouGo' where Id=1");
            Sql("Update MembershipTypes set MembershipName='Monthly' where Id=2");
            Sql("Update MembershipTypes set MembershipName='Quarterly' where Id=3");
            Sql("Update MembershipTypes set MembershipName='Yearly' where Id=4");
        }
        
        public override void Down()
        {
            DropColumn("dbo.MembershipTypes", "MembershipName");
        }
    }
}
