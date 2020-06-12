var dataTable;

$(document).ready(function () {
    loadDataTable();
});




function loadDataTable() {
    DataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/MenuTimeSlot/GetAll",
            "type": "GET",
            "dataSrc": "",
            "datatype": "json"
        },
        "columns": [
            { "data": "timeslotName", "width": "30%" },
            { "data": "startTime", "width": "15%" },
            { "data": "endTime", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class='text-center'>
                        <a href='/MenuTimeSlot/Upsert?id=${data}' class='btn btn-success text-white' style='cursor:pointer; width:70px;'>
                          Edit </a>
 
                        &nbsp;
                <a class='btn btn-danger btnsm'  style='cursor:pointer; width:70px;' href='/MenuTimeSlot/Delete?id=${data}'   >
                         
                        
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