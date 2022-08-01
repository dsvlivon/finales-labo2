using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Entidades
{
    public class NoExisteFileException: Exception
    {
        public NoExisteFileException()
        {

        }
        public NoExisteFileException(string msg)
        {
            ManejadorArchivos<Producto> m = new ManejadorArchivos<Producto>();
            m.GenerarLog(msg);
        }
    }
}