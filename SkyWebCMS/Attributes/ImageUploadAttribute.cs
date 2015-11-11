using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SkyWebCMS.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ImageUploadAttribute : Attribute, IMetadataAware
    {
         public string Folder { get; private set; }
         public ImageUploadAttribute(string folder)
        {
            this.Folder = folder;
            
        }
        public virtual void OnMetadataCreated(ModelMetadata metadata)
        {
            metadata.AdditionalValues.Add("Folder", this.Folder);
           
            metadata.TemplateHint = "ImageUpload";
           

        }
    }
}