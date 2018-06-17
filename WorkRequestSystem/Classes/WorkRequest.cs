using DavesMasterWorkOrderRequestDatabase.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;
using Excel = Microsoft.Office.Interop.Excel;

namespace DavesMasterWorkOrderRequestDatabase
{
    public class WorkRequest
    {
        #region Properties

        private string workDescription;
        private Equipment equipment;
        private DateTime date;
        private double timeSpent;
        private List<Part> partsList;

        #endregion

        #region Constructors

        public WorkRequest(string workDescription, Equipment equipment, DateTime date, double timeSpent, List<Part> partsList = null)
        {
            this.workDescription = workDescription;
            this.Equipment = equipment;
            this.date = date;
            this.timeSpent = timeSpent;
            this.partsList = partsList ?? new List<Part>();
        }

        public WorkRequest(string workDescription = "", Equipment equipment = null, double timeSpent = 0, List<Part> partsList = null)
        {
            this.workDescription = workDescription;
            this.Equipment = equipment ?? new Equipment();
            date = DateTime.Now;
            this.timeSpent = timeSpent;
            this.partsList = partsList ?? new List<Part>();
        }

        #endregion

        #region Accessor Methods

        /// <summary>
        /// Description of the work performed on the equipment
        /// </summary>
        public string WorkDescription { get => workDescription; set => workDescription = value; }

        /// <summary>
        /// Date of the work performed
        /// </summary>
        public DateTime Date { get => date; set => date = value; }

        /// <summary>
        /// Number of hours spent performing the job
        /// </summary>
        public double TimeSpent { get => timeSpent; set => timeSpent = value; }

        /// <summary>
        /// List of parts replaced or fixed
        /// </summary>
        public List<Part> PartsList { get => partsList; set => partsList = value; }

        /// <summary>
        /// The equipment that was worked on
        /// </summary>
        public Equipment Equipment { get => equipment; set => equipment = value; }

        #endregion

        #region Methods

        #region File Methods

        /// <summary>
        /// Loads a WorkRequest from an excel Range
        /// </summary>
        /// <param name="range">Range containing the work request</param>
        /// <returns>Returns the work request contained in the range</returns>
        public static WorkRequest ReadFromString(Excel.Range range)
        {
            return new WorkRequest();
        }

        /// <summary>
        /// Writes a work request to an Excel Range
        /// </summary>
        public virtual string WriteToRange()
        {
            return "";
        }

        #region XML

        /// <summary>
        /// Converts the work request into its xml schema
        /// </summary>
        /// <returns>Returns the XElement containing the work request</returns>
        public XElement ConvertToXml()
        {
            return new XElement("WorkRequest");
        }

        /// <summary>
        /// Loads the work request from an xml element
        /// </summary>
        /// <param name="element">XElement to load from</param>
        public static WorkRequest LoadFromXml(XElement element)
        {
            return new WorkRequest();
        }

        #endregion

        #endregion

        #endregion
    }
}
