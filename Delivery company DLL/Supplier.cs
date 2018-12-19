using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery_company_DLL
{
    public class Supplier : Client
    {
        private List<Item> itemscatalog; //каталог товаров
        //orders - список заказанных товаров (клиент-товар)

        public Supplier(string login, List<Item> itemscatalog) : base(login)
        {
            this.orders = new List<Order>(); //список заказанных товаров
            this.itemscatalog = new List<Item>(itemscatalog); //каталог товаров           
        }
        public Supplier(string login) : base(login)
        {
            this.itemscatalog = new List<Item>();
            this.orders = new List<Order>();
        }
                
        public List<Item> ItemsCatalog
        {
            get
            {
                return this.itemscatalog;
            }
            set
            {
                this.itemscatalog.Clear();
                foreach(Item item in value)
                {
                    this.itemscatalog.Add(item);
                }
            }
        }        

      /*  public string GetLogin()
        {
            return this.login;
        }*/
        
        public void AddOrder(Order order)
        {
            orders.Add(order);
        }

        //изменяет статус доставки у заказа (по индексу) и добавляет клиенту уведомление
        public void ChangeDelivery(int index, bool markDelivery)
        {    
            if (index < this.orders.Count)
            {
                this.orders[index].MarkDelivery = markDelivery;
                if (markDelivery)
                {
                    Client customer = this.orders[index].Customer;
                    customer.AddNotification(this.orders[index].Item);
                }
            }
        }


    }
}
