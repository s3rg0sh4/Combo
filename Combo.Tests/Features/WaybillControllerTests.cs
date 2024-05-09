namespace Combo.Tests.Features;

using Combo.Database.Models;
using Combo.Features.Waybills;

using Microsoft.AspNetCore.Mvc;
using Moq;

public class WaybillControllerTests
{
	private readonly WaybillController _controller;
	private readonly Guid _guid = Guid.NewGuid();

	public WaybillControllerTests()
	{
		var mock = new Mock<IWaybillService>();
		mock.Setup(repo => repo.GetWaybillList()).Returns(GetAllMoq);
		mock.Setup(repo => repo.GetWaybill(_guid)).Returns(GetOneMoq);

		_controller = new(mock.Object);
	}

	[Fact]
	public async Task GetOne()
	{
		var result = await _controller.Get(_guid);

		var actionResult = Assert.IsType<OkObjectResult>(result);
		var model = Assert.IsAssignableFrom<Waybill>(actionResult.Value);

		Assert.NotNull(model);
		Assert.True(model.Id == _guid);
	}

	[Fact]
	public async Task GetOneNotFound()
	{
		var result = await _controller.Get(Guid.Empty);
		Assert.IsType<NotFoundResult>(result);
	}

	[Fact]
	public void GetAll()
	{
		// Act
		var result = _controller.GetAll();

		// Assert
		var actionResult = Assert.IsType<OkObjectResult>(result);
		var model = Assert.IsAssignableFrom<IAsyncEnumerable<Waybill>>(actionResult.Value);

		Assert.True(Compare(GetAllMoq(), model));
	}

	private static async Task<Waybill?> GetOneMoq(Guid id)
	{
		await Task.CompletedTask;

		if (id == Guid.Empty) 
			return null;

		return GetWaybill(id);
	}

	private static Waybill GetWaybill(Guid id) => new()
	{
		Id = id,
		ActualCargo = new(),
		DeclaredCargo = new(),
		CreationDate = DateTime.Now,
		Destination = new() { View = "" },
		OrderId = Guid.Empty,
		Status = WaybillStatus.Accepted,
		Temperature = Temperature.None,
		TemperatureRemark = "123"
	};

	private static async IAsyncEnumerable<Waybill> GetAllMoq()
	{
		for (int i = 0; i < 3; i++)
			yield return GetWaybill(Guid.NewGuid());

		await Task.CompletedTask;
	}

	private static bool Compare(IAsyncEnumerable<Waybill> w1, IAsyncEnumerable<Waybill> w2)
	{
		var e1 = w1.ToBlockingEnumerable();
		var e2 = w2.ToBlockingEnumerable();
		return e1.Count() == e2.Count();
	}
}
