using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barcode_CCSTape.DTO
{
    class Product_DTO
    {
        public string lot_serial { get; set; }
        public string prod_serial { get; set; }
        public string order_no { get; set; }
        public string prod_code { get; set; }

        public Product_DTO(string serial, string orderno, string code)
        {
            this.prod_serial = serial;
            this.order_no = orderno;
            this.prod_code = code;
        }
        public Product_DTO()
        {

        }
    }
}
