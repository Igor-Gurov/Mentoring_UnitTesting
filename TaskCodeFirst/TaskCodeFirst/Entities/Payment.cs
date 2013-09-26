using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskCodeFirst.Entities
{
	public class Payment
	{
		public Guid ID { get; set; }

		public int Quantity { get; set; }

		public DateTime Date { get; set; }

		public Guid Good { get; set; }

		public int CashOperationTypeId { get; set; }

		public CashOperationType CashOperationType { get; set; }

		[ForeignKey("Good")]
		public virtual Good GoodEntity { get; set; }

	}
}
