using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskCodeFirst.Entities
{
	public class Good
	{
		public Guid ID { get; set; }

		public decimal Amount { get; set; }

		public string Name { get; set; }

		public virtual ICollection<Category> Categories { get; set; }
	}
}
