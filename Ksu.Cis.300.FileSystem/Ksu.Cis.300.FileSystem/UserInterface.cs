/* UserInterface.cs
 * Author: Nick Ruffini 
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ksu.Cis._300.FileSystem
{
    /// <summary>
    /// Controls the behavior of the user interface!
    /// </summary>
    public partial class UserInterface : Form
    {
        /// <summary>
        /// Queue that holds the absolute path to the current location in the file system
        /// Is empty when program launches
        /// </summary>
        private Queue<string> _currentpath;
        /// <summary>
        /// Holds the reference to the file system object
        /// Is empty when program launches
        /// </summary>
        private FileSystem _fileSystem;

        /// <summary>
        /// Constructor that sets the state of the application to its
        /// initial state
        /// </summary>
        public UserInterface()
        {
            InitializeComponent();
            _currentpath = new Queue<string>();
            _fileSystem = new FileSystem();
            Display();
            ButtonChange();
        }
        /// <summary>
        /// Method that checks if there is an item selected in the uxListBox, and if there is, 
        /// return true!
        /// </summary>
        /// <param name="selection"> Out parameter used to store the selected item </param>
        /// <returns> Boolean value whether or not there was a selected item </returns>
        private bool TryGetCurrentSelection(out string selection)
        {
            // if something is selected
            if (uxListBox.SelectedIndex >= 0)
            {
                // Set the out parameter to the string version of the item selected
                selection = uxListBox.SelectedItem.ToString();
                return true;
            }
            // if something isn't selected
            else
            {
                selection = default(string);
                return false;
            }
        }
        /// <summary>
        /// Controls the Enabled property of various buttons in the user interface depending
        /// on the state of the program
        /// </summary>
        private void ButtonChange()
        {
            // if there are no items in the uxListBox
            if (uxListBox.Items.Count == 0)
            {
                uxGoToButton.Enabled = false;
                uxRemoveButton.Enabled = false;
            }
            else
            {
                uxGoToButton.Enabled = true;
                uxRemoveButton.Enabled = true;
            }
            // if the path isn't one folder down,
            if (_fileSystem.RootEqualsCurrent())
            {
                uxUpOneLevelButton.Enabled = false;
            }
            else
            {
                uxUpOneLevelButton.Enabled = true;
            }
            // if the current item in the path is of type folder
            if (_fileSystem.GetCurrentType().Equals(FileType.Folder))
            {
                uxMakeFileButton.Enabled = true;
                uxMakeFolderButton.Enabled = true;
            }
            else
            {
                uxMakeFileButton.Enabled = false;
                uxMakeFolderButton.Enabled = false;
            }
        }
        /// <summary>
        /// Creates a new Queue with all the original values from the original queue
        /// </summary>
        /// <param name="original"> Original queue we are copying from </param>
        /// <returns> A new Queue<string> with the same values as the parameter</returns>
        private Queue<string> CloneQueue(Queue<string> original)
        {
            Queue<string> newQueue = new Queue<string>();
            foreach (string s in original)
            {
                newQueue.Enqueue(s);
            }
            return newQueue;
            
        }
        /// <summary>
        /// Adds each of the current path's children to the uxListBox!
        /// Also changes the uxPathLabel's text to the current path!
        /// </summary>
        private void Display()
        {
            Queue<string> newQueue = CloneQueue(_currentpath);
            uxListBox.Items.Clear();
            _fileSystem.GetCurrent(newQueue);
            foreach (string s in _fileSystem.GetCurrentChildren())
            {
                uxListBox.Items.Add(s);
            }

            StringBuilder sb = new StringBuilder();
            Queue<string> newQueue2 = CloneQueue(_currentpath);
            sb.Append("root");
            foreach (string s in newQueue2)
            {
                sb.Append("\\");
                sb.Append(s);
            }
            uxPathLabel.Text = sb.ToString();
        }
        /// <summary>
        /// Creates a new queue excluding the last element in the parameter's queue!
        /// </summary>
        /// <param name="q"> Queue that we are excluding the last item from </param>
        /// <returns> New queue with last element in parameter excluded </returns>
        private Queue<string> RemoveLastInQueue(Queue<string> q)
        {
            Queue<string> newQueue = new Queue<string>();
            Queue<string> oldQueue = CloneQueue(q);
            for (int i = 0; i < oldQueue.Count - 1; i++)
            {
                newQueue.Enqueue(oldQueue.Dequeue());
            }
            return newQueue;
        }

        /// <summary>
        /// Used to navigate down the file system!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxGoToButton_Click(object sender, EventArgs e)
        {
            if (uxListBox.SelectedIndex >= 0)
            {
                string selection;
                bool result = TryGetCurrentSelection(out selection);
                if (result == true)
                {
                    GoTo(selection);
                }
                Display();
                ButtonChange();
            }
            else
            {
                MessageBox.Show("Please select an item from list");
            }
        }
        /// <summary>
        /// Used to navigate up one level in the file system!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxUpOneLevelButton_Click(object sender, EventArgs e)
        {
            GoUp();
            Display();
            ButtonChange();
        }
        /// <summary>
        /// Removes the selected item from the file system!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxRemoveButton_Click(object sender, EventArgs e)
        {
            if (uxListBox.SelectedIndex >= 0)
            {
                string selection;
                bool result = TryGetCurrentSelection(out selection);
                if (result == true)
                {
                    Remove(selection);
                }
                Display();
                ButtonChange();
            }
            else
            {
                MessageBox.Show("Please select an item from the list");
            }
        }
        /// <summary>
        /// Creates a new file in the file system
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxMakeFileButton_Click(object sender, EventArgs e)
        {

            if (uxTextBox.Text != "")
            {
                MakeEntity(uxTextBox.Text, FileType.TextFile);
                Display();
                ButtonChange();
                uxTextBox.Clear();
            }
            else
            {
                MessageBox.Show("Please enter a name");
            }
        }
        /// <summary>
        /// Creates a new folder in the file system
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxMakeFolderButton_Click(object sender, EventArgs e)
        {
            if (uxTextBox.Text != "")
            {
                MakeEntity(uxTextBox.Text, FileType.Folder);
                Display();
                ButtonChange();
                uxTextBox.Clear();
            }
            else
            {
                MessageBox.Show("Please enter a name");
            }
        }

        /// <summary>
        /// Uses the Add method in FileSystem to add an element to the file system
        /// </summary>
        /// <param name="input"> name of file/folder we are creating </param>
        /// <param name="type"> type of file/folder we are creating </param>
        private void MakeEntity(string input, FileType type)
        {
            try
            {
                Queue<string> newQueue = CloneQueue(_currentpath);
                _fileSystem.Add(newQueue, input, type);
            }
            catch (ArgumentException ae)
            {
                MessageBox.Show(ae.Message);
            }
            catch (InvalidOperationException ie)
            {
                MessageBox.Show(ie.Message);
            }
        }
        /// <summary>
        /// Creates a copy of the current path and uses it to remove the parameter from the queue!
        /// </summary>
        /// <param name="input"> what we are removing </param>
        private void Remove(string input)
        {
            Queue<string> newQueue = CloneQueue(_currentpath);
            newQueue.Enqueue(input);
            _fileSystem.Remove(input, newQueue);
        }
        /// <summary>
        /// Moves the _current property to the given filename
        /// </summary>
        /// <param name="filename"> what we are setting _current to! </param>
        private void GoTo(string filename)
        {
            _currentpath.Enqueue(filename);
            _fileSystem.GoTo(filename);

        }
        /// <summary>
        /// If the current path isn't empty, remove the last item on the queue!
        /// Else, set current equal to the root
        /// </summary>
        private void GoUp()
        {
            if (_currentpath.Count != 0)
            {
                _currentpath = RemoveLastInQueue(_currentpath);
            }
            else
            {
                _fileSystem.GoToRoot();
            }
        }


    }
}
