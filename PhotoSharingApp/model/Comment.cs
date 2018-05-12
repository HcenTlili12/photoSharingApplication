using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoSharingApp.model
{
    public class Comment
    {
        private int CommentId { get; set; }
        private String UserName { get; set; }
        private String Subject { get; set; }
        private String Body { get; set; }
        private int PhotoId { get; set; }
        public virtual Photo photo { get; set; }
        
    }
}