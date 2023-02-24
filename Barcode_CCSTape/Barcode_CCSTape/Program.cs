using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Barcode_CCSTape
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Barcode_CCSTape.GUI.fHOME());
            //Application.Run(new Barcode_CCSTape.GUI.fConnectScanner());
            //Application.Run(new Barcode_CCSTape.GUI.count_dgv());
            //Application.Run(new Barcode_CCSTape.GUI.fEquipment());
            //Application.Run(new Barcode_CCSTape.GUI.fTest());

        }
    }
}
