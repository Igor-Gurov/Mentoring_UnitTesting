using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting
{
	public class SetClass<T>: ISets<T>
	{
		private List<T> list;

		public SetClass()
		{
 			this.list=new List<T>();
		}

		public void Add(T entity)
		{
			if (Exist(entity))
				new Exception("Equals entity");
			list.Add(entity);
		}

		public void Delete(T entity)
		{
			list.Remove(entity);
		}

		public List<T> GetCollection()
		{
			return list;
		}

		public bool IsEmpty()
		{
			if (list.Count == 0)
				return true;
			else
				return false;
		}


		public int GetCount
		{
			get { return list.Count; }
		}


		public T GetItem(int index)
		{
			return list[index];
		}


		public bool Exist(T entity)
		{
			foreach (T item in list)
			{
				if (item.Equals(entity))
					return true;
			}
			return false;
		}
	}
}
