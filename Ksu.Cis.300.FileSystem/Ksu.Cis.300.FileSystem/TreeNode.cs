/* TreeNode.cs
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
    /// The TreeNode class defines an immutable tree node
    /// </summary>
    public class TreeNode
    {
        /// <summary>
        /// A property that holds the type of element this node
        /// represents
        /// </summary>
        public FileType Type { get; }
        /// <summary>
        /// This property holds the name of the entity
        /// </summary>
        public string Data { get; }
        /// <summary>
        /// This property holds the children of this node
        /// </summary>
        public List<TreeNode> Children { get; }
        /// <summary>
        /// Constructor that creates an object of
        /// type TreeNode initialized with the values passed in the parameters
        /// </summary>
        /// <param name="type"> The type associated with this tree none (Folder/TextFile) </param>
        /// <param name="data"> String that holds the name of the node </param>
        /// <param name="children"> List of TreeNodes that holds all the children of this node </param>
        public TreeNode(FileType type, string data, List<TreeNode> children)
        {
            Type = type;
            Data = data;
            Children = children;
        }
        /// <summary>
        /// Alternative constructor that creates an object of type
        /// TreeNode initialized with the values passed in the parameters. It sets the children to an
        /// empty list (not null), making this TreeNode a leaf.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="data"></param>
        public TreeNode(FileType type, string data)
        {
            Type = type;
            Data = data;
            Children = new List<TreeNode>();
        }

    }
}
