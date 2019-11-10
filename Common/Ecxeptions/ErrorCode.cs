using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Ecxeptions
{
    public struct ErrorCode
    {
        public static readonly ErrorCode LoginOccupied = new ErrorCode("LOGIN_OCCUPIED");
        public static readonly ErrorCode WrongLogin = new ErrorCode("WRONG_LOGIN");
        public static readonly ErrorCode WrongPassword = new ErrorCode("WRONG_PASSWORD");

        public string Value { get; }

        private ErrorCode(string value)
        {
            Value = value;
        }

        public static bool operator ==(ErrorCode code1, ErrorCode code2)
        {
            return Equals(code1, code2);
        }

        public static bool operator !=(ErrorCode code1, ErrorCode code2)
        {
            return !(code1 == code2);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is ErrorCode other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Value != null ? Value.GetHashCode() : 0;
        }
    }
}
