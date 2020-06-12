var dataTable;

$(document).ready(function () {
    loadDataTable();
});


function loadDataTable() {
    DataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/MenuDetail/GetAll",
            "type": "GET",
            "dataSrc": "",
            "datatype": "json"
        },
        "columns": [
            { "data": "menuItem", "width": "30%" },
            { "data": "menuDate", "width": "20%" },
            { "data": "mRP", "width": "20%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class='text-center'>
                        <a href='/MenuDetail/Upsert?id=${data}' class='btn btn-success text-white' style='cursor:pointer; width:70px;'>
                          Edit </a>
 
                        &nbsp;
                <a class='btn btn-danger btnsm'  style='cursor:pointer; width:70px;' href='/MenuDetail/Delete?id=${data}'   >
                         
                        
                          Delete
                        </a></div>`;
                }, "width": "40%"
            }
        ],
        "language": {
            "emptyTable": "no data found"
        },
        "width": "100%"

    });





}