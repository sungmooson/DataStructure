using System.Diagnostics;

namespace DoubleLinkedList
{
	public class DoublyLinkedListNode<T>
	{
		public T Data { get; set; }
		public DoublyLinkedListNode<T> Prev { get; set; }
		public DoublyLinkedListNode<T> Next { get; set; }
		
		public DoublyLinkedListNode(T data)
			: this(data, null, null)
		{

		}

		public DoublyLinkedListNode(T data,
			DoublyLinkedListNode<T> prev,
			DoublyLinkedListNode<T> next)
		{
			this.Data = data;
			this.Prev = prev;
			this.Next = next;
		}
	}
	
	public class DoublyLinkedList<T>
	{
		public DoublyLinkedListNode<T> head;

		public void Add(DoublyLinkedListNode<T> newNode)
		{
			if(head == null)
			{
				head = newNode;
			}
			else
			{
				var current = head;

				while(current != null && current.Next != null)
				{
					current = current.Next;
				}

				current.Next = newNode;
				newNode.Prev = current;
				newNode.Next = null;
			}
		}

		public void AddAfter(DoublyLinkedListNode<T> current, DoublyLinkedListNode<T> newNode)
		{
			if(head == null || current == null || newNode == null)
			{
				throw new InvalidOperationException();
			}

			newNode.Next = current.Next;
			current.Next.Prev = newNode;
			newNode.Prev = current;
			current.Next = newNode;
			
		}

		public void Remove( DoublyLinkedListNode<T> removeNode)
		{
			if(head == null || removeNode == null)
			{
				return;
			}

			if(head == removeNode)
			{
				head = head.Next;

				if(head != null)
				{
					head.Prev = null;
				}

			}
			else
			{
				removeNode.Prev.Next = removeNode.Next;
				if(removeNode.Next != null)
				{
				removeNode.Next.Prev = removeNode.Prev;
				}
		
				
				removeNode = null;

			}			
		}

		public DoublyLinkedListNode<T> GetNode(int index)
		{
			var current = head;

			for(int i = 0; i <index && current!= null; i++)
			{
				current = current.Next;
			}

			return current;
		}

		public int Count()
		{
			int cnt = 0;

			var current = head;

			while(current != null)
			{
				cnt++;
				current = current.Next;
			}
			return cnt;
		}

	}


	internal class Program
	{
		static void Main(string[] args)
		{
			var list = new DoublyLinkedList<int>();

			for(int i =0; i<5; i++)
			{
				list.Add(new DoublyLinkedListNode<int>(i));
			}

			//Index가 2인 요소 삭제
			var node = list.GetNode(2);
			list.Remove(node);

			node = list.GetNode(1);
			list.AddAfter(node, new DoublyLinkedListNode<int>(100));

			int count = list.Count();

			for(int i=0; i< count; i++)
			{
				var n = list.GetNode(i);
				Console.WriteLine(n.Data);
			}

			node = list.GetNode(4);
			for(int i = 0; i< count; i++)
			{
				Console.WriteLine(node.Data);
				node = node.Prev;
			}


		}
	}
}
