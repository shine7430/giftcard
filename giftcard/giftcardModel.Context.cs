﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace AllTrustUs.giftcard
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class giftcardEntities : DbContext
    {
        public giftcardEntities()
            : base("name=giftcardEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<t_apps> t_apps { get; set; }
        public virtual DbSet<t_company> t_company { get; set; }
        public virtual DbSet<t_user> t_user { get; set; }
        public virtual DbSet<t_user2app> t_user2app { get; set; }
        public virtual DbSet<giftcard> giftcard { get; set; }
        public virtual DbSet<v_giftcard> v_giftcard { get; set; }
    }
}
