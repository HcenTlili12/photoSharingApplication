﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhotoSharingApp.model
{
    public class Photo
    {
        public int PhotoId {get; set; }
        public String Title {get; set; }
        [DisplayName("Picture")]
        public byte[] PhotoFile {get; set; }
        [DataType(DataType.MultilineText)]
        public String Description {get; set; }
        [DataType(DataType.DateTime)]
        [DisplayName("Created Date")]
        [DisplayFormat(DataFormatString ="{0:MM/dd/yy}",ApplyFormatInEditMode =true)]
        public object CreatedDate { get; set; }
        public DBSet prop;
        public String UserName { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}