



function AjaxCallWithoutCallback(url, data, type) {
    var returndata = {};
    $.ajax({
        url: url,
        data: data,
        async: false,
        method: (type == 1 ? "Get" : "Post"),
        success: function (returneddata) {
            returndata = returneddata;
        },
        error: function () {
            returndata.success = false;
        }
    });
    return returndata;
}

function PostAjaxCallWithoutCallback(url, data) {
    var returndata = {};
    $.ajax({
        url: url,
        data: data,
        async: false,
        type: 'post',
        dataType: 'json',
        success: function (returneddata) {
            returndata = returneddata;
        },
        error: function () {
            returndata.success = false;
        }
    });
    return returndata;
}


function AjaxCall(url, data, elem, successCallback, errorCallback) {
    $.ajax({
        url: url,
        data: data,
        type: "POST",
        async: true,
        dataType: "json",
        success: function (data) {
            if (typeof successCallback === "function") {
                successCallback(elem, data);
            }
        },
        error: function () {
            if (typeof errorCallback === "function") {
                errorCallback();
            }
        }
    });
}


function ShowError(elem, message) {
    $(elem).addClass("input-validation-error");
    var nextcntrl = $('.field-validation-valid[data-valmsg-for="' + $(elem).prop("id") + '"]');
    if (nextcntrl.length > 0) {
        $(nextcntrl).html('<span style="color:red;">' + message + '</span>');
        $(nextcntrl).show();
    } else {
        $(elem).after('<span class="field-validation-valid"  data-valmsg-for="' + $(elem).prop("id") + '" data-valmsg-replace="true" style="display:block;"><span style="color:red;">' + message + '</span></span>');
    }
}

function HideError(elem) {
    $(elem).removeClass("input-validation-error");
    var nextcntrl = $(elem).nextAll('.field-validation-valid');
    if (nextcntrl.length > 0) {
        $(nextcntrl).html('');
        $(nextcntrl).hide();
    }
}


function SetControlValue(item, parentid) {
    if (typeof parentid === "undefined" || parentid === null) { parentid = ""; }
    $.each(item, function (key, data) {
        if (IsObject(data)) {
            SetControlValue(data, key);
        }
        else {
            var elem = $('#' + (parentid != '' ? parentid + '_' : '') + key.toString());
            if (elem.length > 0) elem.val(data);
        }
    })
}


function IsObject(data) {
    if (data == null) { return false; }
    if (typeof data === 'object') { return true; }
    return false;
}



DisplayError = function (errors) {
    for (var item in errors) {
        var elem = $('#' + errors[item].key);
        var message = errors[item].value;
        ShowError(elem, message);
    }
}



function ShowMessages(MessageID) {
    if (MessageID != '') {
        bootbox.alert({
            title: "RPS Message",
            message: Messages[MessageID],
            closeButton: false,
            callback: function () { }
        });
    }
}

function ShowMessageWithCallback(MessageID,CallBackUrl) {
    if (MessageID != '') {
        bootbox.alert({
            title: "RPS Message",
            message: Messages[MessageID],
            closeButton: false,
            callback: function () {
                window.location.href = baseUrl + CallBackUrl;
             }
        });
    }
}

function ShowMessageFocus(MessageID, MessageText, ControlId) {
    var Message = MessageText;
    if (MessageID != "") {
        Message = Messages[MessageID];
    }

    if (Message != '') {
        bootbox.alert({
            title: "RPS Message",
            message: Message,
            closeButton: false,
            callback: function () {

                setTimeout(function () {
                    $(ControlId).focus();
                }, 500);

            }
        });

    }
}

//if (typeof str === "undefined" || str === null) { 




function Alert(message) {
    bootbox.alert({
        title: "",
        closeButton: true,
        message: message,
        callback: function () { }
    });
}

function getMessage() {
    var MessageID = '';
    var Url = $(location).attr('search');
    if (Url.indexOf('Message') > -1) {
        MessageID = location.search.match(new RegExp('Message' + "=(.*?)($|\&)", "i"))[1];
    }
    return MessageID;
}

function ShowAlert(title, message, messageType, redirecturl) {
    if (messageType == "" || messageType === undefined) {
        messageType = "info";
    }
    var dialog = new Messi(
                message,
                {
                    title: title,
                    show: false,
                    //center:false,
                    titleClass: 'anim ' + messageType,
                    buttons: [{ id: 0, label: 'Close', val: 'X'}],
                    autoclose: null,
                    redirectUrl: redirecturl,
                    callback: function (val) { AlertCallback(); }
                }
            );
    dialog.show();
}


function isInt(value) {
    if (isNaN(value)) {
        return false
    }
    var x = parseFloat(value);
    return (x | 0) === x
}

function IsNumeric(input, allowZero) {

    var flag = true;
    try {

        if (isNaN(input)) {
            flag = false;

        } else {
            if (!allowZero) {
                if (parseFloat(input) == 0) {
                    flag = false;
                }
            } else {
                flag = true;
            }

        }
        var RE = /^-{0,1}\d*\.{0,1}\d+$/;
        return (RE.test(input));

    } catch (e) {
        return false;
    }

}

function validateEmail(email) {
    var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(email);
}


function isValidDate(dateString) {

    try {

        var match = dateString.match(/^([0-9]{2})\/([0-9]{2})\/([0-9]{4})$/);

        if (match) {

            var test = new Date(match[3], match[1] - 1, match[2]);

            return ((test.getMonth() == match[1] - 1) && (test.getDate() == match[2]) && (test.getFullYear() == match[3]));

        } else {

            return false;

        }

    } catch (e) {

        return false;
    }

}


jQuery.fn.ForceNumericOnly =
function () {
    return this.each(function () {
        $(this).keydown(function (e) {
            var key = e.charCode || e.keyCode || 0;
            // allow backspace, tab, delete, enter, arrows, numbers and keypad numbers ONLY
            // home, end, period, and numpad decimal
            return (
                key == 8 ||
                key == 9 ||
                key == 13 ||
                key == 46 ||
                key == 110 ||
                key == 190 ||
                (key >= 35 && key <= 40) ||
                (key >= 48 && key <= 57) ||
                (key >= 96 && key <= 105));
        });
    });
};

jQuery.fn.ForceNumericOnlyWithoutDot =
function () {
    return this.each(function () {
        $(this).keydown(function (e) {
            var key = e.charCode || e.keyCode || 0;
            // allow backspace, tab, delete, enter, arrows, numbers and keypad numbers ONLY
            // home, end, period, and numpad decimal
            return (
                key == 8 ||
                 key == 46 ||
                (key >= 48 && key <= 57)||
                (key >= 96 && key <= 105));
        });
    });
};

function ShowLoader() {
    $('#divLoader').show();
    $('body').css({ 'overflow': 'hidden' });
 }
 function HideLoader() {
     $('#divLoader').hide();
     $('body').css({ 'overflow': 'auto' });
 }

 jQuery.fn.ForceDecimalOnly =
function () {
    return this.each(function () {
        $(this).keydown(function (e) {
            if (e.shiftKey) {
                e.preventDefault();
                return;
            }
            var key = e.charCode || e.keyCode || 0;
            // allow backspace, tab, delete, enter, arrows, numbers and keypad numbers ONLY
            // home, end, period, and numpad decimal
            if (e.keyCode == 190) {
                if ($("#ActualCost").val().indexOf('.') > -1) {
                    e.preventDefault();
                    return;
                }
            }
             if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
            (e.keyCode === 65 && (e.ctrlKey === true || e.metaKey === true)) ||
            (e.keyCode >= 35 && e.keyCode <= 40)) {
         return;
     }
     
     if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
         e.preventDefault();
         return
     }

    });
 });
};


 function FillSelect(tdata, title, ctrl) {
     var markup = (title != "" ? "<option value='0'>Select " + title + "</option>" : "");
     var myarray = [];
     if (tdata.length > 0) {
         for (var x = 0; x < tdata.length; x++) {
             markup += "<option value=" + tdata[x].Value + ">" + tdata[x].Text + "</option>";
             myarray.push(tdata[x]);
         }
     }
  
     var elem = $("#" + ctrl);
     if (elem.length > 0) {
         $("#" + ctrl).empty()
         $("#" + ctrl).html(markup).show();
     } else {
         $("." + ctrl).empty()
         $("." + ctrl).html(markup).show();
     }
 }

 function SubstringLength(elem, limit) {
     var elemval = $(elem).val();
     var len = elemval.length;
     if (len >= limit) {
         $(elem).val(elemval.substring(0, limit));
     }
 }


 function CheckLength(elem, limit) {
     var len = $(elem).val().length;
     if (len >= limit) {
         return false;
     }
     return true;
 }



 