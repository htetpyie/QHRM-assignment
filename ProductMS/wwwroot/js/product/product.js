$(document).ready(() => {
    drawTable();
})

function drawTable() {
    $('#product-table').DataTable({
        "paging": true,
        "destroyed": true,
        "searching": true,
        "ordering": true,
        "info": true,
        "autoWidth": false,
        "responsive": true,
        "serverSide": true,
        "ajax": {
            "url": "/Product/DataList/",
            "type": "POST",
            "datatype": "json",
            "error": function () {
                window.location.href = 'Home/Error';
            }
        },
        "columnDefs": [{
            "targets": [0, 5],
            "searchable": false,
            "orderable": false
        }],
        "columns": [
            {
                "data": null,
                "render": function (data, type, row, meta) {
                    return meta.row + meta.settings._iDisplayStart + 1;
                }
            },
            { "data": "name", "name": "Name", "autoWidth": true, "className": "text-center" },
            { "data": "priceString", "name": "Price", "autoWidth": true, "className": "text-right" },
            { "data": "description", "name": "Description", "autoWidth": true },
            { "data": "createdDateString", "name": "CreatedDate", "autoWidth": true, "className": "text-center" },
            {
                "data": "id",
                "render": function (data) {
                    return `<a href='/Product/Edit/${data}' class='btn btn-sm btn-outline-info'>
										   <i class="fas fa-pen-square"></i>
									  </a>
									  <a href='javascript:void(0)' onclick="clickDeleteBtn(${data})" class='btn btn-sm btn-outline-danger'>
										  <i class="fas fa-trash-alt"></i>
									   </a>`;
                },
                "className": "text-center"
            },
        ]
    });
}

function clickDeleteBtn(id) {
    $('#delete-form #delete-id').val(id);
    $("#delete-modal").modal('show');
}

$("#btn-delete-form").on("click", () => {
    $("#delete-form").submit();
})
