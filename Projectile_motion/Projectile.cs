using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace Projectile_motion
{
    public class Projectile
    {
        //private double Mass;
        //private Vector Position;
        //private Vector Velocity;
        //private Vector Acceleration;
        public double Mass { get; set; }
        public Vector Position { get; set; }
        public Vector Velocity { get; set; }
        public Vector Acceleration { get; set; }
        public Projectile(double mass, Vector position, Vector velocity)
        { 
            this.Mass = mass;
            Position = position;
            Velocity = velocity;
        }
        public void UpdatePos(double deltaTime, Vector force)
        {
            Acceleration = force / Mass;
            Velocity += Acceleration * deltaTime;
            Position += Velocity * deltaTime;
        }
    }
}
