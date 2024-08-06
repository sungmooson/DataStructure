using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DynamicArr
{
	
	public class SinglyLinkedListNode<T>
	{
		public T Data { get; set; }
		public SinglyLinkedListNode<T> Next { get; set; }

		public SinglyLinkedListNode(T data)
		{
			this.Data = data;
			this.Next = null;
		}
	}
	

	public class SinglyLinkedList<T>
	{
		private SinglyLinkedListNode<T> head;

		public void Add(SinglyLinkedListNode<T> newNode)
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
			}

		}


		public void AddAfter(SinglyLinkedListNode<T> current, SinglyLinkedListNode<T> newNode)
		{
			if(head == null || current == null 
				|| newNode == null)
			{
				throw new InvalidOperationException();
			}

			newNode.Next = current.Next;
			current.Next = newNode;


		}

		public void Remove(SinglyLinkedListNode<T> removeNode)
		{
			if(head == null || removeNode == null)
			{
				return;
			}

			if(head == removeNode)
			{
				head = head.Next;
				removeNode = null;
			}
			else
			{
				var current = head;

				while(current != null && current.Next != removeNode)
				{
					current = current.Next;
				}
				
				if(current != null)
				{
					current.Next = removeNode.Next;
					removeNode = null;
				}
				
			}

		}


		public SinglyLinkedListNode<T> GetNode(int index)
		{
			var current = head;

			for(int i = 0; i< index && current != null; i++)
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





	internal static class Program
	{
		/// <summary>
		/// 해당 애플리케이션의 주 진입점입니다.
		/// </summary>
		[STAThread]
		static void Main()
		{
			var list = new SinglyLinkedList<int>();

			for(int i = 0; i< 5; i++)
			{
				list.Add(new SinglyLinkedListNode<int>(i));
			}

			var node = list.GetNode(2);
			list.Remove(node);

			node = list.GetNode(1);
			list.AddAfter(node, new SinglyLinkedListNode<int>(100));

			int count = list.Count();

			for(int i = 0; i< count; i++)
			{
				var n = list.GetNode(i);
				Console.WriteLine(n.Data);

			}

			//Application.EnableVisualStyles();
			//Application.SetCompatibleTextRenderingDefault(false);
			//Application.Run(new Form1());

		}
	}

	

		

	}


	
	
