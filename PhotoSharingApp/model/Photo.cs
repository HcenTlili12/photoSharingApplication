using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhotoSharingApp.model
{
    public class Photo
    {
        private int PhotoId {get; set; }
        private String Title {get; set; }
        [DisplayName("Picture")]
        private byte[] PhotoFile {get; set; }
        [DataType.(DataType.MultilineText)]
        private String Description {get; set; }
        [DataType.(DataType.DateTime)]
        [DisplayName("Created Date")]
        [DisplayFormat(DataFormatString ="{0:MM/dd/yy}",ApplyFormatInEditMode =true)]
        private object CreatedDate { get; set; }
        
        private String UserName { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}