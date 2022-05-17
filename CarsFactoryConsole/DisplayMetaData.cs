using System;
using System.Collections.Generic;
using System.Text;

namespace CarsFactoryConsole
{
    /// <summary>
    /// Represents metadata information when details print on screen.
    /// </summary>
    public class DisplayMetaData
    {
        public string TimerDetails { get; set; }
        public string Message { get; set; }
        public MessageType MessageType { get; set; }
    }

    /// <summary>
    /// Message type enumeration.
    /// </summary>
    public enum MessageType
    {
        Error,
        Information,
        Success,
        Failed,
        Warning
    }
}
