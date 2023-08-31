/**
 * Получение списка наименований банков.
 *
 * @param {guid} id Идентификатор банка, вносится для выбора по умалчанию (selected).
 * @return  Создаёт option в select id=bank
 */
function GetCatalogs(id) {
    $.ajax({
        url: "https://localhost:7299/api/Catalogs/GetBank",
        type: 'GET',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            $('#bank').find('option').remove()
            $.each(data, function (i, item) {
                if (item.id == id) {
                    $('#bank').append('<option value="' + item.id + '" selected>' + item.name + '</option>');
                }
                else {
                    $('#bank').append('<option value="' + item.id + '">' + item.name + '</option>');
                }
                
            });
        },
        error: function (data) {
            console.log(data);
        }
    });
};
/**
 * Получение списка банков.
 *
 * @return  Создаётся таблица банков
 */
function GetBanksTotal() {
    $("table tbody").html("");
    $.ajax({
        url: "https://localhost:7299/api/BanksTotal/Read",
        type: 'GET',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            $.each(data, function (index, value) {
                $("tbody").append($("<tr>"));
                appendElement = $("tbody tr").last();
                appendElement.append($("<td style='display: none;'>").html(value["id"]));
                appendElement.append($("<td>").html(index+1));
                appendElement.append($("<td>").html(value["bank"]));
                appendElement.append($("<td class='text-center'>").html(value["total"]));
                appendElement.append($("<td class='text-center'>").html("<button type='button' onclick='ShowAddBanksTotal(\"" + value["id"] +"\")' class='btn btn-success'><i class='bi bi-plus-lg'></i></button>"));
                appendElement.append($("<td class='text-center'>").html("<button type='button' onclick='ShowEditBanksTotal(\"" + value["id"] +"\")' class='btn btn-primary'><i class='bi bi-pencil-fill'></i></button>"));
                appendElement.append($("<td class='text-center'>").html("<button type='button' onclick='DeletBanksTotal(\"" + value["id"] +"\")' class='btn btn-outline-danger'><i class='bi bi-trash3'></i></button>"));
                $("tbody").append($("</tr>"));
            });
        },
        error: function (data) {
            console.log(data);
        }
    });
};
/**
 * Открытие диологового окна для добавления нового банка.
 *
 * @return  Открытие диологового окна
 */
function ShowCreateBanksTotal() {
    $('#form-modal').modal('show');
    GetCatalogs();
    $('#total').val(0);
    $('#type').val(0);
    $('#submitValue').val('Создать');
};
/**
 * Открытие диологового окна для добавления в банка новой информации.
 *
 * @param {guid} id Идентификатор банк, к которому будет добавлятся информация.
 * @return  Открытие диологового окна
 */
function ShowAddBanksTotal(id) {
    $.ajax({
        url: "https://localhost:7299/api/BanksTotal/Read/" + id,
        type: 'GET',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            $('#form-modal').modal('show');
            GetCatalogs(data.bank);
            $('#id').val(data.id);
            $('#total').val(0);
            $('#type').val(1);
            $('#submitValue').val('Добавить');
        },
        error: function (data) {
            console.log(data);
        }
    });
};
/**
 * Открытие диологового окна для изменения информации о банке.
 *
 * @param {guid} id Идентификатор банк, информация которого будет изменятся.
 * @return  Открытие диологового окна
 */
function ShowEditBanksTotal(id) {
    $.ajax({
        url: "https://localhost:7299/api/BanksTotal/Read/" + id,
        type: 'GET',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            $('#form-modal').modal('show');
            GetCatalogs(data.bank);
            $('#id').val(data.id);
            $('#total').val(data.total);
            $('#type').val(2);
            $('#submitValue').val('Изменить');
        },
        error: function (data) {
            console.log(data);
        }
    });
};
/**
 * В дологовом окне функция кнопки отправки.
 *
 * @return  Закрытие окна и отправка запросов на сервер
 */
function SaveBanksTotal() {
    var type = $('#type').val();
    var id = $("#id").val();
    var banksTotal = {
        total: parseInt($("#total").val()),
        bank: $("#bank").val()
    };
    switch (parseInt(type)) {
        case 0: //Создание
            CreateBanksTotal(banksTotal);
            break;
        case 1: //Добавление
            AddBanksTotal(id, banksTotal);
            break;
        case 2: //Изменение
            EditBanksTotal(id, banksTotal);
            break;
    }
}
/**
 * Запрос на создание данных.
 *
 * @param {number,string} banksTotal (total,bank) Модель с данными.
 * @return  Отправка запроса
 */
function CreateBanksTotal(banksTotal) {
    $.ajax({
        url: "https://localhost:7299/api/BanksTotal/Create",
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify(banksTotal),
        success: function (data) {
            alert(data);
            GetBanksTotal();
        },
        error: function (data) {
            alert(data);
            console.log(data);
        }
    });
};
/**
 * Запрос на добавление данных.
 *
 * @param {guid} id Идентификатор банк, к которому будет добавлятся информация.
 * @param {number,string} banksTotal (total,bank) Модель с данными.
 * @return  Отправка запроса
 */
function AddBanksTotal(id, banksTotal) {
    $.ajax({
        url: "https://localhost:7299/api/BanksTotal/Create/" + id,
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify(banksTotal),
        success: function (data) {
            alert(data);
            GetBanksTotal();
        },
        error: function (data) {
            alert(data);
            console.log(data);
        }
    });
};
/**
 * Запрос на изменения данных.
 *
 * @param {guid} id Идентификатор банк, информация которого будет изменятся.
 * @param {number,string} banksTotal (total,bank) Модель с данными.
 * @return Отправка запроса
 */
function EditBanksTotal(id, banksTotal) {
    $.ajax({
        url: "https://localhost:7299/api/BanksTotal/Update/" + id,
        type: "PUT",
        contentType: "application/json",
        data: JSON.stringify(banksTotal),
        success: function (data) {
            alert(data);
            GetBanksTotal();
        },
        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            console.log(xhr);
        }
    });
};
/**
 * Запрос на удаления данных.
 *
 * @param {guid} id Идентификатор банк, информация которого будет изменятся.
 * @return  Отправка запроса
 */
function DeletBanksTotal(id) {
    $.ajax({
        url: "https://localhost:7299/api/BanksTotal/Delete/" + id,
        type: "DELETE",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            GetBanksTotal();
            alert(data);
        },
        error: function (data) {
            alert(data);
            console.log(data);
        }
    });
};