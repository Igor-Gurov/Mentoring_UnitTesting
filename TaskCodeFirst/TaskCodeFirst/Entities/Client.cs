using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskCodeFirst.Entities
{
	public class Client
	{
		public int ID { get; set; }

		public string Login { get; set; }

		public string FIO { get; set; }

		public Guid PaymentId { get; set; }

		public virtual Payment Payment { get; set; }
	}
}
