using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotkeySwitcher
{
    /// <summary>
    /// This class represents a hotkeyset
    /// A hotkey set is a combination of an ID, a character class and a descriptive infotext
    /// </summary>
    public class HotkeySet
    {
        // -------------------------------------------------------------------//
        //             FIELDS, CONSTRUCTORS AND INITIALIZATIONS                 //
        // -------------------------------------------------------------------//

        // Fields for the hotkeyset, ID, character class and an infostring
        private int m_id;
        private CharacterClass m_voc;
        private string m_info;

        /// <summary>
        /// Constructor with one param, the ID
        /// The vocation is set to none and the info string is set to empty
        /// </summary>
        /// <param name="ID"></param>
        public HotkeySet(int ID)
        {
            m_id = ID; // Set the field value to the one from param
            m_voc = CharacterClass.None; // Sets the class to none
            m_info = String.Empty; // Makes the infostring emtpty
        }

        /// <summary>
        /// Constructor with 3 params
        /// ID, voc and info
        /// </summary>
        /// <param name="id"></param>
        /// <param name="voc"></param>
        /// <param name="info"></param>
        public HotkeySet(int id, CharacterClass voc, string info)
        {
            // Sets the field values to the ones from the params
            m_id = id; 
            m_voc = voc;
            m_info = info;
        }

        // -------------------------------------------------------------------//
        //                              PROPERTIES                              //
        // -------------------------------------------------------------------//

        /// <summary>
        /// Read/Write properties for the ID
        /// </summary>
        public int ID
        {
            get { return m_id; }
            set { m_id = value; }
        }

        /// <summary>
        /// Read/Write properties for the Vocation
        /// </summary>
        public CharacterClass Voc
        {
            get { return m_voc; }
            set { m_voc = value; }
        }

        /// <summary>
        /// Read/Write properties for the Info
        /// </summary>
        public string Info
        {
            get { return m_info; }
            set
            {
                if (value != null)
                    m_info = value;
            }
        }
    }
}
