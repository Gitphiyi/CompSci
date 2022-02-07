using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace Projectile_motion.Forces
{
    public class Spring : Force
    {
        double constant;
        public Spring(double constant)
        { 
            this.constant = constant;
        }
        public Vector CreateForce(Projectile proj)
        {
            double unstretchedLength = 2;
            return -constant * (proj.Position.Magnitude - unstretchedLength) * Vector.NormalizeVector(proj.Position);
        }
        public Vector CreateForce(Projectile proj1, Projectile proj2)
        {
            double unstretchedLength = 2;
            double distanceBetweenProj = (proj1.Position - proj2.Position).Magnitude;
            return -constant * (distanceBetweenProj - unstretchedLength) * Vector.NormalizeVector(proj1.Position-proj2.Position);
        }
    }
}
