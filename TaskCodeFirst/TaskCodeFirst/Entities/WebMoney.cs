using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskCodeFirst.Entities
{
	public class WebMoney : CashOperationType
	{
		[MaxLength(12)]
		public int Number { get; set; }
	}
}
