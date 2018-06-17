using DavesMasterWorkOrderRequestDatabase;
using DavesMasterWorkOrderRequestDatabase.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorkRequestSystem.Classes;

namespace WorkRequestSystem.Modules
{
    public partial class RequestForm : Form
    {
        #region Events

        public delegate void CompletionEventHandler(object sender, FormCompletionEventArgs e);

        public event CompletionEventHandler CompletionEvent;

        public virtual void OnCompletionEvent()
        {
            CompletionEvent?.Invoke(this, new FormCompletionEventArgs(new RequestFormCompletionData(DB, workRequest)));
        }

        #endregion

        #region Properties

        /// <summary>
        /// Database with all of the parts stored in it, passed in when initialized.
        /// </summary>
        private Database DB;

        /// <summary>
        /// The container for the current item on the screen
        /// </summary>
        private WorkRequest workRequest;

        /// <summary>
        /// Current piece of equipment contained in the form
        /// </summary>
        private Equipment equipment;

        /// <summary>
        /// Current part contained in the form
        /// </summary>
        private Part part;

        /// <summary>
        /// The type of launch that was caused when this form was initialized.
        /// </summary>
        private RequestFormLaunchType launchType;

        #region Auto Complete String Collections

        #region Parts

        /// <summary>
        /// Auto-Complete String collection for the part numbers
        /// </summary>
        private AutoCompleteStringCollection partNumAutoComplete;
        /// <summary>
        /// Auto-Complete String collection for the part names
        /// </summary>
        private AutoCompleteStringCollection partNameAutoComplete;

        #endregion

        #region Equipment

        /// <summary>
        /// Auto complete string collection for the truck number
        /// </summary>
        private AutoCompleteStringCollection truckNumAutoComplete;

        /// <summary>
        /// Auto complete string collection for the truck department
        /// </summary>
        private AutoCompleteStringCollection truckDepAutoComplete;

        /// <summary>
        /// Auto complete string collection for the truck serial number
        /// </summary>
        private AutoCompleteStringCollection truckSerialNumAutoComplete;

        /// <summary>
        /// Auto complete string collection for the truck model number
        /// </summary>
        private AutoCompleteStringCollection truckModelNumAutoComplete;

        /// <summary>
        /// Auto complete string collection for the truck brand
        /// </summary>
        private AutoCompleteStringCollection truckBrandAutoComplete;

        /// <summary>
        /// Auto complete string collection for the truck type
        /// </summary>
        private AutoCompleteStringCollection truckTypeAutoComplete;

        /// <summary>
        /// Auto complete string collection for the truck operator
        /// </summary>
        private AutoCompleteStringCollection truckOperatorAutoComplete;

        #endregion

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Opens the window with intent of editting an existing request
        /// </summary>
        /// <param name="DB">The Database containing the equipment and parts lists</param>
        /// <param name="workRequest">The work request to be edited</param>
        public RequestForm(Database DB, WorkRequest workRequest)
        {
            this.DB = DB;
            this.workRequest = workRequest;
            equipment = workRequest.Equipment;
            launchType = RequestFormLaunchType.Edit;
            Setup();
        }

        /// <summary>
        /// Opens the window with intent of creating a new request
        /// </summary>
        /// <param name="DB">The Database containing the equipment and parts lists</param>
        public RequestForm(Database DB)
        {
            this.DB = DB;
            workRequest = new WorkRequest();
            equipment = new Equipment();
            launchType = RequestFormLaunchType.New;
            Setup();
        }

        /// <summary>
        /// FOR VISUAL STUDIO USE ONLY, DO NOT USE!!!
        /// </summary>
        public RequestForm()
        {
            DB = new Database();
            equipment = new Equipment();
            part = new Part();
            workRequest = new WorkRequest();
            Setup();
        }

        /// <summary>
        /// Sets up the component and the other un-initialized properties in the class
        /// </summary>
        private void Setup()
        {
            InitializeComponent();

            #region Auto Complete

            #region Parts

            partNameAutoComplete = new AutoCompleteStringCollection();
            partNumAutoComplete = new AutoCompleteStringCollection();

            #endregion

            #region Equipment

            truckBrandAutoComplete = new AutoCompleteStringCollection();
            truckDepAutoComplete = new AutoCompleteStringCollection();
            truckModelNumAutoComplete = new AutoCompleteStringCollection();
            truckNumAutoComplete = new AutoCompleteStringCollection();
            truckOperatorAutoComplete = new AutoCompleteStringCollection();
            truckSerialNumAutoComplete = new AutoCompleteStringCollection();
            truckTypeAutoComplete = new AutoCompleteStringCollection();

            #endregion

            #endregion

            part = new Part();
        }

        /// <summary>
        /// Sets up the initial values of the controls if the box is launched in edit mode
        /// </summary>
        private void InitializeControlValues()
        {
            WorkDescriptionText.Text = workRequest.WorkDescription;

            #region Equipment

            TruckNumberComboBox.Text = workRequest.Equipment.EquipmentNumber;
            TruckOperatorComboBox.Text = workRequest.Equipment.EquipmentOperator;
            TruckSerialNumberComboBox.Text = workRequest.Equipment.SerialNumber;
            TruckModelNumberComboBox.Text = workRequest.Equipment.ModelNumber;
            TruckDepartmentComboBox.Text = workRequest.Equipment.Department;
            TruckBrandComboBox.Text = workRequest.Equipment.Brand;
            TruckTypeComboBox.Text = workRequest.Equipment.EquipmentType;

            #endregion

            DateOfWorkPerformedCalendar.SelectionStart = workRequest.Date;
            DateOfWorkPerformedCalendar.SelectionEnd = workRequest.Date;

            HoursWorkedNumeric.Value = (int)workRequest.TimeSpent;
            MinutesWorkedNumeric.Value = (decimal)(workRequest.TimeSpent - (int)workRequest.TimeSpent) * 60;

            UpdatePartsListbox();
        }

        #endregion

        #region Accessor Methods

        /// <summary>
        /// The work request contained by the data in this form.
        /// </summary>
        public WorkRequest WorkRequest { get => workRequest; set => workRequest = value; }

        #endregion

        #region Methods

        /// <summary>
        /// Updates the auto-complete collections based on the filled in data
        /// </summary>
        private void UpdateAutoCompleteLists()
        {
            // Updates the sources

            #region Equipment

            List<Equipment> tempequip = new List<Equipment>();

            #region Type
            if (TruckTypeComboBox.Text == "")
            {
                // Finds equipment that match the search criteria
                tempequip = DB.EquipmentList.FindAll((Equipment e) =>
                {
                    return
                        e.EquipmentNumber == ((TruckNumberComboBox.Text == "") ? e.EquipmentNumber : TruckNumberComboBox.Text) &&
                        e.ModelNumber == ((TruckModelNumberComboBox.Text == "") ? e.ModelNumber : TruckModelNumberComboBox.Text) &&
                        e.SerialNumber == ((TruckSerialNumberComboBox.Text == "") ? e.SerialNumber : TruckSerialNumberComboBox.Text) &&
                        e.Brand == ((TruckBrandComboBox.Text == "") ? e.Brand : TruckBrandComboBox.Text) &&
                        e.Department == ((TruckDepartmentComboBox.Text == "") ? e.Department : TruckDepartmentComboBox.Text) &&
                        e.EquipmentOperator == ((TruckOperatorComboBox.Text == "") ? e.EquipmentOperator : TruckOperatorComboBox.Text);
                });

                // converts to string
                List<string> types = new List<string>(tempequip.Count);
                foreach (Equipment e in tempequip)
                    if (!types.Contains(e.EquipmentType))            // Prevents duplicates
                        types.Add(e.EquipmentType);

                truckTypeAutoComplete.Clear();
                truckTypeAutoComplete.AddRange(types.ToArray());
            }
            #endregion

            #region Operator
            if (TruckOperatorComboBox.Text == "")
            {
                // Finds equipment that match the search criteria
                tempequip = DB.EquipmentList.FindAll((Equipment e) =>
                {
                    return
                        e.EquipmentNumber == ((TruckNumberComboBox.Text == "") ? e.EquipmentNumber : TruckNumberComboBox.Text) &&
                        e.ModelNumber == ((TruckModelNumberComboBox.Text == "") ? e.ModelNumber : TruckModelNumberComboBox.Text) &&
                        e.SerialNumber == ((TruckSerialNumberComboBox.Text == "") ? e.SerialNumber : TruckSerialNumberComboBox.Text) &&
                        e.Brand == ((TruckBrandComboBox.Text == "") ? e.Brand : TruckBrandComboBox.Text) &&
                        e.Department == ((TruckDepartmentComboBox.Text == "") ? e.Department : TruckDepartmentComboBox.Text) &&
                        e.EquipmentType == ((TruckTypeComboBox.Text == "") ? e.EquipmentType : TruckTypeComboBox.Text);
                });

                // converts to string
                List<string> operators = new List<string>(tempequip.Count);
                foreach (Equipment e in tempequip)
                    if (!operators.Contains(e.EquipmentOperator))            // Prevents duplicates
                        operators.Add(e.EquipmentOperator);

                truckOperatorAutoComplete.Clear();
                truckOperatorAutoComplete.AddRange(operators.ToArray());
            }
            #endregion

            #region Department
            if (TruckDepartmentComboBox.Text == "")
            {
                // Finds equipment that match the search criteria
                tempequip = DB.EquipmentList.FindAll((Equipment e) =>
                {
                    return
                        e.EquipmentNumber == ((TruckNumberComboBox.Text == "") ? e.EquipmentNumber : TruckNumberComboBox.Text) &&
                        e.ModelNumber == ((TruckModelNumberComboBox.Text == "") ? e.ModelNumber : TruckModelNumberComboBox.Text) &&
                        e.SerialNumber == ((TruckSerialNumberComboBox.Text == "") ? e.SerialNumber : TruckSerialNumberComboBox.Text) &&
                        e.Brand == ((TruckBrandComboBox.Text == "") ? e.Brand : TruckBrandComboBox.Text) &&
                        e.EquipmentOperator == ((TruckOperatorComboBox.Text == "") ? e.EquipmentOperator : TruckOperatorComboBox.Text) &&
                        e.EquipmentType == ((TruckTypeComboBox.Text == "") ? e.EquipmentType : TruckTypeComboBox.Text);
                });

                // converts to string
                List<string> departments = new List<string>(tempequip.Count);
                foreach (Equipment e in tempequip)
                    if (!departments.Contains(e.Department))            // Prevents duplicates
                        departments.Add(e.Department);

                truckDepAutoComplete.Clear();
                truckDepAutoComplete.AddRange(departments.ToArray());
            }
            #endregion

            #region Brand
            if (TruckBrandComboBox.Text == "")
            {
                // Finds equipment that match the search criteria
                tempequip = DB.EquipmentList.FindAll((Equipment e) =>
                {
                    return
                        e.EquipmentNumber == ((TruckNumberComboBox.Text == "") ? e.EquipmentNumber : TruckNumberComboBox.Text) &&
                        e.ModelNumber == ((TruckModelNumberComboBox.Text == "") ? e.ModelNumber : TruckModelNumberComboBox.Text) &&
                        e.SerialNumber == ((TruckSerialNumberComboBox.Text == "") ? e.SerialNumber : TruckSerialNumberComboBox.Text) &&
                        e.Department == ((TruckDepartmentComboBox.Text == "") ? e.Department : TruckDepartmentComboBox.Text) &&
                        e.EquipmentOperator == ((TruckOperatorComboBox.Text == "") ? e.EquipmentOperator : TruckOperatorComboBox.Text) &&
                        e.EquipmentType == ((TruckTypeComboBox.Text == "") ? e.EquipmentType : TruckTypeComboBox.Text);
                });

                // converts to string
                List<string> brands = new List<string>(tempequip.Count);
                foreach (Equipment e in tempequip)
                    if (!brands.Contains(e.Brand))            // Prevents duplicates
                        brands.Add(e.Brand);

                truckBrandAutoComplete.Clear();
                truckBrandAutoComplete.AddRange(brands.ToArray());
            }
            #endregion

            #region Serial Number
            if (TruckSerialNumberComboBox.Text == "")
            {
                // Finds equipment that match the search criteria
                tempequip = DB.EquipmentList.FindAll((Equipment e) =>
                {
                    return
                        e.EquipmentNumber == ((TruckNumberComboBox.Text == "") ? e.EquipmentNumber : TruckNumberComboBox.Text) &&
                        e.ModelNumber == ((TruckModelNumberComboBox.Text == "") ? e.ModelNumber : TruckModelNumberComboBox.Text) &&
                        e.Brand == ((TruckBrandComboBox.Text == "") ? e.Brand : TruckBrandComboBox.Text) &&
                        e.Department == ((TruckDepartmentComboBox.Text == "") ? e.Department : TruckDepartmentComboBox.Text) &&
                        e.EquipmentOperator == ((TruckOperatorComboBox.Text == "") ? e.EquipmentOperator : TruckOperatorComboBox.Text) &&
                        e.EquipmentType == ((TruckTypeComboBox.Text == "") ? e.EquipmentType : TruckTypeComboBox.Text);
                });

                // converts to string
                List<string> serialNumbers = new List<string>(tempequip.Count);
                foreach (Equipment e in tempequip)
                    if (!serialNumbers.Contains(e.SerialNumber))            // Prevents duplicates
                        serialNumbers.Add(e.SerialNumber);

                truckSerialNumAutoComplete.Clear();
                truckSerialNumAutoComplete.AddRange(serialNumbers.ToArray());
            }
            #endregion

            #region Model Number
            if (TruckModelNumberComboBox.Text == "")
            {
                // Finds equipment that match the search criteria
                tempequip = DB.EquipmentList.FindAll((Equipment e) =>
                {
                    return
                        e.EquipmentNumber == ((TruckNumberComboBox.Text == "") ? e.EquipmentNumber : TruckNumberComboBox.Text) &&
                        e.SerialNumber == ((TruckSerialNumberComboBox.Text == "") ? e.SerialNumber : TruckSerialNumberComboBox.Text) &&
                        e.Brand == ((TruckBrandComboBox.Text == "") ? e.Brand : TruckBrandComboBox.Text) &&
                        e.Department == ((TruckDepartmentComboBox.Text == "") ? e.Department : TruckDepartmentComboBox.Text) &&
                        e.EquipmentOperator == ((TruckOperatorComboBox.Text == "") ? e.EquipmentOperator : TruckOperatorComboBox.Text) &&
                        e.EquipmentType == ((TruckTypeComboBox.Text == "") ? e.EquipmentType : TruckTypeComboBox.Text);
                });

                // converts to string
                List<string> modelNumbers = new List<string>(tempequip.Count);
                foreach (Equipment e in tempequip)
                    if (!modelNumbers.Contains(e.ModelNumber))            // Prevents duplicates
                        modelNumbers.Add(e.ModelNumber);

                truckModelNumAutoComplete.Clear();
                truckModelNumAutoComplete.AddRange(modelNumbers.ToArray());
            }
            #endregion

            #region Truck Number
            if (TruckNumberComboBox.Text == "")
            {
                // Finds equipment that match the search criteria
                tempequip = DB.EquipmentList.FindAll((Equipment e) =>
                {
                    return
                        e.ModelNumber == ((TruckModelNumberComboBox.Text == "") ? e.ModelNumber : TruckModelNumberComboBox.Text) &&
                        e.SerialNumber == ((TruckSerialNumberComboBox.Text == "") ? e.SerialNumber : TruckSerialNumberComboBox.Text) &&
                        e.Brand == ((TruckBrandComboBox.Text == "") ? e.Brand : TruckBrandComboBox.Text) &&
                        e.Department == ((TruckDepartmentComboBox.Text == "") ? e.Department : TruckDepartmentComboBox.Text) &&
                        e.EquipmentOperator == ((TruckOperatorComboBox.Text == "") ? e.EquipmentOperator : TruckOperatorComboBox.Text) &&
                        e.EquipmentType == ((TruckTypeComboBox.Text == "") ? e.EquipmentType : TruckTypeComboBox.Text);
                });

                // converts to string
                List<string> truckNumbers = new List<string>(tempequip.Count);
                foreach (Equipment e in tempequip)
                    if (!truckNumbers.Contains(e.EquipmentNumber))            // Prevents duplicates
                        truckNumbers.Add(e.EquipmentNumber);

                truckNumAutoComplete.Clear();
                truckNumAutoComplete.AddRange(truckNumbers.ToArray());
            }
            #endregion

            #endregion

            #region Parts

            if (PartNameComboBox.Text != "")
            {
                if (PartsNumberComboBox.Text == "")
                {
                    // Finds all parts with the name entered
                    List<Part> temp = DB.PartList.FindAll((Part p) => { return p.Name == PartNameComboBox.Text; });

                    // Converts to strings
                    List<string> partNumbers = new List<string>(temp.Count);
                    foreach (Part p in temp)
                        if(!partNumbers.Contains(p.PartNumber))                 // Prevents duplicates
                            partNumbers.Add(p.PartNumber);

                    // Updates the part numbers string collection
                    partNumAutoComplete.Clear();
                    partNumAutoComplete.AddRange(partNumbers.ToArray());
                }

                // If both are not empty, then do nothing
            }
            else if(PartsNumberComboBox.Text != "")
            {
                // Finds all parts with the number entered
                List<Part> temp = DB.PartList.FindAll((Part p) => { return p.PartNumber == PartsNumberComboBox.Text; });

                // Converts to strings
                List<string> partNames = new List<string>(temp.Count);
                foreach (Part p in temp)
                    if(!partNames.Contains(p.Name))                     // Prevents duplicates
                        partNames.Add(p.Name);

                // Updates the part names string collection
                partNameAutoComplete.Clear();
                partNameAutoComplete.AddRange(partNames.ToArray());
            }
            else
            {
                // If both are empty, then start them with the default, full lists for both
                partNameAutoComplete.Clear();
                partNameAutoComplete.AddRange(DB.PartNames.ToArray());
                partNumAutoComplete.Clear();
                partNumAutoComplete.AddRange(DB.PartNumbers.ToArray());
            }

            #endregion

            // Updates the controls

            #region Equipment

            // There's probably a much more efficient way to do this...

            TruckTypeComboBox.AutoCompleteCustomSource = truckTypeAutoComplete;
            if (truckTypeAutoComplete.Count == 1)
                TruckTypeComboBox.Text = DB.EquipmentTypes.Find((string e) => { return e == truckTypeAutoComplete[0]; });

            TruckBrandComboBox.AutoCompleteCustomSource = truckBrandAutoComplete;
            if (truckBrandAutoComplete.Count == 1)
                TruckBrandComboBox.Text = DB.EquipmentBrands.Find((string e) => { return e == truckBrandAutoComplete[0]; });

            TruckDepartmentComboBox.AutoCompleteCustomSource = truckDepAutoComplete;
            if (truckDepAutoComplete.Count == 1)
                TruckDepartmentComboBox.Text = DB.EquipmentDepartments.Find((string e) => { return e == truckDepAutoComplete[0]; });

            TruckOperatorComboBox.AutoCompleteCustomSource = truckOperatorAutoComplete;
            if (truckOperatorAutoComplete.Count == 1)
                TruckOperatorComboBox.Text = DB.EquipmentOperators.Find((string e) => { return e == truckOperatorAutoComplete[0]; });

            TruckNumberComboBox.AutoCompleteCustomSource = truckNumAutoComplete;
            if (truckNumAutoComplete.Count == 1)
                TruckNumberComboBox.Text = DB.EquipmentNumbers.Find((string e) => { return e == truckNumAutoComplete[0]; });

            TruckModelNumberComboBox.AutoCompleteCustomSource = truckModelNumAutoComplete;
            if (truckModelNumAutoComplete.Count == 1)
                TruckModelNumberComboBox.Text = DB.EquipmentModelNumbers.Find((string e) => { return e == truckModelNumAutoComplete[0]; });

            TruckSerialNumberComboBox.AutoCompleteCustomSource = truckSerialNumAutoComplete;
            if (truckSerialNumAutoComplete.Count == 1)
                TruckSerialNumberComboBox.Text = DB.EquipmentSerialNumbers.Find((string e) => { return e == truckSerialNumAutoComplete[0]; });

            #endregion

            #region Parts

            PartNameComboBox.AutoCompleteCustomSource = partNameAutoComplete;
            if (partNameAutoComplete.Count == 1)
                PartNameComboBox.Text = DB.PartNames.Find((string e) => { return e == partNameAutoComplete[0]; });

            PartsNumberComboBox.AutoCompleteCustomSource = partNumAutoComplete;
            if (partNumAutoComplete.Count == 1)
                PartsNumberComboBox.Text = DB.PartNumbers.Find((string e) => { return e == partNumAutoComplete[0]; });

            #endregion

        }

        /// <summary>
        /// Updates the time spent property of the work request, gets called by the two numeric controls on the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateTimeSpent(object sender, EventArgs e)
        {
            workRequest.TimeSpent = (double)HoursWorkedNumeric.Value + (double)MinutesWorkedNumeric.Value / 60;
        }

        /// <summary>
        /// Updates the parts listbox control
        /// </summary>
        private void UpdatePartsListbox()
        {
            List<string> partList = new List<string>(workRequest.PartsList.Count);

            foreach (Part p in workRequest.PartsList)
                partList.Add(p.Name);

            PartsListBox.DataSource = partList;
        }

        /// <summary>
        /// Checks if all required fields on the form are completed
        /// </summary>
        /// <returns>Returns a boolean representing the completion status</returns>
        private bool CheckCompletion()
        {
            if((equipment.EquipmentNumber != "" && 
               equipment.Brand != "" && 
               equipment.Department != "" && 
               equipment.EquipmentOperator != "" && 
               equipment.EquipmentType != "") && 
               (workRequest.PartsList.Count > 0 && 
               workRequest.WorkDescription != "" && 
               workRequest.TimeSpent != 0))
                return true;
            return false;
        }

        #endregion

        #region Completion Events

        /// <summary>
        /// Triggered when the user clicks on the accept button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AcceptBtn_Click(object sender, EventArgs e)
        {
            if (CheckCompletion())
            {
                OnCompletionEvent();
                Dispose();
            }
            else
            {
                MessageBox.Show("Please fill in all required fields.");
            }
        }

        /// <summary>
        /// Triggered when the user clicks the cancel button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        #endregion

        #region Control Events

        /// <summary>
        /// Triggered when the user clicks the add part button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddPartBtn_Click(object sender, EventArgs e)
        {
            if (part.Name != "")
            {
                if (part.PartNumber != "")
                {
                    workRequest.PartsList.Add(part);
                    UpdatePartsListbox();
                }
                else
                    MessageBox.Show("A part number is required.");
            }
            else
                MessageBox.Show("A part name is required.");
        }

        #region Equipment Control Events

        private void TruckNumberComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            equipment.EquipmentNumber = TruckNumberComboBox.Text;
            UpdateAutoCompleteLists();
        }

        private void TruckBrandComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            equipment.Brand = TruckBrandComboBox.Text;
            UpdateAutoCompleteLists();
        }

        private void TruckTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            equipment.EquipmentType = TruckTypeComboBox.Text;
            UpdateAutoCompleteLists();
        }

        private void TruckSerialNumberComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            equipment.SerialNumber = TruckSerialNumberComboBox.Text;
            UpdateAutoCompleteLists();
        }

        private void TruckModelNumberComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            equipment.ModelNumber = TruckModelNumberComboBox.Text;
            UpdateAutoCompleteLists();
        }

        private void TruckDepartmentComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            equipment.Department = TruckDepartmentComboBox.Text;
            UpdateAutoCompleteLists();
        }

        private void TruckOperatorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            equipment.EquipmentOperator = TruckOperatorComboBox.Text;
            UpdateAutoCompleteLists();
        }

        #endregion

        private void WorkDescriptionText_TextChanged(object sender, EventArgs e)
        {
            workRequest.WorkDescription = WorkDescriptionText.Text;
        }

        private void DateOfWorkPerformedCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            workRequest.Date = DateOfWorkPerformedCalendar.SelectionStart;
        }

        #region Part Control Events

        private void PartNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            part.Name = PartNameComboBox.Text;
            UpdateAutoCompleteLists();
        }

        private void PartsNumberComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            part.PartNumber = PartsNumberComboBox.Text;
            UpdateAutoCompleteLists();
        }

        #endregion

        private void RemovePartBtn_Click(object sender, EventArgs e)
        {
            workRequest.PartsList.RemoveAt(PartsListBox.SelectedIndex);
            UpdatePartsListbox();
        }

        #endregion
    }
}
