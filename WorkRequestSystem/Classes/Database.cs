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
        private static Excel.Application eApp { get; set; }

        #endregion

        public Database(string filePath = "")
        {
            this.FilePath = filePath;
            EquipmentList = new List<Equipment>();
            PartList = new List<Part>();
            WorkRequestList = new List<WorkRequest>();

            if (eApp == null)
            {
                // Begins Excel
                eApp = new Excel.Application();
                eApp.Visible = false;
            }
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
        /// Reads in a database from an excel file
        /// </summary>
        /// <param name="path">Path pointing to the file</param>
        /// <returns>Returns the database contined in the file</returns>
        public static Database ImportFromExcel(string path)
        {
            #region Setup

            Excel.Workbook book = eApp.Workbooks.Open(path);                // Opens the excel workbook to be read from
            Excel.Worksheet workRequestSheet = book.Sheets[1];
            Excel.Worksheet partSheet = book.Sheets[2];
            Excel.Worksheet equipmentSheet = book.Sheets[3];

            int wrRow = 2, pRow = 2, eqRow = 2, currentSheet = 4;

            int requestCount = book.Sheets.Count;                           // Total count of all sheets in the workbook

            Database db = new Database(path);                               // Creates a new database object to house the info

            #endregion

            #region Work Requests

            for(int i = currentSheet; i <= requestCount; i++)
            {
                WorkRequest wr = new WorkRequest();             // Work request object to house the info

                Excel.Worksheet ws = book.Sheets[i];            // Worksheet with the current work request information stored on it
                wr.Date = ws.Cells[1, 2];// FIX THIS
                wr.TimeSpent = ws.Cells[1, 4];

                wr.Equipment.EquipmentNumber = ws.Cells[3, 1];
                wr.Equipment.SerialNumber = ws.Cells[3, 2];
                wr.Equipment.ModelNumber = ws.Cells[3, 3];
                wr.Equipment.Brand = ws.Cells[3, 4];
                wr.Equipment.EquipmentType = ws.Cells[3, 5];
                wr.Equipment.Department = ws.Cells[3, 6];
                wr.Equipment.EquipmentOperator = ws.Cells[3, 7];

                wr.WorkDescription = ws.Cells[5, 1];

                // For Loop for parts list goes here

                db.WorkRequestList.Add(wr);
            }

            #endregion

            return db;
        }

        /// <summary>
        /// Exports the current database to an Excel file database
        /// </summary>
        /// <param name="path">Path pointing to the file</param>
        /// <returns>Returns a boolean indicator of success.</returns>
        public bool ExportToExcel(string path)
        {
            if (eApp == null)
            {
                #region Setup

                eApp.Workbooks.Add();                                       // Adds a new workbook to the list of workbooks
                Excel.Workbook book = eApp.ActiveWorkbook;                  // Creates the workbook to house the new database
                Excel.Worksheet workRequestSheet = book.Sheets[1];          // Worksheet for the list of work request descriptions
                Excel.Worksheet partSheet = book.Sheets[2];                 // Worksheet for the list of parts available
                Excel.Worksheet equipmentSheet = book.Sheets[3];            // Worksheet for the list of equipment available

                int wrRow = 2, pRow = 2, eqRow = 2;                         // Row placeholders for the various sheets

                #endregion

                #region Work Request storage

                #region List Sheet formatting

                workRequestSheet.Name = "Work Request List";                // Name to show up on the tab down in the bottom of the screen

                // Column headers
                workRequestSheet.Cells[1, 1] = "Date";
                workRequestSheet.Cells[1, 2] = "Equipment Number";
                workRequestSheet.Cells[1, 3] = "Work Description";
                workRequestSheet.Cells[1, 4] = "Time spent";

                #endregion

                foreach (WorkRequest wr in workRequestList)
                {
                    #region List Sheet

                    workRequestSheet.Cells[wrRow, 1] = wr.Date.ToLongDateString();
                    workRequestSheet.Cells[wrRow, 2] = wr.Equipment.EquipmentNumber;
                    workRequestSheet.Cells[wrRow, 3] = wr.WorkDescription;
                    workRequestSheet.Cells[wrRow++, 4] = wr.TimeSpent;

                    #endregion

                    #region Personal Sheet

                    Excel.Worksheet wrSheet = book.Sheets.Add(After: book.Sheets.Count);

                    #region Sheet formatting

                    wrSheet.Cells[1, 1] = "Date";
                    wrSheet.Cells[1, 3] = "Time Spent";

                    wrSheet.Cells[2, 1] = "Equipment Number";
                    wrSheet.Cells[2, 2] = "Serial Number";
                    wrSheet.Cells[2, 3] = "Model Number";
                    wrSheet.Cells[2, 4] = "Brand";
                    wrSheet.Cells[2, 5] = "Type";
                    wrSheet.Cells[2, 6] = "Department";
                    wrSheet.Cells[2, 7] = "Operator";

                    wrSheet.Cells[4, 1] = "Work Description";

                    wrSheet.Cells[6, 1] = "Parts Used";
                    wrSheet.Cells[7, 1] = "Part Number";
                    wrSheet.Cells[7, 2] = "Part Name";

                    #endregion

                    #region Data insertion

                    wrSheet.Cells[1, 2] = wr.Date.ToLongDateString();
                    wrSheet.Cells[1, 4] = wr.TimeSpent;

                    wrSheet.Cells[3, 1] = wr.Equipment.EquipmentNumber;
                    wrSheet.Cells[3, 2] = wr.Equipment.SerialNumber;
                    wrSheet.Cells[3, 3] = wr.Equipment.ModelNumber;
                    wrSheet.Cells[3, 4] = wr.Equipment.Brand;
                    wrSheet.Cells[3, 5] = wr.Equipment.EquipmentType;
                    wrSheet.Cells[3, 6] = wr.Equipment.Department;
                    wrSheet.Cells[3, 7] = wr.Equipment.EquipmentOperator;

                    wrSheet.Cells[5, 1] = wr.WorkDescription;

                    int wrRowTemp = 8;

                    foreach (Part p in wr.PartsList)
                    {
                        wrSheet.Cells[wrRowTemp, 1] = p.PartNumber;
                        wrSheet.Cells[wrRowTemp++, 2] = p.Name;
                    }

                    #endregion

                    #endregion
                }

                #endregion

                #region Part List Storage

                #region Formatting

                partSheet.Name = "Parts List";

                partSheet.Cells[1, 1] = "Part Number";
                partSheet.Cells[1, 2] = "Part Name";

                #endregion

                foreach (Part p in partList)
                {
                    partSheet.Cells[pRow, 1] = p.PartNumber;
                    partSheet.Cells[pRow++, 2] = p.Name;
                }

                #endregion

                #region Equipment List Storage

                #region Formatting

                equipmentSheet.Cells[1, 1] = "Equipment Number";
                equipmentSheet.Cells[1, 2] = "Serial Number";
                equipmentSheet.Cells[1, 3] = "Model Number";
                equipmentSheet.Cells[1, 4] = "Brand";
                equipmentSheet.Cells[1, 5] = "Type";
                equipmentSheet.Cells[1, 6] = "Department";
                equipmentSheet.Cells[1, 7] = "Usable Parts";

                #endregion

                #region Data Insertion

                foreach (Equipment eq in equipmentList)
                {
                    equipmentSheet.Cells[eqRow, 1] = eq.EquipmentNumber;
                    equipmentSheet.Cells[eqRow, 2] = eq.SerialNumber;
                    equipmentSheet.Cells[eqRow, 3] = eq.ModelNumber;
                    equipmentSheet.Cells[eqRow, 4] = eq.Brand;
                    equipmentSheet.Cells[eqRow, 5] = eq.EquipmentType;
                    equipmentSheet.Cells[eqRow, 6] = eq.Department;

                    int eqCol = 7;

                    foreach (Part p in eq.UsableParts)
                    {
                        equipmentSheet.Cells[eqRow, eqCol++] = p.PartNumber;
                    }

                    eqRow++;
                }

                #endregion

                #endregion

                #region Saving

                book.SaveAs(path);

                #endregion

                return true;
            }
            return false;
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
