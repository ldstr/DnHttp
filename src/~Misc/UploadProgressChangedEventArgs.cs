namespace DnHttp;

/// <inheritdoc />
/// <summary>
/// Представляет данные для события, сообщающим о прогрессе выгрузки данных.
/// </summary>
/// <inheritdoc />
/// <remarks>
/// Инициализирует новый экземпляр класса <see cref="T:Leaf.xNet.UploadProgressChangedEventArgs" />.
/// </remarks>
/// <param name="bytesSent">Количество отправленных байтов.</param>
/// <param name="totalBytesToSend">Общее количество отправляемых байтов.</param>
public sealed class UploadProgressChangedEventArgs(
    long bytesSent,
    long totalBytesToSend) : EventArgs
{
    #region Свойства (открытые)

    /// <summary>
    /// Возвращает количество отправленных байтов.
    /// </summary>
    public long BytesSent { get; } = bytesSent;

    /// <summary>
    /// Возвращает общее количество отправляемых байтов.
    /// </summary>
    public long TotalBytesToSend { get; } = totalBytesToSend;

    /// <summary>
    /// Возвращает процент отправленных байтов.
    /// </summary>
    // ReSharper disable once UnusedMember.Global
    public double ProgressPercentage => (double)BytesSent / TotalBytesToSend * 100.0;

    #endregion
}
