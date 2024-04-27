using ShoppingBLLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exception;
using ShoppingModelLibrary.Exceptions;

namespace ShoppingDALLibrary
{
    public class CustomerRepository : AbstractRepository<int, Customer>
    {
        public override async Task<Customer> Delete(int key)
        {
            Customer customer = items.SingleOrDefault(c => c.Id == key);
            if (customer != null)
            {
                //items.Remove(customer);
                customer.IsActive = false;
            }
            return customer;

        }
        public override async Task<Customer> Add(Customer item)
        {
            if (items.Count > 0)
            {
                foreach (Customer customer in items)
                {
                    if (customer.Id == item.Id)
                    {
                        throw new DuplicateCustomerException();
                    }
                }
            }
            item.IsActive = true;
            items.Add(item);
            return item;
        }

        //public override Task<ICollection<Customer>> GetAll()
        //{
        //    if(items.Count>0)
        //        return items;
        //    throw new NoCustomerWithGiveIdException();
        //}

        public override async Task<Customer> GetByKey(int key)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Id == key)
                    return items[i];
            }
            throw new NoCustomerWithGiveIdException();
        }

        public override async Task<Customer> Update(Customer item)
        {
            if (items.Count > 0)
            {
                var index = items.FindIndex(p => p.Id == item.Id);
                if (index == -1)
                {
                    throw new NoCustomerWithGiveIdException();
                }
                items[index] = item;
                return item;
            }
            throw new NoCustomerWithGiveIdException();
        }
    }
}