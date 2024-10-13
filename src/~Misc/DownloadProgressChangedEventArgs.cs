namespace DnHttp;

/// <inheritdoc />
/// <summary>
/// Представляет данные для события, сообщающим о прогрессе загрузки данных.
/// </summary>
/// <inheritdoc />
/// <remarks>
/// Инициализирует новый экземпляр класса <see cref="T:Leaf.xNet.DownloadProgressChangedEventArgs" />.
/// </remarks>
/// <param name="bytesReceived">Количество полученных байтов.</param>
/// <param name="totalBytesToReceive">Общее количество получаемых байтов.</param>
public sealed class DownloadProgressChangedEventArgs(
    long bytesReceived,
    long totalBytesToReceive
    ) : EventArgs
{
    #region Свойства (открытые)

    /// <summary>
    /// Возвращает количество полученных байтов.
    /// </summary>
    public long BytesReceived { get; } = bytesReceived;

    /// <summary>
    /// Возвращает общее количество получаемых байтов.
    /// </summary>
    /// <value>Если общее количество получаемых байтов неизвестно, то значение -1.</value>
    public long TotalBytesToReceive { get; } = totalBytesToReceive;

    /// <summary>
    /// Возвращает процент полученных байтов.
    /// </summary>
    // ReSharper disable once UnusedMember.Global
    public double ProgressPercentage => (double)BytesReceived / TotalBytesToReceive * 100.0;

    #endregion
}
