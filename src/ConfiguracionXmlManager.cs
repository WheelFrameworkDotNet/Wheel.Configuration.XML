using System;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using Wheel.Configuration.Exceptions;
using Wheel.Util.FileSystem;

namespace Wheel.Configuration.XML
{
    /// <summary>
    /// Representa un administrador para un archivo de configuración XML externo.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         <h2 class="groupheader">Registro de versiones</h2>
    ///         <ul>
    ///             <li>1.0.0</li>
    ///             <table>
    ///                 <tr style="font-weight: bold;">
    ///                     <td>Autor</td>
    ///                     <td>Fecha</td>
    ///                     <td>Descripción</td>
    ///                 </tr>
    ///                 <tr>
    ///                     <td>Marcos Abraham Hernández Bravo.</td>
    ///                     <td>10/11/2016</td>
    ///                     <td>Versión Inicial.</td>
    ///                 </tr>
    ///             </table>
    ///         </ul>
    ///     </para>
    /// </remarks>
    /// <typeparam name="T">Tipo de la entidad que representa el archivo de configuración.</typeparam>
    public abstract class ConfiguracionXmlManager<T>
    {
        /// <summary>
        /// Entidad de configuración.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         <h2 class="groupheader">Registro de versiones</h2>
        ///         <ul>
        ///             <li>1.0.0</li>
        ///             <table>
        ///                 <tr style="font-weight: bold;">
        ///                     <td>Autor</td>
        ///                     <td>Fecha</td>
        ///                     <td>Descripción</td>
        ///                 </tr>
        ///                 <tr>
        ///                     <td>Marcos Abraham Hernández Bravo.</td>
        ///                     <td>07/11/2016</td>
        ///                     <td>Versión Inicial.</td>
        ///                 </tr>
        ///             </table>
        ///         </ul>
        ///     </para>
        /// </remarks>
        private static T Configuracion;

        /// <summary>
        /// Fecha de última modificación del archivo.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         <h2 class="groupheader">Registro de versiones</h2>
        ///         <ul>
        ///             <li>1.0.0</li>
        ///             <table>
        ///                 <tr style="font-weight: bold;">
        ///                     <td>Autor</td>
        ///                     <td>Fecha</td>
        ///                     <td>Descripción</td>
        ///                 </tr>
        ///                 <tr>
        ///                     <td>Marcos Abraham Hernández Bravo.</td>
        ///                     <td>07/11/2016</td>
        ///                     <td>Versión Inicial.</td>
        ///                 </tr>
        ///             </table>
        ///         </ul>
        ///     </para>
        /// </remarks>
        private static DateTime FechaUltimaModificacion;

        /// <summary>
        /// Obtiene el nombre del archivo si no se especifica uno.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         <h2 class="groupheader">Registro de versiones</h2>
        ///         <ul>
        ///             <li>1.0.0</li>
        ///             <table>
        ///                 <tr style="font-weight: bold;">
        ///                     <td>Autor</td>
        ///                     <td>Fecha</td>
        ///                     <td>Descripción</td>
        ///                 </tr>
        ///                 <tr>
        ///                     <td>Marcos Abraham Hernández Bravo.</td>
        ///                     <td>07/11/2016</td>
        ///                     <td>Versión Inicial.</td>
        ///                 </tr>
        ///             </table>
        ///         </ul>
        ///     </para>
        /// </remarks>
        public abstract string NombreArchivoPorDefecto { get; }

        /// <summary>
        /// Obtiene el nombre del archivo de esquema (XSD) si no se especifica uno.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         <h2 class="groupheader">Registro de versiones</h2>
        ///         <ul>
        ///             <li>1.0.0</li>
        ///             <table>
        ///                 <tr style="font-weight: bold;">
        ///                     <td>Autor</td>
        ///                     <td>Fecha</td>
        ///                     <td>Descripción</td>
        ///                 </tr>
        ///                 <tr>
        ///                     <td>Marcos Abraham Hernández Bravo.</td>
        ///                     <td>07/11/2016</td>
        ///                     <td>Versión Inicial.</td>
        ///                 </tr>
        ///             </table>
        ///         </ul>
        ///     </para>
        /// </remarks>
        public abstract string NombreArchivoValidacionPorDefecto { get; }

        /// <summary>
        /// Obtiene el nombre del archivo que sirbe como clave para obtener su ruta mediante Wheel.Configuration.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         <h2 class="groupheader">Registro de versiones</h2>
        ///         <ul>
        ///             <li>1.0.0</li>
        ///             <table>
        ///                 <tr style="font-weight: bold;">
        ///                     <td>Autor</td>
        ///                     <td>Fecha</td>
        ///                     <td>Descripción</td>
        ///                 </tr>
        ///                 <tr>
        ///                     <td>Marcos Abraham Hernández Bravo.</td>
        ///                     <td>07/11/2016</td>
        ///                     <td>Versión Inicial.</td>
        ///                 </tr>
        ///             </table>
        ///         </ul>
        ///     </para>
        /// </remarks>
        public abstract string NombreArchivoConfiguracion { get; }

        /// <summary>
        /// Obtiene el nombre del archivo de esquema (XSD) que sirbe como clave para obtener su ruta mediante Wheel.Configuration.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         <h2 class="groupheader">Registro de versiones</h2>
        ///         <ul>
        ///             <li>1.0.0</li>
        ///             <table>
        ///                 <tr style="font-weight: bold;">
        ///                     <td>Autor</td>
        ///                     <td>Fecha</td>
        ///                     <td>Descripción</td>
        ///                 </tr>
        ///                 <tr>
        ///                     <td>Marcos Abraham Hernández Bravo.</td>
        ///                     <td>07/11/2016</td>
        ///                     <td>Versión Inicial.</td>
        ///                 </tr>
        ///             </table>
        ///         </ul>
        ///     </para>
        /// </remarks>
        public abstract string NombreArchivoValidacionConfiguracion { get; }

        /// <summary>
        /// Obtiene un valor que indica si el archivo de configuración XML debe ser validado mediante un XSD.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         <h2 class="groupheader">Registro de versiones</h2>
        ///         <ul>
        ///             <li>1.0.0</li>
        ///             <table>
        ///                 <tr style="font-weight: bold;">
        ///                     <td>Autor</td>
        ///                     <td>Fecha</td>
        ///                     <td>Descripción</td>
        ///                 </tr>
        ///                 <tr>
        ///                     <td>Marcos Abraham Hernández Bravo.</td>
        ///                     <td>07/11/2016</td>
        ///                     <td>Versión Inicial.</td>
        ///                 </tr>
        ///             </table>
        ///         </ul>
        ///     </para>
        /// </remarks>
        protected abstract bool ValidarXmlSchema { get; }

        /// <summary>
        /// Obtiene la ruta absoluta del archivo XML.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         <h2 class="groupheader">Registro de versiones</h2>
        ///         <ul>
        ///             <li>1.0.0</li>
        ///             <table>
        ///                 <tr style="font-weight: bold;">
        ///                     <td>Autor</td>
        ///                     <td>Fecha</td>
        ///                     <td>Descripción</td>
        ///                 </tr>
        ///                 <tr>
        ///                     <td>Marcos Abraham Hernández Bravo.</td>
        ///                     <td>07/11/2016</td>
        ///                     <td>Versión Inicial.</td>
        ///                 </tr>
        ///             </table>
        ///         </ul>
        ///     </para>
        /// </remarks>
        public virtual string RutaArchivo
        {
            get
            {
                string ruta = WheelConfigurationManager.ObtenerRutaArchivoConfiguracion(NombreArchivoConfiguracion);
                return FileSystemUtil.ObtenerRutaArchivo(ruta, NombreArchivoPorDefecto);
            }
        }

        /// <summary>
        /// Obtiene la ruta absoluta del archivo de esquema XSD.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         <h2 class="groupheader">Registro de versiones</h2>
        ///         <ul>
        ///             <li>1.0.0</li>
        ///             <table>
        ///                 <tr style="font-weight: bold;">
        ///                     <td>Autor</td>
        ///                     <td>Fecha</td>
        ///                     <td>Descripción</td>
        ///                 </tr>
        ///                 <tr>
        ///                     <td>Marcos Abraham Hernández Bravo.</td>
        ///                     <td>07/11/2016</td>
        ///                     <td>Versión Inicial.</td>
        ///                 </tr>
        ///             </table>
        ///         </ul>
        ///     </para>
        /// </remarks>
        public virtual string RutaArchivoEsquema
        {
            get
            {
                string ruta = WheelConfigurationManager.ObtenerRutaArchivoConfiguracion(NombreArchivoValidacionConfiguracion);
                return FileSystemUtil.ObtenerRutaArchivo(ruta, NombreArchivoValidacionPorDefecto);
            }
        }

        /// <summary>
        /// Valida el archivo XML de forma manual.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         <h2 class="groupheader">Registro de versiones</h2>
        ///         <ul>
        ///             <li>1.0.0</li>
        ///             <table>
        ///                 <tr style="font-weight: bold;">
        ///                     <td>Autor</td>
        ///                     <td>Fecha</td>
        ///                     <td>Descripción</td>
        ///                 </tr>
        ///                 <tr>
        ///                     <td>Marcos Abraham Hernández Bravo.</td>
        ///                     <td>07/11/2016</td>
        ///                     <td>Versión Inicial.</td>
        ///                 </tr>
        ///             </table>
        ///         </ul>
        ///     </para>
        /// </remarks>
        /// <param name="documento">Documento XML.</param>
        protected abstract void ValidarXml(XmlDocument documento);

        /// <summary>
        /// Obtiene una entidad que representa el XML con la configuración cargada desde el archivo.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         <h2 class="groupheader">Registro de versiones</h2>
        ///         <ul>
        ///             <li>1.0.0</li>
        ///             <table>
        ///                 <tr style="font-weight: bold;">
        ///                     <td>Autor</td>
        ///                     <td>Fecha</td>
        ///                     <td>Descripción</td>
        ///                 </tr>
        ///                 <tr>
        ///                     <td>Marcos Abraham Hernández Bravo.</td>
        ///                     <td>07/11/2016</td>
        ///                     <td>Versión Inicial.</td>
        ///                 </tr>
        ///             </table>
        ///         </ul>
        ///     </para>
        /// </remarks>
        /// <returns></returns>
        public virtual T ObtenerConfiguracion()
        {
            return ObtenerConfiguracion(RutaArchivo);
        }

        /// <summary>
        /// Obtiene una entidad que representa el XML con la configuración cargada desde la ruta del archivo especificada.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         <h2 class="groupheader">Registro de versiones</h2>
        ///         <ul>
        ///             <li>1.0.0</li>
        ///             <table>
        ///                 <tr style="font-weight: bold;">
        ///                     <td>Autor</td>
        ///                     <td>Fecha</td>
        ///                     <td>Descripción</td>
        ///                 </tr>
        ///                 <tr>
        ///                     <td>Marcos Abraham Hernández Bravo.</td>
        ///                     <td>07/11/2016</td>
        ///                     <td>Versión Inicial.</td>
        ///                 </tr>
        ///             </table>
        ///         </ul>
        ///     </para>
        /// </remarks>
        /// <param name="ruta">Ruta del archivo.</param>
        /// <returns></returns>
        public virtual T ObtenerConfiguracion(string ruta)
        {
            return ObtenerConfiguracion(null, ruta); 
        }

        /// <summary>
        /// Obtiene una entidad que representa el XML con la configuración cargada desde la ruta del archivo especificada.
        /// Además se solicita una ruta referencial con la cual se determina la ruta absoluta del archivo.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         <h2 class="groupheader">Registro de versiones</h2>
        ///         <ul>
        ///             <li>1.0.0</li>
        ///             <table>
        ///                 <tr style="font-weight: bold;">
        ///                     <td>Autor</td>
        ///                     <td>Fecha</td>
        ///                     <td>Descripción</td>
        ///                 </tr>
        ///                 <tr>
        ///                     <td>Marcos Abraham Hernández Bravo.</td>
        ///                     <td>07/11/2016</td>
        ///                     <td>Versión Inicial.</td>
        ///                 </tr>
        ///             </table>
        ///         </ul>
        ///     </para>
        /// </remarks>
        /// <param name="rutaReferencial">Ruta referencial para determinar la ruta absoluta.</param>
        /// <param name="ruta">Ruta del archivo.</param>
        /// <returns></returns>
        public virtual T ObtenerConfiguracion(string rutaReferencial, string ruta)
        {
            try
            {
                ruta = FileSystemUtil.ObtenerRutaAbsoluta(rutaReferencial, ruta);

                DateTime fechaUltimaModificacionActual = FileSystemUtil.ObtenerFechaUltimaModificacion(ruta);

                if (fechaUltimaModificacionActual > FechaUltimaModificacion)
                {
                    if (ValidarXmlSchema)
                    {
                        ValidarContraXmlSchema();
                    }
                    else
                    {
                        XmlDocument doc = ObtenerXmlDocument(ruta);
                        ValidarXml(doc);
                    }

                    XmlSerializer serializer = ObtenerXmlSerializer();

                    FileStream file = null;

                    try
                    {
                        file = ObtenerFileStreamForRead(ruta);
                        Configuracion = Deserialize(serializer, file);
                    }
                    finally
                    {
                        if (file != null)
                        {
                            file.Close();
                        }
                    }

                    FechaUltimaModificacion = fechaUltimaModificacionActual;
                }
                return Configuracion;
            }
            catch (Exception ex)
            {
                throw new WheelConfigurationException(string.Format("!Error al obtener la configuración de {0}!. {1}", NombreArchivoConfiguracion, ex.Message), ex);
            }
        }

        /// <summary>
        /// Persiste la configuración encapsulada en una entidad, al archivo XML.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         <h2 class="groupheader">Registro de versiones</h2>
        ///         <ul>
        ///             <li>1.0.0</li>
        ///             <table>
        ///                 <tr style="font-weight: bold;">
        ///                     <td>Autor</td>
        ///                     <td>Fecha</td>
        ///                     <td>Descripción</td>
        ///                 </tr>
        ///                 <tr>
        ///                     <td>Marcos Abraham Hernández Bravo.</td>
        ///                     <td>07/11/2016</td>
        ///                     <td>Versión Inicial.</td>
        ///                 </tr>
        ///             </table>
        ///         </ul>
        ///     </para>
        /// </remarks>
        /// <param name="config">Entidad representativa.</param>
        public virtual void GuardarConfiguracion(T config)
        {
            GuardarConfiguracion(config, RutaArchivo);
        }

        /// <summary>
        /// Persiste la configuración encapsulada en una entidad, al archivo XML según la ruta señalada.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         <h2 class="groupheader">Registro de versiones</h2>
        ///         <ul>
        ///             <li>1.0.0</li>
        ///             <table>
        ///                 <tr style="font-weight: bold;">
        ///                     <td>Autor</td>
        ///                     <td>Fecha</td>
        ///                     <td>Descripción</td>
        ///                 </tr>
        ///                 <tr>
        ///                     <td>Marcos Abraham Hernández Bravo.</td>
        ///                     <td>07/11/2016</td>
        ///                     <td>Versión Inicial.</td>
        ///                 </tr>
        ///             </table>
        ///         </ul>
        ///     </para>
        /// </remarks>
        /// <param name="config">Entidad representativa.</param>
        /// <param name="ruta">Ruta del archivo.</param>
        public virtual void GuardarConfiguracion(T config, string ruta)
        {
            GuardarConfiguracion(config, null, ruta);
        }

        /// <summary>
        /// Persiste la configuración encapsulada en una entidad, al archivo XML según la ruta señalada.
        /// Además se solicita una ruta referencial con la cual se determina la ruta absoluta del archivo.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         <h2 class="groupheader">Registro de versiones</h2>
        ///         <ul>
        ///             <li>1.0.0</li>
        ///             <table>
        ///                 <tr style="font-weight: bold;">
        ///                     <td>Autor</td>
        ///                     <td>Fecha</td>
        ///                     <td>Descripción</td>
        ///                 </tr>
        ///                 <tr>
        ///                     <td>Marcos Abraham Hernández Bravo.</td>
        ///                     <td>07/11/2016</td>
        ///                     <td>Versión Inicial.</td>
        ///                 </tr>
        ///             </table>
        ///         </ul>
        ///     </para>
        /// </remarks>
        /// <param name="config">Entidad representativa.</param> 
        /// <param name="rutaReferencial">Ruta referencial para determinar la ruta absoluta.</param>
        /// <param name="ruta">Ruta del archivo.</param>
        public virtual void GuardarConfiguracion(T config, string rutaReferencial, string ruta)
        {
            ruta = FileSystemUtil.ObtenerRutaAbsoluta(rutaReferencial, ruta);

            FileStream file = null;

            try
            {
                XmlSerializer serializer = ObtenerXmlSerializer();

                file = ObtenerFileStreamForWrite(ruta);
                Serialize(serializer, file, config);
            }
            finally
            {
                if (file != null)
                {
                    file.Close();
                }
            }
        }

        /// <summary>
        /// Valida el archivo XML contra su esquema (XSD).
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         <h2 class="groupheader">Registro de versiones</h2>
        ///         <ul>
        ///             <li>1.0.0</li>
        ///             <table>
        ///                 <tr style="font-weight: bold;">
        ///                     <td>Autor</td>
        ///                     <td>Fecha</td>
        ///                     <td>Descripción</td>
        ///                 </tr>
        ///                 <tr>
        ///                     <td>Marcos Abraham Hernández Bravo.</td>
        ///                     <td>07/11/2016</td>
        ///                     <td>Versión Inicial.</td>
        ///                 </tr>
        ///             </table>
        ///         </ul>
        ///     </para>
        /// </remarks>
        protected virtual void ValidarContraXmlSchema()
        {
            XmlDocument doc = new XmlDocument();
            XmlReader reader = null;

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.Schemas.Add(string.Empty, RutaArchivoEsquema);
            settings.ValidationType = ValidationType.Schema;

            try
            {
                reader = XmlReader.Create(RutaArchivo, settings);
                doc.Load(reader);
                doc.Validate(ErrorAlValidar);
            }
            catch (XmlSchemaValidationException xmlValException)
            {
                if (reader != null)
                {
                    reader.Close();
                }
                throw new WheelConfigurationException(string.Format("!Archivo de configuración {0} erróneo!. {1}", NombreArchivoConfiguracion, xmlValException.Message));
            }
            catch (IOException ioE)
            {
                if (reader != null)
                {
                    reader.Close();
                }
                throw new WheelConfigurationException(string.Format("¡No se ha encontrado el archivo de configuración {0} o su esquema!", NombreArchivoConfiguracion), ioE);
            }
        }

        /// <summary>
        /// Evento que relanza la excepción al ocurrir un error de validación en el archivo XML.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         <h2 class="groupheader">Registro de versiones</h2>
        ///         <ul>
        ///             <li>1.0.0</li>
        ///             <table>
        ///                 <tr style="font-weight: bold;">
        ///                     <td>Autor</td>
        ///                     <td>Fecha</td>
        ///                     <td>Descripción</td>
        ///                 </tr>
        ///                 <tr>
        ///                     <td>Marcos Abraham Hernández Bravo.</td>
        ///                     <td>07/11/2016</td>
        ///                     <td>Versión Inicial.</td>
        ///                 </tr>
        ///             </table>
        ///         </ul>
        ///     </para>
        /// </remarks>
        /// <param name="sender">Objeto que inicia el evento.</param>
        /// <param name="e">Argumento del evento.</param>
        protected virtual void ErrorAlValidar(object sender, ValidationEventArgs e)
        {
            throw new WheelConfigurationException(string.Format("!Archivo de configuración {0} erróneo!. {1}", NombreArchivoConfiguracion, e.Message));
        }

        /// <summary>
        /// Obtiene el archivo XML como un objeto de documento XML.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         <h2 class="groupheader">Registro de versiones</h2>
        ///         <ul>
        ///             <li>1.0.0</li>
        ///             <table>
        ///                 <tr style="font-weight: bold;">
        ///                     <td>Autor</td>
        ///                     <td>Fecha</td>
        ///                     <td>Descripción</td>
        ///                 </tr>
        ///                 <tr>
        ///                     <td>Marcos Abraham Hernández Bravo.</td>
        ///                     <td>07/11/2016</td>
        ///                     <td>Versión Inicial.</td>
        ///                 </tr>
        ///             </table>
        ///         </ul>
        ///     </para>
        /// </remarks>
        /// <param name="ruta">Ruta del archivo.</param>
        /// <returns></returns>
        protected virtual XmlDocument ObtenerXmlDocument(string ruta)
        {
            XmlDocument retorno = new XmlDocument();
            retorno.Load(ruta);
            return retorno;
        }

        /// <summary>
        /// Obtiene el serializador XML del archivo.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         <h2 class="groupheader">Registro de versiones</h2>
        ///         <ul>
        ///             <li>1.0.0</li>
        ///             <table>
        ///                 <tr style="font-weight: bold;">
        ///                     <td>Autor</td>
        ///                     <td>Fecha</td>
        ///                     <td>Descripción</td>
        ///                 </tr>
        ///                 <tr>
        ///                     <td>Marcos Abraham Hernández Bravo.</td>
        ///                     <td>07/11/2016</td>
        ///                     <td>Versión Inicial.</td>
        ///                 </tr>
        ///             </table>
        ///         </ul>
        ///     </para>
        /// </remarks>
        /// <returns></returns>
        protected virtual XmlSerializer ObtenerXmlSerializer()
        {
            XmlSerializer retorno = new XmlSerializer(typeof(T));
            return retorno;
        }

        /// <summary>
        /// Obtiene el objeto FileStream en modo de léctura del archivo.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         <h2 class="groupheader">Registro de versiones</h2>
        ///         <ul>
        ///             <li>1.0.0</li>
        ///             <table>
        ///                 <tr style="font-weight: bold;">
        ///                     <td>Autor</td>
        ///                     <td>Fecha</td>
        ///                     <td>Descripción</td>
        ///                 </tr>
        ///                 <tr>
        ///                     <td>Marcos Abraham Hernández Bravo.</td>
        ///                     <td>07/11/2016</td>
        ///                     <td>Versión Inicial.</td>
        ///                 </tr>
        ///             </table>
        ///         </ul>
        ///     </para>
        /// </remarks>
        /// <param name="ruta">Ruta el archivo.</param>
        /// <returns></returns>
        protected virtual FileStream ObtenerFileStreamForRead(string ruta)
        {
            FileStream retorno = new FileStream(ruta, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            return retorno;
        }

        /// <summary>
        /// Obtiene el objeto FileStream en modo de escritura del archivo.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         <h2 class="groupheader">Registro de versiones</h2>
        ///         <ul>
        ///             <li>1.0.0</li>
        ///             <table>
        ///                 <tr style="font-weight: bold;">
        ///                     <td>Autor</td>
        ///                     <td>Fecha</td>
        ///                     <td>Descripción</td>
        ///                 </tr>
        ///                 <tr>
        ///                     <td>Marcos Abraham Hernández Bravo.</td>
        ///                     <td>07/11/2016</td>
        ///                     <td>Versión Inicial.</td>
        ///                 </tr>
        ///             </table>
        ///         </ul>
        ///     </para>
        /// </remarks>
        /// <param name="ruta">Ruta el archivo.</param>
        /// <returns></returns>
        protected virtual FileStream ObtenerFileStreamForWrite(string ruta)
        {
            FileStream retorno = new FileStream(ruta, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
            return retorno;
        }

        /// <summary>
        /// Deserializa un FileStream en una entidad representativa.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         <h2 class="groupheader">Registro de versiones</h2>
        ///         <ul>
        ///             <li>1.0.0</li>
        ///             <table>
        ///                 <tr style="font-weight: bold;">
        ///                     <td>Autor</td>
        ///                     <td>Fecha</td>
        ///                     <td>Descripción</td>
        ///                 </tr>
        ///                 <tr>
        ///                     <td>Marcos Abraham Hernández Bravo.</td>
        ///                     <td>07/11/2016</td>
        ///                     <td>Versión Inicial.</td>
        ///                 </tr>
        ///             </table>
        ///         </ul>
        ///     </para>
        /// </remarks>
        /// <param name="serializer">Serializador XML para lectura.</param>
        /// <param name="file">Archivo XML para lectura.</param>
        /// <returns></returns>
        protected virtual T Deserialize(XmlSerializer serializer, FileStream file)
        {
            return (T)serializer.Deserialize(file);
        }

        /// <summary>
        /// Serializa una entidad representativa a un archivo XML en disco.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         <h2 class="groupheader">Registro de versiones</h2>
        ///         <ul>
        ///             <li>1.0.0</li>
        ///             <table>
        ///                 <tr style="font-weight: bold;">
        ///                     <td>Autor</td>
        ///                     <td>Fecha</td>
        ///                     <td>Descripción</td>
        ///                 </tr>
        ///                 <tr>
        ///                     <td>Marcos Abraham Hernández Bravo.</td>
        ///                     <td>07/11/2016</td>
        ///                     <td>Versión Inicial.</td>
        ///                 </tr>
        ///             </table>
        ///         </ul>
        ///     </para>
        /// </remarks>
        /// <param name="serializer">Serializador XML.</param>
        /// <param name="file">Archivo XML para escribir.</param>
        /// <param name="obj">Entidad con datos a persistir.</param>
        protected virtual void Serialize(XmlSerializer serializer, FileStream file, T obj)
        {
            serializer.Serialize(file, obj);
        }
    }
}