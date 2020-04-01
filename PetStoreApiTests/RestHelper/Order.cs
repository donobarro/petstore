using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStoreApiTests.RestHelper
{
    class Order
    {
        private long id;
        private long petId;
        private long quantity;
        private DateTime shipDate;
        private string status;
        private bool complete;

        public long GetId()
        {
            return id;
        }
        public Order SetId(long id)
        {
            this.id = id;
            return this;
        }
        public long GetPetId()
        {
            return petId;
        }
        public Order SetPetId(long petId)
        {
            this.petId = petId;
            return this;
        }
        public long GetQuantity()
        {
            return quantity;
        }
        public Order SetQuantity(long quantity)
        {
            this.quantity = quantity;
            return this;
        }
        public DateTime GetShipDate()
        {
            return shipDate;
        }
        public Order SetShipDate(DateTime shipDate)
        {
            this.shipDate = shipDate;
            return this;
        }
        public string GetStatus()
        {
            return status;
        }
        public Order SetStatus(string status)
        {
            this.status = status;
            return this;
        }
        public bool GetComplete()
        {
            return complete;
        }
        public Order SetComplete(bool complete)
        {
            this.complete = complete;
            return this;
        }
    }
}
