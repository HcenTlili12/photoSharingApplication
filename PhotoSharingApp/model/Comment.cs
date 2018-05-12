using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhotoSharingApp.model
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }
        public String UserName { get; set; }
        public String Subject { get; set; }
        public String Body { get; set; }
        public int PhotoId { get; set; }
        public virtual Photo photo { get; set; }
        public Comment() { }
        public Comment(String u, String s, String b)
        {
            this.UserName = u;
            this.Subject = s;
            this.Body = b;
        }
    }
}