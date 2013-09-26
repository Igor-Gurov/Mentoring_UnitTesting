using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskCodeFirst.Entities
{
	public class PayPal : CashOperationType
	{
		public string Account { get; set; }
	}
}
