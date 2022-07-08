#region Copyright notice and license

// Copyright 2019 The gRPC Authors
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

#endregion

using System.Runtime.InteropServices;

namespace Grpc.Net.Client.Internal
{
    internal interface IOperatingSystem
    {
        bool IsBrowser { get; }
    }

    internal class OperatingSystem : IOperatingSystem
    {
        public static readonly OperatingSystem Instance = new OperatingSystem();

        public bool IsBrowser { get; }

        private OperatingSystem()
        {
            // NOTE(Cysharp): Some versions of Unity WebGL throw NotSupportedException.
            // https://issuetracker.unity3d.com/issues/notsupportedexception-thrown-when-calling-any-member-of-system-dot-runtime-dot-interopservices-dot-runtimeinformation-in-webgl
            // https://github.com/Cysharp/GrpcWebSocketBridge/issues/2
            IsBrowser = true; // RuntimeInformation.IsOSPlatform(OSPlatform.Create("browser"));
        }
    }
}