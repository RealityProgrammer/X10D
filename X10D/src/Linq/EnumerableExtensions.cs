using System.Runtime.InteropServices;

namespace X10D.Linq;

/// <summary>
///     LINQ-inspired extension methods for <see cref="IEnumerable{T}" />.
/// </summary>
public static class EnumerableExtensions
{
    /// <summary>
    ///     Filters a sequence of values by omitting elements that match a specified value.
    /// </summary>
    /// <param name="source">An <see cref="IEnumerable{T}" /> to filter.</param>
    /// <param name="item">The value to omit.</param>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
    /// <returns>
    ///     An <see cref="IEnumerable{T}" /> that contains elements from the input sequence that do not match the specified
    ///     value.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="source" /> is <see langword="null" />.</exception>
    public static IEnumerable<TSource> Except<TSource>(this IEnumerable<TSource> source, TSource item)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        return source.Where(i => !Equals(i, item));
    }

    /// <summary>
    ///     Returns the minimum and maximum values in a sequence of values.
    /// </summary>
    /// <param name="source">A sequence of values to determine the minimum and maximum values of.</param>
    /// <typeparam name="T">The type of the elements in <paramref name="source" />.</typeparam>
    /// <returns>A tuple containing the minimum and maximum values in <paramref name="source" />.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source" /> is <see langword="null" />.</exception>
    /// <exception cref="InvalidOperationException"><paramref name="source" /> contains no elements.</exception>
    public static (T? Minimum, T? Maximum) MinMax<T>(this IEnumerable<T> source)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        return MinMax(source, Comparer<T>.Default);
    }

    /// <summary>
    ///     Returns the minimum and maximum values in a sequence of values, using a specified comparer.
    /// </summary>
    /// <param name="source">A sequence of values to determine the minimum and maximum values of.</param>
    /// <param name="comparer">The comparer which shall be used to compare each element in the sequence.</param>
    /// <typeparam name="T">The type of the elements in <paramref name="source" />.</typeparam>
    /// <returns>A tuple containing the minimum and maximum values in <paramref name="source" />.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source" /> is <see langword="null" />.</exception>
    /// <exception cref="InvalidOperationException"><paramref name="source" /> contains no elements.</exception>
    public static (T? Minimum, T? Maximum) MinMax<T>(this IEnumerable<T> source, IComparer<T>? comparer)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        comparer ??= Comparer<T>.Default;

        // ReSharper disable once PossibleMultipleEnumeration
        if (source.TryGetSpan(out ReadOnlySpan<T> span))
        {
            return MinMaxSpan(comparer, span);
        }

        T? minValue;
        T? maxValue;

        // ReSharper disable once PossibleMultipleEnumeration
        using (IEnumerator<T> enumerator = source.GetEnumerator())
        {
            if (!enumerator.MoveNext())
            {
                throw new InvalidOperationException(ExceptionMessages.SourceContainsNoElements);
            }

            minValue = enumerator.Current;
            maxValue = minValue;

            while (enumerator.MoveNext())
            {
                T current = enumerator.Current;

                if (minValue is null || comparer.Compare(current, minValue) < 0)
                {
                    minValue = current;
                }

                if (maxValue is null || comparer.Compare(current, maxValue) > 0)
                {
                    maxValue = current;
                }
            }
        }

        return (minValue, maxValue);
    }

    /// <summary>
    ///     Invokes a transform function on each element of a sequence of elements and returns the minimum and maximum values.
    /// </summary>
    /// <param name="source">A sequence of values to determine the minimum and maximum values of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <typeparam name="TSource">The type of the elements in <paramref name="source" />.</typeparam>
    /// <typeparam name="TResult">The type of the elements to compare.</typeparam>
    /// <returns>A tuple containing the minimum and maximum values in <paramref name="source" />.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source" /> is <see langword="null" />.</exception>
    /// <exception cref="InvalidOperationException"><paramref name="source" /> contains no elements.</exception>
    public static (TResult? Minimum, TResult? Maximum) MinMax<TSource, TResult>(this IEnumerable<TSource> source,
        Func<TSource, TResult> selector)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        if (selector is null)
        {
            throw new ArgumentNullException(nameof(selector));
        }

        return MinMax(source, selector, Comparer<TResult>.Default);
    }

    /// <summary>
    ///     Invokes a transform function on each element of a sequence of elements and returns the minimum and maximum values,
    ///     using a specified comparer.
    /// </summary>
    /// <param name="source">A sequence of values to determine the minimum and maximum values of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="comparer">The comparer which shall be used to compare each element in the sequence.</param>
    /// <typeparam name="TSource">The type of the elements in <paramref name="source" />.</typeparam>
    /// <typeparam name="TResult">The type of the elements to compare.</typeparam>
    /// <returns>A tuple containing the minimum and maximum values in <paramref name="source" />.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source" /> is <see langword="null" />.</exception>
    /// <exception cref="InvalidOperationException"><paramref name="source" /> contains no elements.</exception>
    public static (TResult? Minimum, TResult? Maximum) MinMax<TSource, TResult>(this IEnumerable<TSource> source,
        Func<TSource, TResult> selector,
        IComparer<TResult>? comparer)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        if (selector is null)
        {
            throw new ArgumentNullException(nameof(selector));
        }

        comparer ??= Comparer<TResult>.Default;

        // ReSharper disable once PossibleMultipleEnumeration
        if (source.TryGetSpan(out ReadOnlySpan<TSource> span))
        {
            return MinMaxSpan(selector, comparer, span);
        }

        TResult? minValue;
        TResult? maxValue;

        // ReSharper disable once PossibleMultipleEnumeration
        using (IEnumerator<TSource> enumerator = source.GetEnumerator())
        {
            if (!enumerator.MoveNext())
            {
                throw new InvalidOperationException(ExceptionMessages.SourceContainsNoElements);
            }

            minValue = selector(enumerator.Current);
            maxValue = minValue;

            while (enumerator.MoveNext())
            {
                TResult current = selector(enumerator.Current);

                if (minValue is null || comparer.Compare(current, minValue) < 0)
                {
                    minValue = current;
                }

                if (maxValue is null || comparer.Compare(current, maxValue) > 0)
                {
                    maxValue = current;
                }
            }
        }

        return (minValue, maxValue);
    }

    /// <summary>
    ///     Returns the minimum and maximum values in a sequence according to a specified key selector function.
    /// </summary>
    /// <param name="source">A sequence of values to determine the minimum and maximum values of.</param>
    /// <param name="keySelector">A function to extract the key for each element.</param>
    /// <typeparam name="TSource">The type of the elements in <paramref name="source" />.</typeparam>
    /// <typeparam name="TResult">The type of the elements to compare.</typeparam>
    /// <returns>A tuple containing the minimum and maximum values in <paramref name="source" />.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source" /> is <see langword="null" />.</exception>
    /// <exception cref="InvalidOperationException"><paramref name="source" /> contains no elements.</exception>
    public static (TSource? Minimum, TSource? Maximum) MinMaxBy<TSource, TResult>(this IEnumerable<TSource> source,
        Func<TSource, TResult> keySelector)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        if (keySelector is null)
        {
            throw new ArgumentNullException(nameof(keySelector));
        }

        return MinMaxBy(source, keySelector, Comparer<TResult>.Default);
    }

    /// <summary>
    ///     Returns the minimum and maximum values in a sequence according to a specified key selector function.
    /// </summary>
    /// <param name="source">A sequence of values to determine the minimum and maximum values of.</param>
    /// <param name="keySelector">A function to extract the key for each element.</param>
    /// <param name="comparer">The comparer which shall be used to compare each element in the sequence.</param>
    /// <typeparam name="TSource">The type of the elements in <paramref name="source" />.</typeparam>
    /// <typeparam name="TResult">The type of the elements to compare.</typeparam>
    /// <returns>A tuple containing the minimum and maximum values in <paramref name="source" />.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source" /> is <see langword="null" />.</exception>
    /// <exception cref="InvalidOperationException"><paramref name="source" /> contains no elements.</exception>
    public static (TSource? Minimum, TSource? Maximum) MinMaxBy<TSource, TResult>(this IEnumerable<TSource> source,
        Func<TSource, TResult> keySelector,
        IComparer<TResult>? comparer)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        if (keySelector is null)
        {
            throw new ArgumentNullException(nameof(keySelector));
        }

        comparer ??= Comparer<TResult>.Default;
        TSource? minValue;
        TSource? maxValue;

        // ReSharper disable once PossibleMultipleEnumeration
        if (source.TryGetSpan(out ReadOnlySpan<TSource> span))
        {
            return MinMaxSelectedSpan(keySelector, comparer, span);
        }

        // ReSharper disable once PossibleMultipleEnumeration
        using (IEnumerator<TSource> enumerator = source.GetEnumerator())
        {
            if (!enumerator.MoveNext())
            {
                throw new InvalidOperationException(ExceptionMessages.SourceContainsNoElements);
            }

            minValue = enumerator.Current;
            maxValue = minValue;

            while (enumerator.MoveNext())
            {
                TSource current = enumerator.Current;
                TResult transformedCurrent = keySelector(current);

                if (minValue is null || comparer.Compare(transformedCurrent, keySelector(minValue)) < 0)
                {
                    minValue = current;
                }

                if (maxValue is null || comparer.Compare(transformedCurrent, keySelector(maxValue)) > 0)
                {
                    maxValue = current;
                }
            }
        }

        return (minValue, maxValue);
    }

    private static (T? Minimum, T? Maximum) MinMaxSpan<T>(IComparer<T> comparer, ReadOnlySpan<T> span)
    {
        if (span.IsEmpty)
        {
            throw new InvalidOperationException(ExceptionMessages.SourceContainsNoElements);
        }

        T minValue = span[0];
        T maxValue = minValue;

        for (var index = 1; (uint)index < (uint)span.Length; index++)
        {
            T current = span[index];

            if (comparer.Compare(current, minValue) < 0)
            {
                minValue = current;
            }

            if (comparer.Compare(current, maxValue) > 0)
            {
                maxValue = current;
            }
        }

        return (minValue, maxValue);
    }

    private static (TSource? Minimum, TSource? Maximum) MinMaxSelectedSpan<TSource, TResult>(Func<TSource, TResult> keySelector,
        IComparer<TResult> comparer,
        ReadOnlySpan<TSource> span)
    {
        if (span.IsEmpty)
        {
            throw new InvalidOperationException(ExceptionMessages.SourceContainsNoElements);
        }

        TSource minValue = span[0];
        TSource maxValue = minValue;

        for (var index = 1; (uint)index < (uint)span.Length; index++)
        {
            TSource current = span[index];
            TResult transformedCurrent = keySelector(current);

            if (minValue is null || comparer.Compare(transformedCurrent, keySelector(minValue)) < 0)
            {
                minValue = current;
            }

            if (maxValue is null || comparer.Compare(transformedCurrent, keySelector(maxValue)) > 0)
            {
                maxValue = current;
            }
        }

        return (minValue, maxValue);
    }

    private static (TResult?, TResult?) MinMaxSpan<TSource, TResult>(Func<TSource, TResult> selector,
        IComparer<TResult> comparer,
        ReadOnlySpan<TSource> span)
    {
        if (span.IsEmpty)
        {
            throw new InvalidOperationException(ExceptionMessages.SourceContainsNoElements);
        }

        TResult minValue = selector(span[0]);
        TResult maxValue = minValue;

        for (var index = 1; (uint)index < (uint)span.Length; index++)
        {
            TResult current = selector(span[index]);

            if (minValue is null || comparer.Compare(current, minValue) < 0)
            {
                minValue = current;
            }

            if (maxValue is null || comparer.Compare(current, maxValue) > 0)
            {
                maxValue = current;
            }
        }

        return (minValue, maxValue);
    }

    private static bool TryGetSpan<TSource>(this IEnumerable<TSource> source, out ReadOnlySpan<TSource> span)
    {
        var result = true;

        switch (source)
        {
            case TSource[] array:
                span = array;
                break;

            case List<TSource> list:
                span = CollectionsMarshal.AsSpan(list);
                break;

            default:
                span = default;
                result = false;
                break;
        }

        return result;
    }
}
