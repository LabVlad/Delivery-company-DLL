using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery_company_DLL
{
    public class Order
    {
        private Item item; //товар. Изначально предполагалось что в качестве поля будет список товаров, 
                   //однако по факту на складе может не оказаться опреленной позиции, в связи с чем 
                   //для ускорения доставки разные позиции могут быть отправлены раздельно
        private Client customer;//клиент-заказчик.
        private bool markDelivery; //метка доставки

        public Order(Item item, Client customer)
        {
            this.item = item;
            this.customer = customer;
         //   this.supplier = supplier;
            this.markDelivery = false;
        }

        public Item Item
        {
            get
            {
                return this.item;
            }
            set
            {
                this.item = value;
            }
        }
        public Client Customer
        {
            get
            {
                return this.customer;
            }
            set
            {
                this.customer = value;
            }
        }    
        public bool MarkDelivery
        {
            get
            {
                return this.markDelivery;
            }
            set
            {
                this.markDelivery = value;
            }
        }
        
        /* добавление товаров в заказ
         * public void AddInOrder(Item item)
         {
          //добавляем только если одинаковый производитель
             if (item.Any() && item.First().Supplier.Equals(item.Supplier))
             {
                 item.Add(item);
                
             }
         }*/
    }
}
