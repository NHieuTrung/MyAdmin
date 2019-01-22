var integrateTool = {
    sendMail: function () {
        $('#btnSendMail').off('click').on('click', function (e) {
            e.preventDefault();
            $.ajax({
                type: 'POST',
                url: '@Url.Action("SendMail","IntegrateTool")',
                data: { toEmail: $('#iptToEmail').val(), subject: $('#iptSubject').val(), body: $('#summernote').val() },
                success: function (result) {
                    if (result == true) {
                        alert("Gui mail thanh cong :))");
                    }
                    else {
                        alert("Gui mail that bai :((");
                    }
                }
            });
        });
    }
};
integrateTool.sendMail();