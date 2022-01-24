// See https://aka.ms/new-console-template for more information

namespace Kinematics
{
    class project 
    {
        static void Main(string[] args)
        {
            double Velocity = 5;
            double Displacement = 1;//set to 1 for the challenge, set to 0 for normal parts
            double Time = 0;
            double ForceAir = -0.5 * Velocity*Velocity;//this models air resistance. the 4 is the mass and 0.5 is the coefficient.
            double SpringDisplacement = Displacement - 2;
            double ForceSpring = -8*SpringDisplacement;
            double ForceGrav = -9.8 * 4;
            double ForceNet = ForceAir + ForceSpring + ForceGrav;
            double Acceleration = ForceNet/4;


            Console.WriteLine("Time (s)\t Position(m)\t Velocity(m/s)\t Acceleration(m/s^2)");//This simply displays initial condition when t = 0
            Console.WriteLine(Time + "\t\t" + Displacement + "\t\t" + Velocity + "\t\t" + Math.Round(Acceleration, 2));
            for (int i = 1; i <= 1000; i++)
            {
                Time = Math.Round(i * 0.1,1);//updates the time to be right because the time goes by 0.1 and not 1. Rounded because there was a funky error with a 1 in the hundred thousandth place for some reason
                Displacement = Displacement + Velocity * 0.1;//Iterating by doing the d = initiald + v*t
                Velocity = Velocity + Acceleration * 0.1;//v=at so it is iterating as well
                if (Velocity > 0)
                {   
                    ForceAir = (-0.5 * Velocity * Velocity);
                }//if the object is going up the air resistance goes down
                else 
                {
                    ForceAir = (0.5 * Velocity * Velocity);
                }//if the object is going down the air resistance goes up

                if (Displacement > 0)
                {
                    SpringDisplacement = Displacement - 2;
                }
                else 
                {
                    SpringDisplacement = Displacement + 2;
                }
                ForceSpring = -8 * SpringDisplacement;//Direct application of Hooks spring law
                ForceNet = ForceAir + ForceSpring + ForceGrav;//Adds the Force of both things to bring a force net excluding gravity
                Acceleration = ForceNet / 4;//This uses force net and adds onto the gravity already. Gravity could be included already in force net but it is easier this way

                Console.WriteLine(Time + "\t\t" + Math.Round(Displacement,2) + "\t\t" + Math.Round(Velocity,2)+"\t\t"+Math.Round(Acceleration,2));//prints the format out
            }
        }
    }
}
