using System;
using System.Collections;

namespace LinearAlgebra
{
	/// <inheritdoc cref="IMathVector"/>
	public class MathVector : IMathVector 
	{
		private double[] coord;
		public IEnumerator GetEnumerator()
		{
			throw new NotImplementedException();
		}

		public MathVector(int num)
        {
			if (num < 0)
            {
				throw new Exception("Incorrect array length");
			}
			Dimensions = num;
			coord = new double [num];
			for (int i=0; i<Dimensions; i++)
            {
				coord[i] = 0;
            }
        }
		public int Dimensions { get; }
		
		public double this[int i] 
		{
			get 
			{
				if (i < Dimensions && i > -1)
                {
					return coord[i];
				}
				else
                {
					throw new Exception("Incorrect array index");
                }
				
			}
			set 
			{

				if (i < Dimensions && i > -1)
				{
					coord[i] = value;
				}
				else
				{
					throw new Exception("Incorrect array index");
				}
				
			} 
		}

		public double Length 
		{
			get
			{
				double sum = 0;
				for (int i=0; i<Dimensions; i++)
                {
					sum += Math.Pow(this[i], 2);
                }
				
				return Math.Sqrt(sum);
			}

		}

		public IMathVector SumNumber(double number)
        {
			IMathVector vect = new MathVector(Dimensions);
			for (int i=0; i<Dimensions; i++)
            {
				vect[i] = this[i] + number;
            }			
			return vect;
        }

		public IMathVector MultiplyNumber(double number)
        {
			IMathVector vect = new MathVector(Dimensions);
			for (int i = 0; i < Dimensions; i++)
			{
				vect[i] = this[i] * number;
			}

			return vect;
		}

		public IMathVector Sum(IMathVector vector)
        {
			if (this.Dimensions != vector.Dimensions)
			{
				throw new Exception("Vectors have different dimensions");
			}
			else
			{
				IMathVector vect = new MathVector(Dimensions);
				for (int i = 0; i < Dimensions; i++)
				{
					vect[i] = this[i] + vector[i];
				}

				return vect;
			}
		}

		public IMathVector Multiply(IMathVector vector)
        {
			if (this.Dimensions != vector.Dimensions)
			{
				throw new Exception("Vectors have different dimensions");
			}
			else
			{
				IMathVector vect = new MathVector(Dimensions);
				for (int i = 0; i < Dimensions; i++)
				{
					vect[i] = this[i] * vector[i];
				}

				return vect;
			}
		}

		public double ScalarMultiply(IMathVector vector)
        {
			if (this.Dimensions != vector.Dimensions)
			{
				throw new Exception("Vectors have different dimensions");
			}
			else
			{
				double sum = 0;
				for (int i = 0; i < Dimensions; i++)
				{
					sum += this[i] * vector[i];
				}
				return sum;
			}
		}

		public double CalcDistance(IMathVector vector)
        {
			if (this.Dimensions != vector.Dimensions)
			{
				throw new Exception("Vectors have different dimensions");
			}
			else
			{
				double sum = 0;
				for (int i = 0; i < Dimensions; i++)
				{
					sum += Math.Pow(this[i] - vector[i], 2);
				}

				return Math.Sqrt(sum);
			}
		}

		/// <summary>
		/// Sums two vectors.
		/// </summary>
		/// <param name="v1">Input vector 1.</param>
		/// <param name="v2">Input vector 2.</param>
		/// <returns>
		/// New math vector that is sum of two input vectors.
		/// </returns>
		/// <exception cref="Exception">
		/// Throws exception when vectors have different dimensions.
		/// </exception>
		public static IMathVector operator +(MathVector v1, MathVector v2)
		{
			return v1.Sum(v2);
		}

		/// <summary>
		/// Sums a vector and a number.
		/// </summary>
		/// <param name="num">Input number.</param>
		/// <param name="v1">Input vector.</param>
		/// <returns>
		/// New math vector that is sum of input vector and a number.
		/// </returns>
		public static IMathVector operator +(MathVector v1, double num)
		{
			return v1.SumNumber(num);
		}

		/// <summary>
		/// Subtracts two vectors.
		/// </summary>
		/// <param name="num">Input vector 1.</param>
		/// <param name="v1">Input vector 2.</param>
		/// <returns>
		/// New math vector that is subtract of two input vectors.
		/// </returns>
		/// <exception cref="Exception">
		/// Throws exception when vectors have different dimensions.
		/// </exception>
		public static IMathVector operator -(MathVector v1, MathVector v2)
		{
			
			if (v1.Dimensions != v2.Dimensions)
			{
				throw new Exception("Vectors have different dimensions");
			}
			else
			{
				IMathVector tempVector = new MathVector(v1.Dimensions);
				for (int i = 0; i < v1.Dimensions; i++)
				{
					tempVector[i] = (-1)*v2[i];
				}
				return v1.Sum(tempVector);
			}
		}

		/// <summary>
		/// Subtracts a vector and a number.
		/// </summary>
		/// <param name="num">Input number.</param>
		/// <param name="v1">Input vector.</param>
		/// <returns>
		/// New math vector that is subtract of input vector and a number.
		/// </returns>
		public static IMathVector operator -(MathVector v1, double num)
		{
			return v1.SumNumber(-num);
		}

		/// <summary>
		/// Make componentwise vector multiplication by an another vector.
		/// </summary>
		/// <param name="v1">Input vector 1.</param>
		/// <param name="v2">Input vector 2.</param>
		/// <returns>
		/// New math vector that is product of two input vectors.
		/// </returns>
		/// <exception cref="Exception">
		/// Throws exception when vectors have different dimensions.
		/// </exception>
		public static IMathVector operator *(MathVector v1, MathVector v2)
		{
			return v1.Multiply(v2);
		}

		/// <summary>
		/// Make componentwise vector multiplication by a number.
		/// </summary>
		/// <param name="number">Input number.</param>
		/// <param name="v1">Input vector.</param>
		/// <returns>
		/// New math vector that is product of input vector and a number.
		/// </returns>
		public static IMathVector operator *(MathVector v1, double num)
		{
			return v1.MultiplyNumber(num);
		}

		/// <summary>
		/// Make vector componentwise division by an another vector.
		/// </summary>
		/// <param name="v1">Input vector 1.</param>
		/// <param name="v2">Input vector 2.</param>
		/// <returns>
		/// New math vector that is componentwise quotient of vectors.
		/// </returns>
		/// <exception cref="Exception">
		/// Throws exception when vectors have different dimensions or element of vector 2 is 0 (Divide by 0).
		/// </exception>
		public static IMathVector operator /(MathVector v1, MathVector v2)
		{
			if (v1.Dimensions != v2.Dimensions)
			{
				throw new Exception("Vectors have different dimensions");
			}
			else
			{
				IMathVector tempVector = new MathVector(v1.Dimensions);
				for (int i = 0; i < v1.Dimensions; i++)
				{
					if (v2[i] == 0)
					{
						throw new Exception("Division by 0 is not possible");
					}
					else
						tempVector[i] = 1 / v2[i];
				}
				return v1.Multiply(tempVector);
			}
		}

		/// <summary>
		/// Make vector componentwise division by a number.
		/// </summary>
		/// <param name="v1">Input vector.</param>
		/// <param name="num">Input number.</param>
		/// <returns>
		/// New math vector that is componentwise quotient of vector and number.
		/// </returns>
		/// <exception cref="Exception">
		/// Throws exception when divide by zero.
		/// </exception>
		public static IMathVector operator /(MathVector v1, double num)
		{
			if (num == 0)
			{
				throw new Exception("Division by 0 is not possible");
			}
			else
			{
				return v1.MultiplyNumber(1 / num);
			}
		}

		/// <summary>
		/// Make vector scalar multiplication by an another vector.
		/// </summary>
		/// <param name="v1">Input vector 1.</param>
		/// <param name="v2">Input vector 2.</param>
		/// <returns>
		/// New math vector that is scalar product of vectors.
		/// </returns>
		/// <exception cref="Exception">
		/// Throws exception when vectors have different dimensions.
		/// </exception>
		public static double operator %(MathVector v1, MathVector v2)
		{
			return v1.ScalarMultiply(v2);
		}
	}


}
