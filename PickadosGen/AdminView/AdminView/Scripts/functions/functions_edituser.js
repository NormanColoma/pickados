$("#Tipsterp").change(function () {

    if ($(this).is(":checked"))
        $("#Subscription_fee").prop('disabled', false);
    else
        $("#Subscription_fee").prop('disabled', true);
});