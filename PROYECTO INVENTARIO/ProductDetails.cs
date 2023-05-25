using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_INVENTARIO
{
    class ProductDetails : Product
    {
        private int exit;
        public int Exit
        {
            get { return exit; }
            set { exit = value; }
        }
        private int stock;
        public int Stock
        {
            get { return stock; }
            set { stock = value; }
        }
        private int amount;
        public int Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        public ProductDetails() : base()
        {
            name = string.Empty;
            code = string.Empty;
            entry_date = null;
            purchase_price = 0;
            sale_price = 0;
            exit = 0;
            stock = 0;
            amount = 0;
        }
        public ProductDetails(string name, string code, DateTime? entry_date, double purchase_price, double sale_price, int exit, int stock, int amount) : base(name, code, entry_date, purchase_price, sale_price)
        {
            this.name = name;
            this.code = code;   
            this.entry_date = entry_date;
            this.purchase_price = purchase_price;
            this.sale_price = sale_price;
            this.exit = exit;
            this.stock = stock;
            this.amount = amount;
        }
        public override string ToString()
        { return base.ToString() + " salida: " + exit + " Stock: " + stock + " Entrada: " + amount; }
    }
}
