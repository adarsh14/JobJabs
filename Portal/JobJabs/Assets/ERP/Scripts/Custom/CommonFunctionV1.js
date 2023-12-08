"use strict";

$(document).ready(function () {
    SessionUpdater.Setup(baseUrl + "Home/KeepSessionAlive");
    if ($('.commentpopup').length > 0) {
        $('.commentpopup').click(function (event) {
            event.preventDefault();
            OpenViewCommentPopUp($(this).attr("href"));
        });
    }
});

var SessionUpdater = (function () {
    var clientMovedSinceLastTimeout = false;
    var keepSessionAliveUrl = null;
    var timeout = 10 * 1000 * 60; // 15 minutes

    function setupSessionUpdater(actionUrl) {
        // store local value
        keepSessionAliveUrl = actionUrl;
        // setup handlers
        //  listenForChanges();
        // start timeout - it'll run after n minutes
        checkToKeepSessionAlive();
    }

    //function listenForChanges() {
    //    $("body").one("mousemove keydown", function () {
    //        clientMovedSinceLastTimeout = true;
    //    });
    //}


    // fires every n minutes - if there's been movement ping server and restart timer
    function checkToKeepSessionAlive() {
        setTimeout(function () { keepSessionAlive(); }, timeout);
    }

    function keepSessionAlive() {
        // if we've had any movement since last run, ping the server
        $.ajax({
            type: "POST",
            url: keepSessionAliveUrl,
            success: function (data) {
                // alert(data);
                // reset movement flag
                // clientMovedSinceLastTimeout = false;
                // start listening for changes again
                // listenForChanges();
                // restart timeout to check again in n minutes
                checkToKeepSessionAlive();


            },
            error: function (data) {
                console.log("Error posting to " & keepSessionAliveUrl);
            }
        });
    }

    // export setup method
    return {
        Setup: setupSessionUpdater
    };

})();

function GetAjaxCallWithoutCallback(url, data, type) {
    var returndata = {};
    $.ajax({
        url: url,
        data: data,
        async: false,
        method: "Get",
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

function GetAjaxCallWithCallback(url, data, elem, successCallback, errorCallback) {
    $.ajax({
        url: url,
        data: data,
        type: 'get',
        async: false,
        dataType: 'json',
        crossDomain: true,
        success: function (rdata) {
            if (typeof successCallback === "function") {
                successCallback(elem, rdata);
            }

        },
        error: function (jqXHR, exception) {
            if (typeof errorCallback === "function") {
                errorCallback();
            }
        }
    });
}

function PostAjaxCallWithCallback(url, data, elem, successCallback, errorCallback) {
    $.ajax({
        url: url,
        data: data,
        type: "Post",
        async: false,
        dataType: "json",
        success: function (rdata) {
            //  alert(rdata);
            if (typeof successCallback === "function") {
                successCallback(elem, rdata);
            }
        },
        error: function (jqXHR, exception) {
            // alert('exception');
            // alert(exception);
            if (typeof errorCallback === "function") {
                errorCallback();
            }
        }
    });
}

function LoadPartialView(url, data, type, elem, successCallback, errorCallback) {
    $.ajax({
        url: url,
        data: data,
        type: type,
        async: false,
        success: function (rdata) {
            if (typeof successCallback === "function") {
                successCallback(elem, rdata);
            }
        },
        error: function (jqXHR, exception) {
            alert(exception);
            //   alert(exception);
            if (typeof errorCallback === "function") {
                errorCallback();
            }
        }
    });
}

function CheckNewCandidate(spocAdminId) {
    var data = {};
    data.SpocAdminId = spocAdminId;
    GetAjaxCallWithCallback(baseUrl + "Common/CheckIfNewCandidate", data, "", CheckNewCandidateSCBK, CheckNewCandidateERCBK);
}

function CheckNewCandidateSCBK(elem, rdata) {
    if (rdata.Success) {
        ShowHideNewCandidate(rdata.Data);
    }
    else {
        CheckNewCandidateERCBK();
    }
}

function CheckNewCandidateERCBK() {
    alert('!OOPS Error. Please try later.');
}

function ShowHideNewCandidate(newCount) {
    if (newCount === 0) {
        $('#divNewCndCount').hide();
    } else {
        $('#divNewCndCount').show();
    }
}


function OpenViewCommentPopUp(href) {
    $("#divCommentBG").show();
    $("#imgLoading").show();
    var data = {};
    var url = baseUrl + "Common/GetComments?" + href;
    LoadPartialView(url, data, "Get","", ViewCommentPopUpSCBK, ViewCommentPopUpERCBK);
}

function ViewCommentPopUpSCBK(elem, rdata) {
    $("#imgLoading").hide();
    $("#divViewCommentPopUp").show();
    $("#divViewCommentPopUp").empty().append(rdata);
}

function ViewCommentPopUpERCBK() {
    alert('!OOPS Error. Please try later.');
}

function CloseVCSPopup() {
    $("#divCommentBG").hide();
    $("#divViewCommentPopUp").hide();
}


function ResetPassword(uid) {
    $("#divCommentBG").show();
    $("#imgLoading").show();
    var data = {};
    data.userId = uid;
    GetAjaxCallWithCallback(baseUrl + "Common/ResetPassword", data, "", ResetPasswordSCBK, ResetPasswordERCBK);
}

function ResetPasswordSCBK(elem, rdata) {
    if (rdata.Success) {
        $("#lblResetedPassword").html(rdata.Data);
        $("#imgLoading").hide();
        $("#divResetPasswordPopUp").show();
    }
    else {
        ResetPasswordERCBK();
    }
}

function ResetPasswordERCBK() {
    alert('!OOPS Error. Please try later.');
}

function CloseRSPPopup() {
    $("#divCommentBG").hide();
    $("#divResetPasswordPopUp").hide();
    $("#lblResetedPassword").html("");
}