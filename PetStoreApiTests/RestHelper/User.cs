using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStoreApiTests.RestHelper
{
    class User
    {
        public long id;
        public string username;
        public string firstName;
        public string lastName;
        public string email;
        public string password;
        public string phone;
        public long userStatus;

        public long GetId() { return id; }
        public string GetUsername() { return username; }
        public string GetFirstName() { return firstName; }
        public string GetLastName() { return lastName; }
        public string GetEmail() { return email; }
        public string GetPassword() { return password; }
        public string GetPhone() { return phone; }
        public long GetUserStatus() { return userStatus; }
        public User SetId(long id)
        {
            this.id = id;
            return this;
        }
        public User SetUserName(string username)
        {
            this.username = username;
            return this;
        }
        public User SetFirstName(string firstName)
        {
            this.firstName = firstName;
            return this;
        }
        public User SetLastName(string lastName)
        {
            this.lastName = lastName;
            return this;
        }
        public User SetEmail(string email)
        {
            this.email = email;
            return this;
        }
        public User SetPassword(string password)
        {
            this.password = password;
            return this;
        }
        public User SetPhone(string phone)
        {
            this.phone = phone;
            return this;
        }
        public User SetUserStatus(long userStatus)
        {
            this.userStatus = userStatus;
            return this;
        }
    }
}
