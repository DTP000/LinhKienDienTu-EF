(function ($) {
    l = abp.localization.getSource('Dashboard');
    rowIndexModule = null,
        _$modalEditDuAnModule = $('#EditDuAnModuleModal'),
        _$formEditDuAnModule = _$modalEditDuAnModule.find('form');

    _$DuAnModuleEditTable = $("#DuAnModuleEditTable").DataTable({
        pageLength: 50,
        data: editDanhSachModules,
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
                data: 'tenTrangThai',
                sortable: false,
            },
            {
                targets: 5,
                data: null,
                sortable: false,
                width: "160px",
                defaultContent: '',
                render: (data, type, row, meta) => {
                    const actions = [
                        `   <button type="button" class="btn btn-sm bg-danger delete-duAnModule">`,
                        `       <i class="fas fa-trash"></i> ${l('Delete')}`,
                        '   </button>'
                    ];
                    if (row.id != undefined && row.id > 0) {
                        actions.push(
                            `   <button type="button" class="btn btn-sm bg-secondary edit-duAnModule" data-DuAnModule-id="${row.id}" data-toggle="modal" data-target="#EditDuAnModuleModal">`,
                            `       <i class="fas fa-pencil-alt"></i> ${l('Edit')}`,
                            '   </button>',
                        );
                    }

                    return actions.join('');
                }
            },
        ],
    });

    _$modalEditDuAnModule.on('shown.bs.modal', () => {
        _$modalEditDuAnModule.find('input:not([type=hidden]):first').focus();
    }).on('hidden.bs.modal', () => {
        _$formEditDuAnModule.clearForm();
    });

    _$formEditDuAnModule.find("#CapDoModuleId").change(function () {
        var valu = _$formEditDuAnModule.find("#CapDoModuleId").val();
        abp.services.app.capDoModule.get({ id: valu }).done(function (content) {
            _$formEditDuAnModule.find("#ThanhTien").val(content.thanhTien)
        }).always(function () {
        });
    })

    //Them chi tiet
    _$formEditDuAnModule.find('.save-button').click(function (e) {
        e.preventDefault();

        if (!_$formEditDuAnModule.valid()) {
            return;
        }

        var itemForm = _$formEditDuAnModule.serializeFormToObject();
       

        var item = {
            "tenModule": itemForm.TenModule,
            "capDoModuleId": itemForm.CapDoModuleId,
            "tenCapDoModule": _$formEditDuAnModule.find("#CapDoModuleId option:selected").text(),
            "moTa": itemForm.MoTa,
            "thanhTien": itemForm.ThanhTien,
            "tenTrangThai": _$formEditDuAnModule.find("#TrangThai option:selected").text(),
            "trangThai": _$formEditDuAnModule.find("#TrangThai option:selected").val(),
            "id": Number(itemForm.Id)
        };

        var danhSachChiTiet = _$DuAnModuleEditTable.rows().data().toArray();
        var exitsItem = danhSachChiTiet.filter(item => item['id'] != "" && (item['id'] === itemForm.Id || item['id'] === Number(itemForm.Id)));       
        
        //Edit
        if (exitsItem != null && exitsItem.length > 0) {
            _$DuAnModuleEditTable.row(rowIndexModule).data(item).draw();
        }
        //Add
        else {
            _$DuAnModuleEditTable.row.add(item).draw();
        }

        abp.ui.clearBusy(_$formEditDuAnModule);
        _$modalEditDuAnModule.modal('hide');
    });



    $(document).on('click', '.delete-duAnModule', function (e) {
        e.preventDefault();
        _$DuAnModuleEditTable.row($(this).parents('tr'))
            .remove()
            .draw();
    });

    $(document).on('click', '.edit-duAnModule', function (e) {
        e.preventDefault();
        //1. lấy data theo index
        rowIndexModule = _$DuAnModuleEditTable.row($(this).parents('tr')).index();

        //2. Lay data index
        var rowData = _$DuAnModuleEditTable.row($(this).parents('tr')).data();

        //3. bật form
        _$modalEditDuAnModule.modal('show');

        //4.send dữ liệu vào form

        _$formEditDuAnModule.fillToForm(rowData);
    });

})(jQuery);
