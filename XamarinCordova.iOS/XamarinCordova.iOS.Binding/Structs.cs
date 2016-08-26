using System;

namespace XamarinCordova.iOS.Binding
{
    public enum CDVCommandStatus : uint
    {
        NoResult = 0,
        Ok,
        ClassNotFoundException,
        IllegalAccessException,
        InstantiationException,
        MalformedUrlException,
        IoException,
        InvalidAction,
        JsonException,
        Error
    }
}

