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

        #region Equipment

        /// <summary>
        /// The current list of equipment numbers
        /// </summary>
        public List<string> EquipmentNumbers { get => GetEquipmentNumberList(); }

        /// <summary>
        /// The current list of equipment brands
        /// </summary>
        public List<string> EquipmentBrands { get => GetEquipmentBrandList(); }

        /// <summary>
        /// The current list of equipment serial numbers
        /// </summary>
        public List<string> EquipmentSerialNumbers { get => GetEquipmentSerialNumberList(); }

        /// <summary>
        /// The current list of equipment model numbers
        /// </summary>
        public List<string> EquipmentModelNumbers { get => GetEquipmentModelNumberList(); }

        /// <summary>
        /// The current list of equipment departments
        /// </summary>
        public List<string> EquipmentDepartments { get => GetEquipmentDepartmentList(); }

        /// <summary>
        /// The current list of equipment types
        /// </summary>
        public List<string> EquipmentTypes { get => GetEquipmentTypeList(); }

        /// <summary>
        /// The current list of equipment operators
        /// </summary>
        public List<string> EquipmentOperators { get => GetEquipmentOperatorList(); }

        #endregion

        #region Parts

        /// <summary>
        /// The current list of part names
        /// </summary>
        public List<string> PartNames { get => GetPartNames(); }

        /// <summary>
        /// The current list of part numbers
        /// </summary>
        public List<string> PartNumbers { get => GetPartNumbers(); }

        #endregion

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

        #region Equipment

        /// <summary>
        /// Gets the current list of equipment numbers
        /// </summary>
        /// <returns>Returns the list of equipment numbers as a List</returns>
        private List<string> GetEquipmentNumberList()
        {
            List<string> temp = new List<string>(equipmentList.Count);
            foreach (Equipment eq in equipmentList)
                if(!temp.Contains(eq.EquipmentNumber))                  // Prevents duplicates
                    temp.Add(eq.EquipmentNumber);
            return temp;
        }

        /// <summary>
        /// Gets the current list of equipment brands
        /// </summary>
        /// <returns>Returns the list of equipment brands as a List</returns>
        private List<string> GetEquipmentBrandList()
        {
            List<string> temp = new List<string>(equipmentList.Count);
            foreach (Equipment eq in equipmentList)
                if (!temp.Contains(eq.Brand))                  // Prevents duplicates
                    temp.Add(eq.Brand);
            return temp;
        }

        /// <summary>
        /// Gets the current list of equipment serial numbers
        /// </summary>
        /// <returns>Returns the list of equipment serial numbers as a List</returns>
        private List<string> GetEquipmentSerialNumberList()
        {
            List<string> temp = new List<string>(equipmentList.Count);
            foreach (Equipment eq in equipmentList)
                if (!temp.Contains(eq.SerialNumber))                  // Prevents duplicates
                    temp.Add(eq.SerialNumber);
            return temp;
        }

        /// <summary>
        /// Gets the current list of equipment model numbers
        /// </summary>
        /// <returns>Returns the list of equipment model numbers as a List</returns>
        private List<string> GetEquipmentModelNumberList()
        {
            List<string> temp = new List<string>(equipmentList.Count);
            foreach (Equipment eq in equipmentList)
                if (!temp.Contains(eq.ModelNumber))                  // Prevents duplicates
                    temp.Add(eq.ModelNumber);
            return temp;
        }

        /// <summary>
        /// Gets the current list of equipment departments
        /// </summary>
        /// <returns>Returns the list of equipment departments as a List</returns>
        private List<string> GetEquipmentDepartmentList()
        {
            List<string> temp = new List<string>(equipmentList.Count);
            foreach (Equipment eq in equipmentList)
                if (!temp.Contains(eq.Department))                  // Prevents duplicates
                    temp.Add(eq.Department);
            return temp;
        }

        /// <summary>
        /// Gets the current list of equipment types
        /// </summary>
        /// <returns>Returns the list of equipment types as a List</returns>
        private List<string> GetEquipmentTypeList()
        {
            List<string> temp = new List<string>(equipmentList.Count);
            foreach (Equipment eq in equipmentList)
                if (!temp.Contains(eq.EquipmentType))                  // Prevents duplicates
                    temp.Add(eq.EquipmentType);
            return temp;
        }

        /// <summary>
        /// Gets the current list of equipment operators
        /// </summary>
        /// <returns>Returns the list of equipment operators as a List</returns>
        private List<string> GetEquipmentOperatorList()
        {
            List<string> temp = new List<string>(equipmentList.Count);
            foreach (Equipment eq in equipmentList)
                if (!temp.Contains(eq.EquipmentOperator))                  // Prevents duplicates
                    temp.Add(eq.EquipmentOperator);
            return temp;
        }

        #endregion

        #region Parts

        /// <summary>
        /// Gets the current list of part names
        /// </summary>
        /// <returns>Returns the current list of part names</returns>
        private List<string> GetPartNames()
        {
            List<string> temp = new List<string>(partList.Count);
            foreach (Part p in partList)
                if(!temp.Contains(p.Name))                              // Prevents duplicates
                    temp.Add(p.Name);
            return temp;
        }

        /// <summary>
        /// Gets the current list of part numbers
        /// </summary>
        /// <returns>Returns the current list of part numbers</returns>
        private List<string> GetPartNumbers()
        {
            List<string> temp = new List<string>(partList.Count);
            foreach (Part p in partList)
                if(!temp.Contains(p.PartNumber))                        // Prevents duplicates
                    temp.Add(p.PartNumber);
            return temp;
        }

        #endregion

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
