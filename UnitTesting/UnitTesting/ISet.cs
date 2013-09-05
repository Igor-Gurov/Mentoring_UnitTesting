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

		List<T> GetCollection();

		bool CheckCollectionOnEmpty();

		int GetCount();
    }
}
