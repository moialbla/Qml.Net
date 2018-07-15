﻿using System;
using AdvancedDLSupport;
using Qt.NetCore.Internal;

namespace Qt.NetCore
{
    public static class Interop
    {
        static readonly CallbacksImpl DefaultCallbacks = new CallbacksImpl(new DefaultCallbacks());
        
        static Interop()
        {
            Environment.SetEnvironmentVariable("DYLD_LIBRARY_PATH", "/Users/pknopf/git/net-core-qml/src/native/build-QtNetCoreQml-Desktop_Qt_5_11_1_clang_64bit-Debug");
            Callbacks = NativeLibraryBuilder.Default.ActivateInterface<ICallbacksIterop>("QtNetCoreQml");
            NetTypeInfo = NativeLibraryBuilder.Default.ActivateInterface<INetTypeInfoInterop>("QtNetCoreQml");
            NetTypeManager = NativeLibraryBuilder.Default.ActivateInterface<INetTypeManagerInterop>("QtNetCoreQml");

            var cb = DefaultCallbacks.Callbacks();
            Callbacks.RegisterCallbacks(ref cb);
        }
        
        public static ICallbacksIterop Callbacks { get; }

        public static INetTypeInfoInterop NetTypeInfo { get; }
        
        public static INetTypeManagerInterop NetTypeManager { get; }
        
        public static void RegisterCallbacks(ICallbacks callbacks)
        {
            var callbacksImpl = new CallbacksImpl(callbacks);
            var callbacksRef = callbacksImpl.Callbacks();
            Callbacks.RegisterCallbacks(ref callbacksRef);
        }
    }
}