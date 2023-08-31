using Application.Services.Dtos;
using Domain.Entity;
using Domain.Enum;
using System;
using Application.Extensions;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xUnitTest.ValidateModel;

public class ValidateTests
{
    public IList<ValidationResult> ValidateModel(object model)
    {
        var validationResults = new List<ValidationResult>();
        var ctx = new ValidationContext(model, null, null);
        Validator.TryValidateObject(model, ctx, validationResults, true);

        return validationResults;
    }
    [Theory]
    [InlineData("869a4689-67a1-4b29-8c27-972bbe17cf6d", Bank.VTB, 100.02, 0)]
    [InlineData("3282bd90-e2e6-4cd6-b049-759168148943", Bank.AlfaBank, 0, 0)]
    [InlineData("13212ce2-1b9b-43c5-9691-fed90013a609", Bank.AlfaBank, 12.12, 0)]
    [InlineData("e28e204b-640b-420d-8b88-1f773020e4f2", Bank.Promsvyazbank, -100.2, 1)]
    public void BanksTotal_ReturnsCorrectOfErrors(string id, Bank bank, decimal total, int numberExpectedErrors)
    {
        // Arrange
        var request = new BanksTotal { Id = Guid.Parse(id), Bank = bank, Total = total, };
        // Act
        var errorList = ValidateModel(request);
        // Assert
        Assert.Equal(numberExpectedErrors, errorList.Count);
    }
    [Theory]
    [InlineData("869a4689-67a1-4b29-8c27-972bbe17cf6d", Bank.VTB, 100.02, 0)]
    [InlineData("3282bd90-e2e6-4cd6-b049-759168148943", Bank.AlfaBank, 0, 0)]
    [InlineData("13212ce2-1b9b-43c5-9691-fed90013a609", Bank.AlfaBank, 12.12, 0)]
    [InlineData("e28e204b-640b-420d-8b88-1f773020e4f2", Bank.Promsvyazbank, -100.2, 1)]
    public void BanksTotalDto_ReturnsCorrectOfErrors(string id, Bank bank, decimal total, int numberExpectedErrors)
    {
        // Assert
        var request = new BanksTotalDto { Id = Guid.Parse(id), Bank = bank, Total = total, };
        // Act
        var errorList = ValidateModel(request);
        // Assert
        Assert.Equal(numberExpectedErrors, errorList.Count);
    }
    [Theory]
    [InlineData(Bank.VTB, 100.02, 0)]
    [InlineData(Bank.AlfaBank, 0, 0)]
    [InlineData(Bank.AlfaBank, 12.12, 0)]
    [InlineData(Bank.Promsvyazbank, -100.2, 1)]
    public void BanksTotalСreatOrUpdateDto_ReturnsCorrectOfErrors(Bank bank, decimal total, int numberExpectedErrors)
    {
        // Assert
        var request = new BanksTotalСreatOrUpdateDto { Bank = bank, Total = total, };
        // Act
        var errorList = ValidateModel(request);
        // Assert
        Assert.Equal(numberExpectedErrors, errorList.Count);
    }
}
