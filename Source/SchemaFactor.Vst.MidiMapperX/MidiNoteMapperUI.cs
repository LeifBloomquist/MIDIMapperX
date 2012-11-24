using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SchemaFactor.Vst.MidiMapperX
{
    /// <summary>
    /// The plugin custom editor UI.
    /// </summary>
    partial class MidiNoteMapperUI : UserControl
    {
        /// <summary>
        /// Constructs a new instance.  Must be parameterless to avoid error CS0310.
        /// </summary>
        public MidiNoteMapperUI()
        {
            InitializeComponent();
            SizeLastColumn(MapListVw);
            FillList();
        }

        private Plugin _plugin;
        private long _idleCount = 0;
        private bool _showDebug = false;

        private ListViewItemComparer _lvwItemComparer = new ListViewItemComparer();

        public void setPlugin(Plugin plugin)
        {     
            _plugin = plugin;
            FillList();
        }

        /// <summary>
        /// Updates the UI
        /// </summary>
        public void ProcessIdle()
        {
            _idleCount++;

            if (_plugin.presetsLoaded == true)
            {
                FillList();
                _plugin.presetsLoaded = false;
            }


            if ((_plugin != null) && (DebugLabel.Visible))
            {
                DebugLabel.Text = "Keys:   " + _plugin.NoteMap.Count + "\n" +
                                  "Idle:   " + _idleCount + "\n" +
                                  "Calls:  " + _plugin.callCount + "\n" +
                                  "Events: " + _plugin.eventCount + "\n" +
                                  "MIDI:   " + _plugin.midiCount + "\n" +
                                  "Hits:   " + _plugin.hitCount + "\n" +
                                  "Last Output: [" + MapNoteItem.lastOutputString +"]";
            }
        }

        private void SelectNoteMapItem(byte noteNo)
        {
            MapListVw.SelectedIndices.Clear();

            if (MapListVw.Items.ContainsKey(noteNo.ToString()))
            {
                MapListVw.Items[noteNo.ToString()].Selected = true;                
            }
        }

        private void FillList()
        {
            if (_plugin == null) return;

            if ( (!this.Created) || (_plugin.NoteMap == null) ) return;

            MapListVw.Items.Clear();

            foreach (MapNoteItem item in _plugin.NoteMap)
            {
                ListViewItem lvItem = new ListViewItem(item.KeyName);
                lvItem.SubItems.Add(item.TriggerNoteNumber.ToString());
                lvItem.SubItems.Add(item.OutputBytesStringOn);
                lvItem.SubItems.Add(item.OutputBytesStringOff);
                lvItem.Name = item.TriggerNoteNumber.ToString();  // This isn't displayed anywhere, but handy to store the Note#  (used below by Add/Edit)

                MapListVw.Items.Add(lvItem);
            }

            // Do this here because it is done anywhere the GUI is updated, and we know that plugin is set and persistence has loaded. 
            ThruCheckbox.Checked = _plugin.midiThru;
        }

        // "Add" Button
        private void AddBtn_Click(object sender, EventArgs e)
        {
            MapNoteItem newMapNoteItem = new MapNoteItem()
            {
                KeyName = "New Note Map",
                TriggerNoteNumber = 60,  // C4
                OutputBytesStringOn = "",
                OutputBytesStringOff = ""
            };

            bool complete = false;

            while (!complete)
            {
                MapNoteDetailsUI dlg = new MapNoteDetailsUI(newMapNoteItem);

                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    // Check if the NoteMap already exists, and prompt for replacement
                    if (_plugin.NoteMap.Contains(dlg.TempMapNoteItem.TriggerNoteNumber))
                    {
                        if (MessageBox.Show(this,
                                            String.Format("A mapping with Note# {0} already exists.  Replace?", dlg.TempMapNoteItem.TriggerNoteNumber),
                                            "Add a Note Map Item.",
                                            MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            // Remove the old entry    Could use the ChangeItemKey Method here, but let's start simple.
                            _plugin.NoteMap.Remove(dlg.TempMapNoteItem.TriggerNoteNumber);                         
                        }
                        else
                        {
                            newMapNoteItem = dlg.TempMapNoteItem;  // This is a bit wonky, but persists the note item for the next iteration.
                            continue;  // Show the dialog again
                        }
                    } // if

                    // Add new entry
                    _plugin.NoteMap.Add(dlg.TempMapNoteItem);                               
                    complete = true;   // Successfully added
                }
                else
                {
                    complete = true;   // Successfully cancelled
                }
            } // while
            FillList();
        }

        // "Edit" Button
        private void EditBtn_Click(object sender, EventArgs e)
        {
            // Exit if nothing selected
            if (MapListVw.SelectedItems.Count == 0) return;

            byte oldTriggerNoteNum = Byte.Parse(MapListVw.SelectedItems[0].Name);   // .Name was filled in by FillList

            if (_plugin.NoteMap.Contains(oldTriggerNoteNum))
            {
                MapNoteItem tempItem = new MapNoteItem
                {
                    KeyName =  _plugin.NoteMap[oldTriggerNoteNum].KeyName,
                    TriggerNoteNumber =  oldTriggerNoteNum,
                    OutputBytesStringOn = _plugin.NoteMap[oldTriggerNoteNum].OutputBytesStringOn,
                    OutputBytesStringOff = _plugin.NoteMap[oldTriggerNoteNum].OutputBytesStringOff
                };

                MapNoteDetailsUI dlg = new MapNoteDetailsUI(tempItem);

                bool complete = false;

                while (!complete)
                {
                    if (dlg.ShowDialog(this) == DialogResult.OK)
                    {
                        // Check if the NoteMap changed, but already exists in the list
                        if ( (dlg.TempMapNoteItem.TriggerNoteNumber != oldTriggerNoteNum) && (_plugin.NoteMap.Contains(dlg.TempMapNoteItem.TriggerNoteNumber)) )
                        {
                            MessageBox.Show(this,
                                            String.Format("A mapping with Note# {0} already exists.", dlg.TempMapNoteItem.TriggerNoteNumber),
                                            "Edit a Note Map Item.");
                            continue;  // Show dialog again
                        }

                        // Remove the old entry    Could use the ChangeItemKey Method here, but let's keep it simple.         
                        if (_plugin.NoteMap.Remove(oldTriggerNoteNum))
                        {
                            // Add new entry
                            _plugin.NoteMap.Add(dlg.TempMapNoteItem);                           
                            complete = true;  // Successfully replaced
                        }
                        else
                        {
                            MessageBox.Show("(Edit) Logic Error: Remove Failed!  oldTriggerNoteNum=" + oldTriggerNoteNum);
                            break;  
                        }
                    }
                    else                    
                    {
                        complete = true;   // Successfully cancelled
                    }                    
                } // while

                FillList();
            }
            else
            {
                MessageBox.Show("(Edit) Logic Error: oldTriggerNoteNum=" + oldTriggerNoteNum + " is in table but was not found in list.");
            }
        }

        // "Delete" Button
        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            // Exit if nothing selected
            if (MapListVw.SelectedItems.Count == 0) return;
            
            byte oldTriggerNoteNum = Byte.Parse(MapListVw.SelectedItems[0].Name);   // .Name was filled in by FillList

            if (_plugin.NoteMap.Contains(oldTriggerNoteNum))
            {
                MapNoteItem item = _plugin.NoteMap[oldTriggerNoteNum];

                if (MessageBox.Show(this,
                                    String.Format("Are you sure you want to delete {0} ({1})?", item.KeyName, item.TriggerNoteNumber),
                                    "Delete a Note Map Item.",
                                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    _plugin.NoteMap.Remove(oldTriggerNoteNum);
                    FillList();
                }
            }
            else
            {
                MessageBox.Show("(Delete) Logic Error: triggerNoteNum=" + oldTriggerNoteNum + " is in table but not found in list.");
            }
        }

        private void MidiNoteMapperUI_Load(object sender, EventArgs e)
        {
            this.MapListVw.ListViewItemSorter = _lvwItemComparer;            
            FillList();
        }

        private void MapListVw_Resize(object sender, System.EventArgs e)
        {           
            SizeLastColumn((ListView)sender);
        }

        private void SizeLastColumn(ListView lv)
        {
            lv.Columns[lv.Columns.Count - 1].Width = -2;
        }

        private void MapListVw_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
        {          
            SizeLastColumn((ListView)sender);
        }

        // "About" Button
        private void AboutBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show( _plugin.ProductInfo.Vendor + "\n\n" + 
                             _plugin.ProductInfo.Product + "\n\n" +                            
                             "Version: " + _plugin.ProductInfo.FormattedVersion,
                             "Schema Factor MIDIMapperX");
        }

        private void MidiNoteMapperUI_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                _showDebug = !_showDebug;
                DebugLabel.Visible = _showDebug;
            }
        }

        private void MapListVw_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == _lvwItemComparer.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (_lvwItemComparer.Order == SortOrder.Ascending)
                {
                    _lvwItemComparer.Order = SortOrder.Descending;
                }
                else
                {
                    _lvwItemComparer.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                _lvwItemComparer.SortColumn = e.Column;
                _lvwItemComparer.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            MapListVw.Sort();
        }

        private void ThruCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            _plugin.midiThru = ThruCheckbox.Checked;
        }
    }

    /// <summary>
    /// Helper class for the sorting.
    /// From http://stackoverflow.com/questions/4638760/how-to-sort-things-out-in-listview
    /// </summary>
    public class ListViewItemComparer : IComparer
    {
        // Specifies the column to be sorted
        private int ColumnToSort;

        // Specifies the order in which to sort (i.e. 'Ascending').
        private SortOrder OrderOfSort;

        // Case insensitive comparer object
        private CaseInsensitiveComparer ObjectCompare;

        /// <summary>
        /// Class constructor, initializes various elements
        /// </summary>
        public ListViewItemComparer()
        {
            // Initialize the column to '0'
            ColumnToSort = 0;

            // Initialize the sort order to 'none'
            OrderOfSort = SortOrder.None;

            // Initialize the CaseInsensitiveComparer object
            ObjectCompare = new CaseInsensitiveComparer();
        }

        /// <summary>
        /// This method is inherited from the IComparer interface.
        /// It compares the two objects passed using a case
        /// insensitive comparison.
        ///
        /// x: First object to be compared
        /// y: Second object to be compared
        ///
        /// The result of the comparison. "0" if equal,
        /// negative if 'x' is less than 'y' and
        /// positive if 'x' is greater than 'y'
        /// </summary>
        public int Compare(object x, object y)
        {
            int compareResult;
            ListViewItem listviewX, listviewY;

            // Cast the objects to be compared to ListViewItem objects
            listviewX = (ListViewItem)x;
            listviewY = (ListViewItem)y;


            // Determine whether the type being compared is a date type.
            try
            {
                // Parse the two objects passed as a parameter as a DateTime.
                DateTime firstDate = DateTime.Parse(listviewX.SubItems[ColumnToSort].Text);
                DateTime secondDate = DateTime.Parse(listviewY.SubItems[ColumnToSort].Text);

                // Compare the two dates.
                compareResult = DateTime.Compare(firstDate, secondDate);
            }

            // If neither compared object has a valid date format,
            // perform a Case Insensitive Sort
            catch
            {
                try
                {
                    int num1 = int.Parse(listviewX.SubItems[ColumnToSort].Text);
                    int num2 = int.Parse(listviewY.SubItems[ColumnToSort].Text);

                    // Compare the two dates.
                    compareResult = num1.CompareTo(num2);
                }
                catch
                {
                    // Case Insensitive Compare
                    compareResult = ObjectCompare.Compare(
                    listviewX.SubItems[ColumnToSort].Text,
                    listviewY.SubItems[ColumnToSort].Text
                    );
                }
            }

            // Calculate correct return value based on object comparison
            if (OrderOfSort == SortOrder.Ascending)
            {
                // Ascending sort is selected, return normal result of compare operation
                return compareResult;
            }
            else if (OrderOfSort == SortOrder.Descending)
            {
                // Descending sort is selected, return negative result of compare operation
                return (-compareResult);
            }
            else
            {
                // Return '0' to indicate they are equal
                return 0;
            }
        }

        /// Gets or sets the number of the column to which to
        /// apply the sorting operation (Defaults to '0').
        public int SortColumn
        {
            set
            {
                ColumnToSort = value;
            }
            get
            {
                return ColumnToSort;
            }
        }

        /// Gets or sets the order of sorting to apply
        /// (for example, 'Ascending' or 'Descending').
        public SortOrder Order
        {
            set
            {
                OrderOfSort = value;
            }
            get
            {
                return OrderOfSort;
            }
        }
    } 
}
