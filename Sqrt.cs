using System;

public class Program
{
  public static void Main()
  {
    Console.WriteLine("{0}", Sqrt(2D));
  }

  static double Sqrt(double S)
  {
    double c, x, s;

    if(S <= 0D)
    {
      return (S == 0D)? +0D: -1D;
    }
    else
    {
      c = (S > 1D)? +1D: -1D;

      x = S; s = x * x - S; s = (2D * x * s)/(4D * S + 3D * s);

      while (x + c * s  > x)
      {
      x-= s; s = x * x - S; s = (2D * x  *s)/(4D  *S + 3D * s);
      }
      
      return x * 3D / 4D + (x / 4D - s);
    }
  }
}
