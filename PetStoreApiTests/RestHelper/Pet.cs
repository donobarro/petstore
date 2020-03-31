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


        public long getId()
        {
            return id;
        }

        public Pet setId(long id)
        {
            this.id = id;
            return this;
        }

        public Category getCategory()
        {
            return category;
        }
        public Pet setCategory(Category category)
        {
            this.category = category;
            return this;
        }
        public string getName()
        {
            return name;
        }
        public Pet setName(string name)
        {
            this.name = name;
            return this;
        }
        public List<string> getPhotoUrls()
        {
            return photoUrls;
        }
        public Pet setPhotoUrls(List<string> photoUrls)
        {
            this.photoUrls = photoUrls;
            return this;
        }

        public Pet addPhotoUrl(string photoUrl)
        {
            this.photoUrls = new List<string>();
            this.photoUrls.Add(photoUrl);
            return this;
        }

        public List<Tag> getTags()
        {
            return tags;
        }
        public Pet setTags(List<Tag> tags)
        {
            this.tags = tags;
            return this;
        }
        public Pet addTag(Tag tag)
        {
            this.tags = new List<Tag>();
            this.tags.Add(tag);
            return this;
        }
        public string getStatus()
        {
            return status;
        }
        public Pet setStatus(string status)
        {
            this.status = status;
            return this;
        }
    }
}
