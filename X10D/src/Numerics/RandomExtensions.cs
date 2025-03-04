using System.Numerics;
using X10D.Core;

#pragma warning disable CA5394

namespace X10D.Numerics;

/// <summary>
///     Extension methods for <see cref="System.Random" />.
/// </summary>
public static class RandomExtensions
{
    /// <summary>
    ///     Returns a randomly generated rotation as represented by a <see cref="Quaternion" />.
    /// </summary>
    /// <param name="random">The <see cref="System.Random" /> instance.</param>
    /// <returns>
    ///     A <see cref="Quaternion" /> constructed from 3 random single-precision floating point numbers representing the
    ///     yaw, pitch, and roll.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="random" /> is <see langword="null" />.</exception>
    public static Quaternion NextRotation(this Random random)
    {
        if (random is null)
        {
            throw new ArgumentNullException(nameof(random));
        }

        int seed = random.Next();
        var seededRandom = new Random(seed);

        float x = seededRandom.NextSingle(0, 360);
        float y = seededRandom.NextSingle(0, 360);
        float z = seededRandom.NextSingle(0, 360);

        return Quaternion.CreateFromYawPitchRoll(y, x, z);
    }

    /// <summary>
    ///     Returns a randomly generated rotation with uniform distribution.
    /// </summary>
    /// <param name="random">The <see cref="System.Random" /> instance.</param>
    /// <returns>A <see cref="Quaternion" /> constructed with uniform distribution.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="random" /> is <see langword="null" />.</exception>
    public static Quaternion NextRotationUniform(this Random random)
    {
        if (random is null)
        {
            throw new ArgumentNullException(nameof(random));
        }

        int seed = random.Next();
        var seededRandom = new Random(seed);
        float normal, w, x, y, z;

        do
        {
            w = seededRandom.NextSingle(-1f, 1f);
            x = seededRandom.NextSingle(-1f, 1f);
            y = seededRandom.NextSingle(-1f, 1f);
            z = seededRandom.NextSingle(-1f, 1f);
            normal = (w * w) + (x * x) + (y * y) + (z * z);
        } while (normal is 0f or > 1f);

        normal = MathF.Sqrt(normal);
        return new Quaternion(x / normal, y / normal, z / normal, w / normal);
    }

    /// <summary>
    ///     Returns a <see cref="Vector2" /> with magnitude 1 whose components indicate a random point on the unit circle.
    /// </summary>
    /// <param name="random">The <see cref="System.Random" /> instance</param>
    /// <returns>
    ///     A <see cref="Vector2" /> whose <see cref="Vector2.Length()" /> returns 1, and whose components indicate a random
    ///     point on the unit circle.
    /// </returns>
    public static Vector2 NextUnitVector2(this Random random)
    {
        if (random is null)
        {
            throw new ArgumentNullException(nameof(random));
        }

        // no need to construct a seeded random here, since we only call Next once

        float angle = random.NextSingle(0, MathF.PI * 2.0f);
        float x = MathF.Cos(angle);
        float y = MathF.Sin(angle);

        return new Vector2(x, y);
    }

    /// <summary>
    ///     Returns a <see cref="Vector3" /> with magnitude 1 whose components indicate a random point on the unit sphere.
    /// </summary>
    /// <param name="random">The <see cref="System.Random" /> instance</param>
    /// <returns>
    ///     A <see cref="Vector3" /> whose <see cref="Vector3.Length()" /> returns 1, and whose components indicate a random
    ///     point on the unit sphere.
    /// </returns>
    public static Vector3 NextUnitVector3(this Random random)
    {
        if (random is null)
        {
            throw new ArgumentNullException(nameof(random));
        }

        int seed = random.Next();
        var seededRandom = new Random(seed);

        float angle = seededRandom.NextSingle(0, MathF.PI * 2.0f);
        float z = seededRandom.NextSingle(-1, 1);
        float mp = MathF.Sqrt(1 - (z * z));
        float x = mp * MathF.Cos(angle);
        float y = mp * MathF.Sin(angle);

        return new Vector3(x, y, z);
    }
}
