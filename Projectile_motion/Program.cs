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
            //LevelI();
            LevelII();
            //LevelIII();
        }
        private static void LevelI()
        {
            double angle = 45;
            angle = angle * (Math.PI / 180);//converts to radians
            double velocity = 5;
            double velocityX = Math.Cos(angle) * velocity;
            double velocityZ = Math.Sin(angle) * velocity;
            CalculatePos(0,0,0,velocityX,0,velocityZ,0,0,0, false,false);
        }
        private static void LevelII()
        {
            double angle = 45;
            angle = angle * (Math.PI / 180);//converts to radians
            double velocity = 5;
            double velocityX = Math.Cos(angle) * velocity;
            double velocityZ = Math.Sin(angle) * velocity;
            CalculatePos(0, 0, 0, velocityX, 0, velocityZ, 0, 0, 0, false, true);
        }
        private static void LevelIII()
        {
            CalculatePos(-1, 1, -1, 5, -1, 3, 0, 0, 0, true, true);
        }
        private static void CalculatePos(double displacementX, double displacementY, double displacementZ, double velocityX, double velocityY, double velocityZ, double accelerationX, double accelerationY, double accelerationZ, Boolean spring, Boolean air)
        { 
            double distance = Math.Sqrt(displacementX * displacementX + displacementY * displacementY + displacementZ * displacementZ);
            double speed = Math.Sqrt(velocityX * velocityX + velocityY * velocityY + velocityZ * velocityZ);
            double m_Accel = 0;
            double time = 0;
            double fNetZ = 0;
            double fNetY = 0;
            double fNetX = 0;
            double Fgrav = gravAccel * mass;
            double FairX = 0;
            double FairY = 0;
            double FairZ = 0;
            double FspringX = 0;
            double FspringY = 0;
            double FspringZ = 0;
            if (air)
            {
                FairX = -dragConst * velocityX * speed;
                FairY = -dragConst * velocityY * speed;
                FairZ = -dragConst * velocityZ * speed;
            }
            if (distance != 0 && spring)
            {
                FspringX = -springConst * (1 - unstretchSpring / distance) * displacementX;
                FspringY = -springConst * (1 - unstretchSpring / distance) * displacementY;
                FspringZ = -springConst * (1 - unstretchSpring / distance) * displacementZ;
            }
            fNetZ = Fgrav + FairZ + FspringZ;
            fNetY = FairY + FspringY;
            fNetX = FairX + FspringX;
            accelerationX = fNetX / mass;
            accelerationY = fNetY / mass;
            accelerationZ = fNetZ / mass;

            Console.WriteLine("Time \t x \t y \t z \t distance \t velX \t velY \t velZ \t Speed \t \t accelX \t accelY \t accelZ \t Mass_Accel");
            while (displacementZ >= 0)//usually is displacementZ >= 0 but is time < 20 for part 3
            {
                distance = Math.Sqrt(displacementX*displacementX + displacementY*displacementY + displacementZ*displacementZ);
                speed = Math.Sqrt(velocityX*velocityX + velocityY*velocityY + velocityZ*velocityZ);
                m_Accel = Math.Sqrt(accelerationX*accelerationX + accelerationY*accelerationY + accelerationZ*accelerationZ);
                
                Console.WriteLine($"{Math.Round(time,3)} \t {Math.Round(displacementX,2)}\t{Math.Round(displacementY,2)}\t{Math.Round(displacementZ,2)}\t{Math.Round(distance,2)}\t{Math.Round(velocityX,2)}\t{Math.Round(velocityY,2)}\t{Math.Round(velocityZ,2)}\t{Math.Round(speed,2)}\t{Math.Round(accelerationX,2)}\t{Math.Round(accelerationY,2)}\t{Math.Round(accelerationZ,2)}\t{Math.Round(m_Accel,2)}");
                time += deltaTime;
                if(air)
                {
                    FairX = -dragConst * velocityX * speed;
                    FairY = -dragConst * velocityY * speed;
                    FairZ = -dragConst * velocityZ * speed;
                }
                if (spring)
                {
                    FspringX = -springConst * (1 - unstretchSpring / distance) * displacementX;
                    FspringY = -springConst * (1 - unstretchSpring / distance) * displacementY;
                    FspringZ = -springConst * (1 - unstretchSpring / distance) * displacementZ;
                }
                //depends if the situation wants to have spring force or air resistance
                fNetZ = Fgrav + FairZ + FspringZ;
                fNetY = FairY + FspringY;
                fNetX = FairX + FspringX;
                accelerationX = fNetX / mass;
                accelerationY = fNetY / mass;
                accelerationZ = fNetZ / mass;
                velocityX += accelerationX * deltaTime;
                velocityY += accelerationY * deltaTime;
                velocityZ += accelerationZ * deltaTime;
                displacementX += velocityX * deltaTime;
                displacementY += velocityY * deltaTime;
                displacementZ += velocityZ * deltaTime;
            }
        }
    }
}