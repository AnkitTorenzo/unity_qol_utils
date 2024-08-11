using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public class WRB
{
    #region Static Stuff

    private const string ABORT_BUILD_MSG = "ABORTING build chain.";
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

    public static WRB CreateRequestBuilder(string target)
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
    private PayloadType _payloadType;
    private RequestMethod _methodName;

    //Different types of payload
    private Dictionary<string, string> dictPayload;
    private WWWForm formPayload;
    private string _strPayload;

    private Action<string> errorHandler, responseHandler;

    private bool _isBuilt = false;
    private UnityWebRequest _request;

    private WRB() { }

    public WRB SetMethodType(RequestMethod method)
    {
        _methodName = method;
        return this;
    }

    public WRB SetDictPayload(Dictionary<string, string> payload)
    {
        if (!IsPayloadExists())
            return null;

        _payloadType = PayloadType.DICT;
        dictPayload = payload;
        return this;
    }


    public WRB SetWFormPayload(WWWForm payload)
    {
        if (!IsPayloadExists())
            return null;

        if (_methodName == RequestMethod.GET)
        {
            Debug.LogError($"WWWForm is not supported with 'RequestMethod.GET'. Please use the same method with Dictionary<string, string> as parameter, or change the RequestMethod from 'GET' to something-else");
            Debug.LogError(ABORT_BUILD_MSG);
            return null;
        }

        _payloadType = PayloadType.W_FORM;
        formPayload = payload;
        return this;
    }

    public WRB SetStrPayload(string strPayload)
    {
        if (!IsPayloadExists())
            return null;

        if (_methodName == RequestMethod.GET)
        {
            Debug.LogError($"strPayload is not supported with 'RequestMethod.GET'. Please use the same method with Dictionary<string, string> as parameter, or change the RequestMethod from 'GET' to something-else");
            Debug.LogError(ABORT_BUILD_MSG);
            return null;
        }

        _payloadType = PayloadType.STR;
        _strPayload = strPayload;
        return this;
    }

    public WRB AddErrorHandler(Action<string> errorCallback)
    {
        errorHandler = errorCallback;
        return this;
    }

    public WRB AddResponseHandler(Action<string> respHandler)
    {
        responseHandler = respHandler;
        return this;
    }

    private bool IsPayloadExists()
    {
        if (_payloadType != PayloadType.NONE)
        {
            Debug.LogError($"It looks like you already have added the payload in the chain.\nPlease restart the build chain.");
            Debug.LogError(ABORT_BUILD_MSG);
            return false;
        }

        return true;
    }

    public WRB Build()
    {
        if (_isBuilt)
        {
            Debug.LogWarning($"This WebRequest is already built. Returning already built request.");
            return this;
        }

        _request = _methodName switch
        {
            RequestMethod.GET => GenerateGetRequest(),
            RequestMethod.POST => GeneratePostRequest(),
            RequestMethod.PUT => GeneratePutRequest(),
            RequestMethod.DELETE => GenerateDeleteRequest(),
        };
        return this;
    }

    private UnityWebRequest GenerateDeleteRequest()
    {
        return null;
    }

    private UnityWebRequest GeneratePutRequest()
    {
        return null;
    }

    private UnityWebRequest GeneratePostRequest()
    {
        return null;
    }

    private UnityWebRequest GenerateGetRequest()
    {
        if (_payloadType != PayloadType.DICT)
        {
            Debug.LogError($"GetRequest only support Dictionary as it's payload.");
            Debug.LogError(ABORT_BUILD_MSG);
        }
        return null;
    }

    public void Send()
    {
        if (_request == null)
        {
            Debug.LogError($"It seams that you forget to build the request before sending it. Call Build() method right before calling Send() method in the builder chain."); return;
        }
    }
}

public class WRBConfig
{
    public string baseUrl;
    public string authToken;
    public Action<string> defaultErrorHandler;
    public Action<string> defaultResponseHandler;

    internal bool isWellFormedUrl;
}

public enum RequestMethod
{
    GET,
    POST,
    PUT,
    DELETE,
}

public enum PayloadType
{
    NONE,
    STR,
    DICT,
    W_FORM
}