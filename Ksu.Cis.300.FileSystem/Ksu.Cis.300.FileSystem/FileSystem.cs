/* FileSystem.cs
 * Author: Nick Ruffini 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis._300.FileSystem
{
    /// <summary>
    /// Class that represents the construction of a file system!
    /// </summary>
    public class FileSystem
    {
        /// <summary>
        ///  The node that holds the root of the file system
        /// </summary>
        private TreeNode _elements;
        /// <summary>
        /// holds the reference to the current
        /// location in the file system, that is, the current folder/file open
        /// </summary>
        private TreeNode _current;

        /// <summary>
        /// Constructs a new file system with an empty folder as root and sets it as the current
        /// position in the _current property
        /// </summary>
        public FileSystem()
        {
            _elements = new TreeNode(FileType.Folder, "root");
            _current = _elements;
        }

        /// <summary>
        /// Adds a new node to the tree by creating a new tree node containing all of the 
        /// old children plus the new one
        /// </summary>
        /// <param name="filepath"> Location we are adding this new node </param>
        /// <param name="t"> File System we are adding to! </param>
        /// <param name="type"> Type of file this node is (Folder/TextFile) </param>
        /// <param name="data"> Name of the new node </param>
        /// <returns> An updated tree node with the new child added! </returns>
        private TreeNode Add(Queue<string> filepath, TreeNode t, FileType type, string data)
        {
            // List of children we are adding each child node to in order to create our final tree!
            List<TreeNode> children = new List<TreeNode>();

            // If we haven't reached our destination yet...
            if (filepath.Count != 0)
            {
                // Get the string of the filename we want to "dive" into next
                string nextNodeName = filepath.Dequeue();

                // go through each of the children of our current node...
                foreach (TreeNode tree in t.Children)
                {
                    // If we find the child we want to go further into, recursively go further
                    if(tree.Data.Equals(nextNodeName))
                    {
                        children.Add(Add(filepath, tree, type, data));
                    }
                    // If this isn't the child we want to go into, we still need to add it!
                    else
                    {
                        children.Add(tree);
                    }
                }
            }
            // If we reach our destination... (the current folder is where we are adding the new child)
            else
            {
                // Add each child of this tree node into the list of children!
                // Also, check each tree to make sure there are no duplicates
                foreach (TreeNode tree in t.Children)
                {
                    children.Add(tree);
                    // If the data of one of the children equals the data we are looking for,
                    // throw an exception, since we cannot have duplicates!
                    if (tree.Data.Equals(data))
                    {
                        throw new ArgumentException();
                    }
                }
                // Create a new tree node and add it to the list of children
                TreeNode newNode = new TreeNode(type, data);
                children.Add(newNode);
            }
            // Create a new overall tree using our new list of children
            TreeNode newTree = new TreeNode(t.Type, t.Data, children);
            return newTree;
        }

        /// <summary>
        /// Removes a node and creates a new tree with all of the previous's children minus the 
        /// one removed
        /// </summary>
        /// <param name="filepath"> Location we are adding this node </param>
        /// <param name="t"> Tree Node we are looking through </param>
        /// <param name="data"> Data of node we are removing </param>
        /// <param name="removed"> Bool returning whether or not the node was removed </param>
        /// <returns> New tree minus the removed node </returns>
        private TreeNode Remove(Queue<string> filepath, TreeNode t, string data, out bool removed)
        {
            // List of children we are adding each child node to in order to create our final tree!
            List<TreeNode> children = new List<TreeNode>();

            // If we haven't reached our destination yet...
            if (filepath.Count != 0)
            {
                removed = false;
                // Get the string of the filename we want to "dive" into next
                string nextNodeName = filepath.Dequeue();

                // go through each of the children of our current node...
                foreach (TreeNode tree in t.Children)
                {
                    // If we find the child we want to go further into, recursively go further
                    if (tree.Data.Equals(nextNodeName))
                    {
                            TreeNode newNode = Remove(filepath, tree, data, out removed);
                            if (newNode != null)
                            {
                                children.Add(Remove(filepath, tree, data, out removed));
                            }
                         children.Add(Remove(filepath, tree, data, out removed));
                    }
                    // If this isn't the child we want to go into, we still need to add it!
                    else
                    {
                        children.Add(tree);
                    }
                }
            }

            else
            {
                /*foreach (TreeNode tree in t.Children)
                {
                    if (tree.Data.Equals(data))
                    {
                        removed = true;
                        return null;
                    }
                    else if (tree.Data != null)
                    {
                        children.Add(tree);
                    }
                }*/
                removed = true;
                return null;
            }
            // Create a new overall tree using our new list of children
            TreeNode newTree = new TreeNode(t.Type, t.Data, children);
            return newTree;
        }

        /// <summary>
        /// Calls on the private Remove method and returns whether the element was removed or not
        /// </summary>
        /// <param name="data"> Data of node we are removing </param>
        /// <param name="filepath"> Location of the node we are removing </param>
        /// <returns> Bool whether the element was removed or not </returns>
        public bool Remove(string data, Queue<string> filepath)
        {
            _elements = Remove(filepath, _elements, data, out bool removed);
            if (removed == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Calls on the private Add method to add an element to the Tree!
        /// </summary>
        /// <param name="filepath"> Location of the node we are removing </param>
        /// <param name="data"> Data of node we are adding </param>
        /// <param name="type"> Type of file we are adding </param>
        public void Add(Queue<string> filepath, string data, FileType type)
        {
            _elements = Add(filepath, _elements, type, data);
        }
        /// <summary>
        /// Checks if the parameter is a child of the current node, and if it is, sets the 
        /// current node to the child.
        /// </summary>
        /// <param name="input"> Child we are setting current to! </param>
        public void GoTo(string input)
        {
            foreach (TreeNode child in _current.Children)
            {
                if (child.Data.Equals(input))
                {
                    _current = child;
                }
            }
        }
        /// <summary>
        /// Returns all of the children of this node in string form (their names)
        /// </summary>
        /// <returns> List full of the children's names </returns>
        public List<string> GetCurrentChildren()
        {
            List<string> newList = new List<string>();
            foreach (TreeNode node in _current.Children)
            {
                newList.Add(node.Data);
            }
            return newList;
        }
        /// <summary>
        /// Updates _current to path given in filepath!
        /// </summary>
        /// <param name="filepath"> Path we are setting _current equal to! </param>
        /// <param name="t"> Tree we are looking at </param>
        /// <returns></returns>
        private bool FindCurrent(Queue<string> filepath, TreeNode t)
        {
            if (filepath.Count != 0)
            {
                // Get the string of the filename we want to "dive" into next
                string nextNodeName = filepath.Dequeue();

                // go through each of the children of our current node...
                foreach (TreeNode tree in t.Children)
                {
                    // If we find the child we want to go further into, recursively go further
                    if (tree.Data.Equals(nextNodeName))
                    {
                        return FindCurrent(filepath, tree);
                    }
                }
            }
            else
            {
                _current = t;
                return true;
            }
            return false;
        }
        /// <summary>
        /// Uses FindCurrent to update _current and then return the name of the node at the
        /// end of the path!
        /// </summary>
        /// <param name="filepath"> Location of the node we are looking for </param>
        /// <returns> The string name of the node at the end of the path </returns>
        public string GetCurrent(Queue<string> filepath)
        {
            bool result = FindCurrent(filepath, _elements);
            return _current.Data;
        }
        /// <summary>
        /// Sets the _current node to reference the root (_elements)
        /// </summary>
        public void GoToRoot()
        {
            _current = _elements;
        }
        /// <summary>
        /// Returns the file type of the current node (Folder/TextFile)
        /// </summary>
        /// <returns></returns>
        public FileType GetCurrentType()
        {
            return _current.Type;
        }



        /// <summary>
        /// Checks if the current is set equal to the root!
        /// </summary>
        /// <returns> Whether or not the current is set equal to the root </returns>
        public bool RootEqualsCurrent()
        {
            if (_current.Data.Equals(_elements.Data))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
