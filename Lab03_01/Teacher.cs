using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab03_01
{
    internal class Teacher : Person   
    {
        private string address;

        public Teacher() { }

        public Teacher(string id, string fullname, string address)
            : base(id, fullname)   // (1)
        {
            this.Address = address;
        }

        public string Address
        {
            get => address;
            set => address = value;
        }

        public override void Input()   // (2)
        {
            base.Input();   // gọi Input() của Person

            Console.Write("Nhập địa chỉ: ");
            Address = Console.ReadLine();
        }

        public override void Output()   // (3)
        {
            base.Output();   // gọi Output() của Person

            Console.WriteLine(" - Địa chỉ: {0}", this.Address);
        }
    }
}
