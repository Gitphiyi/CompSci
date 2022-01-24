namespace Utility
{
    public class Vector
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }


        public Vector(double x, double y, double z)
        {
            X = x;
            Y = y;
            z = z;
        }

        public static Vector operator +(Vector v1, Vector v2)
        {
            var newVector = new Vector(
            v1.X + v2.X,
            v1.Y + v2.Y,
            v1.Z + v2.Z
            );
            return newVector;
        }

        public static Vector operator *(Vector v1, double scalar)
        {
            return new Vector(
                v1.X * scalar,
                v1.Y * scalar,
                v1.Z * scalar
                );
        }

        public static Vector operator *(double scalar, Vector v1)
        {
            return v1 * scalar;
        }
        public static Vector operator -(Vector v1)
        {
            return -1 * v1;
        }
        public static Vector operator -(Vector v1, Vector v2)
        {
            return v1 + -v2;
        }
        public double Magnitude => Math.Sqrt(X * X + Y * Y + Z * Z);
        public double DotProduct(Vector v1, Vector v2)
        {
            return v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;
        }
        public static Boolean operator ==(Vector v1, Vector v2)
        {
            if (v1.X == v2.X && v1.Y == v2.Y && v1.Z == v2.Z) { return true; }
            else { return false; }
        }
        public static Boolean operator !=(Vector v1, Vector v2)
        {
            if (v1.X != v2.X && v1.Y == v2.Y && v1.Z == v2.Z) { return true; }
            else { return false; }
        }
        public static Vector normalizeVector(Vector v1) 
        {
            return new Vector(v1.X, v1.Y , v1.Z) * 1/v1.Magnitude;
        }
    }
}