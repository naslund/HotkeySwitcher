using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HotkeySwitcher
{
    /// <summary>
    /// This class manages all the copying/deleting/replacing of hotkey config (.cfg) files
    /// </summary>
    public class ConfigHandler
    {
        // -------------------------------------------------------------------//
        //                               METHODS                                //
        // -------------------------------------------------------------------//

        /// <summary>
        /// If the configs directory doesn't exist - create it
        /// </summary>
        private void CreateConfigDirectory()
        {
            string dir = "Configs"; // Folder name

            if (!Directory.Exists(dir)) // If folder doesnt exist
                Directory.CreateDirectory(dir); // Creates that folder
        }

        /// <summary>
        /// Copies the file from the source (the file the user chose) to "sameFolderAsOurExe/Configs/ID.cfg"
        /// Also overwrites the target if it already exists, which means we can use this method for changing config aswell
        /// </summary>
        /// <param name="source"></param>
        /// <param name="ID"></param>
        public bool ImportConfig(string source, int ID)
        {
            CreateConfigDirectory(); // Creates the Configs folder if it does not exist

            // Creates a string with the destination relative to our application root
            // Something like: "Configs/99.cfg"
            string destinationFolder = "Configs";
            string destinationFileName = ID.ToString() + ".cfg";
            string destination = Path.Combine(destinationFolder, Path.GetFileName(destinationFileName));

            // If the source and destination filepaths are NOT the same
            // If they were the same and a copy was attempted, it would result in a runtime error
            if (Path.GetFullPath(source) != Path.GetFullPath(destination)) 
            {
                if (File.Exists(source)) // If the source file exists
                {
                    File.Copy(source, destination, true); // Copies the source file to the destination and overwrites any file in its way
                    return true; // The operation was a success
                }
                else
                {
                    return false; // The operation failed because the source file was not found
                }
            }
            else // If the filepaths are the same
            {
                return false;
            }
        }

        /// <summary>
        /// Deletes the config named "ID.cfg" in the Configs folder
        /// </summary>
        /// <param name="ID">This ID represents a certain config, both in the xml file and the .cfg filename</param>
        /// <returns></returns>
        public bool DeleteConfig(int ID)
        {
            CreateConfigDirectory(); // Creates the Configs folder if it does not exist

            string targetFolder = "Configs"; // The name of the folder that contains all configs
            string targetFileName = ID.ToString() + ".cfg"; // Formats a string like "99.cfg"
            string target = Path.Combine(targetFolder, Path.GetFileName(targetFileName)); // Builds a string like "HotkeySets/99.cfg"

            if (File.Exists(target)) // If the file build above exists
            {
                File.Delete(target); // Deletes that file
                return true; // Returns true
            }
            else // If the file "target" doesn't exist
            {
                return false; // Returns false
            }
        }

        /// <summary>
        /// This method replaces the active config
        /// It copies the file with the right ID from "Configs/ID.cfg" ---> "Roaming/Tibia/Tibia.cfg"
        /// </summary>
        /// <param name="ID"></param>
        public bool ReplaceActive(int ID)
        {
            CreateConfigDirectory(); // Creates the Configs folder if it does not exist

            string sourceFolder = "Configs"; // "Config/"
            string sourceFileName = ID.ToString() + ".cfg"; // "99.cfg"
            string source = Path.Combine(sourceFolder, Path.GetFileName(sourceFileName)); // "Configs/99.cfg"

            string roamingFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData); // Gets the roaming folder "C:/Users/<username>/AppData/Roaming/" for Win7
            string roamingTibiaFolder = Path.Combine(roamingFolder, "Tibia"); // Appends Tibia folder name ".../Roaming/Tibia/"
            string tibiaCfgFileName = "Tibia.cfg"; // The filename of the active config
            string destination = Path.Combine(roamingTibiaFolder, Path.GetFileName(tibiaCfgFileName)); // Appends filename to the tibia folder path ".../Roaming/Tibia/Tibia.cfg"

            if (!File.Exists(source)) // If the source file cannot be found
            {
                return false; // Returns false, could not copy
            }
            else // If the source file can be found
            {
                if (!Directory.Exists(roamingTibiaFolder)) // Check if the /Roaming/Tibia folder exists
                    Directory.CreateDirectory(roamingTibiaFolder); // Create it if it does not exist
                File.Copy(source, destination, true); // Copies from source to destination and overwrites if necessary
                return true; // Returns true, copy was a success
            }
        }
    }
}
