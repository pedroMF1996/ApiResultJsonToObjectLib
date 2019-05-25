using System;

namespace APIJsonResultObjectLib.CustomException
{
    public class ExcecaoPersonalizada:ApplicationException
    {
        public string Msg { get; set; }

        public ExcecaoPersonalizada(string message) : base(message)
        {
        }
    }
}