
    var messageUrl = "";
$(document).ready(function () {

      $('body').on('keyup', '#Message', function () {
            var el = this;
            if ($('#Message').val().length > 0) {
                $('#btnMesageSend').addClass("btnactive");
            } else {
                $('#btnMesageSend').removeClass("btnactive");
            }
            el.style.cssText = 'height:auto; padding:0';
            el.style.cssText = 'height:' + el.scrollHeight + 'px';
      });

    $('.MessageAnchor').click(function () {
            $('#divProductName').html($(this).attr("pname"));
            $('#divProductPrice').html('₹' + $(this).attr("pprice"));
            $('#divProfileName').html($(this).attr("profilename"));
            $('#imgPImage').attr("src", $(this).attr("pimage"));
            $('#divMessageContent').show();
             messageUrl = $(this).attr("url");
        $('#divMessageDetail').load(messageUrl, function () {
            //$('#divMessageDetail').animate({ scrollTop: $('#divMessage').prop("scrollHeight") }, 500);
            $('.innerdiv').animate({ scrollTop: $('.innerdiv').prop("scrollHeight") }, 0, function () { $('.innerdiv').css("opacity", "1") } );
            });
     });


     $("#frmMessage").submit(function (event) {
            /* stop form from submitting normally */
            event.preventDefault();
            var message = '<div class="ccontainer"><span class="currentuserchatcontainer">' + $('#Message').val() + '</span><div class="clearfix"></div></div>';
            $('.innerdiv').append(message);
            $('#divMessage').animate({ scrollTop: $('#divMessage').prop("scrollHeight") }, 500);
            var data = $('#frmMessage').serialize();
            $('#Message').val('');
            PostAjaxCallWithCallback(baseUrl + "MarketPlace/MessagePartial", data, "", AddMessageSCBK, AddMessageERCBK);
     });
});

function AddMessageSCBK(data) {
        $('#divMessage').load(messageUrl);
}

function AddMessageERCBK() {
}


function NotInterested() {
        $('.removebtn').prop("disabled", "true");
    var inurl = baseUrl + "MarketPlace/NotInterested?productId=" + $('.NIProductId').val();
        alert(inurl);
        window.location = inurl;
}
