using System.Diagnostics.Contracts;
using System.Numerics;
using System.Runtime.CompilerServices;
using X10D.CompilerServices;
using X10D.Math;

namespace X10D.Numerics;

/// <summary>
///     Numeric-extensions for <see cref="Vector4" />.
/// </summary>
public static class Vector4Extensions
{
    /// <summary>
    ///     Deconstructs the current <see cref="Vector4" /> into its components.
    /// </summary>
    /// <param name="vector">The vector to deconstruct.</param>
    /// <param name="x">The X component value.</param>
    /// <param name="y">The Y component value.</param>
    /// <param name="z">The Z component value.</param>
    /// <param name="w">The W component value.</param>
    public static void Deconstruct(this Vector4 vector, out float x, out float y, out float z, out float w)
    {
        x = vector.X;
        y = vector.Y;
        z = vector.Z;
        w = vector.W;
    }

    /// <summary>
    ///     Rounds the components in the current <see cref="Vector4" /> to the nearest integer.
    /// </summary>
    /// <param name="vector">The vector whose components to round.</param>
    /// <returns>The rounded vector.</returns>
    [Pure]
    [MethodImpl(CompilerResources.MaxOptimization)]
    public static Vector4 Round(this Vector4 vector)
    {
        return vector.Round(1.0f);
    }

    /// <summary>
    ///     Rounds the components in the current <see cref="Vector4" /> to the nearest multiple of a specified number.
    /// </summary>
    /// <param name="vector">The vector whose components to round.</param>
    /// <param name="nearest">The nearest multiple to which the components should be rounded.</param>
    /// <returns>The rounded vector.</returns>
    [Pure]
    [MethodImpl(CompilerResources.MaxOptimization)]
    public static Vector4 Round(this Vector4 vector, float nearest)
    {
        float x = vector.X.Round(nearest);
        float y = vector.Y.Round(nearest);
        float z = vector.Z.Round(nearest);
        float w = vector.W.Round(nearest);
        return new Vector4(x, y, z, w);
    }

    /// <summary>
    ///     Returns a vector whose Y, Z, and W components are the same as the specified vector, and whose X component is a new
    ///     value.
    /// </summary>
    /// <param name="vector">The vector to copy.</param>
    /// <param name="x">The new X component value.</param>
    /// <returns>
    ///     A new instance of <see cref="Vector4" /> whose <see cref="Vector4.Y" />, <see cref="Vector4.Z" />, and
    ///     <see cref="Vector4.W" /> components are the same as that of <paramref name="vector" />, and whose
    ///     <see cref="Vector4.X" /> component is <paramref name="x" />.
    /// </returns>
    [Pure]
    [MethodImpl(CompilerResources.MaxOptimization)]
    public static Vector4 WithX(this Vector4 vector, float x)
    {
        return vector with {X = x};
    }

    /// <summary>
    ///     Returns a vector whose X, Z, and W components are the same as the specified vector, and whose Y component is a new
    ///     value.
    /// </summary>
    /// <param name="vector">The vector to copy.</param>
    /// <param name="y">The new Y component value.</param>
    /// <returns>
    ///     A new instance of <see cref="Vector4" /> whose <see cref="Vector4.X" />, <see cref="Vector4.Z" />, and
    ///     <see cref="Vector4.W" /> components are the same as that of <paramref name="vector" />, and whose
    ///     <see cref="Vector4.Y" /> component is <paramref name="y" />.
    /// </returns>
    [Pure]
    [MethodImpl(CompilerResources.MaxOptimization)]
    public static Vector4 WithY(this Vector4 vector, float y)
    {
        return vector with {Y = y};
    }

    /// <summary>
    ///     Returns a vector whose X, Y, and W components are the same as the specified vector, and whose Z component is a new
    ///     value.
    /// </summary>
    /// <param name="vector">The vector to copy.</param>
    /// <param name="z">The new Z component value.</param>
    /// <returns>
    ///     A new instance of <see cref="Vector4" /> whose <see cref="Vector4.X" />, <see cref="Vector4.Y" />, and
    ///     <see cref="Vector4.W" /> components are the same as that of <paramref name="vector" />, and whose
    ///     <see cref="Vector4.Z" /> component is <paramref name="z" />.
    /// </returns>
    [Pure]
    [MethodImpl(CompilerResources.MaxOptimization)]
    public static Vector4 WithZ(this Vector4 vector, float z)
    {
        return vector with {Z = z};
    }

    /// <summary>
    ///     Returns a vector whose X, Y, and Z components are the same as the specified vector, and whose W component is a new
    ///     value.
    /// </summary>
    /// <param name="vector">The vector to copy.</param>
    /// <param name="w">The new W component value.</param>
    /// <returns>
    ///     A new instance of <see cref="Vector4" /> whose <see cref="Vector4.X" />, <see cref="Vector4.Y" />, and
    ///     <see cref="Vector4.Z" /> components are the same as that of <paramref name="vector" />, and whose
    ///     <see cref="Vector4.W" /> component is <paramref name="w" />.
    /// </returns>
    [Pure]
    [MethodImpl(CompilerResources.MaxOptimization)]
    public static Vector4 WithW(this Vector4 vector, float w)
    {
        return vector with {W = w};
    }
}
