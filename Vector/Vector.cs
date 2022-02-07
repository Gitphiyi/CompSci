namespace Utility
{
    public struct Vector : IEquatable<Vector>
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }


        public Vector(double x, double y, double z)
        {
            if (Double.IsNaN(x) || Double.IsNaN(y) || Double.IsNaN(z))
            {
                throw new ArgumentException("Invanlid value: NaN");
            }
            else
            { 
                X = (double)x;
                Y = (double)y;
                Z = (double)z;
            }
        }

        public static Vector operator +(Vector v1, Vector v2)
        {
            Vector newVector = new Vector(
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
        public static Vector operator /(Vector v1, double scalar)
        {
            if (scalar == 0)
            {
                throw new ArgumentException("Vector attempted to divide by zero!");
            }
            else 
            {
                return (1 / scalar) * v1;
            }
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
        public static double DotProduct(Vector v1, Vector v2)
        {
            return v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;
        }

        public static bool operator ==(Vector v1, Vector v2)
        {
            if (v1.X == v2.X && v1.Y == v2.Y && v1.Z == v2.Z) { return true; }
            else { return false; }
        }
        public static bool operator !=(Vector v1, Vector v2)
        {
            if (v1.X != v2.X && v1.Y == v2.Y && v1.Z == v2.Z) { return true; }
            else { return false; }
        }
        public static Vector NormalizeVector(Vector v1) 
        {
            return new Vector(v1.X, v1.Y , v1.Z) / v1.Magnitude;
        }

        override public String ToString()
        {
            return $"<{Math.Round(X,3)},{Math.Round(Y,3)},{Math.Round(Z,3)}>";
        }

        public override bool Equals(object? obj)
        {
            return obj is Vector vector && Equals(vector);
        }

        public bool Equals(Vector other)
        {
            return X == other.X &&
                   Y == other.Y &&
                   Z == other.Z;
        }
        public static double Distance (Vector v1, Vector v2)
        {
            return  (v2 - v1).Magnitude;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y, Z);
        }

    }
}