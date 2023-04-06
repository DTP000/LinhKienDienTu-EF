(function ($) {
    //Notification handler
    abp.event.on('abp.notifications.received', function (userNotification) {
        abp.notifications.showUiNotifyForUserNotification(userNotification);

        //Desktop notification
        Push.create("LinhKienDienTu", {
            body: userNotification.notification.data.message,
            icon: abp.appPath + 'img/logo.png',
            timeout: 6000,
            onClick: function () {
                window.focus();
                this.close();
            }
        });
    });

    //serializeFormToObject plugin for jQuery
    $.fn.serializeFormToObject = function (camelCased = false) {
        //serialize to array
        var data = $(this).serializeArray();

        //add also disabled items
        $(':disabled[name]', this).each(function () {
            data.push({ name: this.name, value: $(this).val() });
        });

        //map to object
        var obj = {};
        data.map(function (x) { obj[x.name] = x.value; });

        if (camelCased && camelCased === true) {
            return convertToCamelCasedObject(obj);
        }

        //những input có format là tiền thì phải convert lại thành số
        this.find('.input-amount').toArray().forEach(function (field) {
            obj[field.name] = field.value.replaceAll(".", "")
        });

        return obj;
    };

    //Configure blockUI
    if ($.blockUI) {
        $.blockUI.defaults.baseZ = 2000;
    }

    //Configure validator
    $.validator.setDefaults({
        highlight: (el) => {
            $(el).addClass('is-invalid');
        },
        unhighlight: (el) => {
            $(el).removeClass('is-invalid');
        },
        errorElement: 'p',
        errorClass: 'text-danger',
        errorPlacement: (error, element) => {
            if (element.parent('.input-group').length) {
                error.insertAfter(element.parent());
            } else {
                error.insertAfter(element);
            }
        }
    });

    function convertToCamelCasedObject(obj) {
        var newObj, origKey, newKey, value;
        if (obj instanceof Array) {
            return obj.map(value => {
                if (typeof value === 'object') {
                    value = convertToCamelCasedObject(value);
                }
                return value;
            });
        } else {
            newObj = {};
            for (origKey in obj) {
                if (obj.hasOwnProperty(origKey)) {
                    newKey = (
                        origKey.charAt(0).toLowerCase() + origKey.slice(1) || origKey
                    ).toString();
                    value = obj[origKey];
                    if (
                        value instanceof Array ||
                        (value !== null && value.constructor === Object)
                    ) {
                        value = convertToCamelCasedObject(value);
                    }
                    newObj[newKey] = value;
                }
            }
        }
        return newObj;
    }

    function initAdvSearch() {
        $('.abp-advanced-search').each((i, obj) => {
            var $advSearch = $(obj);
            setAdvSearchDropdownMenuWidth($advSearch);
            setAdvSearchStopingPropagations($advSearch);
        });
    }

    initAdvSearch();

    $(window).resize(() => {
        clearTimeout(window.resizingFinished);
        window.resizingFinished = setTimeout(() => {
            initAdvSearch();
        }, 500);
    });

    function setAdvSearchDropdownMenuWidth($advSearch) {
        var advSearchWidth = 0;
        $advSearch.each((i, obj) => {
            advSearchWidth += parseInt($(obj).width(), 10);
        });
        $advSearch.find('.dropdown-menu').width(advSearchWidth)
    }

    function setAdvSearchStopingPropagations($advSearch) {
        $advSearch.find('.dd-menu, .btn-search, .txt-search')
            .on('click', (e) => {
                e.stopPropagation();
            });
    }

    $.fn.clearForm = function () {
        var $this = $(this);
        $this.validate().resetForm();
        $('[name]', $this).each((i, obj) => {
            $(obj).removeClass('is-invalid');
        });
        $this[0].reset();
    };

    $.fn.disableForm = function () {
        var $this = $(this)
        $('[name]', $this).each((i, obj) => {
            $(obj).prop("disabled", true);
        });
    };

    numberFormat = function numberFormat(value) {
        return new Intl.NumberFormat('vi-VN').format(value);
    }

    numberFormatCurrency = function numberFormatCurrency() {
        return $.fn.dataTable.render.number('.', ',', 0)
    }

    $.fn.fillToForm = function (rowData) {
        var $this = $(this)

        let objKeys = Object.keys(rowData);
        objKeys.forEach(key => {
            let value = rowData[key];
            let keyUpper = key.charAt(0).toUpperCase() + key.slice(1);
            $this.find("#" + keyUpper).val(value);
        });
    };

    $.fn.registerInputAmount = function () {
        var $this = $(this)
        $this.find('.input-amount').toArray().forEach(function (field) {
            new Cleave(field, {
                numeral: true,
                numericOnly: true,
                numeralPositiveOnly: true, //so duong
                numeralDecimalMark: ',',
                delimiter: '.',
                numeralThousandsGroupStyle: 'thousand',
            });
            field.value = field.value;
        });
    };

    removeDotInAmount = function removeDotInAmount(value) {
        return value.replaceAll(".", "");
    }
})(jQuery);
