(function ($) {
    var _duAnService = abp.services.app.duAn,
        l = abp.localization.getSource('Dashboard'),
        _$modal = $('#DuAnEditModal'),
        _$form = _$modal.find('form');

    function save() {
        if (!_$form.valid()) {
            return;
        }

        var duAn = _$form.serializeFormToObject();
        var danhSachModules = { "DanhSachModules": _$DuAnModuleEditTable.rows().data().toArray() };
        var danhSachThanhVienThamGia = { "DanhSachThanhVienThamGia": _$ThanhVienThamGiaEditTable.rows().data().toArray() };

        $.extend(duAn, danhSachModules)
        $.extend(duAn, danhSachThanhVienThamGia)
        abp.ui.setBusy(_$form);
        _duAnService.update(duAn).done(function () {
            _$modal.modal('hide');
            abp.notify.info(l('SavedSuccessfully'));
            abp.event.trigger('duAn.edited', duAn);
        }).always(function () {
            abp.ui.clearBusy(_$form);
        });
    }

    _$form.closest('div.modal-content').find(".save-button").click(function (e) {
        e.preventDefault();
        save();
    });

    _$form.find('input').on('keypress', function (e) {
        if (e.which === 13) {
            e.preventDefault();
            save();
        }
    });

    _$modal.on('shown.bs.modal', function () {
        _$form.find('input[type=text]:first').focus();
    });
})(jQuery);
