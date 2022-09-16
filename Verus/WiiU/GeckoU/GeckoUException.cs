﻿using System;

namespace Verus.WiiU.GeckoU
{
    public class GeckoUException : Exception
    {
        public enum EtcpErrorCode
        {
            FtdiQueryError,
            NoFtdiDevicesFound,
            NoTcpGeckoFound,
            FtdiResetError,
            FtdiPurgeRxError,
            FtdiPurgeTxError,
            FtdiTimeoutSetError,
            FtdiTransferSetError,
            FtdiCommandSendError,
            FtdiReadDataError,
            FtdiInvalidReply,
            TooManyRetries,
            RegStreamSizeInvalid,
            CheatStreamSizeInvalid
        }

        private EtcpErrorCode _pErrorCode;

        public EtcpErrorCode ErrorCode
        {
            get
            {
                return _pErrorCode;
            }
        }

        public GeckoUException(EtcpErrorCode code)
        {
            _pErrorCode = code;
        }
        public GeckoUException(EtcpErrorCode code, string message) : base(message)
        {
            _pErrorCode = code;
        }
        public GeckoUException(EtcpErrorCode code, string message, Exception inner) : base(message, inner)
        {
            _pErrorCode = code;
        }
    }
}
