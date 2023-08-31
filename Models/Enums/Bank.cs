using System.ComponentModel;

namespace Domain.Enum;

/// <summary>
/// Справочник банков
/// </summary>
public enum Bank
{
    [Description("ВТБ")]
    VTB = 0,
    [Description("Сбербанк")]
    Sberbank = 1,
    [Description("Тиньков")]
    Tinkoff = 2,
    [Description("Альфа-Банк")]
    AlfaBank = 3,
    [Description("Промсвязьбанк")]
    Promsvyazbank = 4,
}
