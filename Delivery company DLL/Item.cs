using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery_company_DLL
{
    public class Item
    {
        private string name;
        private string description;
        private Supplier supplier;

        public Item(string name, string description, Supplier supplier)
        {
            this.name = name;
            this.description = description;
            this.supplier = supplier;
            AddInItemCatalog();
        }
        public Item(string name, Supplier supplier)
        {
            this.name = name;
            this.supplier = supplier;
            AddInItemCatalog();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }
        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value;
            }
        }
        public Supplier Supplier
        {
            get
            {
                return this.supplier;
            }
            set
            {
                this.supplier = value;
            }
        }

        public void AddInItemCatalog()
        {
            if (!this.Supplier.ItemsCatalog.Any(i => i.Equals(this)))
            {
                this.Supplier.ItemsCatalog.Add(this);
                Console.WriteLine('y');
            }
            else Console.WriteLine('n');
        }
        
        


    }
}
