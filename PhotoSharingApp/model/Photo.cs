using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoSharingApp.model
{
    public class Photo
    {
        private int PhotoId {get; set; }
        private String Title {get; set; }
        private Byte PhotoFile {get; set; }
        private String Description {get; set; }
        private object CreatedDate { get; set; }
        private String Owner { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}