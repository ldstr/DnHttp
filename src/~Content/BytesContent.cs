namespace DnHttp;

/// <inheritdoc />
/// <summary>
/// Represents the request body as bytes.
/// </summary>
public class BytesContent : HttpContent
{
    #region Поля (защищённые)

    /// <summary>Contents of the request body.</summary>
    protected byte[] Content;
    /// <summary>The byte offset of the request body contents.</summary>
    protected int Offset;
    /// <summary>The number of bytes of content to send.</summary>
    protected int Count;

    #endregion

    #region Конструкторы (открытые)

    /// <inheritdoc />
    /// <summary>
    /// Initializes a new instance of the class, <see cref="T:DnHttp.BytesContent" />.
    /// </summary>
    /// <param name="content">Содержимое тела запроса.</param>
    /// <exception cref="T:System.ArgumentNullException">Значение параметра <paramref name="content" /> равно <see langword="null" />.</exception>
    /// <remarks>По умолчанию используется тип контента - 'application/octet-stream'.</remarks>
    public BytesContent(byte[] content)
        : this(content, 0, content.Length) { }

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="BytesContent"/>.
    /// </summary>
    /// <param name="content">Содержимое тела запроса.</param>
    /// <param name="offset">Смещение в байтах для контента.</param>
    /// <param name="count">Число байтов отправляемых из контента.</param>
    /// <exception cref="System.ArgumentNullException">Значение параметра <paramref name="content"/> равно <see langword="null"/>.</exception>
    /// <exception cref="System.ArgumentOutOfRangeException">
    /// Значение параметра <paramref name="offset"/> меньше 0.
    /// -или-
    /// Значение параметра <paramref name="offset"/> больше длины содержимого.
    /// -или-
    /// Значение параметра <paramref name="count"/> меньше 0.
    /// -или-
    /// Значение параметра <paramref name="count"/> больше (длина содержимого - смещение).</exception>
    /// <remarks>По умолчанию используется тип контента - 'application/octet-stream'.</remarks>
    // ReSharper disable once MemberCanBePrivate.Global
    public BytesContent(byte[] content, int offset, int count)
    {
        #region Проверка параметров

        ArgumentNullException.ThrowIfNull(content);

        if (offset < 0)
            throw ExceptionHelper.CanNotBeLess(nameof(offset), 0);

        if (offset > content.Length)
            throw ExceptionHelper.CanNotBeGreater(nameof(offset), content.Length);

        if (count < 0)
            throw ExceptionHelper.CanNotBeLess(nameof(count), 0);

        if (count > content.Length - offset)
            throw ExceptionHelper.CanNotBeGreater(nameof(count), content.Length - offset);

        #endregion

        Content = content;
        Offset = offset;
        Count = count;

        MimeContentType = "application/octet-stream";
    }

    #endregion


    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="BytesContent"/>.
    /// </summary>
    // ReSharper disable once UnusedMember.Global
    protected BytesContent() { }


    #region Методы (открытые)

    /// <inheritdoc />
    /// <summary>
    /// Подсчитывает и возвращает длину тела запроса в байтах.
    /// </summary>
    /// <returns>Длина тела запроса в байтах.</returns>
    public override long CalculateContentLength()
    {
        return Content.LongLength;
    }

    /// <inheritdoc />
    /// <summary>
    /// Записывает данные тела запроса в поток.
    /// </summary>
    /// <param name="stream">Поток, куда будут записаны данные тела запроса.</param>
    public override void WriteTo(Stream stream)
    {
        stream.Write(Content, Offset, Count);
    }

    #endregion
}
