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
			ISets<object> setClass = new SetClass<object>();
			setClass.Add(new object());
			setClass.Add(new object());
			return setClass;
		}

		public ISets<object> CreateSetClass()
		{
			ISets<object> setClass = new SetClass<object>();
			return setClass;
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
			ISets<object> setClass = ini.CreateSetClassWithCollection();

			Assert.AreEqual(ini.GetListCollection().Count, setClass.GetCount);
		}

		[TestMethod]
		public void CheckCollectionOnEmpty()
		{
			Initialize ini = new Initialize();
			ISets<object> setClass = ini.CreateSetClassWithCollection();

			Assert.IsFalse(setClass.IsEmpty());
		}

		[TestMethod]
		public void CheckEmptyCollectionOnEmpty()
		{
			Initialize ini = new Initialize();
			ISets<object> setClass = ini.CreateSetClass();

			Assert.IsTrue(setClass.IsEmpty());
		}

		[TestMethod]
		public void AddedObject()
		{
			Initialize ini = new Initialize();
			ISets<object> setClass = ini.CreateSetClassWithCollection();
			setClass.Add(new object());

			Assert.AreEqual(3, setClass.GetCount);
		}

		[TestMethod]
		public void CheckEqualObject()
		{
			Initialize ini = new Initialize();
			ISets<object> setClass = ini.CreateSetClassWithCollection();
			object obj = new object();
			try
			{
				setClass.Add(obj);
				setClass.Add(obj);
			}
			catch (Exception e)
			{

				Assert.AreEqual("Object Equals", e.Message);
			}
		}

		
		[TestMethod]
		public void DeleteObjectFromCollection()
		{
			Initialize ini = new Initialize();
			ISets<object> setClass = ini.CreateSetClassWithCollection();
			object obj = new object();

			setClass.Add(obj);
			setClass.Delete(obj);

			Assert.AreEqual(ini.GetListCollection().Count, setClass.GetCount);
		}

		[TestMethod]
		public void DeleteObjectFromEmptyCollection()
		{
			Initialize ini = new Initialize();
			ISets<object> setClass = ini.CreateSetClass();
			object obj = new object();

			setClass.Delete(obj);

			Assert.AreEqual(0, setClass.GetCount);
		}

		[TestMethod]
		public void GetItem()
		{
			Initialize ini = new Initialize();
			ISets<object> setClass = ini.CreateSetClassWithCollection();
			object obj = new object();
			setClass.Add(obj);
			
			Assert.AreEqual(obj, setClass.GetItem(2));
		}

		[TestMethod]
		public void EqualsItemTrue()
		{
			Initialize ini = new Initialize();
			ISets<object> setClass = ini.CreateSetClassWithCollection();
			object obj = new object();
			setClass.Add(obj);

			Assert.IsTrue(setClass.Exist(obj));
		}

		[TestMethod]
		public void EqualsItemFalse()
		{
			Initialize ini = new Initialize();
			ISets<object> setClass = ini.CreateSetClassWithCollection();
			object obj = new object();

			Assert.IsFalse(setClass.Exist(obj));
		}

		[TestMethod]
		public void DelegateEqualsItemTrue()
		{
			Initialize ini = new Initialize();
			ISets<object> setClass = ini.CreateSetClassWithCollection();
			object obj = new object();
			setClass.Add(obj);
			DelegateIsEqual<object> delEqual = setClass.Exist;

			Assert.IsTrue(delEqual(obj));
		}
	}
}
