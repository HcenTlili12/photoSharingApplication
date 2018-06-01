using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;
using PhotoSharingApp.model;

namespace PhotoSharingApp.model
{
    public class PhotoSharingContext : System.Data.Entity.DbContext, IPhotoSharingContext
    {
        public DbSet<Photo> photo { get; set; }
        public DbSet<Comment> comment { get; set; }
        IQueryable<Comment> IPhotoSharingContext.Comments
       {
            get { return Comments; }
                    }
        public DbSet<Comment> Comments { get; set; }


       int IPhotoSharingContext.SaveChanges()
      {
         return SaveChanges();
       }

      T IPhotoSharingContext.Add<T>(T entity)
       {
           return Set<T>().Add(entity);
       }


        Photo IPhotoSharingContext.FindPhotoById(int ID)
        {
            return Set<Photo>().Find(ID);
        }

        Comment IPhotoSharingContext.FindCommentById(int ID)
        {
            return Set<Comment>().Find(ID);
        }


        T IPhotoSharingContext.Delete<T>(T entity)
        {
            return Set<T>().Remove(entity);
        }


        IQueryable<Photo> IPhotoSharingContext.Photos
        {
    get { return photo; }
            }
    }
}