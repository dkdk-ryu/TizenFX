﻿/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Collections.Generic;

namespace Tizen.Network.Nfc
{
    /// <summary>
    /// An extended EventArgs class which contains changed Nfc activation state.
    /// </summary>
    public class ActivationChangedEventArgs : EventArgs
    {
        private bool _activated = false;

        internal ActivationChangedEventArgs(bool activated)
        {
            _activated = activated;
        }

        /// <summary>
        /// The Nfc activation state.
        /// </summary>
        public bool Activated
        {
            get
            {
                return _activated;
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class which contains changed Nfc tag discovered.
    /// </summary>
    public class TagDiscoveredEventArgs : EventArgs
    {
        private NfcDiscoveredType _type = NfcDiscoveredType.Detached;
        private NfcTag _tag;

        internal TagDiscoveredEventArgs(NfcDiscoveredType _type, IntPtr tagHandle)
        {
            _tag = new NfcTag(tagHandle);
        }

        /// <summary>
        /// The tag type.
        /// </summary>
        public NfcDiscoveredType Type
        {
            get
            {
                return _type;
            }
        }

        /// <summary>
        /// Tag object
        /// </summary>
        public NfcTag Tag
        {
            get
            {
                return _tag;
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class which contains changed Nfc p2p target discovered.
    /// </summary>
    public class P2pTargetDiscoveredEventArgs : EventArgs
    {
        private NfcDiscoveredType _type = NfcDiscoveredType.Detached;
        private NfcP2p _p2pTarget;

        internal P2pTargetDiscoveredEventArgs(NfcDiscoveredType _type, IntPtr p2pTargetHandle)
        {
            _p2pTarget = new NfcP2p(p2pTargetHandle);
        }

        /// <summary>
        /// The p2p target type.
        /// </summary>
        public NfcDiscoveredType Type
        {
            get
            {
                return _type;
            }
        }

        /// <summary>
        /// P2p object
        /// </summary>
        public NfcP2p P2pTaget
        {
            get
            {
                return _p2pTarget;
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class which contains changed Nfc ndef discovered.
    /// </summary>
    public class NdefMessageDiscoveredEventArgs : EventArgs
    {
        private NfcNdefMessage _ndef;

        internal NdefMessageDiscoveredEventArgs(IntPtr messageHandle)
        {
            _ndef = new NfcNdefMessage(messageHandle);
        }
        
        /// <summary>
        /// Tag object
        /// </summary>
        public NfcNdefMessage NdefMessage
        {
            get
            {
                return _ndef;
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class which contains changed Secure element event.
    /// </summary>
    public class SecureElementEventArgs : EventArgs
    {
        private NfcSecureElementEvent _eventType = NfcSecureElementEvent.StartTransaction;

        internal SecureElementEventArgs(NfcSecureElementEvent eventType)
        {
            _eventType = eventType;
        }

        /// <summary>
        /// The Nfc secure element event.
        /// </summary>
        public NfcSecureElementEvent EventType
        {
            get
            {
                return _eventType;
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class which contains changed Secure element trasaction event.
    /// </summary>
    public class SecureElementTranscationEventArgs : EventArgs
    {
        private NfcSecureElementType _secureElementType = NfcSecureElementType.Disable;
        byte[] _aid;
        byte[] _param;

        internal SecureElementTranscationEventArgs(NfcSecureElementType secureElementType, byte[] aid, byte[] param)
        {
            _secureElementType = secureElementType;
            _aid = aid;
            _param = param;
        }

        /// <summary>
        /// The Nfc secure element type.
        /// </summary>
        public NfcSecureElementType SecureElementType
        {
            get
            {
                return _secureElementType;
            }
        }
        /// <summary>
        /// The Nfc secure element aid.
        /// </summary>
        public byte[] ApplicationID
        {
            get
            {
                return _aid;
            }
        }
        /// <summary>
        /// The Nfc secure element param.
        /// </summary>
        public byte[] Param
        {
            get
            {
                return _param;
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class which contains changed HCE(Host Card Emulation) event.
    /// </summary>
    public class HostCardEmulationEventArgs : EventArgs
    {
        private NfcSecureElement _se;
        private NfcHceEvent _hceEvent = NfcHceEvent.Deactivated;
        private byte[] _apdu;

        internal HostCardEmulationEventArgs(IntPtr seHandle, NfcHceEvent hcdEvent, byte[] apdu)
        {
            _se = new NfcSecureElement(seHandle);
            _hceEvent = hcdEvent;
            _apdu = apdu;
        }

        /// <summary>
        /// The Nfc secure element.
        /// </summary>
        public NfcSecureElement SecureElement
        {
            get
            {
                return _se;
            }
        }
        /// <summary>
        /// The Nfc hce event.
        /// </summary>
        public NfcHceEvent HcdEvent
        {
            get
            {
                return _hceEvent;
            }
        }
        /// <summary>
        /// The Nfc apdu(Application Protocol Data Unit)
        /// </summary>
        public byte[] Apdu
        {
            get
            {
                return _apdu;
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class which contains changed HCE(Host Card Emulation) event.
    /// </summary>
    public class P2pDataReceivedEventArgs : EventArgs
    {
        private NfcP2p _p2pTarget;
        private NfcNdefMessage _ndefMessage;

        internal P2pDataReceivedEventArgs(IntPtr p2pHandle, IntPtr ndefHandle)
        {
            _p2pTarget = new NfcP2p(p2pHandle);
            _ndefMessage = new NfcNdefMessage(ndefHandle);
        }

        /// <summary>
        /// The Nfc p2p target.
        /// </summary>
        public NfcP2p P2pTarget
        {
            get
            {
                return _p2pTarget;
            }
        }
        /// <summary>
        /// The Nfc ndef message.
        /// </summary>
        public NfcNdefMessage NdefMessage
        {
            get
            {
                return _ndefMessage;
            }
        }
    }
}
