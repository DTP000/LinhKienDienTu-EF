(function ($) {
    l = abp.localization.getSource('LinhKienDienTu');
    _$modalAddDuAnModule = $('#AddOrderDetailModal'),
        _$formAddDuAnModule = _$modalAddDuAnModule.find('form');

    _$OrderDetailCreateTable = $("#OrderDetailCreateTable").DataTable({
        pageLength: 50,
        data: [],
        buttons: [],
        select: true,
        responsive: { details: { type: 'column' } },
        columnDefs: [
            {
                targets: 0,
                data: 'tenModule',
                sortable: false,
            },
            {
                targets: 1,
                data: 'tenCapDoModule',
                sortable: false,
            },
            {
                targets: 2,
                data: 'moTa',
                sortable: false,
            },
            {
                targets: 3,
                data: 'thanhTien',
                sortable: false,
                render: numberFormatCurrency(),
                className: 'text-right'
            },
            {
                targets: 4,
                data: null,
                sortable: false,
                width: "160px",
                defaultContent: '',
                render: (data, type, row, meta) => {
                    return [
                        `   <button type="button" class="btn btn-sm bg-danger delete-duAnModule">`,
                        `       <i class="fas fa-trash"></i> ${l('Delete')}`,
                        '   </button>'
                    ].join('');
                }
            },
        ],
    });

    _$modalAddDuAnModule.on('shown.bs.modal', () => {
        _$modalAddDuAnModule.find('input:not([type=hidden]):first').focus();
    }).on('hidden.bs.modal', () => {
        _$formAddDuAnModule.clearForm();
    });

    /*_$formAddDuAnModule.find("#CapDoModuleId").change(function () {
        var valu = _$formAddDuAnModule.find("#CapDoModuleId").val();
        abp.services.app.capDoModule.get({ id: valu }).done(function (content) {
            _$formAddDuAnModule.find("#CapDoModuleId").val(content.thanhTien)
        }).always(function () {
        });
    })*/

    //Them chi tiet
    _$formAddDuAnModule.find('.save-button').click(function (e) {
        e.preventDefault();

        if (!_$formAddDuAnModule.valid()) {
            return;
        }

        var itemForm = _$formAddDuAnModule.serializeFormToObject();

        _$OrderDetailCreateTable.row.add({
            "tenModule": itemForm.TenModule,
            "capDoModuleId": itemForm.CapDoModuleId,
            "tenCapDoModule": _$formAddDuAnModule.find("#CapDoModuleId option:selected").text(),
            "moTa": itemForm.MoTa,
            "thanhTien": itemForm.ThanhTien,
        }).draw();

        abp.ui.clearBusy(_$formAddDuAnModule);
        _$modalAddDuAnModule.modal('hide');
    });

    $(document).on('click', '.delete-duAnModule', function (e) {
        e.preventDefault();
        _$OrderDetailCreateTable.row($(this).parents('tr'))
            .remove()
            .draw();
    });
})(jQuery);
