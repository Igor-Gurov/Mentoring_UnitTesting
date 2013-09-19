using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting
{
    public interface ISets<T>
    {
		void Add(T entity);

		void Delete(T entity);

		T GetItem(int index);

		bool IsEmpty();

		bool Exist(T entity);

		bool Exist(Predicate<T> pred);

		int GetCount { get; }
    }
}
