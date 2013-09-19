using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace UnitTesting
{
	public class ExistException : Exception
	{
		public ExistException() : base() { }

		public ExistException(string str) : base(str) { }

		public ExistException(string str,Exception inner) : base(str,inner) { }

		public ExistException(SerializationInfo si, StreamingContext sc) : base(si,sc) { }

		public override string ToString()
		{
			return Message;
		}
	}
}
