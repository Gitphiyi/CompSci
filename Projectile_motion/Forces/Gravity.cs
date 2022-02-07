using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace Projectile_motion.Forces
{
    public class Gravity : Force
    {
        double constant;
        public Gravity(double constant)
        { 
         this.constant = constant;
        }
        public Vector CreateForce(Projectile proj)
        {
            return constant * proj.Mass*new Vector(0,0,1);
        }
    }
}
