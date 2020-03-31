namespace PetStoreApiTests.RestHelper
{
    public class Category
    {
        long id;
        string name;

        public long getId()
        {
            return id;
        }
        public Category setId(long id)
        {
            this.id = id;
            return this;
        }
        public string getName()
        {
            return name;
        }
        public Category setName(string name)
        {
            this.name = name;
            return this;
        }
    }
}