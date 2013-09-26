using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskCodeFirst.Entities
{
	public class SpotCash : CashOperationType
	{
		[MaxLength(3)]
		public string Currency { get; set; }	
	}
}
