using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;

namespace HotkeySwitcher
{
    /// <summary>
    /// This class handles all actions regarding reading/writing/deleting from the XML file
    /// </summary>
    public class XMLHandler
    {
        // -------------------------------------------------------------------//
        //                               METHODS                                //
        // -------------------------------------------------------------------//

        /// <summary>
        /// Creates the XML file if it doesnt already exist
        /// </summary>
        public void XMLCreateFile()
        {
            string xmlFile = "HotkeySets.xml"; // Name of the file

            if (!File.Exists(xmlFile)) // If the file does NOT exist
            {
                // Creates a new xml file with the sets node
                new XDocument(
                    new XElement("sets") // <sets> node
                )
                .Save(xmlFile); // Saves it as the filename described above
            }

        }

        /// <summary>
        /// Reads all the sets in the xml file and returns it as a list of hotkeysets
        /// </summary>
        /// <returns>All sets in the XML file as a list</returns>
        public List<HotkeySet> XMLReadAllSets()
        {
            XMLCreateFile(); // Creates an XML file if it doesnt exist
            List<HotkeySet> allSets = new List<HotkeySet>(); // Creates a list of hotkeysets
            XDocument xmlDoc = XDocument.Load("HotkeySets.xml"); // Opens the file

            var sets = from set in xmlDoc.Descendants("set") // Gets all the sets in the xml
                       select new
                       {
                           ID = set.Element("id").Value,
                           Voc = set.Element("voc").Value,
                           Info = set.Element("info").Value,
                       };

            foreach (var set in sets) // Looping through all the sets
            {
                // Creates an hotkeyset object for the currently looped set
                // Adds that set to the list that will be returned
                allSets.Add(new HotkeySet(int.Parse(set.ID), (CharacterClass)int.Parse(set.Voc), set.Info));
            }

            return allSets; // Returns the list
        }

        /// <summary>
        /// Reads a set with a specific ID and outputs that set as an out HotkeySet
        /// </summary>
        /// <param name="ID">The ID of the element that will be read from XML</param>
        /// <param name="setOutput">Out param for the hotkeyset output</param>
        /// <returns>True/false depending on if the read was successful or not</returns>
        public bool XMLReadSet(int ID, out HotkeySet setOutput)
        {
            XMLCreateFile(); // Creates an XML file if it doesnt exist
            XDocument xmlDoc = XDocument.Load("HotkeySets.xml"); // Opens up the xml file

            // Selects all sets with the given ID
            var sets = from set in xmlDoc.Descendants("set")
                       where set.Element("id").Value == ID.ToString()
                       select new
                       {
                           ID = set.Element("id").Value,
                           Voc = set.Element("voc").Value,
                           Info = set.Element("info").Value,
                       };

            // If the first element is "sets" is not null (at least one element was found with that ID)
            if (sets.FirstOrDefault() != null)
            {
                // Sets the setOutput to a new hotkeyset based on the values read from xml
                setOutput = new HotkeySet(ID, (CharacterClass)int.Parse(sets.First().Voc), sets.First().Info);
                return true; // Returns true, the read was successful
            }
            else // If no element with that ID was found
            {
                setOutput = null; // Sets the output to null (wont be used for anything)
                return false; // Returns false, the read failed
            }
        }

        /// <summary>
        /// Adds a new set element with the xml
        /// </summary>
        public void XMLAddSet(HotkeySet setInput)
        {
            XMLCreateFile(); // Creates an XML file if it doesnt exist
            XDocument xmlDoc = XDocument.Load("HotkeySets.xml"); // Opens up the xml file

            // In the root element (<sets>) add a <set> with all the values from param
            xmlDoc.Element("sets").Add(
                new XElement("set",
                    new XElement("id", setInput.ID),
                    new XElement("voc", (int)setInput.Voc),
                    new XElement("info", setInput.Info)));

            xmlDoc.Save("HotkeySets.xml"); // Saves all changes to the xml file
        }

        /// <summary>
        /// Removes the set and its contents from the xml file on a specific id
        /// </summary>
        /// <param name="ID">The id from a set which is to be removed</param>
        public void XMLRemoveSet(int ID)
        {
            XMLCreateFile(); // Creates an XML file if it doesnt exist
            XDocument xmlDoc = XDocument.Load("HotkeySets.xml"); // Opens the xml file for modification

            xmlDoc.Element("sets") // Root node
                .Elements("set") // Select all sets (should be just 1 since the IDs are unique)
                .Where(elem => (string)elem.Element("id").Value == ID.ToString()) // Filters so only sets with the id provided from params is selected
                .Remove(); // Removes said set

            xmlDoc.Save("HotkeySets.xml"); // Saves modifications to the xml
        }

        /// <summary>
        /// Removes the set with the ID from the param object
        /// Adds set from the same param object
        /// </summary>
        /// <param name="setInput">The set to be modified</param>
        public void XMLChangeSet(HotkeySet setInput)
        {
            XMLCreateFile(); // Creates an XML file if it doesnt exist
            XDocument xmlDoc = XDocument.Load("HotkeySets.xml"); // Opens the xml file for modification

            var sets = xmlDoc.Element("sets") // <sets>
                .Elements("set") // <set>
                .Where(elem => (string)elem.Element("id").Value == setInput.ID.ToString()); // Chooses the element (or elements) with the same id as param object's ID

            foreach (var set in sets) // Loops through the sets and updates the matches
            {
                set.Element("voc").Value = ((int)setInput.Voc).ToString(); // Updates the nodevalue to the voc casted into an int, and then turned into a string
                set.Element("info").Value = setInput.Info; // Updates the nodevalue to the info string from param
            }

            xmlDoc.Save("HotkeySets.xml"); // Saves modifications to the xml
        }
    }
}
