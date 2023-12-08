

$(document).ready(function (e) {
   $(".dropdownfill").change(function () {
        var id = $(this).val();
        var url = $(this).attr("wurl");
        var nextctrl = $(this).attr("nextctrl");
       $("." + nextctrl).empty();
        $("." + nextctrl).html("<option value=0>Loading......</option>");
        $.ajax({
            url: baseUrl + url,
            type: "GET",
            async: false,
            dataType: "JSON",
            data: { id: id },
            success: function (data) {
                FillDropDown(data, nextctrl);
            }
        });
       
    });

    $(".dropdownstringvalfill").change(function () {
        var id = $(this).val();
        var url = $(this).attr("wurl");
        var nextctrl = $(this).attr("nextctrl");
        $("." + nextctrl).empty();
        $("." + nextctrl).html("<option value=0>Loading......</option>");
        $.ajax({
            url: baseUrl + url,
            type: "GET",
            async: false,
            dataType: "JSON",
            data: { id: id },
            success: function (data) {
                FillStringValueDropDown(data, nextctrl);
            }
        });

    }); 
});

function FillDropDown(tdata, ctrl) {
    var myarray = [];
    var markup = '';
    if (tdata.length > 0) {
        for (var x = 0; x < tdata.length; x++) {
            markup += "<option value=" + tdata[x].Value + ">" + tdata[x].Text + "</option>";
            myarray.push(tdata[x]);
        }
    }
    $("." + ctrl).empty();
    $("." + ctrl).html(markup).show();
}

function FillStringValueDropDown(tdata, ctrl) {
    var myarray = [];
    var markup = '';
    if (tdata.length > 0) {
        for (var x = 0; x < tdata.length; x++) {
            markup += "<option value=" + tdata[x].StringValue + ">" + tdata[x].Text + "</option>";
            myarray.push(tdata[x]);
        }
    }
    $("." + ctrl).empty();
    $("." + ctrl).html(markup).show();
}

function SubstringLength(elem, limit) {
    var elemval = $(elem).val();
    var len = elemval.length;
    if (len >= limit) {
        $(elem).val(elemval.substring(0, limit));
    }
}

