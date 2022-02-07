using Utility;

namespace Projectile_motion
{
    public class World
    {
        public double Time { get; set; } = new();
        public List<Projectile> Projectiles { get; } = new();
        private Dictionary<Projectile, List<Forces.Force>> ProjForces = new();
        private Dictionary<Projectile, Vector> ProjForceNet = new();

        public World()
        {
            Projectiles = new List<Projectile>();
            Time = 0;
        }
        public void SetProjectiles(Projectile proj)
        {
            Projectiles.Add(proj);
        }
        
        public void setForces(Projectile proj, List<Forces.Force> forces)
        { 
            ProjForces.Add(proj, forces);
        }
        public void updateForcetoVector()
        {
            Vector forceNet = new(0, 0, 0);
            foreach (Projectile proj in Projectiles)
            {
                foreach (Forces.Force f in ProjForces[proj])
                {
                    forceNet += f.CreateForce(proj);
                }
                ProjForceNet[proj] = forceNet;
                forceNet = new(0, 0, 0);
            }
        }
        public void IncrementWorld(double deltaTime)
        {
            updateForcetoVector();
            foreach(Projectile proj in Projectiles)
            {
                Vector forceNet = ProjForceNet[proj];
                proj.UpdatePos(deltaTime,forceNet);
            }
            Time += deltaTime;
        }
        public void Simulate(double totalTime, double deltaTime)
        {
            while (Time < totalTime)
            {
                IncrementWorld(deltaTime);
                foreach (Projectile proj in Projectiles)
                {
                    Console.WriteLine($"Time: {Math.Round(Time, 3)}\t Displacement: {Math.Round(proj.Position.Magnitude, 3)}\t Speed: {Math.Round(proj.Velocity.Magnitude, 3)}\t Magnitude of Accel: {Math.Round(proj.Acceleration.Magnitude, 3)}\t Position: {proj.Position.ToString()}\t Velocity: {proj.Velocity.ToString()}\t Acceleration: {proj.Acceleration.ToString()}");
                }
            }
        }
    }
}
