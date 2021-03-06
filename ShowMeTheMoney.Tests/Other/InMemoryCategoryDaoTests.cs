﻿using System.Collections.Generic;
using FluentAssertions;
using ShowMeTheMoney.Model;
using ShowMeTheMoney.Other;
using Xunit;

namespace ShowMeTheMoney.Tests.Other
{
	public class InMemoryCategoryDaoTests
	{
		[Fact]
		public void GetAll_ReturnsEmtpyList_AfterCreated()
		{
			inMemoryCategoryDao.GetAll().Should().BeEmpty();
		}

		[Fact]
		public void SaveAll_SavesAll()
		{
			inMemoryCategoryDao.SetAll(GetSampleCategoryList());
			inMemoryCategoryDao.GetAll().Should().HaveCount(2);
		}

		[Fact]
		public void SaveAll_ReplacesPreviuos()
		{
			inMemoryCategoryDao.SetAll(GetSampleCategoryList());
			inMemoryCategoryDao.SetAll(new List<Category>());

			inMemoryCategoryDao.GetAll().Should().HaveCount(0);
		}

		[Fact]
		public void SaveAll_DoesNotAcceptDuplicateCategoryNames()
		{
			Assert.Throws<DuplicateCategoryException>(() => inMemoryCategoryDao.SetAll(new List<Category>
			{
				new Category
				{
					Name = "a",
				},
				new Category
				{
					Name = "a"
				}
			}));
		}

		private readonly InMemoryCategoryDao inMemoryCategoryDao = new InMemoryCategoryDao();

		private static List<Category> GetSampleCategoryList()
		{
			return new List<Category> { new Category { Name = "a" }, new Category { Name = "b" } };
		}
	}
}