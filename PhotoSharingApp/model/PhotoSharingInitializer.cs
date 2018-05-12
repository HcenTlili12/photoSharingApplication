using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.IO;

namespace PhotoSharingApp.model
{
    public class PhotoSharingInitializer : DropCreateDatabaseAlways<PhotoSharingContext>
    {
        

        protected override void Seed(PhotoSharingContext context)
        {
            List<Photo> a = new List<Photo>();
            Photo p = new Photo("Test Photo", "first", "NaokiSato", File.ReadAllBytes("C:/Users/ASUS X556U/Desktop/photoSharingProject/photoSharingApplication/PhotoSharingApp/images/men1.png"), "image/jpeg", "today");
            a.Add(p);
            foreach(Photo photo in a)
            {
                context.photo.Add(photo);
            }
           // context.SaveChanges();

            List<Comment> c = new List<Comment>();
            Comment comm = new Comment("NaokiSato","Test Comment"," This comment should appear in photo 1");
            c.Add(comm);
            foreach (Comment commentaire in c)
            {
                context.comment.Add(commentaire);
            }
            context.SaveChanges();
        }
    }
}