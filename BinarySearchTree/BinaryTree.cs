namespace _05.BinarySearchTree
{
    public class BinaryTree<T> where T : IComparable<T>
    {
        Node<T> root;

        public BinaryTree()
        {
            this.root = null;
        }

        public bool Add(T item)
        {
            Node<T> newNode = new Node<T>(item, null, null, null);

            if (root == null)
            {
                root = newNode;
                return true;
            }

            Node<T> current = root;
            while (current != null)
            {
                if (item.CompareTo(current.item) < 0)   // 왼쪽으로 가는 경우
                {
                    // 왼쪽 자식이 있을 경우
                    // 왼쪽으로 가서 계속 하강 작업을 반복
                    if (current.left != null)
                    {
                        current = current.left;
                    }
                    // 왼쪽 자식이 없을 경우
                    // 이 자리가 추가될 자리
                    else
                    {
                        current.left = newNode;
                        newNode.parent = current;
                        break;
                    }
                }
                else if (item.CompareTo(current.item) > 0)  // 오른쪽으로 가는 경우
                {
                    // 오른쪽 자식이 있을 경우
                    // 오른쪽으로 가서 계속 하강 작업을 반복
                    if (current.right != null)
                    {
                        current = current.right;
                    }
                    // 오른쪽 자식이 없는 경우
                    // 이 자리가 추가될 자리
                    else
                    {
                        current.right = newNode;
                        newNode.parent = current;
                        break;
                    }
                }
                else // if (item.CompareTo(current.item) == 0)  // 똑같은 값 찾았을 경우
                {
                    return false;   // 무시
                }
            }
            return true;
        }

        public bool Remove(T item)
        {
            Node<T> findNode = FindNode(item);
            if (findNode != null)
            {
                EraseNode(findNode);
                return true;
            }
            else
            {
                return false;
            }
        }

        private Node<T> FindNode(T item)
        {
            if (root == null)
            {
                return null;
            }

            Node<T> current = root;
            while (current != null)
            {
                if (item.CompareTo(current.item) < 0)   // 왼쪽으로 가는 경우
                {
                    current = current.left;
                }
                else if (item.CompareTo(current.item) > 0)  // 오른쪽으로 가는 경우
                {
                    current = current.right;
                }
                else    // 똑같은 걸 찾은 경우
                {
                    return current;
                }
            }

            return null;
        }

        public bool Contains(T item)
        {
            Node<T> findNode = FindNode(item);
            if (findNode == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void EraseNode(Node<T> node)
        {
            if (node.HasNoChild)
            {
                if (node.IsLeftChild)
                    node.parent.left = null;
                else if (node.IsRightChild)
                    node.parent.right = null;
                else
                    root = null;
            }
            else if (node.HasLeftChild || node.HasRightChild)
            {
                Node<T> parent = node.parent;
                Node<T> child = node.HasLeftChild ? node.left : node.right;

                if (node.IsLeftChild)
                {
                    parent.left = child;
                    child.parent = parent;
                }
                else if (node.IsRightChild)
                {
                    parent.right = child;
                    child.parent = parent;
                }
                else // if (node.IsRootNode)
                {
                    root = child;
                    child.parent = null;
                }
            }
            else // if (node.HasBothChild)
            {
                Node<T> nextNode = node.right;
                while (nextNode.left != null)
                {
                    nextNode = nextNode.left;
                }
                node.item = nextNode.item;
                EraseNode(nextNode);
            }
        }
    }

        

    public class Node<T>
    {
        public T item;

        public Node<T> parent;
        public Node<T> left;
        public Node<T> right;

        public Node(T item, Node<T> parent, Node<T> left, Node<T> rigth)
        {
            this.item = item;
            this.parent = parent;
            this.left = left;
            this.right = rigth;
        }

        public bool IsRootNode { get { return parent == null; } }
        public bool IsLeftChild { get { return parent != null && parent.left == this; } }
        public bool IsRightChild { get { return parent != null && parent.right == this; } }

        public bool HasNoChild { get { return left == null && right == null; } }
        public bool HasLeftChild { get { return left != null && right == null; } }
        public bool HasRightChild { get { return left != null && right != null; } }
        public bool HasBothChild { get { return left != null && right != null; } }
    }

    
}
