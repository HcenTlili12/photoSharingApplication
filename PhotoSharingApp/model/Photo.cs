using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoSharingApp.model
{
    public class Photo
    {
        private int PhotoId;
        private String Title;
        private List<Byte> PhotoFile;
        private String Description;
        private DateTime CreateDate;
        private String Owner;

    }
}