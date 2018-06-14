using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;

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
        /// Reads a part from a file
        /// </summary>
        /// <param name="path">Path pointing to the file</param>
        /// <returns>Returns the part contained in the file</returns>
        public static Part ReadFromFile(string path)
        {
            return new Part();
        }

        /// <summary>
        /// Saves a part to a file
        /// </summary>
        /// <param name="path">Path pointing to the file</param>
        public virtual void WriteToFile(string path)
        {

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
