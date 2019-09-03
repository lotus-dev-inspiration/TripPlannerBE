using Moq;
using System;
using TripPlannerBE.Controllers;
using Xunit;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Entities.Models;
using TripPlannerBE.Repositories;

namespace TripPlannerBE.UnitTests
{
	public class UsersControllerUnitTest
	{
		[Fact]
		public void GetAllUsers()
		{
			// Assign
			var mockedListUsers = new List<User>() { new User() { Id = 1, Name = "Go" } };
			var mockedQueryableUsers = mockedListUsers.AsQueryable();

			var mockRepo = new Mock<IUserRepository>();
			mockRepo.Setup(repo => repo.FindAll()).Returns(mockedQueryableUsers);

			var mockRepoWrapper = new Mock<IRepositoryWrapper>();
			mockRepoWrapper.Setup(repo => repo.User).Returns(mockRepo.Object);

			var usersController = new UsersController(mockRepoWrapper.Object);

			// Act
			var okResult = usersController.Get().Result as OkObjectResult;

			// Assert
			var users = Assert.IsType<List<User>>(okResult.Value);
			Assert.Single(users);
		}
	}
}
