using System.Runtime.Serialization;

namespace Olimpiadas.CrossCutting.Enumerations
{
    /// <summary>
    /// Tipo de formato para retornas reportes, estos deben ser iguales a la enumeracion de CrystalReports
    /// </summary>
    [DataContract]
    public enum EnumFormatoReporte
    {
        /// <summary>
        /// Formato PDF
        /// </summary>
        [EnumMember]
        NoFormat = 0,

        /// <summary>
        /// Formato PDF
        /// </summary>
        [EnumMember]
        PortableDocFormat = 1,

        /// <summary>
        /// Formato Excel
        /// </summary>
        [EnumMember]
        Excel = 2,

        /// <summary>
        /// Formato Excel Datos
        /// </summary>
        [EnumMember]
        ExcelRecord = 3,

        /// <summary>
        /// Formato HTML32
        /// </summary>
        [EnumMember]
        HTML32 = 4,

        /// <summary>
        /// Formato HTML 4
        /// </summary>
        [EnumMember]
        HTML40 = 5,

        /// <summary>
        /// Formato de texto plano
        /// </summary>
        [EnumMember]
        Text = 6,

        /// <summary>
        /// Formato word
        /// </summary>
        [EnumMember]
        WordForWindows = 7,

        /// <summary>
        /// Formato XML.
        /// </summary>
        [EnumMember]
        Xml = 8,

        /// <summary>
        /// Formato Crystalreport.
        /// </summary>
        [EnumMember]
        CrystalReport = 9
    }

    /// <summary>
    /// Tipo de formato para retornas reportes, estos deben ser iguales a la enumeracion de CrystalReports
    /// </summary>
    [DataContract(Name = "FormatoReporteEnumReportViewer")]
    public enum FormatoReporteEnumReportViewer
    {
        /// <summary>
        /// Formato PDF
        /// </summary>
        [EnumMember]
        PortableDocFormat = 0,

        /// <summary>
        /// Formato Excel
        /// </summary>
        [EnumMember]
        Excel = 1,

        /// <summary>
        /// Formato Excel Datos
        /// </summary>
        [EnumMember]
        ExcelRecord = 2,

        /// <summary>
        /// Formato word
        /// </summary>
        [EnumMember]
        Word = 3,

        /// <summary>
        /// Formato XML.
        /// </summary>
        [EnumMember]
        Image = 4
    }
}