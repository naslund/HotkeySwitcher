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
using System.Diagnostics;

namespace HotkeySwitcher
{
    /// <summary>
    /// This class is for the mainform, the form thats being run on application star
    /// It contains handlers for working with the xml, the configs and the list that reflects the xml
    /// It also contains methods for adding/changing/delete the sets and configs and also changing the active config
    /// </summary>
    public partial class MainForm : Form
    {
        // -------------------------------------------------------------------//
        //             FIELDS, CONSTRUCTORS AND INITIALIZATIONS                 //
        // -------------------------------------------------------------------//

        // Fields for the hotkeysetlist, hotkeysetform, confighandler and xmlhandler
        private HotkeySetList hksManager;
        private HotkeySetForm hksForm;
        private ConfigHandler cfgHandler;
        private XMLHandler xmlHandler;

        /// <summary>
        /// Main constructor, instantiates the handlers and the hotkeysetlist
        /// Runs VS inits and my own inits
        /// </summary>
        public MainForm()
        {
            hksManager = new HotkeySetList();
            cfgHandler = new ConfigHandler();
            xmlHandler = new XMLHandler();

            InitializeComponent();
            InitializeGUI();
        }

        /// <summary>
        /// This method run all inits, except those made by VS
        /// </summary>
        private void InitializeGUI()
        {
            UpdateGUI();
        }

        // -------------------------------------------------------------------//
        //                               METHODS                                //
        // -------------------------------------------------------------------//

        /// <summary>
        /// This method contains all the methods that should be run every time things have to update
        /// </summary>
        private void UpdateGUI()
        {
            LoadHotkeys();
        }

        /// <summary>
        /// Loads all the hotkeys to the datagridview list
        /// </summary>
        private void LoadHotkeys()
        {
            hksManager.HotkeySetListData = xmlHandler.XMLReadAllSets(); // Reloads hotkeys from the xml-file into the hksmanager list
            
            dgwHotkeySetList.Rows.Clear(); // Clears the mainform list
            HotkeySet[] hksArray = hksManager.HotkeySetListArray; // Loads the hotkeyset array from hksManager via the property

            for (var i = 0; i < hksArray.Length; i++) // Loops through the array
            {
                dgwHotkeySetList.Rows.Add(hksArray[i].ID, hksArray[i].Voc, hksArray[i].Info); // Adds a row for every item with the array
            }
        }

        /// <summary>
        /// Checks if the game is running (tibia.exe)
        /// </summary>
        /// <returns>True if tibia is running, otherwise false</returns>
        private bool IsTibiaRunning()
        {
            Process[] tibiap = Process.GetProcessesByName("tibia"); // Creates an array with all the processes found called tibia
            if (tibiap.Length == 0) // If the length of that array is 0, i.e no process called tibia was found running
                return false;
            else
                return true;
        }

        /// <summary>
        /// Creates a new hotkeyset with input from the user and a random ID
        /// Imports a config file to go with the hotkeyset
        /// </summary>
        private void AddHotkeySetAndConfig()
        {
            if (IsTibiaRunning()) // If tibia is running
            {
                // Shows an error message
                MessageBox.Show("You cannot add new hotkeysets while tibia is running.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (hksManager.IsListFull()) // If the list is full
                {
                    // Shows an error message
                    MessageBox.Show(String.Format("The maximum number of sets ({0}) have been reached.", hksManager.HotkeySetsLimit), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else // If the list is not full
                {
                    hksForm = new HotkeySetForm(hksManager.NewIDGenerator()); // New instance of the hotkeysetform with a new id in the constructor param
                    hksForm.Text = "Add new config"; // Change the title of the instance

                    if (hksForm.ShowDialog() == DialogResult.OK) // Shows form and if the dialogresult is OK (the user ends the form by pressing "Add")
                    {
                        xmlHandler.XMLAddSet(hksForm.HotkeySetData); // Gets the newly made set from the form and creates an xml element from it
                        // Gets the newly made set's filepath and id and runs the method to import the file to the hotkeysets folder
                        cfgHandler.ImportConfig(hksForm.HotkeySetFile, hksForm.HotkeySetData.ID);
                    }
                }
            }
        }

        /// <summary>
        /// Changes the values (info & character class) of a hotkeyset
        /// Imports a new config to replace the old if selected
        /// The ID never changes with this method
        /// </summary>
        private void ChangeHotkeySetValuesAndConfig()
        {
            if (IsTibiaRunning()) // If tibia is running
            {
                // Shows an error message
                MessageBox.Show("You cannot add edit hotkeysets while tibia is running.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else // If tibia is not running
            {
                if (dgwHotkeySetList.Rows.Count == 0) // If the datagridview is empty
                {
                    MessageBox.Show("The list is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else // If the datagridview has content and thereby have a selected row
                {
                    int selectedID = (int)dgwHotkeySetList.CurrentRow.Cells[0].Value; // Gets the id of the selected row and parses it as an int

                    HotkeySet loadSet; // Creates a HotkeySet object from what's selected in the list
                    xmlHandler.XMLReadSet(selectedID, out loadSet);

                    hksForm = new HotkeySetForm(selectedID); // New instance of the hotkeysetform
                    hksForm.HotkeySetData = loadSet; // Sets the data of the form the ones we loaded
                    hksForm.LoadChangeMode(); // Actually outputs those in the form

                    if (hksForm.ShowDialog() == DialogResult.OK) // If the form was exited by pressing the change button
                    {
                        // Runs the hotkeyset manager's changeset method with a new HotkeySet as param
                        // The new HotkeySet is made by the old ID, and the new vocation and info
                        xmlHandler.XMLChangeSet(hksForm.HotkeySetData);
                        // Imports the specified config to overwrite the old one
                        // If the old and new filepath is the same, does nothing
                        cfgHandler.ImportConfig(hksForm.HotkeySetFile, hksForm.HotkeySetData.ID);
                    }
                }
            }
        }

        // -------------------------------------------------------------------//
        //                          EVENT LISTENERS                             //
        // -------------------------------------------------------------------//

        /// <summary>
        /// Deletes a hotkeyset in the xml and its corresponding config file
        /// </summary>
        private void DeleteHotkeySetAndConfig()
        {
            if (dgwHotkeySetList.Rows.Count == 0) // If the datagridview is empty
            {
                MessageBox.Show("The list is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else // If the datagridview has content and thereby have a selected row
            {
                int selectedID = (int)dgwHotkeySetList.CurrentRow.Cells[0].Value; // Gets the ID of the selected row
                xmlHandler.XMLRemoveSet(selectedID); // Removes the set in the xml by the selected id
                cfgHandler.DeleteConfig(selectedID); // Removes the config by the selected id
            }
        }

        /// <summary>
        /// Activates a new config, in other words:
        /// Replaces the config in tibias settingfolder with the one of our choice
        /// </summary>
        private void ActivateConfig()
        {
            if (dgwHotkeySetList.Rows.Count == 0) // If the datagridview is empty
            {
                MessageBox.Show("The list is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else // If the dgw has content
            {
                int selectedID = (int)dgwHotkeySetList.CurrentRow.Cells[0].Value; // Gets the value of the id cell of the selected row
                string selectedVoc = dgwHotkeySetList.CurrentRow.Cells[1].Value.ToString(); // Gets the value of the vocation cell of the selected row
                string selectedInfo = dgwHotkeySetList.CurrentRow.Cells[2].Value.ToString(); // Gets the value of the info cell of the selected row

                if (IsTibiaRunning()) // Checks if tibia is running
                {
                    MessageBox.Show("You can't change the active hotkeys while tibia is running.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else // If tibia is not running
                {
                    if (cfgHandler.ReplaceActive(selectedID)) // Replaces the active config file with the one chosen in the dgw
                    {
                        // Shows a message that the active config have been updated
                        MessageBox.Show(string.Format("The following config was loaded: {0} ({1})", selectedInfo, selectedVoc), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else // If the replaceactive method returns false
                    {
                        // Shows error message
                        MessageBox.Show("Could not find the source file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                }
            }
        }

        /// <summary>
        /// Event listener for the delete button
        /// When clicked, runs the method and updates GUI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteHotkeySetAndConfig();
            UpdateGUI();
        }

        /// <summary>
        /// Event listener for the edit button
        /// When clicked, runs the method and updates GUI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChange_Click(object sender, EventArgs e)
        {
            ChangeHotkeySetValuesAndConfig();
            UpdateGUI();
        }

        /// <summary>
        /// Event listener for the add button
        /// When clicked, runs the method and updates GUI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddHotkeySetAndConfig();
            UpdateGUI();
        }

        /// <summary>
        /// Event listener for the set active button
        /// When clicked, runs the method and updates GUI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetActive_Click(object sender, EventArgs e)
        {
            ActivateConfig();
            UpdateGUI();
        }

        /// <summary>
        /// This event helps with showing the tray icon in the right moments
        /// Hides the tray icon when the program is normal
        /// Shows the tray icon when the program is minmized
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized) // If the form is minimized
            {
                notifyIconHKS.Visible = true; // Shows the tray icon
                this.Hide(); // Hides the form (from the taskbar)
            }
            else if (this.WindowState == FormWindowState.Normal) // If the form is in normal state
            {
                notifyIconHKS.Visible = false; // Hides the tray icon
            }
        }

        /// <summary>
        /// This event is for when doubleclicking the tray icon when the application is minimized
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notifyIconHKS_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show(); // Shows the form again
            this.WindowState = FormWindowState.Normal; // Set the form state to normal
        }

        /// <summary>
        /// If the user clicks exit in the tray icon context menu
        /// Closes the form (and with that the application)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close(); // Closes the form
        }

        /// <summary>
        /// If the user clicks open hks in the tray icon context menu
        /// Shows the form and sets the form state to normal again (same as doubleclicking the tray icon)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show(); // Shows the form again
            this.WindowState = FormWindowState.Normal; // Set the form state to normal
        }
    }
}
