namespace DnHttp;

/// <inheritdoc />
/// <summary>
/// Represents a collection of strings representing request parameters.
/// </summary>
/// <inheritdoc />
/// <param name="valuesUnescaped">Indicates whether to skip encoding of request parameter values.</param>
/// <param name="keysUnescaped">Indicates whether to skip encoding of query parameter names.</param>
public class RequestParams(
    bool valuesUnescaped = false,
    bool keysUnescaped = false
    ) : List<KeyValuePair<string, string>>
{
    /// <summary>
    /// A request listing parameters and their values.
    /// </summary>
    public string Query => Http.ToQueryString(this, ValuesUnescaped, KeysUnescaped);

    /// <summary>
    /// Indicates whether to skip encoding of request parameter values.
    /// </summary>
    public readonly bool ValuesUnescaped = valuesUnescaped;

    /// <summary>
    /// Indicates whether to skip encoding of query parameter names.
    /// </summary>
    public readonly bool KeysUnescaped = keysUnescaped;

    /// <summary>
    /// Specifies a new request parameter.
    /// </summary>
    /// <param name="paramName">Name of the request parameter.</param>
    /// <exception cref="ArgumentNullException">The value of the <paramref name="paramName"/> parameter is equal to <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">The <paramref name="paramName"/> parameter value is an empty string.</exception>
    public object this[string paramName]
    {
        set
        {
            ArgumentNullException.ThrowIfNull(paramName);

            if (paramName.Length == 0)
                throw ExceptionHelper.EmptyString(nameof(paramName));

            string str = value?.ToString() ?? string.Empty;

            Add(new(paramName, str));
        }
    }
}
