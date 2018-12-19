using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery_company_DLL
{
    public class Client
    {
        protected string login;
        protected List<Order> orders; //сделанные заказы
        protected List<Item> notifications;// список отправленых товаров
        private List<Order> cart; //корзина

        public Client(string login)
        {
            this.login = login;
            this.notifications = new List<Item>();
            this.cart = new List<Order>();
            this.orders = new List<Order>();
        }

        public string Login
        {
            get
            {
                return this.login;
            }
            set
            {
                this.login = value;
            }
        }
        public List<Order> Orders
        {
            get
            {
                return this.orders;
            }
            set
            {
                this.orders.Clear();
                foreach (Order order in value)
                {
                    this.orders.Add(order);
                }
            }
        }

        public void AddNotification(Item item)
        {
            this.notifications.Add(item);
        }

        //вывод всех уведомлений о доставке в консоль
        public void PrintNotification()
        {
            Console.WriteLine("Следующие заказы отправлены вам: ");            
            foreach (Item notification in notifications)
            {
                Console.WriteLine(notification.Name + " от " + notification.Supplier.Login);
            }
        }

        //добавление товара в корзину
        public void AddToCart(Order order)
        {
            cart.Add(order);
        }
        public void AddToCart(List<Order> orders)
        {
            foreach(Order order in orders)
            {
                cart.Add(order);
            }
        }
        public void AddToCart(Item item)
        {
            Order order = new Order(item, this);
            cart.Add(order);
        }
        public void AddToCart(List<Item> items)
        {
            int count = items.Count;
            for (int i = 0; i < items.Count; i++)
            {
                Order order = new Order(items[i], this);
                cart.Add(order);
            }
            
        }

        //сделать заказ. Добавляет заказ поставщику
        public bool MakeAnOrder()
        {
            if (cart.Any()) 
            {
                foreach (Order order in cart)
                {
                    order.Item.Supplier.AddOrder(order);
                }
                cart.Clear();
                return true;
            }
            return false;
        }

    }
}
