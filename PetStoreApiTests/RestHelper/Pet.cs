using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStoreApiTests.RestHelper
{
    public class Pet
    {
        public long id;
        public Category category;
        public string name;
        public List<string> photoUrls;
        public List<Tag> tags;
        public string status;


        public long GetId()
        {
            return id;
        }

        public Pet SetId(long id)
        {
            this.id = id;
            return this;
        }

        public Category GetCategory()
        {
            return category;
        }
        public Pet SetCategory(Category category)
        {
            this.category = category;
            return this;
        }
        public string GetName()
        {
            return name;
        }
        public Pet SetName(string name)
        {
            this.name = name;
            return this;
        }
        public List<string> GetPhotoUrls()
        {
            return photoUrls;
        }
        public Pet SetPhotoUrls(List<string> photoUrls)
        {
            this.photoUrls = photoUrls;
            return this;
        }

        public Pet AddPhotoUrl(string photoUrl)
        {
            this.photoUrls = new List<string>();
            this.photoUrls.Add(photoUrl);
            return this;
        }

        public List<Tag> GetTags()
        {
            return tags;
        }
        public Pet SetTags(List<Tag> tags)
        {
            this.tags = tags;
            return this;
        }
        public Pet AddTag(Tag tag)
        {
            this.tags = new List<Tag>();
            this.tags.Add(tag);
            return this;
        }
        public string GetStatus()
        {
            return status;
        }
        public Pet SetStatus(string status)
        {
            this.status = status;
            return this;
        }
    }
}
