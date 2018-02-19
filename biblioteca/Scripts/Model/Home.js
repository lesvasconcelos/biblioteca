//Load Data in Table when documents is ready
$(document).ready(function () {
    var grid = $('#gridCatalogo').bootgrid({
        ajax: true,
        navigation:0,
        sorting: false,
        ajaxSettings: {
            method: "GET",
            cache: false
        },
        url: '/api/livro',
        responseHandler: function (response) {
            var ret = { rows: response };
            return ret;
        },
        formatters: {
            "commands": function (column, row) {
                return "<button type=\"button\" class=\"btn btn-xs btn-default command-edit\" data-row-id=\"" + row.Id + "\" >Atualizar</button> " +
                    "<button type=\"button\" class=\"btn btn-xs btn-default command-delete\" data-row-id=\"" + row.Id + "\" data-row-title=\""+row.Titulo+"\" >Excluir</button>";
            }
        }
    })
    .on("loaded.rs.jquery.bootgrid", function () {
        /* Executes after data is loaded and rendered */
        grid.find(".command-edit").on("click", function (e) {
            GetByID($(this).data("row-id"));
        }).end().find(".command-delete").on("click", function (e) {
            Delete($(this).data("row-id"), $(this).data("row-title"));
        });
    });;

});

//Add Data Function
function Add() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var empObj = {
        Id: $('#Id').val(),
        Titulo: $('#Titulo').val(),
        Autor: $('#Autor').val(),
        Ano: $('#Ano').val()
    };
    $.ajax({
        url: "/api/livro",
        data: JSON.stringify(empObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            GetBootstrapGrid().reload();
            $('#myModal').modal('hide');
        },
        error: function (errormessAutor) {
            alert(errormessAutor.responseText);
        }
    });
}
//Function for getting the Data Based upon Employee ID
function GetByID(Id) {
    $('#Titulo').css('border-color', 'lightgrey');
    $('#Autor').css('border-color', 'lightgrey');
    $('#Ano').css('border-color', 'lightgrey');
    $.ajax({
        url: "/api/livro/" + Id,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#Id').val(result.Id);
            $('#Titulo').val(result.Titulo);
            $('#Autor').val(result.Autor);
            $('#Ano').val(result.Ano);
            $('#myModal').modal('show');
            $('#btnUpdate').show();
            $('#btnAdd').hide();
            $('.modal-title').text('Atualizar '+result.Titulo)
        },
        error: function (errormessAutor) {
            alert(errormessAutor.responseText);
        }
    });
    return false;
}
//function for updating employee's record
function Update() {
    var Id = $('#Id').val();
    var res = validate();
    if (res == false) {
        return false;
    }
    var empObj = {
        Id: $('#Id').val(),
        Titulo: $('#Titulo').val(),
        Autor: $('#Autor').val(),
        Ano: $('#Ano').val()
    };
    $.ajax({
        url: "/api/livro/"+Id,
        data: JSON.stringify(empObj),
        type: "PUT",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            GetBootstrapGrid().reload();
            $('#myModal').modal('hide');
            $('#Id').val("");
            $('#Titulo').val("");
            $('#Autor').val("");
            $('#Ano').val("");
        },
        error: function (errormessAutor) {
            alert(errormessAutor.responseText);
        }
    });
}
//function for deleting employee's record
function Delete(Id, Title) {
    var ans = confirm("Tem certeza que deseja excluir "+ Title +"?");
    if (ans) {
        $.ajax({
            url: "/api/livro/" + Id,
            type: "DELETE",
            contentType: "application/json;charset=UTF-8",
            dataType: "text",
            success: function (result) {
                GetBootstrapGrid().reload();
            },
            error: function (errormessAutor) {debugger
                if (errormessAutor.responseText)
                    alert(errormessAutor.responseText);
            }
        });
    }
}
//Function for clearing the textboxes
function clearTextBox() {
    $('#Id').val("");
    $('#Titulo').val("");
    $('#Autor').val("");
    $('#Ano').val("");
    $('#btnUpdate').hide();
    $('#btnAdd').show();
    $('#Titulo').css('border-color', 'lightgrey');
    $('#Autor').css('border-color', 'lightgrey');
    $('#Ano').css('border-color', 'lightgrey');
}
//Valdidation using jquery
function validate() {
    var isValid = true;
    if ($('#Titulo').val().trim() == "") {
        $('#Titulo').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Titulo').css('border-color', 'lightgrey');
    }
    if ($('#Autor').val().trim() == "") {
        $('#Autor').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Autor').css('border-color', 'lightgrey');
    }
    if ($('#Ano').val().trim() == "") {
        $('#Ano').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Ano').css('border-color', 'lightgrey');
    }
    return isValid;
}

function GetBootstrapGrid() {
    return $('#gridCatalogo').data('.rs.jquery.bootgrid');
}