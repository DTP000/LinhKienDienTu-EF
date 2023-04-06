(function ($) {
    var _productService = abp.services.app.product,
        l = abp.localization.getSource('LinhKienDienTu'),
        _$modal = $('#ProductCreateModal'),
        _$form = _$modal.find('form'),
        _$table = $('#ProductsTable');
        _$form.registerInputAmount();

    var _$productsTable = _$table.DataTable({
        paging: true,
        serverSide: true,
        listAction: {
            ajaxFunction: _productService.getAll,
            inputFilter: function () {
                return $('#ProductsSearchForm').serializeFormToObject(true);
            }
        },
        buttons: [
            {
                name: 'refresh',
                text: '<i class="fas fa-redo-alt"></i>',
                action: () => _$productsTable.draw(false)
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
                data: 'price',
                render: numberFormatCurrency(),
                className: 'text-right',
                sortable: false
            },
            {
                targets: 3,
                data: 'quantity',
                className: 'text-right',
                sortable: false
            },
            {
                targets: 4,
                data: null,
                sortable: false,
                render: (data, type, row, meta) => {
                    var actions = [];
                    actions.push(
                        `  <img alt="Avatar" class="table-avatar" src="./img/${row.urlImage}">`
                    )
                    return actions.join('');
                }
            },
            {
                targets: 5,
                data: null,
                sortable: false,
                autoWidth: false,
                defaultContent: '',
                render: (data, type, row, meta) => {
                    var actions = [];
                    actions.push(
                        `   <button type="button" class="btn btn-sm bg-warning view-product" data-product-id="${row.id}" data-toggle="modal" data-target="#ProductViewModal">`,
                        `       <i class="fas fa-eye"></i> ${l('View')}`,
                        '   </button>'
                    )
                    actions.push(
                        `   <button type="button" class="btn btn-sm bg-secondary edit-product" data-product-id="${row.id}" data-toggle="modal" data-target="#ProductEditModal">`,
                        `       <i class="fas fa-pencil-alt"></i> ${l('Edit')}`,
                        '   </button>'
                    )
                    return actions.join('');
                }
            }
        ]
    });

    _$form.find('.save-button').on('click', (e) => {
        e.preventDefault();

        if (!_$form.valid()) {
            return;
        }

        var product = _$form.serializeFormToObject();

        abp.ui.setBusy(_$modal);
        _productService
            .create(product)
            .done(function () {
                _$modal.modal('hide');
                _$form[0].reset();
                abp.notify.info(l('SavedSuccessfully'));
                _$productsTable.ajax.reload();
            })
            .always(function () {
                abp.ui.clearBusy(_$modal);
            });
    });


    $(document).on('click', '.edit-product', function (e) {
        var productId = $(this).attr("data-product-id");

        e.preventDefault();
        abp.ajax({
            url: abp.appPath + 'Product/EditModal?productId=' + productId,
            type: 'POST',
            dataType: 'html',
            success: function (content) {
                $('#ProductEditModal div.modal-content').html(content);
                $('#ProductEditModal').find('form').registerInputAmount();
            },
            error: function (e) {
            }
        })
    });

    $(document).on('click', '.view-product', function (e) {
        var productId = $(this).attr("data-product-id");

        e.preventDefault();
        abp.ajax({
            url: abp.appPath + 'Product/ViewModal?productId=' + productId,
            type: 'POST',
            dataType: 'html',
            success: function (content) {
                $('#ProductViewModal div.modal-content').html(content);
                $('#ProductViewModal').find('form').registerInputAmount();
                $('#ProductViewModal').find('form').disableForm();
            },
            error: function (e) {
            }
        })
    });

    abp.event.on('product.edited', (data) => {
        _$productsTable.ajax.reload();
    });

    $('#UrlImage').change(function () {
        var input = this;
        var url = $(this).val();
        console.log(input);
        console.log(input.files[0].name)
        var ext = url.substring(url.lastIndexOf('.') + 1).toLowerCase();
        if (input.files && input.files[0] && (ext == "gif" || ext == "png" || ext == "jpeg" || ext == "jpg")) {
            var reader = new FileReader();

            reader.onload = function (e) {
                $('#img').attr('src', e.target.result);
            }
            reader.readAsDataURL(input.files[0]);
        }
        else {
            $('#img').attr('src', '/wwwroot/img/logo.png');
        }
    });


    _$modal.on('shown.bs.modal', () => {
        _$modal.find('input:not([type=hidden]):first').focus();
    }).on('hidden.bs.modal', () => {
        _$form.clearForm();
    });

    $('.btn-search').on('click', (e) => {
        _$productsTable.ajax.reload();
    });

    $('.txt-search').on('keypress', (e) => {
        if (e.which == 13) {
            _$productsTable.ajax.reload();
            return false;
        }
    });
})(jQuery);
