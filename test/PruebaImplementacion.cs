using System;
using System.Xml;
using UnitTestProject1.Entities;
using Wheel.Configuration.XML;

namespace UnitTestProject1
{
    public class ManagerConfiguracionPrueba : ConfiguracionXmlManager<Configuracion>
    {
        public override string NombreArchivoPorDefecto
        {
            get { return "Configuracion.Xml"; }
        }

        public override string NombreArchivoValidacionPorDefecto
        {
            get { return "Configuracion.xsd"; }
        }

        public override string NombreArchivoConfiguracion
        {
            get { return "ConfiguracionPrueba"; }
        }

        public override string NombreArchivoValidacionConfiguracion
        {
            get { return "ValidacionConfiguracionPrueba"; }
        }

        protected override bool ValidarXmlSchema
        {
            get { return true; }
        }

        protected override void ValidarXml(XmlDocument documento)
        {
            throw new NotImplementedException();
        }
    }
}
