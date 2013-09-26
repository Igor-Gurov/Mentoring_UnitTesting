using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using TaskCodeFirst.HelperType;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskCodeFirst.Entities
{
	public class BankCard : CashOperationType
	{
		[MaxLength(16)]
		public int NumberCard { get; set; }

		public CloseCard Close { get; set; }

		[NotMapped]
		public int CVC { get; set; }
	}
}
