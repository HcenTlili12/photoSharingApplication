using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;

namespace PhotoSharingApp.model
{
    public class PhotoSharingContext : System.Data.Entity.DbContext
    {
        public DbSet<Photo> photo { get; set; }
        public DbSet<Comment> comment { get; set; }
    }
}