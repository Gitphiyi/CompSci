// See https://aka.ms/new-console-template for more information
using Utility;
namespace Kinematics3D
{
    class project
    {
        private const double mass = 4;//in kg
        private const double springConst = 8;
        private const double unstretchSpring = 2;//unstretched length of spring
        private const double dragConst = 0.5;
        private const double gravAccel = -9.8;
        private const double deltaTime = 0.01;
        static void Main(string[] args)
        {
            double v = (double) 5 / 3;
            Console.WriteLine(v);
            //LevelI();
            //LevelII();
            //LevelIII();
        }
        private static void LevelI()
        {
            double angle = 45;
            angle = angle * (Math.PI / 180);//converts to radians
            double velocity = 5;
            double velocityX = Math.Cos(angle) * velocity;
            double velocityZ = Math.Sin(angle) * velocity;
            CalculatePos(new Vector(0,0,0), new Vector(velocityX,0,velocityZ),new Vector(0,0,0), false,false);
        }
        private static void LevelII()
        {
            double angle = 45;
            angle = angle * (Math.PI / 180);//converts to radians
            double velocity = 5;
            double velocityX = Math.Cos(angle) * velocity;
            double velocityZ = Math.Sin(angle) * velocity;
            CalculatePos(new Vector(0,0,0), new Vector(velocityX,0,velocityZ), new Vector(0,0,0), false, true);
        }
        private static void LevelIII()
        {
            CalculatePos(new Vector(-1,1,-1), new Vector(5,-1,3), new Vector(0,0,0), true, true);
        }
        private static void CalculatePos(Vector displacement, Vector velocity, Vector acceleration, Boolean spring, Boolean air)
        { 
            double distance = displacement.Magnitude;
            double speed = velocity.Magnitude;
            double m_Accel = acceleration.Magnitude;
            double time = 0;
            Vector forceNet = new (0,0,0);
            Vector forceAir = new (0,0,0);
            Vector forceGrav = new (0, 0, gravAccel * mass);
            Vector forceSpring = new(0,0,0);

            Console.WriteLine("Time \t x \t y \t z \t distance \t velX \t velY \t velZ \t Speed \t \t accelX \t accelY \t accelZ \t Mass_Accel");
            while (displacement.Z >= 0)//usually is displacement.Z >= 0 but is time < 20 for part 3
            {
                distance = displacement.Magnitude;
                speed = velocity.Magnitude;
                m_Accel = acceleration.Magnitude;

                Console.WriteLine($"{Math.Round(time,3)} \t {Math.Round(displacement.X,2)}\t{Math.Round(displacement.Y,2)}\t{Math.Round(displacement.Z,2)}\t{Math.Round(distance,2)}\t{Math.Round(velocity.X,2)}\t{Math.Round(velocity.Y,2)}\t{Math.Round(velocity.Z,2)}\t{Math.Round(speed,2)}\t{Math.Round(acceleration.X,2)}\t{Math.Round(acceleration.Y,2)}\t{Math.Round(acceleration.Z,2)}\t{Math.Round(m_Accel,2)}");
                time += deltaTime;
                if (air)
                {
                    forceAir = -dragConst * speed * velocity;
                }
                if (distance != 0 && spring)
                {
                    forceSpring = -springConst * displacement;
                }
                //depends if the situation wants to have spring force or air resistance
                forceNet = forceGrav + forceAir + forceSpring;
                acceleration = forceNet / mass;
                velocity += acceleration * deltaTime;
                displacement += velocity * deltaTime;
            }
        }
    }
}