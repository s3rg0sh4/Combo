namespace Combo.Database.Models;

public class Waybill
{
	public Guid Id { get; set; }

	/// <summary>
	/// Восстановленная?
	/// </summary>
	public bool Restored { get; set; }

	/// <summary>
	/// Датат последнего изменения записи
	/// </summary>
	public DateTime UpdatedAt { get; set; }

	/// <summary>
	/// Отметка о том, что накладная прошла через общую площадку и готова к маршрутизации
	/// </summary>
	public bool ReadyForRs { get; set; }

	public DateTime DateCreate { get; set; }

	public int OrderId { get; set; }

	/// <summary>
	/// Температурный режим
	/// </summary>
	public int Temperature { get; set; }

	/// <summary>
	/// Тип груза <see langword="true"/> - провизия
	/// </summary>
	public bool IsProvision { get; set; }

	public int LpId { get; set; }

	public string Number { get; set; } = null!;

	public DateTime Date { get; set; }

	public int DpId { get; set; }

	/// <summary>
	/// Тип паллета
	/// </summary>
	public int PalletType { get; set; }

	public DateTime DateFeed { get; set; }

	public DateTime DateLoadingPlan { get; set; }

	public DateTime DateShipingPlan { get; set; }

	public DateTime DateUnloadingPlan { get; set; }

	public DateTime DateLoadingReal { get; set; }

	public DateTime DateShipingReal { get; set; }

	public DateTime DateUnloadingReal { get; set; }

	public decimal PalletNumPlan { get; set; }

	public decimal PalletNumReal { get; set; }

	public decimal PalletNumShipped { get; set; }

	public int NumBoxesPlan { get; set; }

	public int NumBoxesReal { get; set; }

	public decimal WeightPlan { get; set; }

	public decimal WeightReal { get; set; }

	public decimal SumPlan { get; set; }

	public decimal SumReal { get; set; }

	public string Status { get; set; } = null!;

	public int RsId { get; set; }

	/// <summary>
	/// МЛ Дистрибьютера
	/// </summary>
	public int RsaId { get; set; }

	/// <summary>
	/// ID Локального МЛ
	/// </summary>
	public int LrsId { get; set; }

	/// <summary>
	/// ID Погрузочного листа
	/// </summary>
	public int LsId { get; set; }

	/// <summary>
	/// ID Накладной-основания у транзитной накладной. Является признаком Транзитности
	/// </summary>
	public int TransitId { get; set; }

	/// <summary>
	/// Номер палета  в загруженной машине, в котором находится накладная
	/// </summary>
	public string RsPalletNumber { get; set; } = null!;

	public int BillId { get; set; }

	public int CbillId { get; set; }

	/// <summary>
	/// Номер АВР
	/// </summary>
	public int AvrId { get; set; }

	/// <summary>
	/// ID Внутреннего АВР
	/// </summary>
	public int InsideAvrId { get; set; }

	public sbyte TrTtn { get; set; }

	public string TrTtnNote { get; set; } = null!;

	/// <summary>
	/// Сдана ли ТН
	/// </summary>
	public bool Tn { get; set; }

	/// <summary>
	/// Сдана ли ТрН
	/// </summary>
	public sbyte Trn { get; set; }

	public DateTime DateUnloadingStartPlan { get; set; }

	public DateTime DateUnloadingStartFact { get; set; }

	public DateTime DateUnloadingFinishPlan { get; set; }

	public DateTime? DateUnloadingFinishPlanReal { get; set; }

	public DateTime DateUnloadingFinishFact { get; set; }

	public string? GetNum { get; set; }

	public string? UOrderNumber { get; set; }

	public string? UTtnNumber { get; set; }

	/// <summary>
	/// Дата ТТН заказчика
	/// </summary>
	public DateTime UTtnDate { get; set; }

	/// <summary>
	/// Номер ТрН заказчика
	/// </summary>
	public string UTrnNumber { get; set; } = null!;

	/// <summary>
	/// Дата ТрН заказчика
	/// </summary>
	public DateTime UTrnDate { get; set; }

	/// <summary>
	/// Номер справки Б
	/// </summary>
	public string USbNumber { get; set; } = null!;

	/// <summary>
	/// Дата справки Б
	/// </summary>
	public DateTime USbDate { get; set; }

	public sbyte UTtnStatus { get; set; }

	public string UWbId { get; set; } = null!;

	public DateTime DateFeedTransit { get; set; }

	public DateTime DateShippingTransit { get; set; }

	public DateTime DatePassTransit { get; set; }

	public decimal PalletNumTransit { get; set; }

	public decimal PalletNumShippedTransit { get; set; }

	public int NumBoxesTransit { get; set; }

	public int NumBoxesShippedTransit { get; set; }

	public decimal WeightTransit { get; set; }

	public decimal WeightShippedTransit { get; set; }

	public decimal SumTransit { get; set; }

	public decimal SumShippedTransit { get; set; }

	public int RsIdTransit { get; set; }

	public string? Tariffs { get; set; }

	/// <summary>
	/// ID Блока  тарифов
	/// </summary>
	public int TariffBlockId { get; set; }

	/// <summary>
	/// Повышающий коэффициент тарифа при размещении позже чем надо
	/// </summary>
	public decimal TariffFactor { get; set; }

	/// <summary>
	/// Дата подтверждения повышающего коэффициента
	/// </summary>
	public DateTime TariffFactorConfirmDate { get; set; }

	/// <summary>
	/// Пользователь, подтвердивший повышающий коэффициент
	/// </summary>
	public string TariffFactorConfirmUser { get; set; } = null!;

	/// <summary>
	/// Тип рабочего тарифа, по которому считался доход от накладной
	/// </summary>
	public string TariffType { get; set; } = null!;

	/// <summary>
	/// Если вместо тарифа была минимальная стоимость то фиксируется здесь
	/// </summary>
	public decimal TariffMinSum { get; set; }

	/// <summary>
	/// Доход от накладной
	/// </summary>
	public decimal Profit { get; set; }

	/// <summary>
	/// Доход для комбобазы
	/// </summary>
	public decimal ProfitCombo { get; set; }

	/// <summary>
	/// Дополнительные затраты
	/// </summary>
	public decimal Costs { get; set; }

	/// <summary>
	/// Список дополнительных затрат
	/// </summary>
	public string? CostsArr { get; set; }

	public sbyte CountChanges { get; set; }

	/// <summary>
	/// Сериализованный массив отражающий сданность поднакладных
	/// </summary>
	public string? NumberPassStatuses { get; set; }

	/// <summary>
	/// Планируемая дата сдачи документов по накладной (определяется при отгрузке МЛ дата последней точки разгрузки +n дней)
	/// </summary>
	public DateTime? DocumentPassDatePlan { get; set; }

	/// <summary>
	/// Фактическая дата сдачи документов по накладной (определяется при сдаче МЛ)
	/// </summary>
	public DateTime? DocumentPassDateReal { get; set; }

	/// <summary>
	/// Метка о невозможности изменений накладной. Если 1, никакие изменения кроме статуса по накладной не возможны.
	/// </summary>
	public sbyte NoChange { get; set; }

	/// <summary>
	/// Счет выставлен. Данные экспортированы в 1С
	/// </summary>
	public sbyte BillExposed { get; set; }

	/// <summary>
	/// Печать магазина для Торгового представителя
	/// </summary>
	public sbyte AgentStamp { get; set; }

	/// <summary>
	/// ТР ТТН для торгового представителя
	/// </summary>
	public sbyte AgentTtn { get; set; }

	/// <summary>
	/// Дата возврата досументов по накладной в случае задержки
	/// </summary>
	public DateTime? AgentDateReturn { get; set; }

	/// <summary>
	/// Причина задержки возврата накладной
	/// </summary>
	public string? AgentReturnReason { get; set; }

	public string LastStatusUpdateUser { get; set; } = null!;

	/// <summary>
	/// Комментарии к накладной
	/// </summary>
	public string Comments { get; set; } = null!;

	/// <summary>
	/// Комментарии которые делают сотрудники НАШЕЙ компании
	/// </summary>
	public string StaffComments { get; set; } = null!;

	/// <summary>
	/// Название клиента в системе-исходнике
	/// </summary>
	public string UCustomer { get; set; } = null!;

	/// <summary>
	/// Накладная была экспортирована в КомбоБазу и ждет обновления
	/// </summary>
	public int ExportedToCombo { get; set; }

	/// <summary>
	/// Накладная была импортирована из КомбоБазы
	/// </summary>
	public int ImportedFromCombo { get; set; }

	/// <summary>
	/// ID консолидированной накладной
	/// </summary>
	public int WbcId { get; set; }

	/// <summary>
	/// Пользователь, принявший документы
	/// </summary>
	public string DocInStockUser { get; set; } = null!;

	/// <summary>
	/// Дата принятия документов
	/// </summary>
	public DateTime DocInStockDate { get; set; }

	/// <summary>
	/// Авизо
	/// </summary>
	public DateTime Aviso { get; set; }

	/// <summary>
	/// Простой
	/// </summary>
	public sbyte Demurrage { get; set; }
}

public enum CargoType
{
	Food, 
	NotFood
}