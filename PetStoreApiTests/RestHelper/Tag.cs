namespace PetStoreApiTests.RestHelper
{
    public class Tag
    {
        long id;
        string name;

        public long getId()
        {
            return id;
        }
        public Tag setId(long id)
        {
            this.id = id;
            return this;
        }
        public string getName()
        {
            return name;
        }
        public Tag setName(string name)
        {
            this.name = name;
            return this;
        }
    }
}