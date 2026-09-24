
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace EasyDebug;

public static class Debug
{
    /// <summary>
    /// Affiche un ou plusieurs objets dans la console.
    /// </summary>
    public static void Log(params object[] values)
    {
        foreach (object value in values)
        {
            Console.WriteLine(ToLogString(value));
        }
    }

    /// <summary>
    /// Convertit les objets en texte lisible.
    /// </summary>
    public static string ToLogString(object value)
    {
        if (value == null)
            return "null";

        // Gestion des dictionnaires
        if (value is IDictionary dictionary)
        {
            var entries = new List<string>();

            foreach (DictionaryEntry entry in dictionary)
            {
                entries.Add(
                    $"{ToLogString(entry.Key)}: {ToLogString(entry.Value)}"
                );   
            }

            return "{" + string.Join(", ", entries) + "}";
        }

        // Gestion des listes et autres collections
        if (value is IEnumerable enumerable && value is not string)
        {
            var items = new List<string>();

            foreach (object item in enumerable)
            {
                items.Add(ToLogString(item));
            }

            return "[" + string.Join(", ", items) + "]";
        }

        return value.ToString() ?? "null";
    }

    public static void ConsoleClear()
    {
        Console.Clear();
    }
}