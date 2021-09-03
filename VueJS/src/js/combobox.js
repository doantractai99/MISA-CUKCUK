$('.btn-combobox').click(function() {;
    var check = $('.combobox-data').css('display');
    if (check === 'block') {
        $('.combobox-data').hide();
    } else $('.combobox-data').show();
})

var options = $(".combobox-item");

for (option of options) {
    $(option).click(function() {
        $('#slectField').val($(this).text());
        $('.combobox-data').hide();
    })
}