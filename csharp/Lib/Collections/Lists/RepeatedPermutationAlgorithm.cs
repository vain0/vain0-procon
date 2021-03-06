using System.Collections.Generic;
using System.Linq;

public static class RepeatedPermutationAlgorithm
{
    private static IEnumerable<IReadOnlyList<T>> RepeatedPermutationsIterator<T>(int i, T[] source, T[] buffer)
    {
        if (i == buffer.Length)
        {
            yield return buffer;
        }
        else
        {
            foreach (var item in source)
            {
                buffer[i] = item;

                foreach (var list in RepeatedPermutationsIterator(i + 1, source, buffer))
                {
                    yield return list;
                }
            }
        }
    }

    public static IEnumerable<IReadOnlyList<T>> AllRepeatedPermutations<T>(this IEnumerable<T> source, int count) =>
        RepeatedPermutationsIterator(0, source.ToArray(), new T[count]);
}
