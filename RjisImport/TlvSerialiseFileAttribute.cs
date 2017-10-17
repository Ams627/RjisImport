using System;

namespace RjisImport
{
    internal class TlvSerialiseFileAttribute : Attribute
    {
        private readonly string _filename;
        public TlvSerialiseFileAttribute(string filename)
        {
            _filename = filename;
        }
        public String Filename => _filename;
    }
}