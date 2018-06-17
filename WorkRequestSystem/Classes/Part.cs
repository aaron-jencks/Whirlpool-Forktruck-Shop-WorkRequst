using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;
using Excel = Microsoft.Office.Interop.Excel;

namespace DavesMasterWorkOrderRequestDatabase.Classes
{
    /// <summary>
    /// Contains information about a part for a piece of equipment.
    /// </summary>
    public class Part
    {
        #region Properties

        private string name;
        private string partNumber;

        #endregion

        #region Accessor Methods

        /// <summary>
        /// Name of the part
        /// </summary>
        public string Name { get => name; set => name = value; }

        /// <summary>
        /// Part number of the part
        /// </summary>
        public string PartNumber { get => partNumber; set => partNumber = value; }

        #endregion

        public Part(string name = "", string partNumber = "")
        {
            this.name = name;
            this.partNumber = partNumber;
        }

        #region Methods

        #region File Methods

        /// <summary>
        /// Reads a part from a data string
        /// </summary>
        /// <param name="data">Data string containing the part</param>
        /// <returns>Returns the part contained in the string</returns>
        public static Part ReadFromFile(string data)
        {
            return new Part();
        }

        /// <summary>
        /// Saves a part to a data string
        /// </summary>
        public virtual string WriteToString()
        {
            return "";
        }

        #region XML

        /// <summary>
        /// Converts the part into its xml schema
        /// </summary>
        /// <returns>Returns the XElement containing the part</returns>
        public XElement ConvertToXml()
        {
            return new XElement("Part",
                new XAttribute("Name", name),
                new XAttribute("Number", partNumber));
        }

        /// <summary>
        /// Loads the part from an xml element
        /// </summary>
        /// <param name="element">XElement to load from</param>
        public static Part LoadFromXml(XElement element)
        {
            return new Part();
        }

        #endregion

        #endregion

        #endregion
    }
}
