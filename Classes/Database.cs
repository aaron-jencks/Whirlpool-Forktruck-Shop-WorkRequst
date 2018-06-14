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
    /// Contains all of the lists required for the program operation
    /// </summary>
    public class Database
    {
        #region Properties

        #region Lists

        private List<Equipment> equipmentList;
        private List<Part> partList;
        private List<WorkRequest> workRequestList;

        #endregion

        private string filePath;

        #endregion

        public Database(string filePath = "")
        {
            this.FilePath = filePath;
            EquipmentList = new List<Equipment>();
            PartList = new List<Part>();
            WorkRequestList = new List<WorkRequest>();
        }

        #region Accessor Methods

        /// <summary>
        /// List of usable equipment
        /// </summary>
        public List<Equipment> EquipmentList { get => equipmentList; set => equipmentList = value; }

        /// <summary>
        /// List of usable parts
        /// </summary>
        public List<Part> PartList { get => partList; set => partList = value; }

        /// <summary>
        /// List of current work requests
        /// </summary>
        public List<WorkRequest> WorkRequestList { get => workRequestList; set => workRequestList = value; }

        /// <summary>
        /// Path pointing to the database's current location
        /// </summary>
        public string FilePath { get => filePath; set => filePath = value; }

        #endregion

        #region Operator Methods

        #region Addition

        /// <summary>
        /// Adds an equipment to the list of usable equipment
        /// </summary>
        /// <param name="db">Database to add the equipment to</param>
        /// <param name="equip">Equipment to add</param>
        /// <returns>Returns the original database object</returns>
        public static Database operator +(Database db, Equipment equip)
        {
            db.equipmentList.Add(equip);
            return db;
        }

        /// <summary>
        /// Adds a part to the list of usable parts
        /// </summary>
        /// <param name="db">Database to add the equipment to</param>
        /// <param name="part">Part to add</param>
        /// <returns>Returns the original database object</returns>
        public static Database operator +(Database db, Part part)
        {
            db.partList.Add(part);
            return db;
        }


        /// <summary>
        /// Adds a work request to the list of work requests
        /// </summary>
        /// <param name="db">Database to add the equipment to</param>
        /// <param name="req">Work request to add</param>
        /// <returns>Returns the original database object</returns>
        public static Database operator +(Database db, WorkRequest req)
        {
            db.workRequestList.Add(req);
            return db;
        }

        #endregion

        #region Subtraction

        /// <summary>
        /// Removes an equipment to the list of usable equipment
        /// </summary>
        /// <param name="db">Database to remove the equipment from</param>
        /// <param name="equip">Equipment to remove</param>
        /// <returns>Returns the original database object</returns>
        public static Database operator -(Database db, Equipment equip)
        {
            db.equipmentList.Remove(equip);
            return db;
        }

        /// <summary>
        /// Removes a part from the list of usable parts
        /// </summary>
        /// <param name="db">Database to remove the equipment from</param>
        /// <param name="part">Part to remove</param>
        /// <returns>Returns the original database object</returns>
        public static Database operator -(Database db, Part part)
        {
            db.partList.Add(part);
            return db;
        }


        /// <summary>
        /// Removes a work request from the list of work requests
        /// </summary>
        /// <param name="db">Database to remove the equipment from</param>
        /// <param name="req">Work request to remove</param>
        /// <returns>Returns the original database object</returns>
        public static Database operator -(Database db, WorkRequest req)
        {
            db.workRequestList.Add(req);
            return db;
        }

        #endregion

        #endregion

        #region Methods

        #region File Methods

        /// <summary>
        /// Reads in a database from a file
        /// </summary>
        /// <param name="path">Path pointing to the file</param>
        /// <returns>Returns the database contined in the file</returns>
        public static Database ReadFromFile(string path)
        {
            return new Database(path);
        }

        /// <summary>
        /// Writes a database to a file
        /// </summary>
        /// <param name="path">Path pointing to the file</param>
        public virtual void WriteToFile(string path)
        {

        }

        /// <summary>
        /// Exports the current database to a comma-delimmeted text file
        /// </summary>
        /// <param name="path">Path pointing to the file</param>
        public void ExportToText(string path)
        {

        }

        #region XML

        /// <summary>
        /// Converts the database into its xml schema
        /// </summary>
        /// <returns>Returns the XElement containing the database</returns>
        public XElement ConvertToXml()
        {
            return new XElement("Database");
        }

        /// <summary>
        /// Loads the database from an xml element
        /// </summary>
        /// <param name="element">XElement to load from</param>
        public static Database LoadFromXml(XElement element)
        {
            return new Database();
        }

        #endregion

        #endregion

        #endregion
    }
}
