namespace DnHttp;

internal static class ProxyHelper
{
    public static ProxyClient CreateProxyClient(
        ProxyType proxyType,
        string? host = null,
        int port = 0,
        string? username = null,
        string? password = null
        )
    {
        ArgumentException.ThrowIfNullOrEmpty(host);

        return proxyType switch
        {
            ProxyType.HTTP => port == 0
                ? new HttpProxyClient(host)
                : new HttpProxyClient(host, port, username, password),
            ProxyType.Socks4 => port == 0
                ? new Socks4ProxyClient(host)
                : new Socks4ProxyClient(host, port, username),
            ProxyType.Socks4A => port == 0
                ? new Socks4AProxyClient(host)
                : new Socks4AProxyClient(host, port, username),
            ProxyType.Socks5 => port == 0
                ? new Socks5ProxyClient(host)
                : new Socks5ProxyClient(host, port, username, password),
            _ => throw new InvalidOperationException(),
        };
    }
}
