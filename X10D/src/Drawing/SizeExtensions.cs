using System.Diagnostics.Contracts;
using System.Drawing;
using System.Numerics;
using System.Runtime.CompilerServices;
using X10D.CompilerServices;

namespace X10D.Drawing;

/// <summary>
///     Drawing-related extension methods for <see cref="Size" />.
/// </summary>
public static class SizeExtensions
{
    /// <summary>
    ///     Converts the current <see cref="Size" /> to a <see cref="Point" />.
    /// </summary>
    /// <param name="size">The size to convert.</param>
    /// <returns>The resulting <see cref="Point" />.</returns>
    [Pure]
    [MethodImpl(CompilerResources.MaxOptimization)]
    public static Point ToPoint(this Size size)
    {
        return new Point(size.Width, size.Height);
    }

    /// <summary>
    ///     Converts the current <see cref="Size" /> to a <see cref="PointF" />.
    /// </summary>
    /// <param name="size">The size to convert.</param>
    /// <returns>The resulting <see cref="PointF" />.</returns>
    [Pure]
    [MethodImpl(CompilerResources.MaxOptimization)]
    public static PointF ToPointF(this Size size)
    {
        return new PointF(size.Width, size.Height);
    }

    /// <summary>
    ///     Converts the current <see cref="Size" /> to a <see cref="Vector2" />.
    /// </summary>
    /// <param name="size">The size to convert.</param>
    /// <returns>The resulting <see cref="Vector2" />.</returns>
    [Pure]
    [MethodImpl(CompilerResources.MaxOptimization)]
    public static Vector2 ToVector2(this Size size)
    {
        return new Vector2(size.Width, size.Height);
    }
}
