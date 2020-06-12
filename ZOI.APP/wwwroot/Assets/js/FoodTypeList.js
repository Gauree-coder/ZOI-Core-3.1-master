var dataTable;

$(document).ready(function () {
    loadDataTable();
});




function loadDataTable() {
    DataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/FoodType/GetAll",
            "type": "GET",
            "dataSrc": "",
            "datatype": "json"
        },
        "columns": [
            { "data": "name", "width": "60%" },
            {
                "data": "id",
                "render": function(data) {
                    return `<div class='text-center'>
                        <a href='/FoodType/Upsert?id=${data}' class='btn btn-success text-white' style='cursor:pointer; width:70px;'>
                          Edit </a>
 
                        &nbsp;
                <a class='btn btn-danger btnsm'  style='cursor:pointer; width:70px;' href='/FoodType/Delete?id=${data}'   >
                         
                        
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