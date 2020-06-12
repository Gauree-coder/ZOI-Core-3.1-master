var dataTable;

$(document).ready(function () {
    loadDataTable();
});


function loadDataTable() {
    DataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/Customer/GetAll",
            "type": "GET",
            "dataSrc": "",
            "datatype": "json"
        },
        "columns": [
            { "data": "customerName", "width": "30%" },
            { "data": "loginName", "width": "20%" },
            { "data": "customerMobileNo", "width": "20%" },
            { "data": "address1", "width": "20%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class='text-center'>
                        <a href='/Customer/Upsert?id=${data}' class='btn btn-success text-white' style='cursor:pointer; width:70px;'>
                          Edit </a>
 
                        &nbsp;
                <a class='btn btn-danger btnsm'  style='cursor:pointer; width:70px;' href='/Customer/Delete?id=${data}'   >
                         
                        
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