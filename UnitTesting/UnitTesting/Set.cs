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

		public SetClass(List<T> list)
		{
			this.list = list;
		}

		public void Add(T entity)
		{
			foreach (T item in list)
			{
				if (item.Equals(entity))
					throw new Exception("Object Equals");			
			}
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

		public bool CheckCollectionOnEmpty()
		{
			if (list.Count == 0)
				return true;
			else
				return false;
		}

		public int GetCount()
		{
			return list.Count;
		}
	}
}
