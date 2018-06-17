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
    /// Used to encase Equipment data for equipment (duh...)
    /// </summary>
    public class Equipment
    {
        #region Properties

        private string equipmentNumber;
        private string department;
        private string serialNumber;
        private string modelNumber;
        private string brand;
        private string equipmentType;
        private string equipmentOperator;
        private List<Part> usableParts;

        #endregion

        public Equipment(string equipmentNumber = "", string department = "",
            string serialNumber = "", string modelNumber = "", string brand = "", string equipmentType = "", string equipmentOperator = "",
            List<Part> usableParts = null)
        {
            this.equipmentNumber = equipmentNumber;
            this.department = department;
            this.serialNumber = serialNumber;
            this.modelNumber = modelNumber;
            this.brand = brand;
            this.equipmentType = equipmentType;
            this.equipmentOperator = equipmentOperator;
            UsableParts = usableParts??new List<Part>();
        }

        #region Methods

        /// <summary>
        /// Returns whether the part currently exists in the equipment's valid parts list
        /// </summary>
        /// <param name="part">The part to check for.</param>
        /// <returns>Returns true if the part exists in the parts list</returns>
        public bool isValidPart(Part part)
        {
            return UsableParts.Find((Part p) => { return p.PartNumber == part.PartNumber; }) != null;
        }

        #region File Methods

        /// <summary>
        /// Reads an equipment piece from a data string
        /// </summary>
        /// <param name="data">Data string containing the equipment</param>
        /// <returns>Returns the equipment contained in the string</returns>
        public static Equipment ReadFromString(string data)
        {
            return new Equipment();
        }

        /// <summary>
        /// Converts a equipment to a data string
        /// </summary>
        public virtual string WriteToString()
        {
            return "";
        }

        #region XML

        /// <summary>
        /// Converts the equipment into its xml schema
        /// </summary>
        /// <returns>Returns the XElement containing the equipment</returns>
        public XElement ConvertToXml()
        {
            return new XElement("Equipment");
        }

        /// <summary>
        /// Loads the equipment from an xml element
        /// </summary>
        /// <param name="element">XElement to load from</param>
        public static Equipment LoadFromXml(XElement element)
        {
            return new Equipment();
        }

        #endregion

        #endregion

        #endregion

        #region Operators

        /// <summary>
        /// Adds a part to the usable parts list
        /// </summary>
        /// <param name="equip">The equipment to add the part to</param>
        /// <param name="part">The part to add</param>
        /// <returns>Returns the original equipment object</returns>
        public static Equipment operator +(Equipment equip, Part part)
        {
            equip.UsableParts.Add(part);
            return equip;
        }

        /// <summary>
        /// Removes a part from the usable parts list
        /// </summary>
        /// <param name="equip">The equipment to remove the part from</param>
        /// <param name="part">The part to remove</param>
        /// <returns>Returns the original equipment object</returns>
        public static Equipment operator -(Equipment equip, Part part)
        {
            equip.UsableParts.Remove(part);
            return equip;
        }

        #endregion

        #region Accessor Methods
        /// <summary>
        /// Equipment Number
        /// </summary>
        public string EquipmentNumber { get => equipmentNumber; set => equipmentNumber = value; }

        /// <summary>
        /// Department that the equipment belongs to
        /// </summary>
        public string Department { get => department; set => department = value; }

        /// <summary>
        /// Serial Number of the Equipment
        /// </summary>
        public string SerialNumber { get => serialNumber; set => serialNumber = value; }

        /// <summary>
        /// Model Number of the Equipment
        /// </summary>
        public string ModelNumber { get => modelNumber; set => modelNumber = value; }

        /// <summary>
        /// Brand of the Equipment
        /// </summary>
        public string Brand { get => brand; set => brand = value; }

        /// <summary>
        /// Type of the Equipment
        /// </summary>
        public string EquipmentType { get => equipmentType; set => equipmentType = value; }

        /// <summary>
        /// Operator/Driver of the equipment
        /// </summary>
        public string EquipmentOperator { get => equipmentOperator; set => equipmentOperator = value; }

        /// <summary>
        /// List of parts that can be used on this vehicle, the list of parts is not limited to this list,
        /// It's only for the ease-of-use for part suggestions when creating work requests.
        /// </summary>
        public List<Part> UsableParts { get => usableParts; set => usableParts = value; }
        #endregion
    }
}
