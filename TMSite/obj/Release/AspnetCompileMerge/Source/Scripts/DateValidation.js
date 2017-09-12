$("#licenceExpiryDate").datepicker({
    dateFormat: "dd-M-yy",
    minDate: 0,
    onSelect: function (date) {
        //var dt2 = $('#LicenceExpiryDate');
        var startDate = $(this).datepicker('getDate');
        //var minDate = $(this).datepicker('getDate');
        //dt2.datepicker('setDate', minDate);
        startDate.setDate(startDate.getDate() + 30);
        ////sets dt2 maxDate to the last day of 30 days window
        //dt2.datepicker('option', 'maxDate', startDate);
        //dt2.datepicker('option', 'minDate', minDate);
        //$(this).datepicker('option', 'minDate', minDate);
    }
});
//$('#LicenceExpiryDate').datepicker({
//    dateFormat: "dd-M-yy"
//});
//});