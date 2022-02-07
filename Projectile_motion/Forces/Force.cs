using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace Projectile_motion.Forces
{
    public interface Force
    {
        Vector CreateForce(Projectile proj);
    }
}
