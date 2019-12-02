using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CheckSome.Library.Resources.Core.SqlServer
{
    /// <summary>
    /// base class for dbset objects
    /// </summary>
    public class O_CS_BASE
    {
        [Key]
        public int      OBJECT_ID     { get; set; }
        public bool     ACTIVE_YN     { get; set; }
        public DateTime CREATE_ON_DTS { get; set; }
        public string   CREATE_BY_UID { get; set; }
        public DateTime UPDATE_ON_DTS { get; set; }
        public string   UPDATE_BY_UID { get; set; }
    }

    /// <summary>
    /// base class for reference objects
    /// </summary>
    public class O_CS_TYPE_BASE : O_CS_BASE
    {
        public string TYPE_CD  { get; set; }
        public string TYPE_TXT { get; set; }
        public int    ORDER_NO { get; set; }
        public string DESC_TXT { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    [Table("SI_DOMAIN", Schema = "SYSINFO")]
    public class O_SI_DOMAIN : O_CS_BASE
    {
        public string DOMAIN_NM { get; set; }
        public string DESC_TXT  { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    [Table("SI_SERVER_LEVEL_TYPE", Schema = "SYSINFO")]
    public class O_SI_SERVER_LEVEL_TYPE : O_CS_TYPE_BASE
    {
    }

    /// <summary>
    /// 
    /// </summary>
    [Table("SI_SERVER", Schema = "SYSINFO")]
    public class O_SI_SERVER : O_CS_BASE
    {
        public int    DOMAIN_ID   { get; set; }
        public string SERVER_NM   { get; set; }
        public string VERSION_TXT { get; set; }
        public string DESC_TXT    { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    [Table("SI_DATABASE_TYPE", Schema = "SYSINFO")]
    public class O_SI_DATABASE_TYPE : O_CS_TYPE_BASE
    {
    }

    /// <summary>
    /// 
    /// </summary>
    [Table("SI_DATABASE", Schema = "SYSINFO")]
    public class O_SI_DATABASE : O_CS_BASE
    {
        public int    SERVER_ID        { get; set; }
        public string DATABASE_NM      { get; set; }
        public int    DATABASE_TYPE_ID { get; set; }
        public string DESC_TXT         { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    [Table("SI_APPLICATION_TYPE", Schema = "SYSINFO")]
    public class O_SI_APPLICATION_TYPE : O_CS_TYPE_BASE
    {
    }

    /// <summary>
    /// 
    /// </summary>
    [Table("SI_APPLICATION", Schema = "SYSINFO")]
    public class O_SI_APPLICATION : O_CS_BASE
    {
        public int    SERVER_ID           { get; set; }
        public string APPLICATION_NM      { get; set; }
        public int    APPLICATION_TYPE_ID { get; set; }
        public string DESC_TXT            { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    [Table("SI_APP_DB", Schema = "SYSINFO")]
    public class O_SI_APP_DB : O_CS_BASE
    {
        public int    APPLICATION_ID { get; set; }
        public int    DATABASE_ID    { get; set; }
        public int?   DB_LINK_ID     { get; set; }
        public string DESC_TXT       { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    [Table("SI_DB_LINK", Schema = "SYSINFO")]
    public class O_SI_DB_LINK : O_CS_BASE
    {
        public int    SOURCE_DB_ID { get; set; }
        public int    TARGET_DB_ID { get; set; }
        public string DESC_TXT     { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class SysInfoEntities : DbContext
    {
        private readonly string _ConnTxt;

        public SysInfoEntities (string aConnTxt) : base ()
        {
            _ConnTxt = aConnTxt;
        }

        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            if (! optionsBuilder.IsConfigured)
            {
                //var builder = new ConfigurationBuilder()
                //               .SetBasePath(Directory.GetCurrentDirectory())
                //               .AddJsonFile("appsettings.json");

                //var configuration = builder.Build();
                //var connectionString = configuration.GetConnectionString("MyDb");

                optionsBuilder.UseSqlServer(_ConnTxt);
            }
        }

        //protected override void OnModelCreating (DbModelBuilder modelBuilder)
        //{
        //    Database.SetInitializer<CheckSomeEntities>(null);
        //    base.OnModelCreating(modelBuilder);
        //}

        public DbSet<O_SI_DOMAIN>            SI_DOMAIN { get; set; }
        public DbSet<O_SI_SERVER_LEVEL_TYPE> SI_SERVER_LEVEL_TYPE { get; set; }
        public DbSet<O_SI_SERVER>            SI_SERVER { get; set; }
        public DbSet<O_SI_APPLICATION_TYPE>  SI_APPLICATION_TYPE { get; set; }
        public DbSet<O_SI_APPLICATION>       SI_APPLICATION { get; set; }
        public DbSet<O_SI_DATABASE_TYPE>     SI_DATABASE_TYPE { get; set; }
        public DbSet<O_SI_DATABASE>          SI_DATABASE { get; set; }
        public DbSet<O_SI_APP_DB>            SI_APP_DB { get; set; }
        public DbSet<O_SI_DB_LINK>           SI_DB_LINK { get; set; }
    }
}
