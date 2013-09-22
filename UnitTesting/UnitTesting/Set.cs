using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting
{
	public class Setz<T>: ISets<T>
	{
		private List<T> list;

		public Setz()
		{
 			this.list=new List<T>();
		}

		public void Add(T entity)
		{
			if (Exist(entity))
				throw new ExistException("Equals entity");
			list.Add(entity);
		}

		public void Add(T entity,Predicate<T> pred)
		{
			if (Exist(pred))
				throw new ExistException("Equals entity");
			list.Add(entity);
		}

		public void Delete(T entity)
		{
			list.Remove(entity);
		}

		public bool IsEmpty()
		{
			return list.Count == 0;
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
			return list.Exists(e => e.Equals(entity));
		}

		public bool Exist(Predicate<T> pred)
		{
			return list.Exists(pred);
		}
	}
}
