(function ($) {
    $("#OrderDetailViewTable").DataTable({
        pageLength: 50,
        data: viewOrderDetail,
        buttons: [],
        select: true,
        responsive: { details: { type: 'column' } },
        columnDefs: [
            {
                targets: 0,
                data: 'productName',
                sortable: false,
            },
            {
                targets: 1,
                data: 'quantity',
                sortable: false,
            },
            {
                targets: 2,
                data: 'price',
                sortable: false,
                render: numberFormatCurrency(),
                className: 'text-right'
            },
            {
                targets: 3,
                data: 'note',
                sortable: false
                
            }
        ],
    });
    //luôn clear modal khi đóng form, đề phòng cache
    $('#OrderViewModal').on('hide.bs.modal', function () {
        $('#OrderViewModal').find('div.modal-content').html('');
    });
})(jQuery);
