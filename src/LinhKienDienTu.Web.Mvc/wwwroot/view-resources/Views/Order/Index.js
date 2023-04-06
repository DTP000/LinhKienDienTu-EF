(function ($) {
    var _duAnService = abp.services.app.order,
        l = abp.localization.getSource('LinhKienDienTu'),
        _$modal = $('#OrderCreateModal'),
        _$form = _$modal.find('form'),
        _$table = $('#OrdersTable')
    _$OrderDetailCreateTable = null;

    var _$DuAnTable = _$table.DataTable({
        paging: true,
        serverSide: true,
        listAction: {
            ajaxFunction: _duAnService.getAll,
            inputFilter: function () {
                return $('#ProductsSearchForm').serializeFormToObject(true);
            }
        },
        buttons: [
            {
                name: 'refresh',
                text: '<i class="fas fa-redo-alt"></i>',
                action: () => _$DuAnTable.draw(false)
            }
        ],
        responsive: {
            details: {
                type: 'column'
            }
        },
        columnDefs: [
            {
                targets: 0,
                className: 'control',
                defaultContent: '',
            },
            {
                targets: 1,
                data: 'name',
                sortable: false
            },
            {
                targets: 2,
                data: 'phone',
                sortable: false
            },
            {
                targets: 3,
                data: 'totalPrice',
                sortable: false,
                render: numberFormatCurrency(),
                className: 'text-right'
            },
            {
                targets: 4,
                data: 'nameOrderStatus',
                sortable: false
            },
            {
                targets: 5,
                data: 'address',
                sortable: false
            },
            {
                targets: 6,
                data: null,
                sortable: false,
                autoWidth: false,
                defaultContent: '',
                render: (data, type, row, meta) => {
                    var actions = [];
                    actions.push(
                        `   <button type="button" class="btn btn-sm bg-warning view-DuAn" data-DuAn-id="${row.id}" data-toggle="modal" data-target="#OrderViewModal">`,
                        `       <i class="fas fa-eye"></i> ${l('View')}`,
                        '   </button>'
                    )
                        actions.push(
                            `   <button type="button" class="btn btn-sm bg-secondary edit-DuAn " data-DuAn-id="${row.id}" data-toggle="modal" data-target="#OrderEditModal" disabled>`,
                            `       <i class="fas fa-pencil-alt"></i> ${l('Edit')}`,
                            '   </button>'
                        )
                    return actions.join('');
                }
            }
        ]
    });

    _$form.find('.save-button').click(function (e) {
        e.preventDefault();

        if (!_$form.valid()) {
            return;
        }

        var order = _$form.serializeFormToObject();
        var orderDetail = { "OrderDetails ": _$OrderDetailCreateTable.rows().data().toArray() };
        console.log(orderDetail);
        $.extend(order, orderDetail)

        abp.ui.setBusy(_$modal);

        _duAnService
            .create(order)
            .done(function () {
                _$modal.modal('hide');
                _$form[0].reset();
                abp.notify.info(l('SavedSuccessfully'));
                _$DuAnTable.ajax.reload();
            })
            .always(function () {
                abp.ui.clearBusy(_$modal);
            });
    });

    $(document).on('click', '.edit-DuAn', function (e) {
        var DuAnId = $(this).attr('data-DuAn-id');

        abp.ajax({
            url: abp.appPath + 'Order/EditModal?id=' + DuAnId,
            type: 'POST',
            dataType: 'html',
            success: function (content) {
                $('#OrderEditModal div.modal-content').html(content);
            },
            error: function (e) {
            }
        });
    });
    $(document).on('click', '.view-DuAn', function (e) {
        var DuAnId = $(this).attr('data-DuAn-id');

        abp.ajax({
            url: abp.appPath + 'Order/ViewModal?orderId=' + DuAnId,
            type: 'POST',
            dataType: 'html',
            success: function (content) {
                $('#OrderViewModal div.modal-content').html(content);
                $('#OrderViewModal').find('form').disableForm();
            },
            error: function (e) {
            }
        });
    });

    abp.event.on('order.edited', (data) => {
        _$DuAnTable.ajax.reload();
    });

    _$modal.on('shown.bs.modal', () => {
        _$modal.find('input:not([type=hidden]):first').focus();
    }).on('hidden.bs.modal', () => {
        _$form.clearForm();
    });

    $('.btn-search').on('click', (e) => {
        _$DuAnTable.ajax.reload();
    });

    $('.btn-filter-search').on('change', (e) => {
        _$DuAnTable.ajax.reload();
    })

    $('.btn-clear').on('click', (e) => {
        $('input[name=Keyword]').val('');
        $('input[name=IsActive][value=""]').prop('checked', true);
        _$DuAnTable.ajax.reload();
    });

    $('.txt-search').on('keypress', (e) => {
        if (e.which == 13) {
            _$DuAnTable.ajax.reload();
            return false;
        }
    });
})(jQuery);