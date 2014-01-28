using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Windows.Forms;

namespace HotkeySwitcher
{
    /// <summary>
    /// This class represents the list displayed in the mainform
    /// Simply a list of hotkeysets
    /// </summary>
    public class HotkeySetList
    {
        // -------------------------------------------------------------------//
        //             FIELDS, CONSTRUCTORS AND INITIALIZATIONS                 //
        // -------------------------------------------------------------------//

        private List<HotkeySet> m_hotkeysetlist; // The list of HotkeySets (to be displayed in the mainform)
        private const int m_maxHotkeySets = 100; // Max amount of hotkeysets in the list

        /// <summary>
        /// Default constructor, instantiates the hotkeyset list
        /// </summary>
        public HotkeySetList()
        {
            m_hotkeysetlist = new List<HotkeySet>();
        }

        // -------------------------------------------------------------------//
        //                              PROPERTIES                              //
        // -------------------------------------------------------------------//
        
        /// <summary>
        /// Write access for the hotkeyset list
        /// We can read the list from xml and set it with this property
        /// </summary>
        public List<HotkeySet> HotkeySetListData
        {
            set
            {
                if (value != null)
                    m_hotkeysetlist = value;
            }
        }

        /// <summary>
        /// Returns the amount of items in the hotkeyset list
        /// </summary>
        public int Count
        {
            get { return m_hotkeysetlist.Count(); }
        }

        /// <summary>
        /// Returns the list as an array of hotkeysets
        /// </summary>
        public HotkeySet[] HotkeySetListArray
        {
            get { return m_hotkeysetlist.ToArray(); }
        }

        /// <summary>
        /// Returns the hotkeyset limit from the const field value
        /// </summary>
        public int HotkeySetsLimit
        {
            get { return m_maxHotkeySets; }
        }

        // -------------------------------------------------------------------//
        //                               METHODS                                //
        // -------------------------------------------------------------------//

        /// <summary>
        /// This method checks if a given ID is already assigned to an item in the list
        /// The method will be used for when giving a new set an id, since we want all the items to have unique ids
        /// </summary>
        /// <param name="ID"></param>
        /// <returns>True if the ID is available, otherwise false</returns>
        public bool IsIDAvailable(int ID)
        {
            // If an item with the given ID does NOT exist in the lists
            if (m_hotkeysetlist.Find(item => item.ID == ID) == null)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Checks if the list of hotkeysets is full
        /// </summary>
        /// <returns>True/False depending if list is full or not</returns>
        public bool IsListFull()
        {
            if (Count >= HotkeySetsLimit) // If the amount of items in the list is equal to or more than the limit
                return true;
            else
                return false;
        }

        /// <summary>
        /// This method generates a new and unique id to go with a hotkeyset
        /// </summary>
        /// <returns>Returns a random id between 1 and the limit or 0 if the list is full</returns>
        public int NewIDGenerator()
        {
            Random rnd = new Random(); // Creates a new instance of the random object
            int id = 0; // Initiates id as 0

            if (IsListFull() == false) // If the hotkeyset list is not full
            {
                // If the id is equal to 0 (hasn't been assigned a random value yet) OR
                // The random id generated is unavailable (already taken by another list item)
                while (id == 0 || IsIDAvailable(id) == false)
                {
                    id = rnd.Next(1, HotkeySetsLimit + 1); // Generates a random number between 1 and the limit
                }
            }

            return id; // Returns the id
        }
    }
}
