using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assi5_Question2AbstractVehicle
{
    internal abstract class Vehicle
    {
        public int VId {  get; set; }
        public string VName { get; set; }
        public double VPrice {  get; set; }
        public Vehicle(int vid,string vname,double vprice) { 
            VId = vid;
            VName = vname;  
            VPrice = vprice;
                 

        }
        public abstract void GetInsuranceAmount();
    }
}
