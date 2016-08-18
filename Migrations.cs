using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.Data.Migration;

namespace Dcmg.CustomerDB
{
    public class Migrations:DataMigrationImpl
    {
        public int Create()
        {
            //Creating initial Customer DB
            SchemaBuilder.CreateTable("Customers", table => table
             .Column("id",System.Data.DbType.Int32,col=>col.PrimaryKey().Identity())
             .Column("Name",System.Data.DbType.String)
             .Column("Address",System.Data.DbType.String)
             .Column("PhoneNumber",System.Data.DbType.String)
             .Column("PrimaryPOC", System.Data.DbType.String)
             .Column("SecondaryPOC", System.Data.DbType.String)
             .Column("PrimaryPOCEmail", System.Data.DbType.String)
             .Column("SecondaryPOCEmail", System.Data.DbType.String)
             .Column("EmailAlias", System.Data.DbType.String)
             .Column("Notes", System.Data.DbType.String)
            );

            return 1;
        }
    }
}