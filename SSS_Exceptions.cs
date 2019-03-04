using System;
using System.Collections.Generic;
using System.Text;

namespace SSS_Exceptions
{
    public class ZeroWeightException : ApplicationException
    {
        public ZeroWeightException() { }
        public ZeroWeightException(int value) : base(String.Format("Warning: Weight is Zero: {0}", value)) { }
        public ZeroWeightException(string message,
                                   System.Exception inner) : base(message, inner) { }
    }

    public class InvalidWeightException : ApplicationException
    {
        public InvalidWeightException() { }
        public InvalidWeightException(int value) : base(String.Format("Exception: Weight {0} is not bewtween 100 and 300 lbs.", value)) { }
        public InvalidWeightException(string message,
                                   System.Exception inner) : base(message, inner) { }
    }

    public class ZeroHeightException : ApplicationException
    {
        public ZeroHeightException() { }
        public ZeroHeightException(int value) : base(String.Format("Warning: Height is Zero: {0}", value)) { }
        public ZeroHeightException(string message,
                                   System.Exception inner) : base(message, inner) { }
    }

    public class InvalidHeightException : ApplicationException
    {
        public InvalidHeightException() { }
        public InvalidHeightException(int value) : base(String.Format("Exception: Height {0} is not between 4 and  7 ft", value)) { }
        public InvalidHeightException(string message,
                                   System.Exception inner) : base(message, inner) { }
    }

    public class ScreenNameNullException : ApplicationException
    {
        public ScreenNameNullException() { }
        public ScreenNameNullException(string entry) : base(String.Format("Exception: Sceenname {0} cannot be NULL", entry)) { }
        public ScreenNameNullException(string message,
                                   System.Exception inner) : base(message, inner) { }
    }

    public class ScreenNameInUseException : ApplicationException
    {
        public ScreenNameInUseException() { }
        public ScreenNameInUseException(string entry) : base(String.Format("Excdption Screenname {0} is already in use", entry)) { }
        public ScreenNameInUseException(string message,
                                   System.Exception inner) : base(message, inner) { }
    }

    public class OtherException : ApplicationException
    {
        public OtherException() { }
        public OtherException(string message) : base(message) { }
        public OtherException(string message,
                                   System.Exception inner) : base(message, inner) { }
    }

}
