namespace Combo.Tests.Features;

using Combo.Database.Models;
using Combo.Features.Waybills;

using Microsoft.AspNetCore.Mvc;

using Moq;

public class WaybillControllerTests
{
	private readonly Mock<IWaybillService> _service = new();
	private readonly Guid _guid = Guid.NewGuid();

	[Fact]
	public async Task GetOne()
	{
		_service.Setup(repo => repo.GetWaybill(_guid)).Returns(async () => GetWaybill(_guid));
		var controller = new WaybillController(_service.Object);
		var result = await controller.Get(_guid);

		var actionResult = Assert.IsType<OkObjectResult>(result);
		var model = Assert.IsAssignableFrom<Waybill>(actionResult.Value);

		Assert.NotNull(model);
		Assert.True(model.Id == _guid);
	}

	[Fact]
	public void GetAll()
	{
		// Arrange
		_service.Setup(repo => repo.GetWaybillList()).Returns(GetAllMoq);
		var controller = new WaybillController(_service.Object);

		// Act
		var result = controller.GetAll();

		// Assert
		var actionResult = Assert.IsType<OkObjectResult>(result);
		var model = Assert.IsAssignableFrom<IAsyncEnumerable<Waybill>>(actionResult.Value);

		var mock = GetAllMoq().ToBlockingEnumerable();
		var list = model.ToBlockingEnumerable();
		Assert.True(mock.Count() == list.Count());
	}

	[Fact]
	public async Task CreateOne()
	{
		var waybill = GetWaybill(_guid);
		_service.Setup(repo => repo.AddWaybill(waybill)).Returns(async () => _guid);
		_service.Setup(repo => repo.GetWaybill(_guid)).Returns(async () => waybill);
		var controller = new WaybillController(_service.Object);

		var result = await controller.Post(waybill);

		var actionResult = Assert.IsType<OkObjectResult>(result);
		var model = Assert.IsAssignableFrom<Waybill>(actionResult.Value);

		Assert.NotNull(model);
		Assert.True(model.CreationDate != DateTimeOffset.MinValue);
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
}
