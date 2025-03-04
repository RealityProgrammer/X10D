using System.Diagnostics.Contracts;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;
using X10D.CompilerServices;

namespace X10D.Reflection;

/// <summary>
///     Extension methods for <see cref="MemberInfo" />.
/// </summary>
public static class MemberInfoExtensions
{
    /// <summary>
    ///     Returns a value indicating whether or not the current member has been decorated with a specified attribute.
    /// </summary>
    /// <param name="member">The member attributes to check.</param>
    /// <typeparam name="T">The attribute type.</typeparam>
    /// <returns>
    ///     <see langword="true" /> if the current member has been decorated with a specified attribute, or
    ///     <see langword="false" /> otherwise.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="member" /> is <see langword="null" />.</exception>
    [Pure]
    [MethodImpl(CompilerResources.MaxOptimization)]
    public static bool HasCustomAttribute<T>(this MemberInfo member)
        where T : Attribute
    {
        if (member is null)
        {
            throw new ArgumentNullException(nameof(member));
        }

        return Attribute.IsDefined(member, typeof(T));
    }

    /// <summary>
    ///     Returns a value indicating whether or not the current member has been decorated with a specified attribute.
    /// </summary>
    /// <param name="member">The member attributes to check.</param>
    /// <param name="attribute">The attribute type.</param>
    /// <returns>
    ///     <see langword="true" /> if the current member has been decorated with a specified attribute, or
    ///     <see langword="false" /> otherwise.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="member" /> is <see langword="null" />.</exception>
    [Pure]
    [MethodImpl(CompilerResources.MaxOptimization)]
    public static bool HasCustomAttribute(this MemberInfo member, Type attribute)
    {
        if (member is null)
        {
            throw new ArgumentNullException(nameof(member));
        }

        if (attribute is null)
        {
            throw new ArgumentNullException(nameof(attribute));
        }

        if (!attribute.Inherits<Attribute>())
        {
            throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, ExceptionMessages.TypeDoesNotInheritAttribute,
                attribute, typeof(Attribute)), nameof(attribute));
        }

        return Attribute.IsDefined(member, attribute);
    }

    /// <summary>
    ///     Retrieves a custom attribute that is decorated by the current member, and projects it into to a new form.
    /// </summary>
    /// <typeparam name="TAttribute">The attribute type.</typeparam>
    /// <typeparam name="TReturn">The return type of the <paramref name="selector" /> delegate.</typeparam>
    /// <param name="member">The member.</param>
    /// <param name="selector">A transform function to apply to the attribute.</param>
    /// <returns>
    ///     An instance of <typeparamref name="TReturn" /> as provided from <paramref name="selector" />.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="member" /> is <see langword="null" />
    ///     -or-
    ///     <paramref name="selector" /> is <see langword="null" />.
    /// </exception>
    public static TReturn? SelectFromCustomAttribute<TAttribute, TReturn>(this MemberInfo member,
        Func<TAttribute, TReturn> selector)
        where TAttribute : Attribute
    {
        if (member is null)
        {
            throw new ArgumentNullException(nameof(member));
        }

        if (selector is null)
        {
            throw new ArgumentNullException(nameof(selector));
        }

        return member.SelectFromCustomAttribute(selector, default);
    }

    /// <summary>
    ///     Retrieves a custom attribute that is decorated by the current member, and projects it into to a new form.
    /// </summary>
    /// <typeparam name="TAttribute">The attribute type.</typeparam>
    /// <typeparam name="TReturn">The return type of the <paramref name="selector" /> delegate.</typeparam>
    /// <param name="member">The member.</param>
    /// <param name="selector">A transform function to apply to the attribute.</param>
    /// <param name="defaultValue">The default value to return when the specified attribute is not found.</param>
    /// <returns>
    ///     An instance of <typeparamref name="TReturn" /> as provided from <paramref name="selector" />.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="member" /> is <see langword="null" />
    ///     -or-
    ///     <paramref name="selector" /> is <see langword="null" />.
    /// </exception>
    public static TReturn? SelectFromCustomAttribute<TAttribute, TReturn>(this MemberInfo member,
        Func<TAttribute, TReturn> selector, TReturn? defaultValue)
        where TAttribute : Attribute
    {
        if (member is null)
        {
            throw new ArgumentNullException(nameof(member));
        }

        if (selector is null)
        {
            throw new ArgumentNullException(nameof(selector));
        }

        return member.GetCustomAttribute<TAttribute>() is { } attribute
            ? selector(attribute)
            : defaultValue;
    }
}
