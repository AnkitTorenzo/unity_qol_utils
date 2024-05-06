
using System;
using System.IO;
using UnityEngine;

public class WRB
{
    #region Static Stuff
    private static WRBConfig _config;

    public static void Init(WRBConfig config)
    {
        if (!Uri.IsWellFormedUriString(config.baseUrl, UriKind.RelativeOrAbsolute))
        {
            Debug.LogWarning($"{config.baseUrl} is not a valid url, please take a look at it. Relative endpoints will not work.");
            config.isWellFormedUrl = false;
        }
        config.isWellFormedUrl = true;
        _config = config;
    }

    public static WRB CreateGetRequestBuilder(string target)
    {
        if (!Uri.IsWellFormedUriString(target, UriKind.RelativeOrAbsolute))
        {
            if (_config == null || !_config.isWellFormedUrl)
            {
                Debug.LogError($"Did not found a valid url, nether in the config nor in the method parameter 'url'. Aborting the building chain. If you haven't configured the RequestBuilder please do so using WRB.Init(WRBConfig)");
                return null;
            }

            return new WRB()
            {
                _url = Path.Combine(_config.baseUrl, target),
            };
        }

        return new WRB()
        {
            _url = target
        };
    }
    #endregion

    private string _url;
    private WRB() { }
}

public class WRBConfig
{
    public string baseUrl;
    public string authToken;

    internal bool isWellFormedUrl;
}