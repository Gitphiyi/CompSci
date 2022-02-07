using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace Projectile_motion
{
    public class Driver
    {
        private World world = new World();
        private Dictionary<Projectile, List<Forces.Force>> forces = new Dictionary<Projectile, List<Forces.Force>>();
        private double dragConst = 0.5;
        private double gravAccel = -9.8;
        private double springConst = 8;

        private Forces.Force fAir;
        private Forces.Force fGrav;
        private Forces.Force fSpring;
        public Driver() 
        {
            fAir = new Forces.AirResistance(dragConst);
            fGrav = new Forces.Gravity(gravAccel);
            fSpring = new Forces.Spring(springConst);
        }
        public static void Main(String[] args)
        {
            Driver driver = new Driver();
            //driver.LevelI();
            //driver.LevelII();
            driver.LevelIII();
        }
        public void LevelI() 
        {
            double angle = 45 * Math.PI/180;//convert to Radians
            double velocity = 5;
            var projectileOne = new Projectile(4, new Vector(0, 0, 0), new Vector(Math.Cos(angle) * velocity, 0, Math.Sin(angle) * velocity));
            world.SetProjectiles(projectileOne);
            world.setForces(projectileOne, new List<Forces.Force> { fGrav });
            world.Simulate(2, 0.01);
        }
        public void LevelII()
        {
            double angle = 45 * Math.PI / 180;//convert to Radians
            double velocity = 5;
            var projectileTwo = new Projectile(4, new Vector(0, 0, 0), new Vector(Math.Cos(angle) * velocity, 0, Math.Sin(angle) * velocity));
            world.SetProjectiles(projectileTwo);
            world.setForces(projectileTwo, new List<Forces.Force> { fGrav, fAir });
            world.Simulate(20, 0.001);
        }
        public void LevelIII()
        {
            var projectileThree = new Projectile(4, new Vector(-1, 1, -1), new Vector(5, -1, 3));
            world.SetProjectiles(projectileThree);
            world.setForces(projectileThree, new List<Forces.Force> { fGrav, fAir, fSpring });
            world.Simulate(20, 0.01);
        }
    }
}
