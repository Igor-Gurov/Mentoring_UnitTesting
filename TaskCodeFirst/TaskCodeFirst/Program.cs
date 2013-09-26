using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskCodeFirst
{
	class Program
	{
		static void Main(string[] args)
		{
			TaskContext db = new TaskContext();

			db.Category.FirstOrDefault(c => c.ID == 1);

			db.Goods.FirstOrDefault(g => g.ID == new Guid());

			db.Payments.FirstOrDefault(p => p.ID == new Guid());

			db.Clients.FirstOrDefault(c => c.ID == 1);
		}
	}
}
