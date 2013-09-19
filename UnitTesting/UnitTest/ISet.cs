using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTesting;

namespace UnitTest
{
	#region PreTesting

	public class Initialize
	{
		private List<object> list;

		public Initialize()
		{
			list = new List<object>(){
				new object(),
				new object(),
			};
		}

		public ISets<object> CreateSetClassWithCollection()
		{
			ISets<object> setClass = new Setz<object>();
			setClass.Add(new object());
			setClass.Add(new object());
			return setClass;
		}

		public ISets<object> CreateSetClass()
		{
			ISets<object> setz = new Setz<object>();
			return setz;
		}

		public List<object> GetListCollection()
		{
			return list;
		}
	}
	#endregion

	[TestClass]
	public class ISetTest
	{
		[TestMethod]
		public void CheckCount()
		{
			Initialize ini = new Initialize();
			ISets<object> setz = ini.CreateSetClassWithCollection();

			Assert.AreEqual(ini.GetListCollection().Count, setz.GetCount);
		}

		[TestMethod]
		public void CheckCollectionOnEmpty()
		{
			Initialize ini = new Initialize();
			ISets<object> setz = ini.CreateSetClassWithCollection();

			Assert.IsFalse(setz.IsEmpty());
		}

		[TestMethod]
		public void CheckEmptyCollectionOnEmpty()
		{
			Initialize ini = new Initialize();
			ISets<object> setz = ini.CreateSetClass();

			Assert.IsTrue(setz.IsEmpty());
		}

		[TestMethod]
		public void AddedObject()
		{
			Initialize ini = new Initialize();
			ISets<object> setz = ini.CreateSetClassWithCollection();
			setz.Add(new object());

			Assert.AreEqual(3, setz.GetCount);
		}

		[TestMethod]
		public void CheckEqualObject()
		{
			Initialize ini = new Initialize();
			ISets<object> setz = ini.CreateSetClassWithCollection();
			object obj = new object();
			try
			{
				setz.Add(obj);
				setz.Add(obj);
			}
			catch (ExistException e)
			{

				Assert.AreEqual("Equals entity", e.Message);
			}
		}

		
		[TestMethod]
		public void DeleteObjectFromCollection()
		{
			Initialize ini = new Initialize();
			ISets<object> setz = ini.CreateSetClassWithCollection();
			object obj = new object();

			setz.Add(obj);
			setz.Delete(obj);

			Assert.AreEqual(ini.GetListCollection().Count, setz.GetCount);
		}

		[TestMethod]
		public void DeleteObjectFromEmptyCollection()
		{
			Initialize ini = new Initialize();
			ISets<object> setz = ini.CreateSetClass();
			object obj = new object();

			setz.Delete(obj);

			Assert.AreEqual(0, setz.GetCount);
		}

		[TestMethod]
		public void GetItem()
		{
			Initialize ini = new Initialize();
			ISets<object> setz = ini.CreateSetClassWithCollection();
			object obj = new object();
			setz.Add(obj);
			
			Assert.AreEqual(obj, setz.GetItem(2));
		}

		[TestMethod]
		public void EqualsItemTrue()
		{
			Initialize ini = new Initialize();
			ISets<object> setz = ini.CreateSetClassWithCollection();
			object obj = new object();
			setz.Add(obj);

			Assert.IsTrue(setz.Exist(obj));
		}

		[TestMethod]
		public void EqualsItemFalse()
		{
			Initialize ini = new Initialize();
			ISets<object> setz = ini.CreateSetClassWithCollection();
			object obj = new object();

			Assert.IsFalse(setz.Exist(obj));
		}

		[TestMethod]
		public void EqualsPredicateItemTrue()
		{
			Initialize ini = new Initialize();
			ISets<object> setz = ini.CreateSetClassWithCollection();
			object obj = new object();
			setz.Add(obj);

			Assert.IsTrue(setz.Exist(e=>e.Equals(obj)));
		}
	}
}
