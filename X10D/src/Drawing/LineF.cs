using System.Drawing;
using System.Numerics;
using X10D.Numerics;

namespace X10D.Drawing;

/// <summary>
///     Represents a line in 2D space that is composed of single-precision floating-point X and Y coordinates.
/// </summary>
public readonly struct LineF : IEquatable<LineF>, IComparable<LineF>, IComparable
{
    /// <summary>
    ///     The empty line. That is, a line whose start and end points are at (0, 0).
    /// </summary>
    public static readonly LineF Empty = new();

    /// <summary>
    ///     The line whose start point is at (0, 0) and end point is at (1, 1).
    /// </summary>
    public static readonly LineF One = new(Vector2.Zero, new Vector2(1, 1));

    /// <summary>
    ///     The line whose start point is at (0, 0) and end point is at (1, 0).
    /// </summary>
    public static readonly LineF UnitX = new(Vector2.Zero, new Vector2(1, 0));

    /// <summary>
    ///     The line whose start point is at (0, 0) and end point is at (0, 1).
    /// </summary>
    public static readonly LineF UnitY = new(Vector2.Zero, new Vector2(0, 1));

    /// <summary>
    ///     Initializes a new instance of the <see cref="LineF" /> struct by taking the start and end points.
    /// </summary>
    /// <param name="start">The start point.</param>
    /// <param name="end">The end point.</param>
    public LineF(Vector2 start, Vector2 end)
        : this(start.ToPointF(), end.ToPointF())
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="LineF" /> struct by taking the start and end points.
    /// </summary>
    /// <param name="start">The start point.</param>
    /// <param name="end">The end point.</param>
    public LineF(PointF start, PointF end)
    {
        End = end;
        Start = start;
    }

    /// <summary>
    ///     Gets the end point of the line.
    /// </summary>
    /// <value>The end point.</value>
    public PointF End { get; }

    /// <summary>
    ///     Gets the length of this line.
    /// </summary>
    /// <value>The length.</value>
    public float Length
    {
        get => MathF.Sqrt(LengthSquared);
    }

    /// <summary>
    ///     Gets the length of this line, squared.
    /// </summary>
    /// <value>The squared length.</value>
    public float LengthSquared
    {
        get => MathF.Pow(End.X - Start.X, 2.0f) + MathF.Pow(End.Y - Start.Y, 2.0f);
    }

    /// <summary>
    ///     Gets the start point of the line.
    /// </summary>
    /// <value>The start point.</value>
    public PointF Start { get; }

    /// <summary>
    ///     Returns a value indicating whether two instances of <see cref="LineF" /> are equal.
    /// </summary>
    /// <param name="left">The first instance.</param>
    /// <param name="right">The second instance.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="left" /> and <paramref name="right" /> are considered equal; otherwise,
    ///     <see langword="false" />.
    /// </returns>
    public static bool operator ==(in LineF left, in LineF right)
    {
        return left.Equals(right);
    }

    /// <summary>
    ///     Returns a value indicating whether two instances of <see cref="LineF" /> are not equal.
    /// </summary>
    /// <param name="left">The first instance.</param>
    /// <param name="right">The second instance.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="left" /> and <paramref name="right" /> are considered not equal; otherwise,
    ///     <see langword="false" />.
    /// </returns>
    public static bool operator !=(in LineF left, in LineF right)
    {
        return !left.Equals(right);
    }

    /// <summary>
    ///     Returns a value indicating whether the length of one line is less than that of another.
    /// </summary>
    /// <param name="left">The first instance.</param>
    /// <param name="right">The second instance.</param>
    /// <returns>
    ///     <see langword="true" /> if the <see cref="Length" /> of <paramref name="left" /> is less than that of
    ///     <paramref name="right" />; otherwise, <see langword="false" />.
    /// </returns>
    public static bool operator <(in LineF left, in LineF right)
    {
        return left.CompareTo(right) < 0;
    }

    /// <summary>
    ///     Returns a value indicating whether the length of one line is greater than that of another.
    /// </summary>
    /// <param name="left">The first instance.</param>
    /// <param name="right">The second instance.</param>
    /// <returns>
    ///     <see langword="true" /> if the <see cref="Length" /> of <paramref name="left" /> is greater than that of
    ///     <paramref name="right" />; otherwise, <see langword="false" />.
    /// </returns>
    public static bool operator >(in LineF left, in LineF right)
    {
        return left.CompareTo(right) > 0;
    }

    /// <summary>
    ///     Returns a value indicating whether the length of one line is less than or equal to that of another.
    /// </summary>
    /// <param name="left">The first instance.</param>
    /// <param name="right">The second instance.</param>
    /// <returns>
    ///     <see langword="true" /> if the <see cref="Length" /> of <paramref name="left" /> is less than or equal to that of
    ///     <paramref name="right" />; otherwise, <see langword="false" />.
    /// </returns>
    public static bool operator <=(in LineF left, in LineF right)
    {
        return left.CompareTo(right) <= 0;
    }

    /// <summary>
    ///     Returns a value indicating whether the length of one line is greater than or equal to that of another.
    /// </summary>
    /// <param name="left">The first instance.</param>
    /// <param name="right">The second instance.</param>
    /// <returns>
    ///     <see langword="true" /> if the <see cref="Length" /> of <paramref name="left" /> is greater than or equal to that of
    ///     <paramref name="right" />; otherwise, <see langword="false" />.
    /// </returns>
    public static bool operator >=(in LineF left, in LineF right)
    {
        return left.CompareTo(right) >= 0;
    }

    /// <summary>
    ///     Implicitly converts a <see cref="Line" /> to a <see cref="LineF" />.
    /// </summary>
    /// <param name="line">The line to convert.</param>
    /// <returns>The converted line.</returns>
    public static implicit operator LineF(in Line line)
    {
        return FromLine(line);
    }

    /// <summary>
    ///     Explicitly converts a <see cref="Line3D" /> to a <see cref="LineF" />.
    /// </summary>
    /// <param name="line">The line to convert.</param>
    /// <returns>The converted line.</returns>
    public static explicit operator LineF(in Line3D line)
    {
        return FromLine3D(line);
    }

    /// <summary>
    ///     Converts a <see cref="Line" /> to a <see cref="LineF" />.
    /// </summary>
    /// <param name="line">The line to convert.</param>
    /// <returns>The converted line.</returns>
    public static LineF FromLine(in Line line)
    {
        return new LineF(line.Start, line.End);
    }

    /// <summary>
    ///     Converts a <see cref="Line3D" /> to a <see cref="LineF" />.
    /// </summary>
    /// <param name="line">The line to convert.</param>
    /// <returns>The converted line.</returns>
    public static LineF FromLine3D(in Line3D line)
    {
        Vector3 start = line.Start;
        Vector3 end = line.End;
        return new LineF(new PointF(start.X, start.Y), new PointF(end.X, end.Y));
    }

    /// <summary>
    ///     Compares this instance to another object.
    /// </summary>
    /// <param name="obj">The object with with which to compare</param>
    /// <returns>
    ///     A signed number indicating the relative values of this instance and <paramref name="obj"/>.
    ///
    ///     <list type="table">
    ///         <listheader>
    ///             <term>Return value</term>
    ///             <description>Meaning</description>
    ///         </listheader>
    ///
    ///         <item>
    ///             <term>Less than zero</term>
    ///             <description>
    ///                 The <see cref="Length" /> of this instance is less than that of <paramref name="obj" />.
    ///             </description>
    ///         </item>
    ///         <item>
    ///             <term>Zero</term>
    ///             <description>
    ///                 This instance is equal to <paramref name="obj" />, or the <see cref="Length" /> of both this instance
    ///                 and <paramref name="obj" /> are not a number (<see cref="float.NaN" />),
    ///                 <see cref="float.PositiveInfinity" />, or <see cref="float.NegativeInfinity" />.
    ///             </description>
    ///         </item>
    ///         <item>
    ///             <term>Greater than zero</term>
    ///             <description>
    ///                 The <see cref="Length" /> of this instance is greater than that of <paramref name="obj" />.
    ///             </description>
    ///         </item>
    ///     </list>
    /// </returns>
    /// <remarks>
    ///     Comparison internally measures the <see cref="LengthSquared" /> property to avoid calls to <see cref="MathF.Sqrt" />.
    /// <exception cref="ArgumentException"><paramref name="obj" /> is not an instance of <see cref="Line" />.</exception>
    /// </remarks>
    public int CompareTo(object? obj)
    {
        if (ReferenceEquals(null, obj))
        {
            return 1;
        }

        if (obj is not LineF other)
        {
            throw new ArgumentException(ExceptionMessages.ObjectIsNotAValidType);
        }

        return CompareTo(other);
    }

    /// <summary>
    ///     Compares this instance to another <see cref="Line" />.
    /// </summary>
    /// <param name="other"></param>
    /// <returns>
    ///     A signed number indicating the relative values of this instance and <paramref name="other" />.
    ///
    ///     <list type="table">
    ///         <listheader>
    ///             <term>Return value</term>
    ///             <description>Meaning</description>
    ///         </listheader>
    ///
    ///         <item>
    ///             <term>Less than zero</term>
    ///             <description>
    ///                 The <see cref="Length" /> of this instance is less than that of <paramref name="other" />.
    ///             </description>
    ///         </item>
    ///         <item>
    ///             <term>Zero</term>
    ///             <description>
    ///                 This instance is equal to <paramref name="other" />, or the <see cref="Length" /> of both this instance
    ///                 and <paramref name="other" /> are not a number (<see cref="float.NaN" />),
    ///                 <see cref="float.PositiveInfinity" />, or <see cref="float.NegativeInfinity" />.
    ///             </description>
    ///         </item>
    ///         <item>
    ///             <term>Greater than zero</term>
    ///             <description>
    ///                 The <see cref="Length" /> of this instance is greater than that of <paramref name="other" />.
    ///             </description>
    ///         </item>
    ///     </list>
    /// </returns>
    /// <remarks>
    ///     Comparison internally measures the <see cref="LengthSquared" /> property to avoid calls to <see cref="MathF.Sqrt" />.
    /// </remarks>
    public int CompareTo(LineF other)
    {
        return LengthSquared.CompareTo(other.LengthSquared);
    }

    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        return obj is LineF other && Equals(other);
    }

    /// <summary>
    ///     Returns a value indicating whether this instance and another instance are equal.
    /// </summary>
    /// <param name="other">The instance with which to compare.</param>
    /// <returns>
    ///     <see langword="true" /> if this instance and <paramref name="other" /> are considered equal; otherwise,
    ///     <see langword="false" />.
    /// </returns>
    public bool Equals(LineF other)
    {
        return End.Equals(other.End) && Start.Equals(other.Start);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        return HashCode.Combine(End, Start);
    }
}
