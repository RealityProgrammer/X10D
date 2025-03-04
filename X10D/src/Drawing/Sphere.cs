using System.Numerics;

namespace X10D.Drawing;

/// <summary>
///     Represents a sphere in 3D space, which uses single-precision floating-point numbers for its coordinates.
/// </summary>
public readonly struct Sphere : IEquatable<Sphere>, IComparable<Sphere>, IComparable
{
    /// <summary>
    ///     The empty sphere. That is, a sphere with a radius of zero.
    /// </summary>
    public static readonly Sphere Empty = new();

    /// <summary>
    ///     The unit sphere. That is, a sphere with a radius of 1.
    /// </summary>
    public static readonly Sphere Unit = new(0, 0, 0, 1f);

    /// <summary>
    ///     Initializes a new instance of the <see cref="Sphere" /> struct.
    /// </summary>
    /// <param name="centerX">The X coordinate of the center point.</param>
    /// <param name="centerY">The Y coordinate of the center point.</param>
    /// <param name="centerZ">The Z coordinate of the center point.</param>
    /// <param name="radius">The radius.</param>
    public Sphere(float centerX, float centerY, float centerZ, float radius)
        : this(new Vector3(centerX, centerY, centerZ), radius)
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="Sphere" /> struct.
    /// </summary>
    /// <param name="center">The center point.</param>
    /// <param name="radius">The radius.</param>
    public Sphere(Vector3 center, float radius)
    {
        Center = center;
        Radius = radius;
    }

    /// <summary>
    ///     Gets the center-point of the sphere.
    /// </summary>
    /// <value>The center point.</value>
    public Vector3 Center { get; }

    /// <summary>
    ///     Gets the circumference of the sphere.
    /// </summary>
    /// <value>The circumference of the sphere, calculated as <c>2πr</c>.</value>
    public float Circumference
    {
        get => 2 * MathF.PI * Radius;
    }

    /// <summary>
    ///     Gets the diameter of the sphere.
    /// </summary>
    /// <value>The diameter.</value>
    public float Diameter
    {
        get => Radius * 2;
    }

    /// <summary>
    ///     Gets the radius of the sphere.
    /// </summary>
    /// <value>The radius.</value>
    public float Radius { get; }

    /// <summary>
    ///     Gets the volume of this sphere.
    /// </summary>
    /// <value>The volume.</value>
    public float Volume
    {
        get => (4f / 3f) * MathF.PI * Radius * Radius * Radius;
    }

    /// <summary>
    ///     Returns a value indicating whether two instances of <see cref="Sphere" /> are equal.
    /// </summary>
    /// <param name="left">The first instance.</param>
    /// <param name="right">The second instance.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="left" /> and <paramref name="right" /> are considered equal; otherwise,
    ///     <see langword="false" />.
    /// </returns>
    public static bool operator ==(Sphere left, Sphere right)
    {
        return left.Equals(right);
    }

    /// <summary>
    ///     Returns a value indicating whether two instances of <see cref="Sphere" /> are not equal.
    /// </summary>
    /// <param name="left">The first instance.</param>
    /// <param name="right">The second instance.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="left" /> and <paramref name="right" /> are considered not equal; otherwise,
    ///     <see langword="false" />.
    /// </returns>
    public static bool operator !=(Sphere left, Sphere right)
    {
        return !left.Equals(right);
    }

    /// <summary>
    ///     Returns a value indicating whether the radius of one circle is less than that of another.
    /// </summary>
    /// <param name="left">The first instance.</param>
    /// <param name="right">The second instance.</param>
    /// <returns>
    ///     <see langword="true" /> if the <see cref="Radius" /> of <paramref name="left" /> is less than that of
    ///     <paramref name="right" />; otherwise, <see langword="false" />.
    /// </returns>
    public static bool operator <(Sphere left, Sphere right)
    {
        return left.CompareTo(right) < 0;
    }

    /// <summary>
    ///     Returns a value indicating whether the radius of one circle is greater than to that of another.
    /// </summary>
    /// <param name="left">The first instance.</param>
    /// <param name="right">The second instance.</param>
    /// <returns>
    ///     <see langword="true" /> if the <see cref="Radius" /> of <paramref name="left" /> is greater than that of
    ///     <paramref name="right" />; otherwise, <see langword="false" />.
    /// </returns>
    public static bool operator >(Sphere left, Sphere right)
    {
        return left.CompareTo(right) > 0;
    }

    /// <summary>
    ///     Returns a value indicating whether the radius of one circle is less than or equal to that of another.
    /// </summary>
    /// <param name="left">The first instance.</param>
    /// <param name="right">The second instance.</param>
    /// <returns>
    ///     <see langword="true" /> if the <see cref="Radius" /> of <paramref name="left" /> is less than or equal to that of
    ///     <paramref name="right" />; otherwise, <see langword="false" />.
    /// </returns>
    public static bool operator <=(Sphere left, Sphere right)
    {
        return left.CompareTo(right) <= 0;
    }

    /// <summary>
    ///     Returns a value indicating whether the radius of one circle is greater than or equal to that of another.
    /// </summary>
    /// <param name="left">The first instance.</param>
    /// <param name="right">The second instance.</param>
    /// <returns>
    ///     <see langword="true" /> if the <see cref="Radius" /> of <paramref name="left" /> is greater than or equal to that of
    ///     <paramref name="right" />; otherwise, <see langword="false" />.
    /// </returns>
    public static bool operator >=(Sphere left, Sphere right)
    {
        return left.CompareTo(right) >= 0;
    }

    /// <summary>
    ///     Compares this instance to another <see cref="Sphere" />.
    /// </summary>
    /// <param name="obj">The other object.</param>
    /// <returns>
    ///     A signed number indicating the relative values of this instance and <paramref name="obj" />.
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
    ///                 The <see cref="Radius" /> of this instance is less than that of <paramref name="obj" />.
    ///             </description>
    ///         </item>
    ///         <item>
    ///             <term>Zero</term>
    ///             <description>
    ///                 This instance is equal to <paramref name="obj" />, or the <see cref="Radius" /> of both this instance
    ///                 and <paramref name="obj" /> are not a number (<see cref="float.NaN" />),
    ///                 <see cref="float.PositiveInfinity" />, or <see cref="float.NegativeInfinity" />.
    ///             </description>
    ///         </item>
    ///         <item>
    ///             <term>Greater than zero</term>
    ///             <description>
    ///                 The <see cref="Radius" /> of this instance is greater than that of <paramref name="obj" />, or
    ///                 <paramref name="obj" /> is <see langword="null" />.
    ///             </description>
    ///         </item>
    ///     </list>
    /// </returns>
    /// <remarks>Comparison only takes into consideration the <see cref="Radius" />.</remarks>
    /// <exception cref="ArgumentException"><paramref name="obj" /> is not an instance of <see cref="Sphere" />.</exception>
    public int CompareTo(object? obj)
    {
        if (ReferenceEquals(null, obj))
        {
            return 1;
        }

        if (obj is not Sphere other)
        {
            throw new ArgumentException(ExceptionMessages.ObjectIsNotAValidType);
        }

        return CompareTo(other);
    }

    /// <summary>
    ///     Compares this instance to another <see cref="Sphere" />.
    /// </summary>
    /// <param name="other">The other sphere.</param>
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
    ///                 The <see cref="Radius" /> of this instance is less than that of <paramref name="other" />.
    ///             </description>
    ///         </item>
    ///         <item>
    ///             <term>Zero</term>
    ///             <description>
    ///                 This instance is equal to <paramref name="other" />, or the <see cref="Radius" /> of both this instance
    ///                 and <paramref name="other" /> are not a number (<see cref="float.NaN" />),
    ///                 <see cref="float.PositiveInfinity" />, or <see cref="float.NegativeInfinity" />.
    ///             </description>
    ///         </item>
    ///         <item>
    ///             <term>Greater than zero</term>
    ///             <description>
    ///                 The <see cref="Radius" /> of this instance is greater than that of <paramref name="other" />.
    ///             </description>
    ///         </item>
    ///     </list>
    /// </returns>
    /// <remarks>Comparison only takes into consideration the <see cref="Radius" />.</remarks>
    public int CompareTo(Sphere other)
    {
        return Radius.CompareTo(other.Radius);
    }

    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        return obj is Sphere other && Equals(other);
    }

    /// <summary>
    ///     Returns a value indicating whether this instance and another instance are equal.
    /// </summary>
    /// <param name="other">The instance with which to compare.</param>
    /// <returns>
    ///     <see langword="true" /> if this instance and <paramref name="other" /> are considered equal; otherwise,
    ///     <see langword="false" />.
    /// </returns>
    public bool Equals(Sphere other)
    {
        return Center.Equals(other.Center) && Radius.Equals(other.Radius);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        return HashCode.Combine(Center, Radius);
    }
}
