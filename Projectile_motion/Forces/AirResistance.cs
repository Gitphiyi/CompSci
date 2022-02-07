using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace Projectile_motion.Forces
{
    public class AirResistance : Force
    {
        double constant;
        public AirResistance(double constant)
        { 
            this.constant = constant;   
        }
        public Vector CreateForce(Projectile proj)
        {
            double speed = proj.Velocity.Magnitude;
            return -proj.Velocity * speed * constant;
        }
    }
}
