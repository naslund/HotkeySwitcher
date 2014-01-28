using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace HotkeySwitcher
{
    /// <summary>
    /// This class is for the hotkeysetform, it's being used when adding a new set
    /// or editing an existing one
    /// </summary>
    public partial class HotkeySetForm : Form
    {
        // -------------------------------------------------------------------//
        //             FIELDS, CONSTRUCTORS AND INITIALIZATIONS                 //
        // -------------------------------------------------------------------//

        // Fields for a hotkeyset and a filepath
        private HotkeySet m_hotkeyset;
        private string m_file;

        /// <summary>
        /// Contructor with 1 param - the ID
        /// Does inits and instantiates the hotkeyset field
        /// </summary>
        /// <param name="ID"></param>
        public HotkeySetForm(int ID)
        {
            InitializeComponent(); // VS inits
            InitializeGUI(); // My own inits

            m_hotkeyset = new HotkeySet(ID); // Creates a new hotkeyset from the param ID
        }

        // -------------------------------------------------------------------//
        //                              PROPERTIES                              //
        // -------------------------------------------------------------------//

        /// <summary>
        /// Read access to the filepath
        /// </summary>
        public string HotkeySetFile
        {
            get { return m_file; }
        }

        /// <summary>
        /// Read/write access to the hotkeyset
        /// </summary>
        public HotkeySet HotkeySetData
        {
            get { return m_hotkeyset; }
            set { m_hotkeyset = value; }
        }

        // -------------------------------------------------------------------//
        //                               METHODS                                //
        // -------------------------------------------------------------------//

        /// <summary>
        /// Initializes the GUI
        /// Fills the combobox with the different vocs
        /// Checks radiobutton by default
        /// Hides radiobutton that should only be visible when editing a hotkeyset
        /// </summary>
        private void InitializeGUI()
        {
            FillComboFromEnumType(cmbVocation, typeof(CharacterClass), false); // Fills vocation combobox with the CharacterClass enum
            rbtnImport.Checked = true; // Selects import radiobutton as default
            rbtnDontChange.Visible = false; // Hides "dont change" radio button by default
        }

        /// <summary>
        /// Fills a combobox with the all the values from a certain enum type
        /// Also replaces all underscores with spaces depending on the 3rd parameter
        /// 
        /// A method call might look something like this:
        /// FillComboFromEnumType(cmbVocation, typeof(CharacterClass), false);
        /// 
        /// * This method is generic and can be applied to all comboboxes and enum types *
        /// </summary>
        /// <param name="cmbBox">The combobox to be filled</param>
        /// <param name="enumType">The enum type that the box will be filled with</param>
        /// <param name="replaceUnderscores">If the underscores should be replaced with spaces</param>
        private void FillComboFromEnumType(ComboBox cmbBox, Type enumType, bool replaceUnderscores)
        {
            cmbBox.Items.Clear(); // Clears combobox
            string[] fillStrings = Enum.GetNames(enumType); // Creates new array of strings
            if (replaceUnderscores) // If the replaceUnderscores bool is true (from param)
            {
                for (var i = 0; i < fillStrings.Length; i++) // Run a loop as long as the strings array's length
                {
                    fillStrings[i] = fillStrings[i].Replace('_', ' '); // Replaces all the underscores in the arrayindexes with spaces
                }
            }
            cmbBox.Items.AddRange(fillStrings); // Adds the formatted strings to the combobox
            cmbBox.SelectedIndex = 0; // Sets the selected index to the first item in the enum
        }

        /// <summary>
        /// This method is run when this form is about to edit a currently existing hotkeyset
        /// </summary>
        public void LoadChangeMode()
        {
            this.Text = "Change hotkeyinfo"; // Change the title of this instance
            btnAdd.Text = "Save"; // Change the former "Add" button to "Change"

            txtInfo.Text = m_hotkeyset.Info; // Sets the info to what's loaded
            cmbVocation.SelectedIndex = (int)m_hotkeyset.Voc;  // Sets the voc to what's loaded

            rbtnDontChange.Visible = true; // Shows the "don't change" radio button
            // Checks the "don't change" radio button by default
            // This also causes the event listener to trigger so the txtChosenFile can gets updated
            rbtnDontChange.Checked = true; 
        }

        /// <summary>
        /// Reads all inputs with separate methods, checks so all inputs are OK
        /// </summary>
        /// <returns>True/false depending on if the read was successful or not</returns>
        private bool ReadInput()
        {
            // Declares variables for voc, description, and the file
            CharacterClass vocInput;
            string infoInput;
            string fileInput;

            // Reads all input and output results with out params
            // Also provides bool for each part making sure they are read successfully
            bool vocOK = ReadVocation(out vocInput);
            bool infoOK = ReadDescription(out infoInput);
            bool fileOK = ReadFileInput(out fileInput);

            if (vocOK && infoOK && fileOK) // If all the inputs are OK
            {
                m_hotkeyset.Voc = vocInput; // Sets the voc of the hotkeyset to what has been inputted
                m_hotkeyset.Info = infoInput; // Sets the info of the hotkeyset to what has been inputted
                m_file = fileInput; // Sets the filepath to what has been inputted
                return true; // The read was a success
            }
            else // If any of the inputs failed
            {
                return false; // The read failed
            }
            
        }

        /// <summary>
        /// Reads the vocation from user input
        /// </summary>
        /// <param name="vocOutput"></param>
        /// <returns>True/false depending on if the read was successful or not</returns>
        private bool ReadVocation(out CharacterClass vocOutput)
        {
            // Checks if a vocation has been selected, this statment should never be true since the combobox gets
            // an index selected and it cant be set back to nothing aka. "-1"
            if (cmbVocation.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a vocation.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                vocOutput = (CharacterClass)0; // Sets vocOutput to "None", this value will not be used either way
                return false;
            }
            else
            {
                vocOutput = (CharacterClass)cmbVocation.SelectedIndex; // Sets vocOutput to the selected index
                return true;
            }
        }

        /// <summary>
        /// Reads the description (info) from user input
        /// </summary>
        /// <param name="infoOutput"></param>
        /// <returns>False if the input is empty, otherwise true</returns>
        private bool ReadDescription(out string infoOutput)
        {
            // Trims the info inputstring
            infoOutput = txtInfo.Text.Trim();
            if (String.IsNullOrEmpty(infoOutput)) // If the trimmed string is empty
            {
                MessageBox.Show("Please enter a description.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Reads the filepath from user input
        /// </summary>
        /// <param name="fileOutput"></param>
        /// <returns>True if the file exists, otherwise false</returns>
        private bool ReadFileInput(out string fileOutput)
        {
            fileOutput = txtChosenFile.Text; // Sets fileOutput to the value of the file input
            if (File.Exists(fileOutput)) // If the file inputted exists
            {
                return true;
            }
            else // If the inputted file doesnt exist
            {
                MessageBox.Show("Could not find the specified config file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // -------------------------------------------------------------------//
        //                          EVENT LISTENERS                             //
        // -------------------------------------------------------------------//

        /// <summary>
        /// Displays a confirmation if user exit the form in any other way than pressing "Add"
        /// If user confirms, closes the form
        /// Otherwise stays on the form and prevents default
        /// 
        /// * This method is generic and can be applied to any formclosing event *
        /// * Remember to set the OK-button's DialogResult to OK *
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HotkeySetForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK) // If we exit the form by clicking the OK button, no closing confirmation will be prompted
            {
                e.Cancel = false; // Exits form
            }
            else // If the form is exited otherwise (Cancel button, exit-cross (X), or ALT-F4)
            {
                // If the user confirm he want to exit the form and discard all info
                if (MessageBox.Show("Are you sure you want to close the form without saving the inputs?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    e.Cancel = false; // Exits form
                }
                else // If user presses cancel on the prompt
                {
                    e.Cancel = true; // Stays on the form and prevents default event (which is exiting the form)
                }
            }
        }

        /// <summary>
        /// When the import radio button is checked
        /// Enables the "choose file" button and empties the textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtnImport_CheckedChanged(object sender, EventArgs e)
        {
            btnChooseFile.Enabled = true; // Enables choose file button
            txtChosenFile.Text = String.Empty; // Empies textbox
        }

        /// <summary>
        /// When the currently active radio button is checked
        /// Disables the "choose file" button and changes the textbox to the filepath of the tibiaconfig
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtnCurrentlyActive_CheckedChanged(object sender, EventArgs e)
        {
            btnChooseFile.Enabled = false; // Disables "choose file" button

            // Builds a filepath to the config file in the tibia settings folder which is in the systems roaming folder
            string roamingFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string TibiaFolder = Path.Combine(roamingFolder, "Tibia");
            string tibiaCfgFileName = "Tibia.cfg";
            string fullCfgFileName = Path.Combine(TibiaFolder, Path.GetFileName(tibiaCfgFileName));

            txtChosenFile.Text = fullCfgFileName; // Sets the textbox to the filepath
        }

        /// <summary>
        /// When the user presses the add button (or save button in the case of an edit)
        /// Reads the input to the fields
        /// If the read fails, stays on the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ReadInput() == false) // Runs readinput method
            {
                this.DialogResult = DialogResult.None; // Prevents the form from being exited on an unsuccessful read
            }
        }

        /// <summary>
        /// When the user presses the choose file button
        /// Changes properties for the dialog
        /// Shows the dialog, if the dialog is ended by pressing the OK button (rather than cancel)
        /// Sets the textbox to the newly attained filepath
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            ofdChooseFile.Filter = "Tibia Config|*.cfg"; // Filters the file types available to choose
            ofdChooseFile.Title = "Choose the hotkey file you wish to import"; // Changes the title of the openfiledialog
            ofdChooseFile.FileName = "Tibia.cfg"; // Changes the default filename (the placeholder)
            if (ofdChooseFile.ShowDialog() == DialogResult.OK) // If the user has chosen a file
            {
                txtChosenFile.Text = ofdChooseFile.FileName; // Updates the textbox to the chosen file
            }
        }

        /// <summary>
        /// This is the event listener for the radio button "Don't Change"
        /// The button is only visible when editing a hotkeyset
        /// It creates a filepath string like "/Configs/66.cfg" 
        /// and sets the chosenfile (readonly textbox) to that value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtnDontChange_CheckedChanged(object sender, EventArgs e)
        {
            btnChooseFile.Enabled = false; // Disables the choose file button

            // Builds a filepath to the loaded file
            string sourceFolder = "Configs";
            string sourceFileName = m_hotkeyset.ID.ToString() + ".cfg";
            string source = Path.Combine(sourceFolder, Path.GetFileName(sourceFileName));

            txtChosenFile.Text = source; // Sets the chosen file textbox to that path
        }
    }
}
