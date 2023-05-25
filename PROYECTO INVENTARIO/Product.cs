using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_INVENTARIO
{
    public abstract class Product
    {
        public string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string code;
        public string Code
        {
            get { return code; }
            set { code = value; }
        }
        public DateTime? entry_date;
        public DateTime? Entry_date
        {
            get { return entry_date; }
            set { entry_date = value; }
        }
        public double purchase_price;
        public double Purchase_price
        {
            get { return purchase_price; }
            set { purchase_price = value; }
        }
        public double sale_price;
        public double Sale_price
        {
            get { return sale_price; }
            set { sale_price= value; }
        }
        public Product()
        {
            name = string.Empty;
            code = string.Empty;
            entry_date = null;
            purchase_price = 0;
            sale_price = 0;
        }
        public Product(string name, string code, DateTime? entry_date, double purchase_price, double sale_price)
        {
            this.name = name;
            this.code = code;
            this.entry_date = entry_date;
            this.purchase_price = purchase_price;
            this.sale_price = sale_price;
        }
        public override string ToString()
        { return "Nombre: " + name + " Codigo: " + code + " Fecha de entrada: " + entry_date + " Precio de compra: " + purchase_price + " Precio de venta: " + sale_price; }
    }
}
