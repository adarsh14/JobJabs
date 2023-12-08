"use strict";

$(document).ready(function () {
    SessionUpdater.Setup(baseUrl + "Home/KeepSessionAlive");
});

var SessionUpdater = (function () {
    var clientMovedSinceLastTimeout = false;
    var keepSessionAliveUrl = null;
    var timeout = 5 * 1000 * 60; // 5 minutes

    function setupSessionUpdater(actionUrl) {
        // store local value
        keepSessionAliveUrl = actionUrl;
        // setup handlers
        listenForChanges();
        // start timeout - it'll run after n minutes
        checkToKeepSessionAlive();
    }

    function listenForChanges() {
        $("body").one("mousemove keydown", function () {
            clientMovedSinceLastTimeout = true;
        });
    }


    // fires every n minutes - if there's been movement ping server and restart timer
    function checkToKeepSessionAlive() {
        setTimeout(function () { keepSessionAlive(); }, timeout);
    }

    function keepSessionAlive() {
        // if we've had any movement since last run, ping the server
        if (clientMovedSinceLastTimeout && keepSessionAliveUrl != null) {
            $.ajax({
                type: "POST",
                url: keepSessionAliveUrl,
                success: function (data) {
                    // reset movement flag
                    clientMovedSinceLastTimeout = false;
                    // start listening for changes again
                    listenForChanges();
                    // restart timeout to check again in n minutes
                    checkToKeepSessionAlive();


                },
                error: function (data) {
                    console.log("Error posting to " & keepSessionAliveUrl);
                }
            });
        }
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

function LoadPartialView(url, data, elem, successCallback, errorCallback) {
    $.ajax({
        url: url,
        data: data,
        type: "Post",
        async: false,
        success: function (rdata) {
            //alert(rdata);
            if (typeof successCallback === "function") {
                successCallback(elem, rdata);
            }
        },
        error: function (jqXHR, exception) {
         //   alert('exception');
         //   alert(exception);
            if (typeof errorCallback === "function") {
                errorCallback();
            }
        }
    });
}








