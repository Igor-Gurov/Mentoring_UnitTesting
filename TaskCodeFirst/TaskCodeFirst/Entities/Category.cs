using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskCodeFirst.Entities
{
	public class Category
	{
		public int ID { get; set; }

		public string Name { get; set; }

		public int? Parent_Id { get; set; }

		public virtual ICollection<Good> Goods { get; set; }

		[ForeignKey("Parent_Id")]
		public virtual ICollection<Category> Categories { get; set; }
	}
}
