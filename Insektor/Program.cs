using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InsektorComm;

namespace Insektor
{
    class Program
    {
        static void Main(string[] args)
        {
            InsektorCommTest.Test();

            var form = new Form1();
            Application.Run(form);

        }
    }
}
