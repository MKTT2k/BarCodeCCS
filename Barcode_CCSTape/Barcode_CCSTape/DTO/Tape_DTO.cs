using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barcode_CCSTape.DTO
{
    class Tape_DTO
    {
        public string material_code { get; set; }

        public string material_lotno { get; set; }

        public string serial { get; set; }

        public string type { get; set; }

        public string quantity { get; set; }

        public string brand { get; set; }

        public string use { get; set; }

        public string totalNG { get; set; }

        public Tape_DTO()
        {

        }

        public Tape_DTO(string code, string lotno, string serial, string type, string qty)
        {
            this.material_code = code;
            this.material_lotno = lotno;
            this.serial = serial;
            this.type = type;
            this.quantity = qty;
        }

        public Tape_DTO(string code, string lotno, string serial, string type, string qty, string use, string ng)
        {
            this.material_code = code;
            this.material_lotno = lotno;
            this.serial = serial;
            this.type = type;
            this.quantity = qty;
            this.use = use;
            this.totalNG = ng;
        }
    }
}
