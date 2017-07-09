$(function () {
    $('#posts').tablesorter();
});

$(".panel-heading span.clickable").on("click", function (e) {
    var $this = $(this);
    if (!$this.hasClass('panel-collapsed')) {
        $this.parents('.panel').find('.panel-body').slideUp();
        $this.addClass('panel-collapsed');
        $this.find('i').removeClass('glyphicon-chevron-up').addClass('glyphicon-chevron-down');
    } else {
        $this.parents('.panel').find('.panel-body').slideDown();
        $this.removeClass('panel-collapsed');
        $this.find('i').removeClass('glyphicon-chevron-down').addClass('glyphicon-chevron-up');
    }
})

$("#poststat_btn").on("click", function () {
    var i_date = $('#iDateStat').val();
    var f_date = $('#fDateStat').val();

    $.ajax({
        url: "/stats/_poststat",
        type: "post",
        data: {
            iDate: i_date,
            fDate: f_date
        },
        beforeSend: function () {
            if (i_date != null && f_date != null) {
                var iDate = Date.parse(i_date);
                var fDate = Date.parse(f_date);
                var today = Date.parse(new Date());

                if (iDate <= today && fDate <= today)
                    return true;
                else
                    return false;
            }

            return false;
        }
    })
    .done(function (result) {
        $("#poststat").html(result);
        $("#iDateStat").val('');
        $("#fDateStat").val('');
    });
});

$("#postlist_btn").on("click", function () {
    var i_date = $('#iDateList').val();
    var f_date = $('#fDateList').val();

    $.ajax({
        url: "/stats/_postlist",
        type: "post",
        data: {
            iDate: i_date,
            fDate: f_date
        },
        beforeSend: function () {
            if (i_date != null && f_date != null) {
                var iDate = Date.parse(i_date);
                var fDate = Date.parse(f_date);
                var today = Date.parse(new Date());

                if (iDate < fDate && iDate <= today && fDate <= today) {

                    $.cookie("postlist_iDate", i_date);
                    $.cookie("postlist_fDate", f_date);

                    return true;
                }
                else
                    return false;
            }

            return false;
        }
    })
    .done(function (result) {
        $("#posts").html(result);
        $("#iDateList").val('');
        $("#fDateList").val('');
    });
});