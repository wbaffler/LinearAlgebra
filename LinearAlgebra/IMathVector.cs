using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace LinearAlgebra
{
	/// <summary>
	/// Math Vector.
	/// </summary>
	public interface IMathVector : IEnumerable
	{
		/// <summary>
		/// Gets vector demension.
		/// </summary>
		int Dimensions { get; }

		/// <summary>
		/// Gets and sets vector element with index. Index stars from zero.
		/// </summary>
		/// <param name="vector">Input vector.</param>
		/// <exception cref="Exception">
		/// Throws exception when index less tham 0 or more than dimsion.
		/// </exception>
		double this[int i] { get; set; }

		/// <summary>Gets vector length.</summary>
		double Length { get; }

		/// <summary>
		/// Sums a vector and a number.
		/// </summary>
		/// <param name="number">Input number.</param>
		/// <returns>
		/// New math vector that is sum of input vector and a number.
		/// </returns>
		IMathVector SumNumber(double number);

		/// <summary>
		/// Make componentwise vector multiplication by a number.
		/// </summary>
		/// <param name="number">Input number.</param>
		/// <returns>
		/// New math vector that is product of input vector and a number.
		/// </returns>
		IMathVector MultiplyNumber(double number);

		/// <summary>
		/// Sums two vectors.
		/// </summary>
		/// <param name="vector">Input vector.</param>
		/// <returns>
		/// New math vector that is sum of two input vectors.
		/// </returns>
		/// <exception cref="Exception">
		/// Throws exception when vectors have different dimensions.
		/// </exception>
		IMathVector Sum(IMathVector vector);

		/// <summary>
		/// Make componentwise vector multiplication by an another vector.
		/// </summary>
		/// <param name="vector">Input vector.</param>
		/// <returns>
		/// New math vector that is product of two input vectors.
		/// </returns>
		/// <exception cref="Exception">
		/// Throws exception when vectors have different dimensions.
		/// </exception>
		IMathVector Multiply(IMathVector vector);

		/// <summary>
		/// Make vector scalar multiplication by an another vector.
		/// </summary>
		/// <param name="vector">Input vector.</param>
		/// <returns>
		/// New math vector that is scalar product of vectors.
		/// </returns>
		/// <exception cref="DivideByZeroException">
		/// Throws exception when vectors have different dimensions.
		/// </exception>
		double ScalarMultiply(IMathVector vector);


		/// <summary>
		/// Calculate Euclidean distance to another vector.
		/// </summary>
		/// <param name="vector">Input vector.</param>
		/// <returns>
		/// Number that is Euclidean distance between vectors.
		/// </returns>
		/// <exception cref="Exception">
		/// Throws exception when vectors have different dimensions.
		/// </exception>
		double CalcDistance(IMathVector vector);

	}
}
