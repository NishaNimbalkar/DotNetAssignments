using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assi5_Question2AbstractVehicle
{
    internal class Twowheeler : Vehicle
    {
        public Twowheeler(int vid, string vname, double vprice) : base(vid, vname, vprice)
        {

        }

        public override void GetInsuranceAmount()
        {
            Console.WriteLine($"{VName} insurance value is {VPrice*.5}");
         }
    }
}
