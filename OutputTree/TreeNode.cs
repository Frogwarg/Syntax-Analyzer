using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutputTree
{
    public class TreeNode<T> : IEnumerable<TreeNode<T>>
    {
        public T Data { get; set; }
        public TreeNode<T> Parent { get; set; }
        public List<TreeNode<T>> Children = new List<TreeNode<T>>();

        public TreeNode() { }
        public TreeNode(T data)
        {
            Data = data;
        }

        public void AddChild(TreeNode<T> child)
        {
            child.Parent = this;
            Children.Add(child);
        }

        public bool RemoveChild(TreeNode<T> node)
        {
            if (node == null)
                throw new ArgumentNullException(nameof(node));

            var result = Children.Remove(node);
            if (result)
            {
                node.Parent = null;
            }
            return result;
        }

        public TreeNode<T> GetNode(T data, bool ignoreCurrentNode = false, bool searchAmongChildrenOnly = false)
        {
            if (!ignoreCurrentNode && EqualityComparer<T>.Default.Equals(Data, data))
            {
                return this;
            }

            if (searchAmongChildrenOnly)
            {
                foreach (var child in Children)
                {
                    if (EqualityComparer<T>.Default.Equals(child.Data, data))
                    {
                        return child;
                    }
                }
            }
            else
            {
                foreach (var child in Children)
                {
                    var result = child.GetNode(data);
                    if (result != null)
                    {
                        return result;
                    }
                }
            }

            return null;
        }
        public string LeftmostLeafTraversal()
        {
            StringBuilder result = new StringBuilder();

            LeftmostLeafTraversal(this, result);

            return result.ToString();
        }

        private void LeftmostLeafTraversal(TreeNode<T> node, StringBuilder result)
        {
            if (node == null)
                return;

            if (node.Children.Count == 0)
            {
                result.Append(node.Data.ToString()).Append(" "); // Сохраняем лист в строку
            }
            else
            {
                foreach (var child in node.Children)
                {
                    LeftmostLeafTraversal(child, result);
                }
            }
        }

        public IEnumerator<TreeNode<T>> GetEnumerator()
        {
            return Children.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
